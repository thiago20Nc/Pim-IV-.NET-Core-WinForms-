namespace TELAS
{
    partial class TeladeInicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.DarkGreen;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LightGray;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(166, 40);
            label1.TabIndex = 1;
            label1.Text = "Green Tech";
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.BackColor = Color.DarkGreen;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.LightGray;
            button1.Location = new Point(761, 17);
            button1.Name = "button1";
            button1.Size = new Size(127, 43);
            button1.TabIndex = 2;
            button1.Text = "Entrar ➡️";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkGreen;
            button2.BackgroundImageLayout = ImageLayout.Center;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.LightGray;
            button2.Location = new Point(607, 17);
            button2.Name = "button2";
            button2.Size = new Size(133, 43);
            button2.TabIndex = 3;
            button2.Text = "Sobre nós";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.DarkGreen;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.LightGray;
            label2.Location = new Point(172, 178);
            label2.Name = "label2";
            label2.Size = new Size(651, 40);
            label2.TabIndex = 4;
            label2.Text = "🌳 Tecnologia a Serviço do Meio Ambiente🌳";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TeladeInicio
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(900, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            Name = "TeladeInicio";
            Text = "Green Tech";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button button1;
        private Button button2;

        private void Form1_Load(object sender, EventArgs e)
        {
            // Percorre todos os controles do formulário
            foreach (Control ctl in this.Controls)
            {
                // Verifica se o controle é do tipo MdiClient, que é o fundo do MDI
                if (ctl is MdiClient)
                {
                    // Altera a cor de fundo
                    ctl.BackColor = Color.LightGray; // Aqui você define a cor desejada
                }
            }
        }

        private Label label2;
    }
}
