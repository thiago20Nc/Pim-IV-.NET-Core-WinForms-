using System;
using Microsoft.Data.SqlClient; 
using System.Windows.Forms;

namespace TELAS
{
    public partial class Cadastro : Form
    {
        private string connectionString = "Server=localhost;Database=CadastroBD;Integrated Security=True;";

        public Cadastro()
        {
            InitializeComponent();
            this.Shown += new EventHandler(Cadastro_Shown);
            this.Resize += new EventHandler(Cadastro_Resize);
        }

        private void Cadastro_Shown(object sender, EventArgs e)
        {
            centralizarGroupBox();
        }

        private void Cadastro_Resize(object sender, EventArgs e)
        {
            centralizarGroupBox();
        }

        private void centralizarGroupBox()
        {
            if (groupBox1 != null)
            {
                groupBox1.Left = (this.ClientSize.Width - groupBox1.Width) / 2;
                groupBox1.Top = (this.ClientSize.Height - groupBox1.Height) / 2;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.MdiParent = this.MdiParent;
            login.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Todos os campos devem ser preenchidos.");
                return; 
            }

            if (!long.TryParse(textBox2.Text, out _) || !long.TryParse(textBox3.Text, out _))
            {
                MessageBox.Show("Os campos CPF e Telefone devem conter apenas números.");
                return; 
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO CadastroUsuários (Nome, CPF, Telefone, Email, Senha) VALUES (@Nome, @CPF, @Telefone, @Email, @Senha)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", textBox1.Text);
                        command.Parameters.AddWithValue("@CPF", textBox2.Text);
                        command.Parameters.AddWithValue("@Telefone", textBox3.Text);
                        command.Parameters.AddWithValue("@Email", textBox5.Text);
                        command.Parameters.AddWithValue("@Senha", textBox4.Text);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Cadastro efetuado com sucesso!\nFaça Login...");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e){}

        private void textBox2_TextChanged(object sender, EventArgs e){}

        private void textBox3_TextChanged(object sender, EventArgs e){}

        private void textBox4_TextChanged(object sender, EventArgs e){}

        private void textBox5_TextChanged(object sender, EventArgs e) {}
        private void groupBox1_Enter(object sender, EventArgs e){}
    }
}
