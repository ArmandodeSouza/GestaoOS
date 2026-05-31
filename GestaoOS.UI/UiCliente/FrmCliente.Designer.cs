namespace GestaoOS.UI.UiCliente {
    partial class FrmCliente {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.TblTop = new System.Windows.Forms.TableLayoutPanel();
            this.TblMid = new System.Windows.Forms.TableLayoutPanel();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.TblBot = new System.Windows.Forms.TableLayoutPanel();
            this.btnNovo = new System.Windows.Forms.Button();
            this.pnlNome = new System.Windows.Forms.Panel();
            this.txtNomePesquisa = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.cmbTipoPessoa = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mskDocumentoPesquisa = new System.Windows.Forms.MaskedTextBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbStatusCliente = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.TblTop.SuspendLayout();
            this.TblMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.TblBot.SuspendLayout();
            this.pnlNome.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TblTop
            // 
            this.TblTop.ColumnCount = 2;
            this.TblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TblTop.Controls.Add(this.pnlNome, 0, 0);
            this.TblTop.Controls.Add(this.panel1, 0, 1);
            this.TblTop.Controls.Add(this.panel2, 1, 1);
            this.TblTop.Controls.Add(this.panel3, 1, 0);
            this.TblTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.TblTop.Location = new System.Drawing.Point(0, 0);
            this.TblTop.Name = "TblTop";
            this.TblTop.RowCount = 2;
            this.TblTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TblTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TblTop.Size = new System.Drawing.Size(800, 100);
            this.TblTop.TabIndex = 0;
            // 
            // TblMid
            // 
            this.TblMid.ColumnCount = 1;
            this.TblMid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TblMid.Controls.Add(this.dgvClientes, 0, 0);
            this.TblMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TblMid.Location = new System.Drawing.Point(0, 100);
            this.TblMid.Name = "TblMid";
            this.TblMid.RowCount = 1;
            this.TblMid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TblMid.Size = new System.Drawing.Size(800, 350);
            this.TblMid.TabIndex = 1;
            // 
            // dgvClientes
            // 
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClientes.Location = new System.Drawing.Point(3, 3);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.Size = new System.Drawing.Size(794, 344);
            this.dgvClientes.TabIndex = 0;
            // 
            // TblBot
            // 
            this.TblBot.ColumnCount = 2;
            this.TblBot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TblBot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TblBot.Controls.Add(this.btnNovo, 1, 1);
            this.TblBot.Controls.Add(this.btnEditar, 1, 0);
            this.TblBot.Controls.Add(this.btnExcluir, 0, 1);
            this.TblBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TblBot.Location = new System.Drawing.Point(0, 350);
            this.TblBot.Name = "TblBot";
            this.TblBot.RowCount = 2;
            this.TblBot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TblBot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TblBot.Size = new System.Drawing.Size(800, 100);
            this.TblBot.TabIndex = 2;
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNovo.Location = new System.Drawing.Point(722, 63);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // pnlNome
            // 
            this.pnlNome.Controls.Add(this.lblNome);
            this.pnlNome.Controls.Add(this.txtNomePesquisa);
            this.pnlNome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNome.Location = new System.Drawing.Point(3, 3);
            this.pnlNome.Name = "pnlNome";
            this.pnlNome.Size = new System.Drawing.Size(394, 44);
            this.pnlNome.TabIndex = 0;
            // 
            // txtNomePesquisa
            // 
            this.txtNomePesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomePesquisa.Location = new System.Drawing.Point(50, 9);
            this.txtNomePesquisa.Name = "txtNomePesquisa";
            this.txtNomePesquisa.Size = new System.Drawing.Size(341, 20);
            this.txtNomePesquisa.TabIndex = 0;
            // 
            // lblNome
            // 
            this.lblNome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(9, 12);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "Nome";
            // 
            // cmbTipoPessoa
            // 
            this.cmbTipoPessoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbTipoPessoa.FormattingEnabled = true;
            this.cmbTipoPessoa.Items.AddRange(new object[] {
            "Pessoa Física",
            "Pessoa Jurídica"});
            this.cmbTipoPessoa.Location = new System.Drawing.Point(86, 8);
            this.cmbTipoPessoa.Name = "cmbTipoPessoa";
            this.cmbTipoPessoa.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoPessoa.TabIndex = 1;
            this.cmbTipoPessoa.SelectedIndexChanged += new System.EventHandler(this.cmbTipoPessoa_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDocumento);
            this.panel1.Controls.Add(this.mskDocumentoPesquisa);
            this.panel1.Controls.Add(this.cmbTipoPessoa);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 44);
            this.panel1.TabIndex = 2;
            // 
            // mskDocumentoPesquisa
            // 
            this.mskDocumentoPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.mskDocumentoPesquisa.Location = new System.Drawing.Point(226, 8);
            this.mskDocumentoPesquisa.Name = "mskDocumentoPesquisa";
            this.mskDocumentoPesquisa.Size = new System.Drawing.Size(165, 20);
            this.mskDocumentoPesquisa.TabIndex = 2;
            // 
            // lblDocumento
            // 
            this.lblDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(9, 11);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(62, 13);
            this.lblDocumento.TabIndex = 3;
            this.lblDocumento.Text = "Documento";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPesquisar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(403, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(394, 44);
            this.panel2.TabIndex = 4;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPesquisar.Location = new System.Drawing.Point(310, 8);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 4;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblStatus);
            this.panel3.Controls.Add(this.cmbStatusCliente);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(403, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(394, 44);
            this.panel3.TabIndex = 5;
            // 
            // cmbStatusCliente
            // 
            this.cmbStatusCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatusCliente.FormattingEnabled = true;
            this.cmbStatusCliente.Items.AddRange(new object[] {
            "Todos",
            "Ativo",
            "Inativo"});
            this.cmbStatusCliente.Location = new System.Drawing.Point(270, 8);
            this.cmbStatusCliente.Name = "cmbStatusCliente";
            this.cmbStatusCliente.Size = new System.Drawing.Size(121, 21);
            this.cmbStatusCliente.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(227, 12);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Status";
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnEditar.Location = new System.Drawing.Point(722, 13);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnExcluir.Location = new System.Drawing.Point(3, 63);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // FrmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TblBot);
            this.Controls.Add(this.TblMid);
            this.Controls.Add(this.TblTop);
            this.Name = "FrmCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.FrmCliente_Load);
            this.TblTop.ResumeLayout(false);
            this.TblMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.TblBot.ResumeLayout(false);
            this.pnlNome.ResumeLayout(false);
            this.pnlNome.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TblTop;
        private System.Windows.Forms.TableLayoutPanel TblMid;
        private System.Windows.Forms.TableLayoutPanel TblBot;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Panel pnlNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNomePesquisa;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.MaskedTextBox mskDocumentoPesquisa;
        private System.Windows.Forms.ComboBox cmbTipoPessoa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatusCliente;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnExcluir;
    }
}