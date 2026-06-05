namespace GestaoOS.UI {
    partial class FrmMain {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.incluirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tblTop = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTipoPesquisa = new System.Windows.Forms.Panel();
            this.cmbStatusOs = new System.Windows.Forms.ComboBox();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.cmbTipoPesquisaOs = new System.Windows.Forms.ComboBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.pnlDatas = new System.Windows.Forms.Panel();
            this.dtpDataFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpDataInicial = new System.Windows.Forms.DateTimePicker();
            this.lblDataFinal = new System.Windows.Forms.Label();
            this.lblDataInicial = new System.Windows.Forms.Label();
            this.tblBot = new System.Windows.Forms.TableLayoutPanel();
            this.btnNovaOs = new System.Windows.Forms.Button();
            this.btnEditarOs = new System.Windows.Forms.Button();
            this.tblMid = new System.Windows.Forms.TableLayoutPanel();
            this.dgvOs = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.tblTop.SuspendLayout();
            this.pnlTipoPesquisa.SuspendLayout();
            this.pnlDatas.SuspendLayout();
            this.tblBot.SuspendLayout();
            this.tblMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOs)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem,
            this.servicoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pesquisarToolStripMenuItem,
            this.incluirToolStripMenuItem});
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.clienteToolStripMenuItem.Text = "Cliente";
            // 
            // pesquisarToolStripMenuItem
            // 
            this.pesquisarToolStripMenuItem.Name = "pesquisarToolStripMenuItem";
            this.pesquisarToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.pesquisarToolStripMenuItem.Text = "Pesquisar";
            this.pesquisarToolStripMenuItem.Click += new System.EventHandler(this.pesquisarToolStripMenuItem_Click);
            // 
            // incluirToolStripMenuItem
            // 
            this.incluirToolStripMenuItem.Name = "incluirToolStripMenuItem";
            this.incluirToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.incluirToolStripMenuItem.Text = "Incluir";
            this.incluirToolStripMenuItem.Click += new System.EventHandler(this.incluirToolStripMenuItem_Click);
            // 
            // servicoToolStripMenuItem
            // 
            this.servicoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pesquisarToolStripMenuItem1,
            this.incluirToolStripMenuItem1});
            this.servicoToolStripMenuItem.Name = "servicoToolStripMenuItem";
            this.servicoToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.servicoToolStripMenuItem.Text = "Servico";
            // 
            // pesquisarToolStripMenuItem1
            // 
            this.pesquisarToolStripMenuItem1.Name = "pesquisarToolStripMenuItem1";
            this.pesquisarToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.pesquisarToolStripMenuItem1.Text = "Pesquisar";
            this.pesquisarToolStripMenuItem1.Click += new System.EventHandler(this.pesquisarToolStripMenuItem1_Click);
            // 
            // incluirToolStripMenuItem1
            // 
            this.incluirToolStripMenuItem1.Name = "incluirToolStripMenuItem1";
            this.incluirToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.incluirToolStripMenuItem1.Text = "Incluir";
            this.incluirToolStripMenuItem1.Click += new System.EventHandler(this.incluirToolStripMenuItem1_Click);
            // 
            // tblTop
            // 
            this.tblTop.ColumnCount = 2;
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblTop.Controls.Add(this.pnlTipoPesquisa, 0, 0);
            this.tblTop.Controls.Add(this.btnPesquisar, 1, 1);
            this.tblTop.Controls.Add(this.pnlDatas, 1, 0);
            this.tblTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblTop.Location = new System.Drawing.Point(0, 24);
            this.tblTop.Name = "tblTop";
            this.tblTop.RowCount = 2;
            this.tblTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.81554F));
            this.tblTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.18447F));
            this.tblTop.Size = new System.Drawing.Size(800, 103);
            this.tblTop.TabIndex = 1;
            // 
            // pnlTipoPesquisa
            // 
            this.pnlTipoPesquisa.Controls.Add(this.cmbStatusOs);
            this.pnlTipoPesquisa.Controls.Add(this.txtPesquisa);
            this.pnlTipoPesquisa.Controls.Add(this.cmbTipoPesquisaOs);
            this.pnlTipoPesquisa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTipoPesquisa.Location = new System.Drawing.Point(3, 3);
            this.pnlTipoPesquisa.Name = "pnlTipoPesquisa";
            this.pnlTipoPesquisa.Size = new System.Drawing.Size(394, 69);
            this.pnlTipoPesquisa.TabIndex = 0;
            // 
            // cmbStatusOs
            // 
            this.cmbStatusOs.FormattingEnabled = true;
            this.cmbStatusOs.Location = new System.Drawing.Point(159, 25);
            this.cmbStatusOs.Name = "cmbStatusOs";
            this.cmbStatusOs.Size = new System.Drawing.Size(121, 21);
            this.cmbStatusOs.TabIndex = 2;
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPesquisa.Location = new System.Drawing.Point(159, 26);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(232, 20);
            this.txtPesquisa.TabIndex = 0;
            // 
            // cmbTipoPesquisaOs
            // 
            this.cmbTipoPesquisaOs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbTipoPesquisaOs.FormattingEnabled = true;
            this.cmbTipoPesquisaOs.Location = new System.Drawing.Point(9, 25);
            this.cmbTipoPesquisaOs.Name = "cmbTipoPesquisaOs";
            this.cmbTipoPesquisaOs.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoPesquisaOs.TabIndex = 0;
            this.cmbTipoPesquisaOs.SelectedIndexChanged += new System.EventHandler(this.cmbTipoPesquisaOs_SelectedIndexChanged);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPesquisar.Location = new System.Drawing.Point(722, 78);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 22);
            this.btnPesquisar.TabIndex = 1;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // pnlDatas
            // 
            this.pnlDatas.Controls.Add(this.dtpDataFinal);
            this.pnlDatas.Controls.Add(this.dtpDataInicial);
            this.pnlDatas.Controls.Add(this.lblDataFinal);
            this.pnlDatas.Controls.Add(this.lblDataInicial);
            this.pnlDatas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDatas.Location = new System.Drawing.Point(403, 3);
            this.pnlDatas.Name = "pnlDatas";
            this.pnlDatas.Size = new System.Drawing.Size(394, 69);
            this.pnlDatas.TabIndex = 2;
            // 
            // dtpDataFinal
            // 
            this.dtpDataFinal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dtpDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFinal.Location = new System.Drawing.Point(302, 26);
            this.dtpDataFinal.Name = "dtpDataFinal";
            this.dtpDataFinal.Size = new System.Drawing.Size(83, 20);
            this.dtpDataFinal.TabIndex = 3;
            this.dtpDataFinal.ValueChanged += new System.EventHandler(this.dtpDataInicial_ValueChanged);
            // 
            // dtpDataInicial
            // 
            this.dtpDataInicial.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dtpDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataInicial.Location = new System.Drawing.Point(160, 26);
            this.dtpDataInicial.Name = "dtpDataInicial";
            this.dtpDataInicial.Size = new System.Drawing.Size(83, 20);
            this.dtpDataInicial.TabIndex = 2;
            // 
            // lblDataFinal
            // 
            this.lblDataFinal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDataFinal.AutoSize = true;
            this.lblDataFinal.Location = new System.Drawing.Point(316, 10);
            this.lblDataFinal.Name = "lblDataFinal";
            this.lblDataFinal.Size = new System.Drawing.Size(52, 13);
            this.lblDataFinal.TabIndex = 1;
            this.lblDataFinal.Text = "Data final";
            // 
            // lblDataInicial
            // 
            this.lblDataInicial.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDataInicial.AutoSize = true;
            this.lblDataInicial.Location = new System.Drawing.Point(170, 10);
            this.lblDataInicial.Name = "lblDataInicial";
            this.lblDataInicial.Size = new System.Drawing.Size(59, 13);
            this.lblDataInicial.TabIndex = 0;
            this.lblDataInicial.Text = "Data inicial";
            // 
            // tblBot
            // 
            this.tblBot.ColumnCount = 2;
            this.tblBot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblBot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblBot.Controls.Add(this.btnNovaOs, 1, 1);
            this.tblBot.Controls.Add(this.btnEditarOs, 1, 0);
            this.tblBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tblBot.Location = new System.Drawing.Point(0, 350);
            this.tblBot.Name = "tblBot";
            this.tblBot.RowCount = 2;
            this.tblBot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblBot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblBot.Size = new System.Drawing.Size(800, 100);
            this.tblBot.TabIndex = 2;
            // 
            // btnNovaOs
            // 
            this.btnNovaOs.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNovaOs.Location = new System.Drawing.Point(722, 63);
            this.btnNovaOs.Name = "btnNovaOs";
            this.btnNovaOs.Size = new System.Drawing.Size(75, 23);
            this.btnNovaOs.TabIndex = 0;
            this.btnNovaOs.Text = "Nova OS";
            this.btnNovaOs.UseVisualStyleBackColor = true;
            this.btnNovaOs.Click += new System.EventHandler(this.btnNovaOs_Click);
            // 
            // btnEditarOs
            // 
            this.btnEditarOs.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnEditarOs.Location = new System.Drawing.Point(722, 13);
            this.btnEditarOs.Name = "btnEditarOs";
            this.btnEditarOs.Size = new System.Drawing.Size(75, 23);
            this.btnEditarOs.TabIndex = 1;
            this.btnEditarOs.Text = "Editar OS";
            this.btnEditarOs.UseVisualStyleBackColor = true;
            this.btnEditarOs.Click += new System.EventHandler(this.btnEditarOs_Click);
            // 
            // tblMid
            // 
            this.tblMid.ColumnCount = 1;
            this.tblMid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMid.Controls.Add(this.dgvOs, 0, 0);
            this.tblMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMid.Location = new System.Drawing.Point(0, 127);
            this.tblMid.Name = "tblMid";
            this.tblMid.RowCount = 1;
            this.tblMid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMid.Size = new System.Drawing.Size(800, 223);
            this.tblMid.TabIndex = 3;
            // 
            // dgvOs
            // 
            this.dgvOs.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvOs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOs.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvOs.Location = new System.Drawing.Point(3, 3);
            this.dgvOs.Name = "dgvOs";
            this.dgvOs.Size = new System.Drawing.Size(794, 217);
            this.dgvOs.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tblMid);
            this.Controls.Add(this.tblBot);
            this.Controls.Add(this.tblTop);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle Central";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tblTop.ResumeLayout(false);
            this.pnlTipoPesquisa.ResumeLayout(false);
            this.pnlTipoPesquisa.PerformLayout();
            this.pnlDatas.ResumeLayout(false);
            this.pnlDatas.PerformLayout();
            this.tblBot.ResumeLayout(false);
            this.tblMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pesquisarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incluirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem servicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pesquisarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem incluirToolStripMenuItem1;
        private System.Windows.Forms.TableLayoutPanel tblTop;
        private System.Windows.Forms.TableLayoutPanel tblBot;
        private System.Windows.Forms.TableLayoutPanel tblMid;
        private System.Windows.Forms.DataGridView dgvOs;
        private System.Windows.Forms.Panel pnlTipoPesquisa;
        private System.Windows.Forms.ComboBox cmbTipoPesquisaOs;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnNovaOs;
        private System.Windows.Forms.Button btnEditarOs;
        private System.Windows.Forms.ComboBox cmbStatusOs;
        private System.Windows.Forms.Panel pnlDatas;
        private System.Windows.Forms.Label lblDataInicial;
        private System.Windows.Forms.DateTimePicker dtpDataFinal;
        private System.Windows.Forms.DateTimePicker dtpDataInicial;
        private System.Windows.Forms.Label lblDataFinal;
    }
}

