using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Text;

namespace TELAS
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
            this.Load += TelaPrincipal_Load;
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            groupBox1.Location = new Point((this.ClientSize.Width - groupBox1.Width) / 2,
                                            (this.ClientSize.Height - groupBox1.Height) / 2);
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) { }

        private void anexarRelatóriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|Text files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileExtension = Path.GetExtension(filePath).ToLower();
                if (fileExtension == ".pdf" || fileExtension == ".txt")
                {
                    string fileName = Path.GetFileName(filePath);
                    byte[] fileData = File.ReadAllBytes(filePath);

                    SalvarRelatorioNoBanco(fileName, fileData);

                    MessageBox.Show("Relatório anexado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Formato de arquivo inválido. Somente arquivos PDF e TXT são permitidos.");
                }
            }
        }


        private void SalvarRelatorioNoBanco(string fileName, byte[] fileData)
        {
            string connectionString = @"Server=localhost;Database=CadastroBD;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Relatorios (Nome, Arquivo, DataAnexo) VALUES (@Nome, @Arquivo, @DataAnexo)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", fileName);
                    cmd.Parameters.AddWithValue("@Arquivo", fileData);
                    cmd.Parameters.AddWithValue("@DataAnexo", DateTime.Now);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        private void consultarRelatóriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=localhost;Database=CadastroBD;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Nome FROM Relatorios";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    using (Form selectionForm = new Form())
                    {
                        selectionForm.Text = "Selecionar Relatório";
                        selectionForm.Size = new System.Drawing.Size(400, 300);

                        ListBox listBox = new ListBox { Dock = DockStyle.Fill };
                        foreach (DataRow row in dataTable.Rows)
                        {
                            listBox.Items.Add($"{row["Id"]} - {row["Nome"]}");
                        }

                        Button btnAbrir = new Button { Text = "Abrir", Dock = DockStyle.Bottom };
                        btnAbrir.Click += (s, eArgs) =>
                        {
                            if (listBox.SelectedItem != null)
                            {
                                string selectedItem = listBox.SelectedItem.ToString();
                                int relatorioId = int.Parse(selectedItem.Split('-')[0].Trim());
                                AbrirRelatorio(relatorioId);
                                selectionForm.Close();
                            }
                        };

                        selectionForm.Controls.Add(listBox);
                        selectionForm.Controls.Add(btnAbrir);
                        selectionForm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Nenhum relatório encontrado.");
                }
            }
        }

        private void AbrirRelatorio(int relatorioId)
        {
            string connectionString = @"Server=localhost;Database=CadastroBD;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Nome, Arquivo FROM Relatorios WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", relatorioId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string nomeArquivo = reader["Nome"].ToString();
                            byte[] arquivoBytes = (byte[])reader["Arquivo"];

                            string caminhoTemp = Path.Combine(Path.GetTempPath(), nomeArquivo);
                            File.WriteAllBytes(caminhoTemp, arquivoBytes);

                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(caminhoTemp) { UseShellExecute = true });
                        }
                    }

                    conn.Close();
                }
            }
        }
        private void removerRelatóriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Microsoft.VisualBasic.Interaction.InputBox("Informe o ID do relatório a ser removido:", "Remover Relatório");

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("ID não pode ser vazio.");
                return;
            }

            string connectionString = @"Server=localhost;Database=CadastroBD;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Relatorios WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Relatório de vendas removido com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Relatório não encontrado.");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro inesperado: " + ex.Message);
                }
            }
        }
        private void anexarRelatóriosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|Text files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileExtension = Path.GetExtension(filePath).ToLower();

                if (fileExtension == ".pdf" || fileExtension == ".txt")
                {
                    string fileName = Path.GetFileName(filePath);
                    byte[] fileData = File.ReadAllBytes(filePath);

                    SalvarRelatorioEntregaNoBanco(fileName, fileData);

                    MessageBox.Show("Relatório de entrega anexado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Formato de arquivo inválido. Somente arquivos PDF e TXT são permitidos.");
                }
            }
        }


        private void SalvarRelatorioEntregaNoBanco(string fileName, byte[] fileData)
        {
            string connectionString = @"Server=localhost;Database=CadastroBD;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO RelatoriosEntrega (Nome, Arquivo, DataAnexo) VALUES (@Nome, @Arquivo, @DataAnexo)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", fileName);
                    cmd.Parameters.AddWithValue("@Arquivo", fileData);
                    cmd.Parameters.AddWithValue("@DataAnexo", DateTime.Now);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        private void consultarRelatóriosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=localhost;Database=CadastroBD;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Nome FROM RelatoriosEntrega";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    using (Form selectionForm = new Form())
                    {
                        selectionForm.Text = "Selecionar Relatório de Entrega";
                        selectionForm.Size = new System.Drawing.Size(400, 300);

                        ListBox listBox = new ListBox { Dock = DockStyle.Fill };
                        foreach (DataRow row in dataTable.Rows)
                        {
                            listBox.Items.Add($"{row["Id"]} - {row["Nome"]}");
                        }

                        Button btnAbrir = new Button { Text = "Abrir", Dock = DockStyle.Bottom };
                        btnAbrir.Click += (s, eArgs) =>
                        {
                            if (listBox.SelectedItem != null)
                            {
                                string selectedItem = listBox.SelectedItem.ToString();
                                int relatorioId = int.Parse(selectedItem.Split('-')[0].Trim());
                                AbrirRelatorioEntrega(relatorioId);
                                selectionForm.Close();
                            }
                        };

                        selectionForm.Controls.Add(listBox);
                        selectionForm.Controls.Add(btnAbrir);
                        selectionForm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Nenhum relatório de entrega encontrado.");
                }
            }
        }
        private void AbrirRelatorioEntrega(int relatorioId)
        {
            string connectionString = @"Server=localhost;Database=CadastroBD;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Nome, Arquivo FROM RelatoriosEntrega WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", relatorioId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string nomeArquivo = reader["Nome"].ToString();
                            byte[] arquivoBytes = (byte[])reader["Arquivo"];

                            string caminhoTemp = Path.Combine(Path.GetTempPath(), nomeArquivo);
                            File.WriteAllBytes(caminhoTemp, arquivoBytes);

                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(caminhoTemp) { UseShellExecute = true });
                        }
                    }

                    conn.Close();
                }
            }
        }
        private void removerRelatóriosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = Microsoft.VisualBasic.Interaction.InputBox("Informe o ID do relatório de entrega a ser removido:", "Remover Relatório de Entrega");

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("ID não pode ser vazio.");
                return;
            }

            string connectionString = @"Server=localhost;Database=CadastroBD;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM RelatoriosEntrega WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Relatório de entrega removido com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Relatório de entrega não encontrado.");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro inesperado: " + ex.Message);
                }
            }
        }

        private async void tabelaDeViabilidadeDePlantioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cidade = "São Paulo";
            string url = $"https://api.open-meteo.com/v1/forecast?latitude=-23.5505&longitude=-46.6333&current_weather=true";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string resposta = await client.GetStringAsync(url);
                    JObject dados = JObject.Parse(resposta);

                    string temperatura = dados["current_weather"]["temperature"].ToString();
                    string vento = dados["current_weather"]["windspeed"].ToString();
                    string descricao = dados["current_weather"]["weathercode"].ToString();

                    string descricaoClima = ObterDescricaoClima(descricao);

                    MessageBox.Show($"Temperatura: {temperatura}°C\nVelocidade do Vento: {vento} km/h\nDescrição: {descricaoClima}",
                                    "Previsão do Tempo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                catch (HttpRequestException httpEx)
                {
                    MessageBox.Show($"Erro ao fazer a requisição: {httpEx.Message}",
                                    "Erro de Requisição",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao obter dados da API: {ex.Message}",
                                    "Erro",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private string ObterDescricaoClima(string codigo)
        {
            return codigo switch
            {
                "0" => "Céu limpo",
                "1" => "Poucas nuvens",
                "2" => "Nuvens",
                "3" => "Nuvens densas",
                "45" => "Nebuloso",
                "48" => "Nevoeiro",
                "61" => "Chuvisco",
                "63" => "Chuva",
                "71" => "Neve",

                _ => "Descrição desconhecida"
            };
        }

        private void análiseClimáticaToolStripMenuItem_Click(object sender, EventArgs e) { }

        private async void relatórioDeTendênciasClimáticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cidade = "São Paulo";
            string url = $"https://api.open-meteo.com/v1/forecast?latitude=-23.5505&longitude=-46.6333&daily=temperature_2m_max,temperature_2m_min&timezone=America/Sao_Paulo";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string resposta = await client.GetStringAsync(url);
                    JObject dados = JObject.Parse(resposta);

                    var maxTemperaturas = dados["daily"]["temperature_2m_max"].ToObject<List<double>>();
                    var minTemperaturas = dados["daily"]["temperature_2m_min"].ToObject<List<double>>();
                    var datas = dados["daily"]["time"].ToObject<List<string>>();

                    StringBuilder relatorio = new StringBuilder();
                    relatorio.AppendLine("Relatório de Tendências Climáticas:");
                    relatorio.AppendLine("Data | Temperatura Máxima (°C) | Temperatura Mínima (°C)");

                    for (int i = 0; i < maxTemperaturas.Count; i++)
                    {
                        relatorio.AppendLine($"{datas[i]} | {maxTemperaturas[i]}°C | {minTemperaturas[i]}°C");
                    }

                    MessageBox.Show(relatorio.ToString(), "Relatório de Tendências Climáticas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (HttpRequestException httpEx)
                {
                    MessageBox.Show($"Erro ao fazer a requisição: {httpEx.Message}", "Erro de Requisição", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao obter dados da API: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void registroDeCulturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Form
            {
                Text = "Registrar Cultura",
                Size = new Size(400, 400),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.LightGray
            };

            Label lblNome = new Label()
            {
                Text = "Nome da Cultura:",
                Location = new Point(10, 20),
                AutoSize = true,
                ForeColor = Color.LightGray,
                BackColor = Color.DarkGreen
            };
            TextBox txtNome = new TextBox() { Location = new Point(10, 40), Width = 360 }; // Ajusta a largura

            Label lblDataPlantio = new Label()
            {
                Text = "Data de Plantio:",
                Location = new Point(10, 80),
                AutoSize = true,
                ForeColor = Color.LightGray,
                BackColor = Color.DarkGreen
            };
            DateTimePicker dtpPlantio = new DateTimePicker() { Location = new Point(10, 100), Width = 360 }; // Ajusta a largura

            Label lblDataColheita = new Label()
            {
                Text = "Data de Colheita:",
                Location = new Point(10, 140),
                AutoSize = true,
                ForeColor = Color.LightGray,
                BackColor = Color.DarkGreen
            };
            DateTimePicker dtpColheita = new DateTimePicker() { Location = new Point(10, 160), Width = 360 }; // Ajusta a largura

            Label lblObservacoes = new Label()
            {
                Text = "Observações:",
                Location = new Point(10, 200),
                AutoSize = true,
                ForeColor = Color.LightGray,
                BackColor = Color.DarkGreen
            };
            TextBox txtObservacoes = new TextBox() { Location = new Point(10, 220), Width = 360, Multiline = true, Height = 60 }; // Ajusta a largura e a altura

            Button btnSalvar = new Button()
            {
                Text = "Salvar",
                Location = new Point(10, 290),
                AutoSize = true,
                ForeColor = Color.LightGray,
                BackColor = Color.DarkGreen
            };

            btnSalvar.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    MessageBox.Show("Por favor, insira o nome da cultura.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SalvarCulturaNoBanco(txtNome.Text, dtpPlantio.Value, dtpColheita.Value, txtObservacoes.Text);
                MessageBox.Show("Cultura registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form.Close();
            };

            form.Controls.Add(lblNome);
            form.Controls.Add(txtNome);
            form.Controls.Add(lblDataPlantio);
            form.Controls.Add(dtpPlantio);
            form.Controls.Add(lblDataColheita);
            form.Controls.Add(dtpColheita);
            form.Controls.Add(lblObservacoes);
            form.Controls.Add(txtObservacoes);
            form.Controls.Add(btnSalvar);

            form.ShowDialog();
        }
        private void SalvarCulturaNoBanco(string nome, DateTime dataPlantio, DateTime dataColheita, string observacoes)
        {
            string connectionString = @"Server=localhost;Database=CadastroBD;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Culturas (Nome, DataPlantio, DataColheita, Observacoes) VALUES (@Nome, @DataPlantio, @DataColheita, @Observacoes)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@DataPlantio", dataPlantio);
                    cmd.Parameters.AddWithValue("@DataColheita", dataColheita);
                    cmd.Parameters.AddWithValue("@Observacoes", observacoes);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            MessageBox.Show("Cultura registrada com sucesso!");
        }
        private void consultaDeCulturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=localhost;Database=CadastroBD;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Nome, DataPlantio, DataColheita, Observacoes FROM Culturas";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    StringBuilder relatorio = new StringBuilder();
                    relatorio.AppendLine("Relatório de Culturas:");
                    relatorio.AppendLine("ID | Nome | Data de Plantio | Data de Colheita | Observações");

                    foreach (DataRow row in dataTable.Rows)
                    {
                        relatorio.AppendLine($"{row["Id"]} | {row["Nome"]} | {row["DataPlantio"]} | {row["DataColheita"]} | {row["Observacoes"]}");
                    }

                    MessageBox.Show(relatorio.ToString(), "Culturas Registradas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nenhuma cultura encontrada.", "Consulta de Culturas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void removerCulturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Microsoft.VisualBasic.Interaction.InputBox("Informe o ID da cultura a ser removida:", "Remover Cultura");

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("ID não pode ser vazio.");
                return;
            }

            string connectionString = @"Server=localhost;Database=CadastroBD;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Culturas WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cultura removida com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Cultura não encontrada.");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro inesperado: " + ex.Message);
                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void cadastrarProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Form
            {
                Text = "Cadastrar Produto",
                Size = new Size(400, 300),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.LightGray
            };

            Label lblNome = new Label()
            {
                Text = "Nome do Produto:",
                Location = new Point(10, 20),
                AutoSize = true,
                ForeColor = Color.LightGray,
                BackColor = Color.DarkGreen
            };

            TextBox txtNome = new TextBox()
            {
                Location = new Point(170, 20),
                Width = 200,
                BackColor = Color.White,
                ForeColor = Color.Black
            };

            Label lblPreco = new Label()
            {
                Text = "Preço do Produto:",
                Location = new Point(10, 60),
                AutoSize = true,
                ForeColor = Color.LightGray,
                BackColor = Color.DarkGreen
            };

            TextBox txtPreco = new TextBox()
            {
                Location = new Point(170, 60),
                Width = 200,
                BackColor = Color.White,
                ForeColor = Color.Black
            };

            Button btnSalvar = new Button()
            {
                Text = "Salvar Produto",
                Location = new Point(10, 100),
                AutoSize = true,
                BackColor = Color.DarkGreen,
                ForeColor = Color.LightGray
            };

            btnSalvar.Click += (s, ev) =>
            {

                string precoTexto = txtPreco.Text.Replace(",", ".").Trim();


                if (!decimal.TryParse(precoTexto, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal preco))
                {
                    MessageBox.Show("Por favor, insira um valor numérico válido para o preço.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string connectionString = @"Server=localhost;Database=CadastroBD;Integrated Security=True;TrustServerCertificate=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Produtos (Nome, Preco) VALUES (@Nome, @Preco)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
                        cmd.Parameters.AddWithValue("@Preco", preco);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Produto cadastrado com sucesso!");
                    }
                }
                form.Close();
            };


            form.Controls.Add(lblNome);
            form.Controls.Add(txtNome);
            form.Controls.Add(lblPreco);
            form.Controls.Add(txtPreco);
            form.Controls.Add(btnSalvar);

            form.ShowDialog();
        }

        private void consultarProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=localhost;Database=CadastroBD;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Nome, Preco FROM Produtos";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                Form form = new Form
                {
                    Text = "Consultar Produtos",
                    Size = new Size(400, 300),
                    StartPosition = FormStartPosition.CenterParent,
                    BackColor = Color.LightGray
                };

                DataGridView dataGridView = new DataGridView
                {
                    DataSource = dataTable,
                    Dock = DockStyle.Fill,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                };

                form.Controls.Add(dataGridView);
                form.ShowDialog();
            }
        }

        private void removerProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=localhost;Database=CadastroBD;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Nome FROM Produtos";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                Form form = new Form
                {
                    Text = "Remover Produto",
                    Size = new Size(400, 300),
                    StartPosition = FormStartPosition.CenterParent,
                    BackColor = Color.LightGray
                };

                ComboBox comboBox = new ComboBox
                {
                    DataSource = dataTable,
                    DisplayMember = "Nome",
                    ValueMember = "Id",
                    Location = new Point(10, 20),
                    Width = 360
                };

                Button btnRemover = new Button
                {
                    Text = "Remover Produto",
                    Location = new Point(10, 60),
                    AutoSize = true,
                    BackColor = Color.DarkGreen,
                    ForeColor = Color.LightGray
                };

                btnRemover.Click += (s, ev) =>
                {
                    int produtoId = (int)comboBox.SelectedValue;

                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Produtos WHERE Id = @Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", produtoId);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Produto removido com sucesso!");
                    }

                    form.Close();
                };

                form.Controls.Add(comboBox);
                form.Controls.Add(btnRemover);
                form.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Instruções de Uso:\n-Relatórios de Vendas, você pode anexar um relatório direto" +
                " do seu dispositivo, você tambem pode consultá-lo.\n-Relatórios de Entregas, você pode anexar um relatório direto" +
                " do seu dispositivo, você tambem pode consultá-lo.\n-Análise Climática, você pode consultar a previsão do tempo atual" +
                " e também consultar um relatório de tendências climáticas.\n-Plantil e colheita, você pode registrar uma cultura, informando" +
                "a data da plantação e a previsão de colheite, e também consultar as culturas salvas.\n-Produtos, você pode cadastrar, consultar e " +
                "remover produtos.\n\nÁrea administrativa, acesso permitido somente à pessoas autorizadas.\n\nOutras dúvidas entre em contato com o suporte: " +
                "(11)99929-7623");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            this.Hide();
            admin.Show();
        }
        private void alimentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formAlimentos = new Form
            {
                Text = "Informações sobre Alimentos",
                Size = new System.Drawing.Size(400, 300),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.LightGray
            };

            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            var alimentos = new (string nome, string info, string epoca, string periodoCultivo)[]
            {
                ("Alface", "Rica em vitaminas A e C.", "O ano todo.", "30-45 dias"),
                ("Rúcula", "Boa fonte de vitamina K.", "Primavera e outono.", "30-40 dias"),
                ("Salsa", "Rica em vitamina C e ferro.", "Todo o ano.", "60-90 dias"),
                ("Coentro", "Fonte de antioxidantes.", "Primavera e verão.", "30-40 dias"),
                ("Tomate", "Rico em licopeno.", "Verão.", "60-80 dias"),
                ("Pimentão", "Rico em vitamina C.", "Verão.", "70-90 dias"),
                ("Cenoura", "Boa fonte de beta-caroteno.", "O ano todo.", "70-80 dias"),
                ("Morango", "Rico em antioxidantes.", "Inverno e primavera.", "60-90 dias"),
                ("Framboesa", "Boa fonte de fibras.", "Verão.", "60-80 dias"),
                ("Batata-doce", "Rica em carboidratos saudáveis.", "Todo o ano.", "90-120 dias"),
                ("Mandioca", "Fonte de fibras.", "O ano todo.", "8-24 meses"),
            };

            foreach (var alimento in alimentos)
            {
                Button btn = new Button
                {
                    Text = alimento.nome,
                    Width = 120,
                    AutoSize = true,
                    Margin = new Padding(5),
                    BackColor = Color.DarkGreen,
                    ForeColor = Color.LightGray
                };

                btn.Click += (s, args) =>
                {
                    MessageBox.Show(
                        $"Informações sobre {alimento.nome}:\n\n{alimento.info}\n\nÉpoca de Plantio: {alimento.epoca}\n\nPeríodo de Cultivo: {alimento.periodoCultivo}",
                        "Informações do Alimento",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                };

                panel.Controls.Add(btn);
            }

            formAlimentos.Controls.Add(panel);
            formAlimentos.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void produçãoToolStripMenuItem_Click(object sender, EventArgs e) { }

    }
}
