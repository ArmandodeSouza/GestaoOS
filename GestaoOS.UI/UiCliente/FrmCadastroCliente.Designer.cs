namespace GestaoOS.UI.UiCliente {
    partial class FrmCadastroCliente {
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
            this.TblBot = new System.Windows.Forms.TableLayoutPanel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.TblMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblTipoPessoa = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.cmbTipoPessoa = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.mskDocumento = new System.Windows.Forms.MaskedTextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.mskTelefone = new System.Windows.Forms.MaskedTextBox();
            this.ckbAtivo = new System.Windows.Forms.CheckBox();
            this.TblBot.SuspendLayout();
            this.TblMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TblBot
            // 
            this.TblBot.ColumnCount = 2;
            this.TblBot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TblBot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TblBot.Controls.Add(this.btnSalvar, 1, 1);
            this.TblBot.Controls.Add(this.btnCancelar, 0, 1);
            this.TblBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TblBot.Location = new System.Drawing.Point(0, 361);
            this.TblBot.Name = "TblBot";
            this.TblBot.RowCount = 2;
            this.TblBot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TblBot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TblBot.Size = new System.Drawing.Size(508, 89);
            this.TblBot.TabIndex = 0;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalvar.Location = new System.Drawing.Point(430, 55);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancelar.Location = new System.Drawing.Point(3, 55);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // TblMain
            // 
            this.TblMain.ColumnCount = 3;
            this.TblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.TblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 199F));
            this.TblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 235F));
            this.TblMain.Controls.Add(this.lblNome, 0, 0);
            this.TblMain.Controls.Add(this.lblTipoPessoa, 0, 1);
            this.TblMain.Controls.Add(this.lblEmail, 0, 2);
            this.TblMain.Controls.Add(this.lblTelefone, 0, 3);
            this.TblMain.Controls.Add(this.txtNome, 1, 0);
            this.TblMain.Controls.Add(this.cmbTipoPessoa, 1, 1);
            this.TblMain.Controls.Add(this.tableLayoutPanel1, 2, 1);
            this.TblMain.Controls.Add(this.txtEmail, 1, 2);
            this.TblMain.Controls.Add(this.mskTelefone, 1, 3);
            this.TblMain.Controls.Add(this.ckbAtivo, 0, 4);
            this.TblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TblMain.Location = new System.Drawing.Point(0, 0);
            this.TblMain.Name = "TblMain";
            this.TblMain.RowCount = 5;
            this.TblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TblMain.Size = new System.Drawing.Size(508, 361);
            this.TblMain.TabIndex = 1;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(3, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome";
            // 
            // lblTipoPessoa
            // 
            this.lblTipoPessoa.AutoSize = true;
            this.lblTipoPessoa.Location = new System.Drawing.Point(3, 50);
            this.lblTipoPessoa.Name = "lblTipoPessoa";
            this.lblTipoPessoa.Size = new System.Drawing.Size(66, 13);
            this.lblTipoPessoa.TabIndex = 1;
            this.lblTipoPessoa.Text = "Tipo Pessoa";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(3, 100);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email";
            // 
            // lblTelefone
            // 
            this.lblTelefone.AutoSize = true;
            this.lblTelefone.Location = new System.Drawing.Point(3, 150);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Size = new System.Drawing.Size(49, 13);
            this.lblTelefone.TabIndex = 3;
            this.lblTelefone.Text = "Telefone";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(77, 3);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(193, 20);
            this.txtNome.TabIndex = 5;
            // 
            // cmbTipoPessoa
            // 
            this.cmbTipoPessoa.FormattingEnabled = true;
            this.cmbTipoPessoa.Items.AddRange(new object[] {
            "Pessoa Física",
            "Pessoa Jurídica"});
            this.cmbTipoPessoa.Location = new System.Drawing.Point(77, 53);
            this.cmbTipoPessoa.Name = "cmbTipoPessoa";
            this.cmbTipoPessoa.Size = new System.Drawing.Size(112, 21);
            this.cmbTipoPessoa.TabIndex = 6;
            this.cmbTipoPessoa.SelectedIndexChanged += new System.EventHandler(this.cmbTipoPessoa_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.131F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.869F));
            this.tableLayoutPanel1.Controls.Add(this.lblDocumento, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mskDocumento, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(276, 53);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(229, 44);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(3, 0);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(62, 13);
            this.lblDocumento.TabIndex = 0;
            this.lblDocumento.Text = "Documento";
            // 
            // mskDocumento
            // 
            this.mskDocumento.Location = new System.Drawing.Point(71, 3);
            this.mskDocumento.Name = "mskDocumento";
            this.mskDocumento.Size = new System.Drawing.Size(148, 20);
            this.mskDocumento.TabIndex = 1;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(77, 103);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(193, 20);
            this.txtEmail.TabIndex = 8;
            // 
            // mskTelefone
            // 
            this.mskTelefone.Location = new System.Drawing.Point(77, 153);
            this.mskTelefone.Name = "mskTelefone";
            this.mskTelefone.Size = new System.Drawing.Size(112, 20);
            this.mskTelefone.TabIndex = 9;
            // 
            // ckbAtivo
            // 
            this.ckbAtivo.AutoSize = true;
            this.ckbAtivo.Location = new System.Drawing.Point(3, 203);
            this.ckbAtivo.Name = "ckbAtivo";
            this.ckbAtivo.Size = new System.Drawing.Size(50, 17);
            this.ckbAtivo.TabIndex = 10;
            this.ckbAtivo.Text = "Ativo";
            this.ckbAtivo.UseVisualStyleBackColor = true;
            // 
            // FrmCadastroCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 450);
            this.Controls.Add(this.TblMain);
            this.Controls.Add(this.TblBot);
            this.Name = "FrmCadastroCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Cliente";
            this.Load += new System.EventHandler(this.FrmCadastroCliente_Load);
            this.TblBot.ResumeLayout(false);
            this.TblMain.ResumeLayout(false);
            this.TblMain.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TblBot;
        private System.Windows.Forms.TableLayoutPanel TblMain;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblTipoPessoa;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.ComboBox cmbTipoPessoa;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.MaskedTextBox mskDocumento;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.MaskedTextBox mskTelefone;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox ckbAtivo;
    }
}