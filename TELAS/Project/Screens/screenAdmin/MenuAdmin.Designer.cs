namespace TELAS
{
    partial class MenuAdmin
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
            orçamentoToolStripMenuItem = new ToolStripMenuItem();
            registrarReceitasToolStripMenuItem = new ToolStripMenuItem();
            adcionarReceitasToolStripMenuItem = new ToolStripMenuItem();
            listarResceitasToolStripMenuItem = new ToolStripMenuItem();
            removerReceitasToolStripMenuItem = new ToolStripMenuItem();
            registrarDespesasToolStripMenuItem = new ToolStripMenuItem();
            adcionarDespesasToolStripMenuItem = new ToolStripMenuItem();
            listarDespesasToolStripMenuItem = new ToolStripMenuItem();
            removerDespesasToolStripMenuItem = new ToolStripMenuItem();
            resumoFinanceiroToolStripMenuItem = new ToolStripMenuItem();
            saldoTotalToolStripMenuItem = new ToolStripMenuItem();
            funcionáriosToolStripMenuItem = new ToolStripMenuItem();
            cadastraToolStripMenuItem = new ToolStripMenuItem();
            consultarInformaçõesToolStripMenuItem = new ToolStripMenuItem();
            removerFuncionárioToolStripMenuItem = new ToolStripMenuItem();
            coToolStripMenuItem = new ToolStripMenuItem();
            fornecedoresToolStripMenuItem = new ToolStripMenuItem();
            cadastrarFornecedorToolStripMenuItem = new ToolStripMenuItem();
            consultarFornecedorToolStripMenuItem = new ToolStripMenuItem();
            removerFornecedorToolStripMenuItem = new ToolStripMenuItem();
            informaçõesParaPagamentoToolStripMenuItem = new ToolStripMenuItem();
            gerenciamentoDeTarefasToolStripMenuItem = new ToolStripMenuItem();
            registrarTarefasToolStripMenuItem = new ToolStripMenuItem();
            statusDeTarefasToolStripMenuItem = new ToolStripMenuItem();
            consultarStatusDasTarefasToolStripMenuItem = new ToolStripMenuItem();
            suporteEAjudaToolStripMenuItem = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.LightGray;
            menuStrip1.Dock = DockStyle.Left;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { orçamentoToolStripMenuItem, funcionáriosToolStripMenuItem, fornecedoresToolStripMenuItem, gerenciamentoDeTarefasToolStripMenuItem, suporteEAjudaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(9, 3, 0, 3);
            menuStrip1.Size = new Size(321, 883);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // orçamentoToolStripMenuItem
            // 
            orçamentoToolStripMenuItem.BackColor = Color.DarkGreen;
            orçamentoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registrarReceitasToolStripMenuItem, registrarDespesasToolStripMenuItem, resumoFinanceiroToolStripMenuItem });
            orçamentoToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            orçamentoToolStripMenuItem.ForeColor = Color.LightGray;
            orçamentoToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            orçamentoToolStripMenuItem.Name = "orçamentoToolStripMenuItem";
            orçamentoToolStripMenuItem.Size = new Size(302, 32);
            orçamentoToolStripMenuItem.Text = "Planejamento Financeiro      >";
            orçamentoToolStripMenuItem.Click += orçamentoToolStripMenuItem_Click;
            // 
            // registrarReceitasToolStripMenuItem
            // 
            registrarReceitasToolStripMenuItem.BackColor = Color.LightGray;
            registrarReceitasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { adcionarReceitasToolStripMenuItem, listarResceitasToolStripMenuItem, removerReceitasToolStripMenuItem });
            registrarReceitasToolStripMenuItem.ForeColor = Color.DarkGreen;
            registrarReceitasToolStripMenuItem.Name = "registrarReceitasToolStripMenuItem";
            registrarReceitasToolStripMenuItem.Size = new Size(275, 32);
            registrarReceitasToolStripMenuItem.Text = "Receitas";
            // 
            // adcionarReceitasToolStripMenuItem
            // 
            adcionarReceitasToolStripMenuItem.BackColor = Color.LightGray;
            adcionarReceitasToolStripMenuItem.ForeColor = Color.DarkGreen;
            adcionarReceitasToolStripMenuItem.Name = "adcionarReceitasToolStripMenuItem";
            adcionarReceitasToolStripMenuItem.Size = new Size(272, 32);
            adcionarReceitasToolStripMenuItem.Text = "Adicionar Receitas";
            adcionarReceitasToolStripMenuItem.Click += adcionarReceitasToolStripMenuItem_Click;
            // 
            // listarResceitasToolStripMenuItem
            // 
            listarResceitasToolStripMenuItem.BackColor = Color.LightGray;
            listarResceitasToolStripMenuItem.ForeColor = Color.DarkGreen;
            listarResceitasToolStripMenuItem.Name = "listarResceitasToolStripMenuItem";
            listarResceitasToolStripMenuItem.Size = new Size(272, 32);
            listarResceitasToolStripMenuItem.Text = "Listar Receitas";
            listarResceitasToolStripMenuItem.Click += listarResceitasToolStripMenuItem_Click;
            // 
            // removerReceitasToolStripMenuItem
            // 
            removerReceitasToolStripMenuItem.BackColor = Color.LightGray;
            removerReceitasToolStripMenuItem.ForeColor = Color.DarkGreen;
            removerReceitasToolStripMenuItem.Name = "removerReceitasToolStripMenuItem";
            removerReceitasToolStripMenuItem.Size = new Size(272, 32);
            removerReceitasToolStripMenuItem.Text = "Remover Receitas";
            removerReceitasToolStripMenuItem.Click += removerReceitasToolStripMenuItem_Click;
            // 
            // registrarDespesasToolStripMenuItem
            // 
            registrarDespesasToolStripMenuItem.BackColor = Color.LightGray;
            registrarDespesasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { adcionarDespesasToolStripMenuItem, listarDespesasToolStripMenuItem, removerDespesasToolStripMenuItem });
            registrarDespesasToolStripMenuItem.ForeColor = Color.DarkGreen;
            registrarDespesasToolStripMenuItem.Name = "registrarDespesasToolStripMenuItem";
            registrarDespesasToolStripMenuItem.Size = new Size(275, 32);
            registrarDespesasToolStripMenuItem.Text = "Despesas ";
            // 
            // adcionarDespesasToolStripMenuItem
            // 
            adcionarDespesasToolStripMenuItem.BackColor = Color.LightGray;
            adcionarDespesasToolStripMenuItem.ForeColor = Color.DarkGreen;
            adcionarDespesasToolStripMenuItem.Name = "adcionarDespesasToolStripMenuItem";
            adcionarDespesasToolStripMenuItem.Size = new Size(281, 32);
            adcionarDespesasToolStripMenuItem.Text = "Adicionar Despesas";
            adcionarDespesasToolStripMenuItem.Click += adcionarDespesasToolStripMenuItem_Click;
            // 
            // listarDespesasToolStripMenuItem
            // 
            listarDespesasToolStripMenuItem.BackColor = Color.LightGray;
            listarDespesasToolStripMenuItem.ForeColor = Color.DarkGreen;
            listarDespesasToolStripMenuItem.Name = "listarDespesasToolStripMenuItem";
            listarDespesasToolStripMenuItem.Size = new Size(281, 32);
            listarDespesasToolStripMenuItem.Text = "Listar Despesas";
            listarDespesasToolStripMenuItem.Click += listarDespesasToolStripMenuItem_Click;
            // 
            // removerDespesasToolStripMenuItem
            // 
            removerDespesasToolStripMenuItem.BackColor = Color.LightGray;
            removerDespesasToolStripMenuItem.ForeColor = Color.DarkGreen;
            removerDespesasToolStripMenuItem.Name = "removerDespesasToolStripMenuItem";
            removerDespesasToolStripMenuItem.Size = new Size(281, 32);
            removerDespesasToolStripMenuItem.Text = "Remover Despesas";
            removerDespesasToolStripMenuItem.Click += removerDespesasToolStripMenuItem_Click;
            // 
            // resumoFinanceiroToolStripMenuItem
            // 
            resumoFinanceiroToolStripMenuItem.BackColor = Color.LightGray;
            resumoFinanceiroToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saldoTotalToolStripMenuItem });
            resumoFinanceiroToolStripMenuItem.ForeColor = Color.DarkGreen;
            resumoFinanceiroToolStripMenuItem.Name = "resumoFinanceiroToolStripMenuItem";
            resumoFinanceiroToolStripMenuItem.Size = new Size(275, 32);
            resumoFinanceiroToolStripMenuItem.Text = "Resumo Financeiro";
            // 
            // saldoTotalToolStripMenuItem
            // 
            saldoTotalToolStripMenuItem.BackColor = Color.LightGray;
            saldoTotalToolStripMenuItem.ForeColor = Color.DarkGreen;
            saldoTotalToolStripMenuItem.Name = "saldoTotalToolStripMenuItem";
            saldoTotalToolStripMenuItem.Size = new Size(213, 32);
            saldoTotalToolStripMenuItem.Text = "Saldo Total ";
            saldoTotalToolStripMenuItem.Click += saldoTotalToolStripMenuItem_Click;
            // 
            // funcionáriosToolStripMenuItem
            // 
            funcionáriosToolStripMenuItem.BackColor = Color.DarkGreen;
            funcionáriosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cadastraToolStripMenuItem, consultarInformaçõesToolStripMenuItem, removerFuncionárioToolStripMenuItem, coToolStripMenuItem });
            funcionáriosToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            funcionáriosToolStripMenuItem.ForeColor = Color.LightGray;
            funcionáriosToolStripMenuItem.Name = "funcionáriosToolStripMenuItem";
            funcionáriosToolStripMenuItem.Size = new Size(302, 32);
            funcionáriosToolStripMenuItem.Text = "Funcionários                         >";
            funcionáriosToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cadastraToolStripMenuItem
            // 
            cadastraToolStripMenuItem.BackColor = Color.LightGray;
            cadastraToolStripMenuItem.ForeColor = Color.DarkGreen;
            cadastraToolStripMenuItem.Name = "cadastraToolStripMenuItem";
            cadastraToolStripMenuItem.Size = new Size(478, 32);
            cadastraToolStripMenuItem.Text = "Cadastrar Funcionário";
            cadastraToolStripMenuItem.Click += cadastraToolStripMenuItem_Click;
            // 
            // consultarInformaçõesToolStripMenuItem
            // 
            consultarInformaçõesToolStripMenuItem.BackColor = Color.LightGray;
            consultarInformaçõesToolStripMenuItem.ForeColor = Color.DarkGreen;
            consultarInformaçõesToolStripMenuItem.Name = "consultarInformaçõesToolStripMenuItem";
            consultarInformaçõesToolStripMenuItem.Size = new Size(478, 32);
            consultarInformaçõesToolStripMenuItem.Text = "Listar Funcionários";
            consultarInformaçõesToolStripMenuItem.Click += consultarInformaçõesToolStripMenuItem_Click;
            // 
            // removerFuncionárioToolStripMenuItem
            // 
            removerFuncionárioToolStripMenuItem.BackColor = Color.LightGray;
            removerFuncionárioToolStripMenuItem.ForeColor = Color.DarkGreen;
            removerFuncionárioToolStripMenuItem.Name = "removerFuncionárioToolStripMenuItem";
            removerFuncionárioToolStripMenuItem.Size = new Size(478, 32);
            removerFuncionárioToolStripMenuItem.Text = "Remover Funcionário";
            removerFuncionárioToolStripMenuItem.Click += removerFuncionárioToolStripMenuItem_Click;
            // 
            // coToolStripMenuItem
            // 
            coToolStripMenuItem.BackColor = Color.LightGray;
            coToolStripMenuItem.ForeColor = Color.DarkGreen;
            coToolStripMenuItem.Name = "coToolStripMenuItem";
            coToolStripMenuItem.Size = new Size(478, 32);
            coToolStripMenuItem.Text = "Consultar Informações Para Pagamento";
            coToolStripMenuItem.Click += coToolStripMenuItem_Click;
            // 
            // fornecedoresToolStripMenuItem
            // 
            fornecedoresToolStripMenuItem.BackColor = Color.DarkGreen;
            fornecedoresToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cadastrarFornecedorToolStripMenuItem, consultarFornecedorToolStripMenuItem, removerFornecedorToolStripMenuItem, informaçõesParaPagamentoToolStripMenuItem });
            fornecedoresToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            fornecedoresToolStripMenuItem.ForeColor = Color.LightGray;
            fornecedoresToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            fornecedoresToolStripMenuItem.Name = "fornecedoresToolStripMenuItem";
            fornecedoresToolStripMenuItem.Size = new Size(302, 32);
            fornecedoresToolStripMenuItem.Text = "Fornecedores                         >";
            fornecedoresToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cadastrarFornecedorToolStripMenuItem
            // 
            cadastrarFornecedorToolStripMenuItem.BackColor = Color.LightGray;
            cadastrarFornecedorToolStripMenuItem.ForeColor = Color.DarkGreen;
            cadastrarFornecedorToolStripMenuItem.Name = "cadastrarFornecedorToolStripMenuItem";
            cadastrarFornecedorToolStripMenuItem.Size = new Size(378, 32);
            cadastrarFornecedorToolStripMenuItem.Text = "Cadastrar Fornecedor";
            cadastrarFornecedorToolStripMenuItem.Click += cadastrarFornecedorToolStripMenuItem_Click;
            // 
            // consultarFornecedorToolStripMenuItem
            // 
            consultarFornecedorToolStripMenuItem.BackColor = Color.LightGray;
            consultarFornecedorToolStripMenuItem.ForeColor = Color.DarkGreen;
            consultarFornecedorToolStripMenuItem.Name = "consultarFornecedorToolStripMenuItem";
            consultarFornecedorToolStripMenuItem.Size = new Size(378, 32);
            consultarFornecedorToolStripMenuItem.Text = "Consultar Fornecedor";
            consultarFornecedorToolStripMenuItem.Click += consultarFornecedorToolStripMenuItem_Click;
            // 
            // removerFornecedorToolStripMenuItem
            // 
            removerFornecedorToolStripMenuItem.BackColor = Color.LightGray;
            removerFornecedorToolStripMenuItem.ForeColor = Color.DarkGreen;
            removerFornecedorToolStripMenuItem.Name = "removerFornecedorToolStripMenuItem";
            removerFornecedorToolStripMenuItem.Size = new Size(378, 32);
            removerFornecedorToolStripMenuItem.Text = "Remover Fornecedor ";
            removerFornecedorToolStripMenuItem.Click += removerFornecedorToolStripMenuItem_Click;
            // 
            // informaçõesParaPagamentoToolStripMenuItem
            // 
            informaçõesParaPagamentoToolStripMenuItem.BackColor = Color.LightGray;
            informaçõesParaPagamentoToolStripMenuItem.ForeColor = Color.DarkGreen;
            informaçõesParaPagamentoToolStripMenuItem.Name = "informaçõesParaPagamentoToolStripMenuItem";
            informaçõesParaPagamentoToolStripMenuItem.Size = new Size(378, 32);
            informaçõesParaPagamentoToolStripMenuItem.Text = "Informações para pagamento";
            informaçõesParaPagamentoToolStripMenuItem.Click += informaçõesParaPagamentoToolStripMenuItem_Click;
            // 
            // gerenciamentoDeTarefasToolStripMenuItem
            // 
            gerenciamentoDeTarefasToolStripMenuItem.BackColor = Color.DarkGreen;
            gerenciamentoDeTarefasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registrarTarefasToolStripMenuItem, statusDeTarefasToolStripMenuItem, consultarStatusDasTarefasToolStripMenuItem });
            gerenciamentoDeTarefasToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            gerenciamentoDeTarefasToolStripMenuItem.ForeColor = Color.LightGray;
            gerenciamentoDeTarefasToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            gerenciamentoDeTarefasToolStripMenuItem.Name = "gerenciamentoDeTarefasToolStripMenuItem";
            gerenciamentoDeTarefasToolStripMenuItem.Size = new Size(302, 32);
            gerenciamentoDeTarefasToolStripMenuItem.Text = "Gerenciamento de Tarefas    >";
            gerenciamentoDeTarefasToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // registrarTarefasToolStripMenuItem
            // 
            registrarTarefasToolStripMenuItem.BackColor = Color.LightGray;
            registrarTarefasToolStripMenuItem.ForeColor = Color.DarkGreen;
            registrarTarefasToolStripMenuItem.Name = "registrarTarefasToolStripMenuItem";
            registrarTarefasToolStripMenuItem.Size = new Size(393, 32);
            registrarTarefasToolStripMenuItem.Text = "Atribuir Tarefas a Funcionários";
            registrarTarefasToolStripMenuItem.Click += registrarTarefasToolStripMenuItem_Click;
            // 
            // statusDeTarefasToolStripMenuItem
            // 
            statusDeTarefasToolStripMenuItem.BackColor = Color.LightGray;
            statusDeTarefasToolStripMenuItem.ForeColor = Color.DarkGreen;
            statusDeTarefasToolStripMenuItem.Name = "statusDeTarefasToolStripMenuItem";
            statusDeTarefasToolStripMenuItem.Size = new Size(393, 32);
            statusDeTarefasToolStripMenuItem.Text = "Atualizar Status da Tarefa";
            statusDeTarefasToolStripMenuItem.Click += statusDeTarefasToolStripMenuItem_Click;
            // 
            // consultarStatusDasTarefasToolStripMenuItem
            // 
            consultarStatusDasTarefasToolStripMenuItem.BackColor = Color.LightGray;
            consultarStatusDasTarefasToolStripMenuItem.ForeColor = Color.DarkGreen;
            consultarStatusDasTarefasToolStripMenuItem.Name = "consultarStatusDasTarefasToolStripMenuItem";
            consultarStatusDasTarefasToolStripMenuItem.Size = new Size(393, 32);
            consultarStatusDasTarefasToolStripMenuItem.Text = "Consultar Status daTarefa";
            consultarStatusDasTarefasToolStripMenuItem.Click += consultarStatusDasTarefasToolStripMenuItem_Click;
            // 
            // suporteEAjudaToolStripMenuItem
            // 
            suporteEAjudaToolStripMenuItem.BackColor = Color.DarkGreen;
            suporteEAjudaToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            suporteEAjudaToolStripMenuItem.ForeColor = Color.LightGray;
            suporteEAjudaToolStripMenuItem.Name = "suporteEAjudaToolStripMenuItem";
            suporteEAjudaToolStripMenuItem.Size = new Size(302, 32);
            suporteEAjudaToolStripMenuItem.Text = "Suporte e Ajuda                    >";
            suporteEAjudaToolStripMenuItem.Click += suporteEAjudaToolStripMenuItem_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.BackColor = Color.LightGray;
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(353, 262);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(676, 157);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.DarkGreen;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LightGray;
            label1.Location = new Point(4, 30);
            label1.Name = "label1";
            label1.Size = new Size(666, 82);
            label1.TabIndex = 3;
            label1.Text = "Green Tech \r\n🌳 Tecnologia a Serviço do Meio Ambiente🌳";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.AutoSize = true;
            button1.BackColor = Color.LightGray;
            button1.ForeColor = Color.DarkGreen;
            button1.Location = new Point(1407, 12);
            button1.Name = "button1";
            button1.Size = new Size(102, 38);
            button1.TabIndex = 2;
            button1.Text = "Sair ➡️";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.BackColor = Color.LightGray;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.DarkGreen;
            button2.Location = new Point(1316, 831);
            button2.Name = "button2";
            button2.Size = new Size(193, 40);
            button2.TabIndex = 5;
            button2.Text = "Precisa de Ajuda?";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // MenuAdmin
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGreen;
            ClientSize = new Size(1521, 883);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            ForeColor = Color.LightGray;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "MenuAdmin";
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
        private ToolStripMenuItem orçamentoToolStripMenuItem;
        private ToolStripMenuItem funcionáriosToolStripMenuItem;
        private ToolStripMenuItem fornecedoresToolStripMenuItem;
        private ToolStripMenuItem registrarReceitasToolStripMenuItem;
        private ToolStripMenuItem adcionarReceitasToolStripMenuItem;
        private ToolStripMenuItem listarResceitasToolStripMenuItem;
        private ToolStripMenuItem removerReceitasToolStripMenuItem;
        private ToolStripMenuItem registrarDespesasToolStripMenuItem;
        private ToolStripMenuItem adcionarDespesasToolStripMenuItem;
        private ToolStripMenuItem listarDespesasToolStripMenuItem;
        private ToolStripMenuItem removerDespesasToolStripMenuItem;
        private ToolStripMenuItem resumoFinanceiroToolStripMenuItem;
        private ToolStripMenuItem saldoTotalToolStripMenuItem;
        private ToolStripMenuItem cadastraToolStripMenuItem;
        private ToolStripMenuItem consultarInformaçõesToolStripMenuItem;
        private ToolStripMenuItem removerFuncionárioToolStripMenuItem;
        private ToolStripMenuItem coToolStripMenuItem;
        private ToolStripMenuItem cadastrarFornecedorToolStripMenuItem;
        private ToolStripMenuItem consultarFornecedorToolStripMenuItem;
        private ToolStripMenuItem removerFornecedorToolStripMenuItem;
        private ToolStripMenuItem informaçõesParaPagamentoToolStripMenuItem;
        private ToolStripMenuItem gerenciamentoDeTarefasToolStripMenuItem;
        private ToolStripMenuItem registrarTarefasToolStripMenuItem;
        private ToolStripMenuItem statusDeTarefasToolStripMenuItem;
        private ToolStripMenuItem suporteEAjudaToolStripMenuItem;
        private GroupBox groupBox1;
        private Label label1;
        private Button button1;
        private Button button2;
        private ToolStripMenuItem consultarStatusDasTarefasToolStripMenuItem;
    }
}