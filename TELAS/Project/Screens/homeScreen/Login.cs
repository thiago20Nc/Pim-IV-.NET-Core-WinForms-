using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace TELAS
{
    public partial class Login : Form
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=CadastroBD;Integrated Security=True;Encrypt=False"; // Ajuste conforme sua configuração

        public Login()
        {
            InitializeComponent();
            this.Load += new EventHandler(Login_Load);
            this.Resize += new EventHandler(Login_Resize);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            CentralizarGroupBox();
        }

        private void Login_Resize(object sender, EventArgs e)
        {
            CentralizarGroupBox();
        }

        private void CentralizarGroupBox()
        {
            groupBox1.Location = new System.Drawing.Point(
                (this.ClientSize.Width - groupBox1.Width) / 2,
                (this.ClientSize.Height - groupBox1.Height) / 2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string senha = textBox2.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Todos os campos devem ser preenchidos.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(1) FROM CadastroUsuários WHERE Email = @Email AND Senha = @Senha"; // Query para verificar credenciais
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email); // Adiciona parâmetro para o email e senha
                        command.Parameters.AddWithValue("@Senha", senha);

                        int count = Convert.ToInt32(command.ExecuteScalar()); // Executa a query e obtém a contagem

                        if (count == 1)
                        {
                            TelaPrincipal telaPrincipal = new TelaPrincipal();
                            this.Hide();
                            telaPrincipal.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Email ou senha incorretos. Tente novamente.");
                            return;
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


        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Não se preoculpe, entre em contato com o suporte, iremos te ajudar...\n" +
                "Contatos:\nsuporte@email.com\n(11)10001-0110");
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void groupBox1_Enter(object sender, EventArgs e) { }

        private void textBox2_TextChanged(object sender, EventArgs e) { }
    }
}
