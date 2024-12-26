using System;
using System.Drawing;
using System.Windows.Forms;

namespace TELAS
{
    public partial class TeladeInicio : Form
    {
        public TeladeInicio()
        {
            InitializeComponent();
            this.IsMdiContainer = true; 
            this.BackColor = Color.LightGray;
        }

        private void TeladeInicio_Load(object sender, EventArgs e)
        {
            label2.TextAlign = ContentAlignment.MiddleCenter; 
            CentralizarLabel(); 
            AjustarBotoes(); 
        }

        private void CentralizarLabel()
        {
            label2.Location = new Point(
                (this.ClientSize.Width - label2.Width) / 2,
                (this.ClientSize.Height - label2.Height) / 2); 
        }

        private void AjustarBotoes()
        {
           
            button1.Location = new Point(this.ClientSize.Width - button1.Width - button2.Width - 20, 10); 
            button2.Location = new Point(button1.Right + 10, 10);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CentralizarLabel(); 
            AjustarBotoes(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("GreenTech é um sistema para fazendas urbanas que conecta colaboradores, fornecedores e clientes, " +
            "permitindo que os clientes consultem produtos e realizem compras diretamente.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginCadstro loginCad = new LoginCadstro();
            this.Hide();
            loginCad.ShowDialog(); 
        }
    }
}
