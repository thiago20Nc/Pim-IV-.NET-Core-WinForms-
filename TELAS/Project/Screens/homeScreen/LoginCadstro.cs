using System;
using System.Windows.Forms;

namespace TELAS
{
    public partial class LoginCadstro : Form
    {
        public LoginCadstro()
        {
            InitializeComponent();
            this.Load += new EventHandler(LoginCadstro_Load); 
            this.Resize += new EventHandler(LoginCadstro_Resize);
        }

        private void LoginCadstro_Load(object sender, EventArgs e)
        {
            CentralizarGroupBox(); 
        }

        private void LoginCadstro_Resize(object sender, EventArgs e)
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
            Cadastro cad = new Cadastro();
            cad.MdiParent = this.MdiParent; 
            cad.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.MdiParent = this.MdiParent; 
            login.Show();
            this.Close();
        }

        private void groupBox1_Enter_1(object sender, EventArgs e){}
    }
}

