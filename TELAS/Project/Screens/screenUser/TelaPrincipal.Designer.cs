namespace TELAS
{
    partial class TelaPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            anexarRelatóriosToolStripMenuItem = new ToolStripMenuItem();
            consultarRelatóriosToolStripMenuItem = new ToolStripMenuItem();
            removerRelatóriosToolStripMenuItem = new ToolStripMenuItem();
            relatóriosDeEntregasToolStripMenuItem = new ToolStripMenuItem();
            anexarRelatóriosToolStripMenuItem1 = new ToolStripMenuItem();
            consultarRelatóriosToolStripMenuItem1 = new ToolStripMenuItem();
            removerRelatóriosToolStripMenuItem1 = new ToolStripMenuItem();
            análiseClimáticaToolStripMenuItem = new ToolStripMenuItem();
            analiseClimaticaPrevisaoDoTempo = new ToolStripMenuItem();
            relatórioDeTendênciasClimáticasToolStripMenuItem = new ToolStripMenuItem();
            plantilEColheitaToolStripMenuItem = new ToolStripMenuItem();
            registroDeCulturasToolStripMenuItem = new ToolStripMenuItem();
            consultaDeCulturasToolStripMenuItem = new ToolStripMenuItem();
            removerCulturasToolStripMenuItem = new ToolStripMenuItem();
            produtosToolStripMenuItem = new ToolStripMenuItem();
            cadastrarProdutoToolStripMenuItem = new ToolStripMenuItem();
            consultarProdutosToolStripMenuItem = new ToolStripMenuItem();
            removerProdutoToolStripMenuItem = new ToolStripMenuItem();
            produçãoToolStripMenuItem = new ToolStripMenuItem();
            alimentosToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            groupBox1 = new GroupBox();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.LightGray;
            menuStrip1.Dock = DockStyle.Left;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, relatóriosDeEntregasToolStripMenuItem, análiseClimáticaToolStripMenuItem, plantilEColheitaToolStripMenuItem, produtosToolStripMenuItem, produçãoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(322, 706);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.BackColor = Color.DarkGreen;
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { toolStripSeparator1, anexarRelatóriosToolStripMenuItem, consultarRelatóriosToolStripMenuItem, removerRelatóriosToolStripMenuItem });
            toolStripMenuItem1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            toolStripMenuItem1.ForeColor = Color.LightGray;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(309, 32);
            toolStripMenuItem1.Text = "Relatórios de Vendas         >    ";
            toolStripMenuItem1.TextAlign = ContentAlignment.MiddleLeft;
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(289, 6);
            // 
            // anexarRelatóriosToolStripMenuItem
            // 
            anexarRelatóriosToolStripMenuItem.BackColor = Color.LightGray;
            anexarRelatóriosToolStripMenuItem.ForeColor = Color.DarkGreen;
            anexarRelatóriosToolStripMenuItem.Name = "anexarRelatóriosToolStripMenuItem";
            anexarRelatóriosToolStripMenuItem.Size = new Size(292, 32);
            anexarRelatóriosToolStripMenuItem.Text = "Anexar Relatórios";
            anexarRelatóriosToolStripMenuItem.Click += anexarRelatóriosToolStripMenuItem_Click;
            // 
            // consultarRelatóriosToolStripMenuItem
            // 
            consultarRelatóriosToolStripMenuItem.BackColor = Color.LightGray;
            consultarRelatóriosToolStripMenuItem.ForeColor = Color.DarkGreen;
            consultarRelatóriosToolStripMenuItem.Name = "consultarRelatóriosToolStripMenuItem";
            consultarRelatóriosToolStripMenuItem.Size = new Size(292, 32);
            consultarRelatóriosToolStripMenuItem.Text = "Consultar Relatórios";
            consultarRelatóriosToolStripMenuItem.Click += consultarRelatóriosToolStripMenuItem_Click;
            // 
            // removerRelatóriosToolStripMenuItem
            // 
            removerRelatóriosToolStripMenuItem.BackColor = Color.LightGray;
            removerRelatóriosToolStripMenuItem.ForeColor = Color.DarkGreen;
            removerRelatóriosToolStripMenuItem.Name = "removerRelatóriosToolStripMenuItem";
            removerRelatóriosToolStripMenuItem.Size = new Size(292, 32);
            removerRelatóriosToolStripMenuItem.Text = "Remover Relatórios";
            removerRelatóriosToolStripMenuItem.Click += removerRelatóriosToolStripMenuItem_Click;
            // 
            // relatóriosDeEntregasToolStripMenuItem
            // 
            relatóriosDeEntregasToolStripMenuItem.BackColor = Color.DarkGreen;
            relatóriosDeEntregasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { anexarRelatóriosToolStripMenuItem1, consultarRelatóriosToolStripMenuItem1, removerRelatóriosToolStripMenuItem1 });
            relatóriosDeEntregasToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            relatóriosDeEntregasToolStripMenuItem.ForeColor = Color.LightGray;
            relatóriosDeEntregasToolStripMenuItem.Name = "relatóriosDeEntregasToolStripMenuItem";
            relatóriosDeEntregasToolStripMenuItem.Size = new Size(309, 32);
            relatóriosDeEntregasToolStripMenuItem.Text = "Relatórios de Entregas      >";
            relatóriosDeEntregasToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // anexarRelatóriosToolStripMenuItem1
            // 
            anexarRelatóriosToolStripMenuItem1.BackColor = Color.LightGray;
            anexarRelatóriosToolStripMenuItem1.ForeColor = Color.DarkGreen;
            anexarRelatóriosToolStripMenuItem1.Name = "anexarRelatóriosToolStripMenuItem1";
            anexarRelatóriosToolStripMenuItem1.Size = new Size(292, 32);
            anexarRelatóriosToolStripMenuItem1.Text = "Anexar Relatórios ";
            anexarRelatóriosToolStripMenuItem1.Click += anexarRelatóriosToolStripMenuItem1_Click;
            // 
            // consultarRelatóriosToolStripMenuItem1
            // 
            consultarRelatóriosToolStripMenuItem1.BackColor = Color.LightGray;
            consultarRelatóriosToolStripMenuItem1.ForeColor = Color.DarkGreen;
            consultarRelatóriosToolStripMenuItem1.Name = "consultarRelatóriosToolStripMenuItem1";
            consultarRelatóriosToolStripMenuItem1.Size = new Size(292, 32);
            consultarRelatóriosToolStripMenuItem1.Text = "Consultar Relatórios";
            consultarRelatóriosToolStripMenuItem1.Click += consultarRelatóriosToolStripMenuItem1_Click;
            // 
            // removerRelatóriosToolStripMenuItem1
            // 
            removerRelatóriosToolStripMenuItem1.BackColor = Color.LightGray;
            removerRelatóriosToolStripMenuItem1.ForeColor = Color.DarkGreen;
            removerRelatóriosToolStripMenuItem1.Name = "removerRelatóriosToolStripMenuItem1";
            removerRelatóriosToolStripMenuItem1.Size = new Size(292, 32);
            removerRelatóriosToolStripMenuItem1.Text = "Remover Relatórios ";
            removerRelatóriosToolStripMenuItem1.Click += removerRelatóriosToolStripMenuItem1_Click;
            // 
            // análiseClimáticaToolStripMenuItem
            // 
            análiseClimáticaToolStripMenuItem.BackColor = Color.DarkGreen;
            análiseClimáticaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { analiseClimaticaPrevisaoDoTempo, relatórioDeTendênciasClimáticasToolStripMenuItem });
            análiseClimáticaToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            análiseClimáticaToolStripMenuItem.ForeColor = Color.LightGray;
            análiseClimáticaToolStripMenuItem.Name = "análiseClimáticaToolStripMenuItem";
            análiseClimáticaToolStripMenuItem.Size = new Size(309, 32);
            análiseClimáticaToolStripMenuItem.Text = "Análise Climática              >";
            análiseClimáticaToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            análiseClimáticaToolStripMenuItem.Click += análiseClimáticaToolStripMenuItem_Click;
            // 
            // analiseClimaticaPrevisaoDoTempo
            // 
            analiseClimaticaPrevisaoDoTempo.BackColor = Color.LightGray;
            analiseClimaticaPrevisaoDoTempo.ForeColor = Color.DarkGreen;
            analiseClimaticaPrevisaoDoTempo.Name = "analiseClimaticaPrevisaoDoTempo";
            analiseClimaticaPrevisaoDoTempo.Size = new Size(428, 32);
            analiseClimaticaPrevisaoDoTempo.Text = "Previsão do Tempo";
            analiseClimaticaPrevisaoDoTempo.Click += tabelaDeViabilidadeDePlantioToolStripMenuItem_Click;
            // 
            // relatórioDeTendênciasClimáticasToolStripMenuItem
            // 
            relatórioDeTendênciasClimáticasToolStripMenuItem.BackColor = Color.LightGray;
            relatórioDeTendênciasClimáticasToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic);
            relatórioDeTendênciasClimáticasToolStripMenuItem.ForeColor = Color.DarkGreen;
            relatórioDeTendênciasClimáticasToolStripMenuItem.Name = "relatórioDeTendênciasClimáticasToolStripMenuItem";
            relatórioDeTendênciasClimáticasToolStripMenuItem.Size = new Size(428, 32);
            relatórioDeTendênciasClimáticasToolStripMenuItem.Text = "Relatório de Tendências Climáticas";
            relatórioDeTendênciasClimáticasToolStripMenuItem.Click += relatórioDeTendênciasClimáticasToolStripMenuItem_Click;
            // 
            // plantilEColheitaToolStripMenuItem
            // 
            plantilEColheitaToolStripMenuItem.BackColor = Color.DarkGreen;
            plantilEColheitaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registroDeCulturasToolStripMenuItem, consultaDeCulturasToolStripMenuItem, removerCulturasToolStripMenuItem });
            plantilEColheitaToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            plantilEColheitaToolStripMenuItem.ForeColor = Color.LightGray;
            plantilEColheitaToolStripMenuItem.Name = "plantilEColheitaToolStripMenuItem";
            plantilEColheitaToolStripMenuItem.Size = new Size(309, 32);
            plantilEColheitaToolStripMenuItem.Text = "Plantio e Colheita             >";
            plantilEColheitaToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // registroDeCulturasToolStripMenuItem
            // 
            registroDeCulturasToolStripMenuItem.BackColor = Color.LightGray;
            registroDeCulturasToolStripMenuItem.ForeColor = Color.DarkGreen;
            registroDeCulturasToolStripMenuItem.Name = "registroDeCulturasToolStripMenuItem";
            registroDeCulturasToolStripMenuItem.Size = new Size(296, 32);
            registroDeCulturasToolStripMenuItem.Text = "Registro de Culturas ";
            registroDeCulturasToolStripMenuItem.Click += registroDeCulturasToolStripMenuItem_Click;
            // 
            // consultaDeCulturasToolStripMenuItem
            // 
            consultaDeCulturasToolStripMenuItem.BackColor = Color.LightGray;
            consultaDeCulturasToolStripMenuItem.ForeColor = Color.DarkGreen;
            consultaDeCulturasToolStripMenuItem.Name = "consultaDeCulturasToolStripMenuItem";
            consultaDeCulturasToolStripMenuItem.Size = new Size(296, 32);
            consultaDeCulturasToolStripMenuItem.Text = "Consulta de Culturas";
            consultaDeCulturasToolStripMenuItem.Click += consultaDeCulturasToolStripMenuItem_Click;
            // 
            // removerCulturasToolStripMenuItem
            // 
            removerCulturasToolStripMenuItem.BackColor = Color.LightGray;
            removerCulturasToolStripMenuItem.ForeColor = Color.DarkGreen;
            removerCulturasToolStripMenuItem.Name = "removerCulturasToolStripMenuItem";
            removerCulturasToolStripMenuItem.Size = new Size(296, 32);
            removerCulturasToolStripMenuItem.Text = "Remover Culturas";
            removerCulturasToolStripMenuItem.Click += removerCulturasToolStripMenuItem_Click;
            // 
            // produtosToolStripMenuItem
            // 
            produtosToolStripMenuItem.BackColor = Color.DarkGreen;
            produtosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cadastrarProdutoToolStripMenuItem, consultarProdutosToolStripMenuItem, removerProdutoToolStripMenuItem });
            produtosToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            produtosToolStripMenuItem.ForeColor = Color.LightGray;
            produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            produtosToolStripMenuItem.Size = new Size(309, 32);
            produtosToolStripMenuItem.Text = "Produtos                           >";
            produtosToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cadastrarProdutoToolStripMenuItem
            // 
            cadastrarProdutoToolStripMenuItem.BackColor = Color.LightGray;
            cadastrarProdutoToolStripMenuItem.ForeColor = Color.DarkGreen;
            cadastrarProdutoToolStripMenuItem.Name = "cadastrarProdutoToolStripMenuItem";
            cadastrarProdutoToolStripMenuItem.Size = new Size(275, 32);
            cadastrarProdutoToolStripMenuItem.Text = "Cadastrar Produto";
            cadastrarProdutoToolStripMenuItem.Click += cadastrarProdutoToolStripMenuItem_Click;
            // 
            // consultarProdutosToolStripMenuItem
            // 
            consultarProdutosToolStripMenuItem.BackColor = Color.LightGray;
            consultarProdutosToolStripMenuItem.ForeColor = Color.DarkGreen;
            consultarProdutosToolStripMenuItem.Name = "consultarProdutosToolStripMenuItem";
            consultarProdutosToolStripMenuItem.Size = new Size(275, 32);
            consultarProdutosToolStripMenuItem.Text = "Consultar Produto";
            consultarProdutosToolStripMenuItem.Click += consultarProdutosToolStripMenuItem_Click;
            // 
            // removerProdutoToolStripMenuItem
            // 
            removerProdutoToolStripMenuItem.BackColor = Color.LightGray;
            removerProdutoToolStripMenuItem.ForeColor = Color.DarkGreen;
            removerProdutoToolStripMenuItem.Name = "removerProdutoToolStripMenuItem";
            removerProdutoToolStripMenuItem.Size = new Size(275, 32);
            removerProdutoToolStripMenuItem.Text = "Remover Produto";
            removerProdutoToolStripMenuItem.Click += removerProdutoToolStripMenuItem_Click;
            // 
            // produçãoToolStripMenuItem
            // 
            produçãoToolStripMenuItem.BackColor = Color.DarkGreen;
            produçãoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { alimentosToolStripMenuItem });
            produçãoToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            produçãoToolStripMenuItem.ForeColor = Color.LightGray;
            produçãoToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            produçãoToolStripMenuItem.Name = "produçãoToolStripMenuItem";
            produçãoToolStripMenuItem.Size = new Size(309, 32);
            produçãoToolStripMenuItem.Text = "Produção                          >";
            produçãoToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            produçãoToolStripMenuItem.Click += produçãoToolStripMenuItem_Click;
            // 
            // alimentosToolStripMenuItem
            // 
            alimentosToolStripMenuItem.BackColor = Color.LightGray;
            alimentosToolStripMenuItem.DoubleClickEnabled = true;
            alimentosToolStripMenuItem.ForeColor = Color.DarkGreen;
            alimentosToolStripMenuItem.Name = "alimentosToolStripMenuItem";
            alimentosToolStripMenuItem.Size = new Size(750, 32);
            alimentosToolStripMenuItem.Text = "Informações Sobre Alimentos, Épocas de Plantio e Período de Cultivo";
            alimentosToolStripMenuItem.Click += alimentosToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.DarkGreen;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LightGray;
            label1.Location = new Point(6, 35);
            label1.Name = "label1";
            label1.Size = new Size(666, 82);
            label1.TabIndex = 2;
            label1.Text = "Green Tech \r\n🌳 Tecnologia a Serviço do Meio Ambiente🌳";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.LightGray;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.DarkGreen;
            button1.Location = new Point(1061, 12);
            button1.Name = "button1";
            button1.Size = new Size(247, 40);
            button1.TabIndex = 3;
            button1.Text = "Área Administrativa ➡️";
            button1.TextAlign = ContentAlignment.TopRight;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.BackColor = Color.LightGray;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.DarkGreen;
            button2.Location = new Point(1115, 654);
            button2.Name = "button2";
            button2.Size = new Size(193, 40);
            button2.TabIndex = 4;
            button2.Text = "Precisa de Ajuda?";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.BackColor = Color.LightGray;
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(454, 273);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(676, 157);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // TelaPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGreen;
            ClientSize = new Size(1320, 706);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            Controls.Add(groupBox1);
            MainMenuStrip = menuStrip1;
            Name = "TelaPrincipal";
            Text = "Green Tech";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem anexarRelatóriosToolStripMenuItem;
        private ToolStripMenuItem consultarRelatóriosToolStripMenuItem;
        private ToolStripMenuItem relatóriosDeEntregasToolStripMenuItem;
        private ToolStripMenuItem anexarRelatóriosToolStripMenuItem1;
        private ToolStripMenuItem consultarRelatóriosToolStripMenuItem1;
        private ToolStripMenuItem análiseClimáticaToolStripMenuItem;
        private ToolStripMenuItem analiseClimaticaPrevisaoDoTempo;
        private ToolStripMenuItem relatórioDeTendênciasClimáticasToolStripMenuItem;
        private ToolStripMenuItem plantilEColheitaToolStripMenuItem;
        private ToolStripMenuItem registroDeCulturasToolStripMenuItem;
        private ToolStripMenuItem consultaDeCulturasToolStripMenuItem;
        private ToolStripMenuItem produtosToolStripMenuItem;
        private ToolStripMenuItem cadastrarProdutoToolStripMenuItem;
        private ToolStripMenuItem consultarProdutosToolStripMenuItem;
        private ToolStripMenuItem removerProdutoToolStripMenuItem;
        private Label label1;
        private Button button1;
        private Button button2;
        private GroupBox groupBox1;
        private ToolStripMenuItem removerRelatóriosToolStripMenuItem;
        private ToolStripMenuItem removerRelatóriosToolStripMenuItem1;
        private ToolStripMenuItem removerCulturasToolStripMenuItem;
        private ToolStripMenuItem produçãoToolStripMenuItem;
        private ToolStripMenuItem alimentosToolStripMenuItem;
    }
}