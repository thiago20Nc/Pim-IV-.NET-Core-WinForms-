using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace TELAS
{
    public partial class MenuAdmin : Form
    {

        private string connectionString = "Data Source=localhost;Initial Catalog=CadastroBD;Integrated Security=True;Encrypt=False";

        public MenuAdmin()
        {
            InitializeComponent(); 
        }

        private void orçamentoToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            TeladeInicio teladeInicio = new TeladeInicio();
            this.Hide();
            teladeInicio.Show();
            this.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void adcionarReceitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form dialog = new Form
            {
                Size = new Size(400, 300),
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.LightGray,
                Text = "Adicionar Receita",
                FormBorderStyle = FormBorderStyle.FixedDialog
            };

            Label labelValor = new Label { Text = "Valor:", AutoSize = true, ForeColor = Color.LightGray, BackColor = Color.DarkGreen };
            TextBox textBoxValor = new TextBox { Width = 200 };

            Label labelTipo = new Label { Text = "Tipo:", AutoSize = true, ForeColor = Color.LightGray, BackColor = Color.DarkGreen };
            TextBox textBoxTipo = new TextBox { Width = 200, Text = "Receita" };
            textBoxTipo.ReadOnly = true;

            Label labelDescricao = new Label { Text = "Descrição:", AutoSize = true, ForeColor = Color.LightGray, BackColor = Color.DarkGreen };
            TextBox textBoxDescricao = new TextBox { Width = 200 };

            Label labelData = new Label { Text = "Data:", AutoSize = true, ForeColor = Color.LightGray, BackColor = Color.DarkGreen };
            DateTimePicker datePicker = new DateTimePicker { Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy", Width = 200 };

            Button btnSalvar = new Button { Text = "Salvar", AutoSize = true, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };

            labelValor.Location = new Point(20, 30);
            textBoxValor.Location = new Point(150, 30);

            labelTipo.Location = new Point(20, 80);
            textBoxTipo.Location = new Point(150, 80);

            labelDescricao.Location = new Point(20, 130);
            textBoxDescricao.Location = new Point(150, 130);

            labelData.Location = new Point(20, 180);
            datePicker.Location = new Point(150, 180);

            btnSalvar.Location = new Point(150, 230);

            dialog.Controls.Add(labelValor);
            dialog.Controls.Add(textBoxValor);
            dialog.Controls.Add(labelTipo);
            dialog.Controls.Add(textBoxTipo);
            dialog.Controls.Add(labelDescricao);
            dialog.Controls.Add(textBoxDescricao);
            dialog.Controls.Add(labelData);
            dialog.Controls.Add(datePicker);
            dialog.Controls.Add(btnSalvar);

            btnSalvar.Click += (senderBtn, eBtn) =>
            {
                string valor = textBoxValor.Text;
                string tipo = textBoxTipo.Text;
                string descricao = textBoxDescricao.Text;
                string data = datePicker.Value.ToString("dd-MM-yyyy");

                if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(descricao))
                {
                    MessageBox.Show("Valor e descrição devem ser preenchidos.");
                    return;
                }

                decimal valorDecimal;

                valor = valor.Replace(",", "."); 

                if (!decimal.TryParse(valor, NumberStyles.Any, CultureInfo.InvariantCulture, out valorDecimal))
                {
                    MessageBox.Show("O valor deve ser um número válido.");
                    return;
                }


                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();
                    string query = "INSERT INTO Financeiro (Valor, Tipo, Descricao, DataRegistro) VALUES (@valor, @tipo, @descricao, @data)";
                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@valor", valor);
                        comando.Parameters.AddWithValue("@tipo", tipo);
                        comando.Parameters.AddWithValue("@descricao", descricao);
                        comando.Parameters.AddWithValue("@data", data);
                        comando.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Receita adicionada com sucesso!");
                dialog.Close();
            };

            dialog.ShowDialog();
        }

        private void listarResceitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                string query = "SELECT * FROM Financeiro WHERE Tipo = 'Receita'";
                using (SqlCommand comando = new SqlCommand(query, conexao))
                {
                    using (SqlDataReader leitor = comando.ExecuteReader())
                    {
                        StringBuilder listaReceitas = new StringBuilder();

                        while (leitor.Read())
                        {
                            listaReceitas.AppendLine($"ID: {leitor["Id"]}, Valor: {leitor["Valor"]}, Tipo: {leitor["Tipo"]}, Descrição: {leitor["Descricao"]}, Data: {Convert.ToDateTime(leitor["DataRegistro"]).ToString("dd/MM/yyyy")}");
                        }

                        MessageBox.Show(listaReceitas.ToString(), "Lista de Receitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void removerReceitasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form dialog = new Form
            {
                Size = new Size(300, 150),
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.LightGray,
                Text = "Remover Receitas",
                FormBorderStyle = FormBorderStyle.FixedDialog
            };

            Label labelID = new Label { Text = "ID da Receita:", AutoSize = true, ForeColor = Color.LightGray, BackColor = Color.DarkGreen };
            TextBox textBoxID = new TextBox() { Width = 100 };

            Button btnRemover = new Button { Text = "Remover", AutoSize = true, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };

            labelID.Location = new Point(20, 30);
            textBoxID.Location = new Point(150, 30);

            btnRemover.Location = new Point(150, 80);

            dialog.Controls.Add(labelID);
            dialog.Controls.Add(textBoxID);
            dialog.Controls.Add(btnRemover);

            btnRemover.Click += (senderBtn, eBtn) =>
            {

                int idReceita = int.Parse(textBoxID.Text);

                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();
                    string query = "DELETE FROM Financeiro WHERE Id = @id";
                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@id", idReceita);
                        int linhasAfetadas = comando.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Receita removida com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Nenhuma receita encontrada com esse ID.");
                        }
                    }
                }

                dialog.Close();
            };

            dialog.ShowDialog();
        }

        private void adcionarDespesasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form dialog = new Form
            {
                Size = new Size(400, 300),
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.LightGray,
                Text = "Adicionar Despesa",
                FormBorderStyle = FormBorderStyle.FixedDialog
            };

            Label labelValor = new Label { Text = "Valor:", AutoSize = true, ForeColor = Color.LightGray, BackColor = Color.DarkGreen };
            TextBox textBoxValor = new TextBox { Width = 200 };

            Label labelTipo = new Label { Text = "Tipo:", AutoSize = true, ForeColor = Color.LightGray, BackColor = Color.DarkGreen };
            TextBox textBoxTipo = new TextBox { Width = 200, Text = "Despesa" };
            textBoxTipo.ReadOnly = true;

            Label labelDescricao = new Label { Text = "Descrição:", AutoSize = true, ForeColor = Color.LightGray, BackColor = Color.DarkGreen };
            TextBox textBoxDescricao = new TextBox { Width = 200 };

            Label labelData = new Label { Text = "Data:", AutoSize = true, ForeColor = Color.LightGray, BackColor = Color.DarkGreen };
            DateTimePicker datePicker = new DateTimePicker { Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy", Width = 200 };

            Button btnSalvar = new Button { Text = "Salvar", AutoSize = true, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };

            labelValor.Location = new Point(20, 30);
            textBoxValor.Location = new Point(150, 30);

            labelTipo.Location = new Point(20, 80);
            textBoxTipo.Location = new Point(150, 80);

            labelDescricao.Location = new Point(20, 130);
            textBoxDescricao.Location = new Point(150, 130);

            labelData.Location = new Point(20, 180);
            datePicker.Location = new Point(150, 180);

            btnSalvar.Location = new Point(150, 230);

            dialog.Controls.Add(labelValor);
            dialog.Controls.Add(textBoxValor);
            dialog.Controls.Add(labelTipo);
            dialog.Controls.Add(textBoxTipo);
            dialog.Controls.Add(labelDescricao);
            dialog.Controls.Add(textBoxDescricao);
            dialog.Controls.Add(labelData);
            dialog.Controls.Add(datePicker);
            dialog.Controls.Add(btnSalvar);

            btnSalvar.Click += (senderBtn, eBtn) =>
            {
                string valor = textBoxValor.Text;
                string tipo = textBoxTipo.Text;
                string descricao = textBoxDescricao.Text;
                string data = datePicker.Value.ToString("dd-MM-yyyy");

                if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(descricao))
                {
                    MessageBox.Show("Valor e descrição devem ser preenchidos.");
                    return;
                }

                decimal valorDecimal;

                valor = valor.Replace(",", ".");

                if (!decimal.TryParse(valor, NumberStyles.Any, CultureInfo.InvariantCulture, out valorDecimal))
                {
                    MessageBox.Show("O valor deve ser um número válido.");
                    return;
                }

                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();
                    string query = "INSERT INTO Financeiro (Valor, Tipo, Descricao, DataRegistro) VALUES (@valor, @tipo, @descricao, @data)";
                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@valor", valor);
                        comando.Parameters.AddWithValue("@tipo", tipo);
                        comando.Parameters.AddWithValue("@descricao", descricao);
                        comando.Parameters.AddWithValue("@data", data);
                        comando.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Despesa adicionada com sucesso!");
                dialog.Close();
            };

            dialog.ShowDialog();
        }

        private void listarDespesasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();
                string query = "SELECT * FROM Financeiro WHERE Tipo = 'Despesa'";
                using (SqlCommand comando = new SqlCommand(query, conexao))
                {
                    using (SqlDataReader leitor = comando.ExecuteReader())
                    {
                        StringBuilder listaDespesas = new StringBuilder();

                        while (leitor.Read())
                        {
                            listaDespesas.AppendLine($"ID: {leitor["Id"]}, Valor: {leitor["Valor"]}, Tipo: {leitor["Tipo"]}, Descrição: {leitor["Descricao"]}, Data: {Convert.ToDateTime(leitor["DataRegistro"]).ToString("dd/MM/yyyy")}");
                        }

                        MessageBox.Show(listaDespesas.ToString(), "Lista de Despesas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void removerDespesasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form dialog = new Form
            {
                Size = new Size(300, 150),
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.LightGray,
                Text = "Remover Receitas",
                FormBorderStyle = FormBorderStyle.FixedDialog
            };

            Label labelID = new Label { Text = "ID da Receita:", AutoSize = true, ForeColor = Color.LightGray, BackColor = Color.DarkGreen };
            TextBox textBoxID = new TextBox() { Width = 100 };

            Button btnRemover = new Button { Text = "Remover", AutoSize = true, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };

            labelID.Location = new Point(20, 30);
            textBoxID.Location = new Point(150, 30);

            btnRemover.Location = new Point(150, 80);

            dialog.Controls.Add(labelID);
            dialog.Controls.Add(textBoxID);
            dialog.Controls.Add(btnRemover);

            btnRemover.Click += (senderBtn, eBtn) =>
            {
                int idReceita = int.Parse(textBoxID.Text);

                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();
                    string query = "DELETE FROM Financeiro WHERE Id = @id";
                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@id", idReceita);
                        int linhasAfetadas = comando.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Receita removida com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Nenhuma receita encontrada com esse ID.");
                        }
                    }
                }

                dialog.Close();
            };

            dialog.ShowDialog();
        }

        private void saldoTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decimal totalReceitas = 0;
            decimal totalDespesas = 0;

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();


                string queryReceitas = "SELECT SUM(Valor) FROM Financeiro WHERE Tipo = 'Receita'";
                using (SqlCommand comandoReceitas = new SqlCommand(queryReceitas, conexao))
                {
                    totalReceitas = (decimal)comandoReceitas.ExecuteScalar();
                }


                string queryDespesas = "SELECT SUM(Valor) FROM Financeiro WHERE Tipo = 'Despesa'";
                using (SqlCommand comandoDespesas = new SqlCommand(queryDespesas, conexao))
                {
                    totalDespesas = (decimal)comandoDespesas.ExecuteScalar();
                }
            }

            decimal saldoTotal = totalReceitas - totalDespesas;
            MessageBox.Show($"O saldo total é: R${saldoTotal}");
        }

        private void cadastraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form cadastroForm = new Form())
            {
                cadastroForm.Text = "Cadastrar Funcionário";
                cadastroForm.Size = new Size(400, 450);
                cadastroForm.StartPosition = FormStartPosition.CenterParent;

                Label lblNome = new Label { Text = "Nome:", AutoSize = true, Top = 20, Left = 10, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };
                TextBox txtNome = new TextBox { Top = 20, Left = 100, Width = 150 };

                Label lblCPF = new Label { Text = "CPF:", AutoSize = true, Top = 60, Left = 10, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };
                TextBox txtCPF = new TextBox { Top = 60, Left = 100, Width = 150 };

                Label lblEmail = new Label { Text = "Email:", AutoSize = true, Top = 100, Left = 10, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };
                TextBox txtEmail = new TextBox { Top = 100, Left = 100, Width = 150 };

                Label lblTelefone = new Label { Text = "Telefone:", AutoSize = true, Top = 140, Left = 10, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };
                TextBox txtTelefone = new TextBox { Top = 140, Left = 100, Width = 150 };

                Label lblEndereco = new Label { Text = "Endereço:", AutoSize = true, Top = 180, Left = 10, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };
                TextBox txtEndereco = new TextBox { Top = 180, Left = 100, Width = 150 };

                Label lblChavePix = new Label { Text = "Chave PIX:", AutoSize = true, Top = 220, Left = 10, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };
                TextBox txtChavePix = new TextBox { Top = 220, Left = 100, Width = 150 };

                Label lblSalario = new Label { Text = "Salário:", AutoSize = true, Top = 260, Left = 10, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };
                TextBox txtSalario = new TextBox { Top = 260, Left = 100, Width = 150 };

                Label lblFuncao = new Label { Text = "Função:", AutoSize = true, Top = 300, Left = 10, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };
                TextBox txtFuncao = new TextBox { Top = 300, Left = 100, Width = 150 };

                Button btnCadastrar = new Button { Text = "Cadastrar", AutoSize = true, Top = 340, Left = 100, Width = 100, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };

                cadastroForm.Controls.Add(lblNome);
                cadastroForm.Controls.Add(txtNome);
                cadastroForm.Controls.Add(lblCPF);
                cadastroForm.Controls.Add(txtCPF);
                cadastroForm.Controls.Add(lblEmail);
                cadastroForm.Controls.Add(txtEmail);
                cadastroForm.Controls.Add(lblTelefone);
                cadastroForm.Controls.Add(txtTelefone);
                cadastroForm.Controls.Add(lblEndereco);
                cadastroForm.Controls.Add(txtEndereco);
                cadastroForm.Controls.Add(lblChavePix);
                cadastroForm.Controls.Add(txtChavePix);
                cadastroForm.Controls.Add(lblSalario);
                cadastroForm.Controls.Add(txtSalario);
                cadastroForm.Controls.Add(lblFuncao);
                cadastroForm.Controls.Add(txtFuncao);
                cadastroForm.Controls.Add(btnCadastrar);

                btnCadastrar.Click += (s, args) =>
                {
                    string nome = txtNome.Text;
                    string cpf = txtCPF.Text;
                    string email = txtEmail.Text;
                    string telefone = txtTelefone.Text;
                    string endereco = txtEndereco.Text;
                    string chavePix = txtChavePix.Text; 
                    decimal salario;
                    string funcao = txtFuncao.Text;

                    if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cpf) ||
                        string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(telefone) ||
                        string.IsNullOrWhiteSpace(endereco) || string.IsNullOrWhiteSpace(chavePix) ||
                        string.IsNullOrWhiteSpace(txtSalario.Text) || string.IsNullOrWhiteSpace(funcao))
                    {
                        MessageBox.Show("Todos os campos devem ser preenchidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!decimal.TryParse(txtSalario.Text, out salario))
                    {
                        MessageBox.Show("Salário inválido. Por favor, insira um valor numérico.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    long cpfNumerico;
                    long telefoneNumerico;

                    if (!long.TryParse(cpf, out cpfNumerico))
                    {
                        MessageBox.Show("O CPF deve conter apenas números.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!long.TryParse(telefone, out telefoneNumerico))
                    {
                        MessageBox.Show("O telefone deve conter apenas números.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (SqlConnection conexao = new SqlConnection(connectionString))
                    {
                        conexao.Open();
                        string query = "INSERT INTO Funcionarios (Nome, CPF, Email, Telefone, Endereco, ChavePIX, Salario, Funcao) VALUES (@nome, @cpf, @email, @telefone, @endereco, @chavePix, @salario, @funcao)";

                        using (SqlCommand comando = new SqlCommand(query, conexao))
                        {
                            comando.Parameters.AddWithValue("@nome", nome);
                            comando.Parameters.AddWithValue("@cpf", cpf);
                            comando.Parameters.AddWithValue("@email", email);
                            comando.Parameters.AddWithValue("@telefone", telefone);
                            comando.Parameters.AddWithValue("@endereco", endereco);
                            comando.Parameters.AddWithValue("@chavePix", chavePix);
                            comando.Parameters.AddWithValue("@salario", salario);
                            comando.Parameters.AddWithValue("@funcao", funcao);

                            try
                            {
                                comando.ExecuteNonQuery();
                                MessageBox.Show("Funcionário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cadastroForm.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Erro ao cadastrar funcionário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                };
                cadastroForm.ShowDialog();
            }
        }

        private void consultarInformaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();
                    string query = "SELECT * FROM Funcionarios";
                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        using (SqlDataReader leitor = comando.ExecuteReader())
                        {
                            StringBuilder listaFuncionarios = new StringBuilder();

                            while (leitor.Read())
                            {
                                listaFuncionarios.AppendLine($"ID: {leitor["Id"]}, Nome: {leitor["Nome"]}, CPF: {leitor["CPF"]}, Email: {leitor["Email"]}, Telefone: {leitor["Telefone"]}, " +
                                    $"Endereco: {leitor["Endereco"]}, ChavePIX: {leitor["ChavePIX"]}, Salário: {leitor["Salario"]}, Funcão: {leitor["Funcao"]} ");
                            }

                            MessageBox.Show(listaFuncionarios.ToString(), "Lista de Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao consultar funcionários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void removerFuncionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form dialog = new Form
            {
                Size = new Size(300, 150),
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.LightGray,
                Text = "Remover Funcionário",
                FormBorderStyle = FormBorderStyle.FixedDialog
            };

            Label labelID = new Label { Text = "ID do Funcionário:", AutoSize = true, ForeColor = Color.LightGray, BackColor = Color.DarkGreen };
            TextBox textBoxID = new TextBox() { Width = 100 };

            Button btnRemover = new Button { Text = "Remover", AutoSize = true, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };

            labelID.Location = new Point(20, 30);
            textBoxID.Location = new Point(150, 30);

            btnRemover.Location = new Point(150, 80);

            dialog.Controls.Add(labelID);
            dialog.Controls.Add(textBoxID);
            dialog.Controls.Add(btnRemover);

            btnRemover.Click += (senderBtn, eBtn) =>
            {
                int idReceita = int.Parse(textBoxID.Text);

                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();
                    string query = "DELETE FROM Funcionarios WHERE Id = @id";
                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@id", idReceita);
                        int linhasAfetadas = comando.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Funcionário removido com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Nenhum funcionário encontrado com esse ID.");
                        }
                    }
                }

                dialog.Close();
            };

            dialog.ShowDialog();
        }

        private void coToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();
                    string query = "SELECT Nome, Funcao, ChavePIX, Salario FROM Funcionarios"; 
                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        using (SqlDataReader leitor = comando.ExecuteReader())
                        {
                            StringBuilder listaFuncionarios = new StringBuilder();

                            while (leitor.Read())
                            {
                                listaFuncionarios.AppendLine($"Nome: {leitor["Nome"]}, Função: {leitor["Funcao"]}, Chave PIX: {leitor["ChavePIX"]}, Salario: {leitor["Salario"]}");
                            }

                            if (listaFuncionarios.Length == 0)
                            {
                                MessageBox.Show("Nenhum funcionário encontrado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(listaFuncionarios.ToString(), "Lista de Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao consultar funcionários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cadastrarFornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form cadastroForm = new Form())
            {
                cadastroForm.Text = "Cadastrar Fornecedor:";
                cadastroForm.Size = new Size(500, 650);
                cadastroForm.StartPosition = FormStartPosition.CenterParent;

                Label lblNome = new Label { Text = "Nome:", AutoSize = true, Top = 20, Left = 10, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };
                TextBox txtNome = new TextBox { Top = 20, Left = 100, Width = 150 };

                Label lblCNPJ = new Label { Text = "CNPJ:", AutoSize = true, Top = 60, Left = 10, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };
                TextBox txtCNPJ = new TextBox { Top = 60, Left = 100, Width = 150 };

                Label lblEmail = new Label { Text = "Email:", AutoSize = true, Top = 100, Left = 10, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };
                TextBox txtEmail = new TextBox { Top = 100, Left = 100, Width = 150 };

                Label lblTelefone = new Label { Text = "Telefone:", AutoSize = true, Top = 140, Left = 10, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };
                TextBox txtTelefone = new TextBox { Top = 140, Left = 100, Width = 150 };

                Label lblEndereco = new Label { Text = "Endereço:", AutoSize = true, Top = 180, Left = 10, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };
                TextBox txtEndereco = new TextBox { Top = 180, Left = 100, Width = 150 };

                Label lblChavePix = new Label { Text = "Chave PIX:", AutoSize = true, Top = 220, Left = 10, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };
                TextBox txtChavePix = new TextBox { Top = 220, Left = 100, Width = 150 };

                Label lblTipoProduto = new Label { Text = "Tipo de Produto:", AutoSize = true, Top = 260, Left = 10, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };
                TextBox txtTipoProduto = new TextBox { Top = 260, Left = 135, Width = 150 };

                Label lblValorProduto = new Label { Text = "Valor do Produto:", AutoSize = true, Top = 300, Left = 10, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };
                TextBox txtValorProduto = new TextBox { Top = 300, Left = 135, Width = 150 };

                Button btnCadastrar = new Button { Text = "Cadastrar", AutoSize = true, Top = 340, Left = 100, Width = 100, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };

                cadastroForm.Controls.Add(lblNome);
                cadastroForm.Controls.Add(txtNome);
                cadastroForm.Controls.Add(lblCNPJ);
                cadastroForm.Controls.Add(txtCNPJ);
                cadastroForm.Controls.Add(lblEmail);
                cadastroForm.Controls.Add(txtEmail);
                cadastroForm.Controls.Add(lblTelefone);
                cadastroForm.Controls.Add(txtTelefone);
                cadastroForm.Controls.Add(lblEndereco);
                cadastroForm.Controls.Add(txtEndereco);
                cadastroForm.Controls.Add(lblChavePix);
                cadastroForm.Controls.Add(txtChavePix);
                cadastroForm.Controls.Add(lblTipoProduto);
                cadastroForm.Controls.Add(txtTipoProduto);
                cadastroForm.Controls.Add(lblValorProduto);
                cadastroForm.Controls.Add(txtValorProduto);
                cadastroForm.Controls.Add(btnCadastrar);

                btnCadastrar.Click += (s, args) =>
                {
                    string nome = txtNome.Text;
                    string cnpj = txtCNPJ.Text;
                    string email = txtEmail.Text;
                    string telefone = txtTelefone.Text;
                    string endereco = txtEndereco.Text;
                    string chavePix = txtChavePix.Text;
                    string tipoProduto = txtTipoProduto.Text;
                    decimal valorProduto;

                    if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cnpj) ||
                        string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(telefone) ||
                        string.IsNullOrWhiteSpace(endereco) || string.IsNullOrWhiteSpace(chavePix) ||
                        string.IsNullOrWhiteSpace(tipoProduto) || string.IsNullOrWhiteSpace(txtValorProduto.Text))
                    {
                        MessageBox.Show("Todos os campos devem ser preenchidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    if (!decimal.TryParse(txtValorProduto.Text, out valorProduto))
                    {
                        MessageBox.Show("O valor do produto deve ser um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    long cnpjNumerico;
                    long telefoneNumerico;

                    if (!long.TryParse(cnpj, out cnpjNumerico))
                    {
                        MessageBox.Show("O CNPJ deve conter apenas números.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!long.TryParse(telefone, out telefoneNumerico))
                    {
                        MessageBox.Show("O telefone deve conter apenas números.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (SqlConnection conexao = new SqlConnection(connectionString))
                    {
                        conexao.Open();
                        string query = "INSERT INTO Fornecedores (Nome, CNPJ, Email, Telefone, Endereco, ChavePIX, TipoProduto, ValorProduto) VALUES (@nome, @cnpj, @email, @telefone, @endereco, @chavePix, @tipoProduto, @valorProduto)";

                        using (SqlCommand comando = new SqlCommand(query, conexao))
                        {
                            comando.Parameters.AddWithValue("@nome", nome);
                            comando.Parameters.AddWithValue("@cnpj", cnpj);
                            comando.Parameters.AddWithValue("@email", email);
                            comando.Parameters.AddWithValue("@telefone", telefone);
                            comando.Parameters.AddWithValue("@endereco", endereco);
                            comando.Parameters.AddWithValue("@chavePix", chavePix);
                            comando.Parameters.AddWithValue("@tipoProduto", tipoProduto);
                            comando.Parameters.AddWithValue("@valorProduto", valorProduto);

                            try
                            {
                                comando.ExecuteNonQuery();
                                MessageBox.Show("Fornecedor cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cadastroForm.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Erro ao cadastrar fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                };
                cadastroForm.ShowDialog();
            }
        }

        private void consultarFornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();
                    string query = "SELECT * FROM Fornecedores";
                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        using (SqlDataReader leitor = comando.ExecuteReader())
                        {
                            StringBuilder listaFuncionarios = new StringBuilder();

                            while (leitor.Read())
                            {
                                listaFuncionarios.AppendLine($"ID: {leitor["Id"]}, Nome: {leitor["Nome"]}, CNPJ: {leitor["CNPJ"]}, Email: {leitor["Email"]}, Telefone: {leitor["Telefone"]}, " +
                                    $"Endereco: {leitor["Endereco"]}, ChavePIX: {leitor["ChavePIX"]}, Tipo de Produto: {leitor["TipoProduto"]}, Valor do Produto: {leitor["ValorProduto"]} ");
                            }

                            MessageBox.Show(listaFuncionarios.ToString(), "Lista de Fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao consultar funcionários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removerFornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form dialog = new Form
            {
                Size = new Size(300, 150),
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.LightGray,
                Text = "Remover Fornecedor",
                FormBorderStyle = FormBorderStyle.FixedDialog
            };

            Label labelID = new Label { Text = "ID do Fornecedor:", AutoSize = true, ForeColor = Color.LightGray, BackColor = Color.DarkGreen };
            TextBox textBoxID = new TextBox() { Width = 100 };

            Button btnRemover = new Button { Text = "Remover", AutoSize = true, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };

            labelID.Location = new Point(20, 30);
            textBoxID.Location = new Point(150, 30);

            btnRemover.Location = new Point(150, 80);

            dialog.Controls.Add(labelID);
            dialog.Controls.Add(textBoxID);
            dialog.Controls.Add(btnRemover);

            btnRemover.Click += (senderBtn, eBtn) =>
            {
                int idReceita = int.Parse(textBoxID.Text);

                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();
                    string query = "DELETE FROM Fornecedores WHERE Id = @id";
                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@id", idReceita);
                        int linhasAfetadas = comando.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Fornecedor removido com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Nenhum fornecedor encontrado com esse ID.");
                        }
                    }
                }

                dialog.Close();
            };

            dialog.ShowDialog();
        }

        private void informaçõesParaPagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();
                    string query = "SELECT Nome, CNPJ, ChavePIX, ValorProduto FROM Fornecedores";
                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        using (SqlDataReader leitor = comando.ExecuteReader())
                        {
                            StringBuilder listaFuncionarios = new StringBuilder();

                            while (leitor.Read())
                            {
                                listaFuncionarios.AppendLine($"Nome: {leitor["Nome"]}, CNPJ: {leitor["CNPJ"]}, Chave PIX: {leitor["ChavePIX"]}, Valor do Produto: {leitor["ValorProduto"]}");
                            }

                            if (listaFuncionarios.Length == 0)
                            {
                                MessageBox.Show("Nenhum fornecedor encontrado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(listaFuncionarios.ToString(), "Lista de Fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao consultar fornecedores: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void registrarTarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form dialog = new Form
            {
                Size = new Size(800, 600),
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.LightGray,
                Text = "Registrar Tarefa:",
                FormBorderStyle = FormBorderStyle.FixedDialog
            };

            System.Windows.Forms.Label labelDescricao = new System.Windows.Forms.Label { Text = "Descrição:", AutoSize = true, ForeColor = Color.LightGray, BackColor = Color.DarkGreen };
            System.Windows.Forms.TextBox textBoxDescricao = new System.Windows.Forms.TextBox { Width = 400 };

            System.Windows.Forms.Label labelDataCriacao = new System.Windows.Forms.Label { Text = "Data de Criação:", AutoSize = true, ForeColor = Color.LightGray, BackColor = Color.DarkGreen };
            System.Windows.Forms.DateTimePicker datePickerDataCriacao = new System.Windows.Forms.DateTimePicker { Format = DateTimePickerFormat.Short };

            System.Windows.Forms.Label labelResponsavel = new System.Windows.Forms.Label { Text = "Responsável:", AutoSize = true, ForeColor = Color.LightGray, BackColor = Color.DarkGreen };
            System.Windows.Forms.TextBox textBoxResponsavel = new System.Windows.Forms.TextBox { Width = 200 };

            System.Windows.Forms.Label labelPrioridade = new System.Windows.Forms.Label { Text = "Prioridade:", AutoSize = true, ForeColor = Color.LightGray, BackColor = Color.DarkGreen };
            System.Windows.Forms.ComboBox comboBoxPrioridade = new System.Windows.Forms.ComboBox { Width = 200 };
            comboBoxPrioridade.Items.AddRange(new string[] { "Baixa", "Média", "Alta" });

            System.Windows.Forms.Label labelStatus = new System.Windows.Forms.Label { Text = "Status:", AutoSize = true, ForeColor = Color.LightGray, BackColor = Color.DarkGreen };
            System.Windows.Forms.ComboBox comboBoxStatus = new System.Windows.Forms.ComboBox { Width = 200 };
            comboBoxStatus.Items.AddRange(new string[] { "Pendente", "Iniciada" }); 
            System.Windows.Forms.Button btnSalvar = new System.Windows.Forms.Button { Text = "Salvar", AutoSize = true, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };

            labelDescricao.Location = new Point(20, 30);
            textBoxDescricao.Location = new Point(150, 30);

            labelDataCriacao.Location = new Point(20, 80);
            datePickerDataCriacao.Location = new Point(150, 80);

            labelResponsavel.Location = new Point(20, 130);
            textBoxResponsavel.Location = new Point(150, 130);

            labelPrioridade.Location = new Point(20, 180);
            comboBoxPrioridade.Location = new Point(150, 180);

            labelStatus.Location = new Point(20, 230);
            comboBoxStatus.Location = new Point(150, 230);

            btnSalvar.Location = new Point(150, 280);

            dialog.Controls.Add(labelDescricao);
            dialog.Controls.Add(textBoxDescricao);
            dialog.Controls.Add(labelDataCriacao);
            dialog.Controls.Add(datePickerDataCriacao);
            dialog.Controls.Add(labelResponsavel);
            dialog.Controls.Add(textBoxResponsavel);
            dialog.Controls.Add(labelPrioridade);
            dialog.Controls.Add(comboBoxPrioridade);
            dialog.Controls.Add(labelStatus);
            dialog.Controls.Add(comboBoxStatus);
            dialog.Controls.Add(btnSalvar);

            btnSalvar.Click += (senderBtn, eBtn) =>
            {
                string descricao = textBoxDescricao.Text;
                string responsavel = textBoxResponsavel.Text;
                string prioridade = comboBoxPrioridade.SelectedItem?.ToString(); 
                string status = comboBoxStatus.SelectedItem?.ToString();

                if (string.IsNullOrWhiteSpace(descricao)  ||  string.IsNullOrWhiteSpace(responsavel) ||
                    string.IsNullOrWhiteSpace(prioridade) ||  string.IsNullOrWhiteSpace(status))
                {
                    MessageBox.Show("Todos os campos devem ser preenchidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                string dataCriacao = datePickerDataCriacao.Value.ToString("dd/MM/yyyy");

                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();
                    string query = "INSERT INTO Tarefas (Descricao, DataCriacao, Status, Responsavel, Prioridade) VALUES (@descricao, @dataCriacao, @status, @responsavel, @prioridade)";
                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@descricao", descricao);
                        comando.Parameters.AddWithValue("@dataCriacao", dataCriacao);
                        comando.Parameters.AddWithValue("@status", status);
                        comando.Parameters.AddWithValue("@Responsavel", responsavel);
                        comando.Parameters.AddWithValue("@prioridade", prioridade);
                        comando.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Tarefa registrada com sucesso!");
                dialog.Close();
            };

            dialog.ShowDialog();
        }

        private void statusDeTarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form dialog = new Form
            {
                Size = new Size(800, 600),
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.LightGray,
                Text = "Atualizar Status da Tarefa:",
                FormBorderStyle = FormBorderStyle.FixedDialog
            };

            System.Windows.Forms.Label labelTarefa = new System.Windows.Forms.Label { Text = "Tarefas:", AutoSize = true, ForeColor = Color.LightGray, BackColor = Color.DarkGreen };
            System.Windows.Forms.ListBox listBoxTarefas = new System.Windows.Forms.ListBox { Width = 600, Height = 200 };

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();
                string query = "SELECT Descricao FROM Tarefas WHERE Status != 'Concluída'";
                using (SqlCommand comando = new SqlCommand(query, conexao))
                {
                    using (SqlDataReader leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            listBoxTarefas.Items.Add(leitor["Descricao"].ToString());
                        }
                    }
                }
            }

            System.Windows.Forms.Label labelStatus = new System.Windows.Forms.Label { Text = "Novo Status:", AutoSize = true, ForeColor = Color.LightGray, BackColor = Color.DarkGreen };
            System.Windows.Forms.RadioButton radioPendente = new System.Windows.Forms.RadioButton { Text = "Pendente", ForeColor = Color.LightGray, BackColor = Color.DarkGreen };
            System.Windows.Forms.RadioButton radioIniciada = new System.Windows.Forms.RadioButton { Text = "Iniciada", ForeColor = Color.LightGray, BackColor = Color.DarkGreen };
            System.Windows.Forms.RadioButton radioConcluida = new System.Windows.Forms.RadioButton { Text = "Concluída", ForeColor = Color.LightGray, BackColor = Color.DarkGreen };

            System.Windows.Forms.Button btnAtualizar = new System.Windows.Forms.Button { Text = "Atualizar", AutoSize = true, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };

            labelTarefa.Location = new Point(20, 30);
            listBoxTarefas.Location = new Point(150, 30);

            labelStatus.Location = new Point(20, 250);
            radioPendente.Location = new Point(150, 250);
            radioIniciada.Location = new Point(150, 280);
            radioConcluida.Location = new Point(150, 310);

            btnAtualizar.Location = new Point(150, 350);

            dialog.Controls.Add(labelTarefa);
            dialog.Controls.Add(listBoxTarefas);
            dialog.Controls.Add(labelStatus);
            dialog.Controls.Add(radioPendente);
            dialog.Controls.Add(radioIniciada);
            dialog.Controls.Add(radioConcluida);
            dialog.Controls.Add(btnAtualizar);

            btnAtualizar.Click += (senderBtn, eBtn) =>
            {
                if (listBoxTarefas.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecione uma tarefa.");
                    return;
                }

                string novaStatus = "";
                if (radioPendente.Checked)
                {
                    novaStatus = "Pendente";
                }
                else if (radioIniciada.Checked)
                {
                    novaStatus = "Iniciada";
                }
                else if (radioConcluida.Checked)
                {
                    novaStatus = "Concluída";
                }
                else
                {
                    MessageBox.Show("Por favor, selecione um status.");
                    return; 
                }

                string tarefaSelecionada = listBoxTarefas.SelectedItem.ToString();

                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();
                    string query = "UPDATE Tarefas SET Status = @status WHERE Descricao = @descricao";
                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@status", novaStatus);
                        comando.Parameters.AddWithValue("@descricao", tarefaSelecionada);
                        comando.ExecuteNonQuery();
                    }

                    if (novaStatus == "Concluída")
                    {
                        listBoxTarefas.Items.Remove(tarefaSelecionada);
                    }
                }

                MessageBox.Show("Status atualizado com sucesso!");
            };

            dialog.ShowDialog();
        }

        private void consultarStatusDasTarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form dialog = new Form
            {
                Size = new Size(400, 300),
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.LightGray,
                Text = "Consultar Status da Tarefa:",
                FormBorderStyle = FormBorderStyle.FixedDialog
            };

            Label labelDescricao = new Label { Text = "Descrição da Tarefa:", AutoSize = true, ForeColor = Color.LightGray, BackColor = Color.DarkGreen };
            TextBox textBoxDescricao = new TextBox { Width = 200 };

            Button btnConsultar = new Button { Text = "Consultar", AutoSize = true, BackColor = Color.DarkGreen, ForeColor = Color.LightGray };

            labelDescricao.Location = new Point(20, 30);
            textBoxDescricao.Location = new Point(180, 30);
            btnConsultar.Location = new Point(150, 80);

            dialog.Controls.Add(labelDescricao);
            dialog.Controls.Add(textBoxDescricao);
            dialog.Controls.Add(btnConsultar);

            btnConsultar.Click += (senderBtn, eBtn) =>
            {
                string descricao = textBoxDescricao.Text;
                if (string.IsNullOrWhiteSpace(descricao))
                {
                    MessageBox.Show("Por favor, preencha a descrição da tarefa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string status = "";

                using (SqlConnection conexao = new SqlConnection(connectionString))
                {
                    conexao.Open();
                    string query = "SELECT Status FROM Tarefas WHERE Descricao = @descricao";
                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@descricao", descricao);
                        SqlDataReader reader = comando.ExecuteReader();

                        if (reader.Read())
                        {
                            status = reader["Status"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Tarefa não encontrada.");
                            dialog.Close();
                            return;
                        }
                    }
                }

                MessageBox.Show($"Status da Tarefa: {status}");
            };

            dialog.ShowDialog();
        }

        private void suporteEAjudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Algum problema? Entre em contato com o suporte:\n" +
                "Email: suporte@email.com\n" +
                "Telefone: (11)9999-8787");
        }
    }
}
