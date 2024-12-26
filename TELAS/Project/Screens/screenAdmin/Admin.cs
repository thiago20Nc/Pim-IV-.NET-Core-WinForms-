using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace TELAS
{
    public partial class Admin : Form
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=CadastroBD;Integrated Security=True;Encrypt=False";

        public Admin()
        {
            InitializeComponent();
            this.FormClosed += Form1_FormClosed;
            this.FormClosing += (s, e) =>
            {
                System.Windows.Forms.Application.Exit();
            };
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); 
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form adminLoginDialog = new Form
            {
                Text = "Área Administrativa",
                Size = new Size(450, 350),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.LightGray
            };

            Label labelNome = new Label 
            { 
                Text = "Nome:", Location = new Point(10, 20), 
                BackColor = Color.DarkGreen, ForeColor = Color.LightGray, AutoSize = true
            };
            TextBox textBoxNome = new TextBox { Location = new Point(80, 20), Width = 180 };

            Label labelEmail = new Label 
            {
                Text = "Email:", Location = new Point(10, 60), 
                BackColor = Color.DarkGreen, ForeColor = Color.LightGray, AutoSize = true 
            };
            TextBox textBoxEmail = new TextBox { Location = new Point(80, 60), Width = 180 };

            Label labelSenha = new Label 
            { 
                Text = "Senha:", Location = new Point(10, 100), 
                BackColor = Color.DarkGreen, ForeColor = Color.LightGray, AutoSize = true
            };
            TextBox textBoxSenha = new TextBox { Location = new Point(80, 100), Width = 180, PasswordChar = '*' };

            Button buttonEntrar = new Button
            {
                Text = "Entrar",
                Location = new Point(80, 140),
                AutoSize = true,
                BackColor = Color.DarkGreen,
                ForeColor = Color.LightGray
            };

            Button buttonCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(180, 140),
                AutoSize = true,
                BackColor = Color.DarkGreen,
                ForeColor = Color.LightGray
            };

            buttonEntrar.Click += (s, args) =>
            {
                string nome = textBoxNome.Text;
                string email = textBoxEmail.Text;
                string senha = textBoxSenha.Text;

                if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
                {
                    MessageBox.Show("Todos os campos devem ser preenchidos.");
                    return; 
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT COUNT(1) FROM Administrador WHERE Nome = @Nome AND Email = @Email AND Senha = @Senha";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Nome", nome);
                            command.Parameters.AddWithValue("@Email", email);
                            command.Parameters.AddWithValue("@Senha", senha);

                            int count = Convert.ToInt32(command.ExecuteScalar());

                            if (count == 1)
                            {
                                MenuAdmin menuAdmin = new MenuAdmin();
                                adminLoginDialog.Hide();
                                menuAdmin.ShowDialog();
                                adminLoginDialog.Close();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Nome, email ou senha incorretos. Tente novamente.");
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
            };

            buttonCancelar.Click += (s, args) => adminLoginDialog.Close();

            adminLoginDialog.Controls.Add(labelNome);
            adminLoginDialog.Controls.Add(textBoxNome);
            adminLoginDialog.Controls.Add(labelEmail);
            adminLoginDialog.Controls.Add(textBoxEmail);
            adminLoginDialog.Controls.Add(labelSenha);
            adminLoginDialog.Controls.Add(textBoxSenha);
            adminLoginDialog.Controls.Add(buttonEntrar);
            adminLoginDialog.Controls.Add(buttonCancelar);

            adminLoginDialog.ShowDialog(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Apenas pessoas autorizadas podem entrar.\n" +
                "Se você é um administrador, solicite ao suporte de TI, que crie seu cadastro!");
        }
    }
}
