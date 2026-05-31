namespace GestaoOS.UI.UiServico {
    partial class FrmCadastroServico {
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
            this.tblTop = new System.Windows.Forms.TableLayoutPanel();
            this.tblBot = new System.Windows.Forms.TableLayoutPanel();
            this.tblMid = new System.Windows.Forms.TableLayoutPanel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlNome = new System.Windows.Forms.Panel();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.pnlValor = new System.Windows.Forms.Panel();
            this.lblValor = new System.Windows.Forms.Label();
            this.pnlPorcentagem = new System.Windows.Forms.Panel();
            this.lblImposto = new System.Windows.Forms.Label();
            this.numImposto = new System.Windows.Forms.NumericUpDown();
            this.lblPorcentagem = new System.Windows.Forms.Label();
            this.pnlAtivo = new System.Windows.Forms.Panel();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.txtValorBase = new System.Windows.Forms.TextBox();
            this.tblTop.SuspendLayout();
            this.tblBot.SuspendLayout();
            this.tblMid.SuspendLayout();
            this.pnlNome.SuspendLayout();
            this.pnlValor.SuspendLayout();
            this.pnlPorcentagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImposto)).BeginInit();
            this.pnlAtivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblTop
            // 
            this.tblTop.ColumnCount = 2;
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 320F));
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tblTop.Controls.Add(this.pnlNome, 0, 1);
            this.tblTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblTop.Location = new System.Drawing.Point(0, 0);
            this.tblTop.Name = "tblTop";
            this.tblTop.RowCount = 2;
            this.tblTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tblTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tblTop.Size = new System.Drawing.Size(508, 100);
            this.tblTop.TabIndex = 0;
            // 
            // tblBot
            // 
            this.tblBot.ColumnCount = 2;
            this.tblBot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblBot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblBot.Controls.Add(this.btnSalvar, 1, 1);
            this.tblBot.Controls.Add(this.btnCancelar, 0, 1);
            this.tblBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tblBot.Location = new System.Drawing.Point(0, 350);
            this.tblBot.Name = "tblBot";
            this.tblBot.RowCount = 2;
            this.tblBot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblBot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblBot.Size = new System.Drawing.Size(508, 100);
            this.tblBot.TabIndex = 1;
            // 
            // tblMid
            // 
            this.tblMid.ColumnCount = 2;
            this.tblMid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 319F));
            this.tblMid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tblMid.Controls.Add(this.pnlValor, 0, 0);
            this.tblMid.Controls.Add(this.pnlPorcentagem, 0, 1);
            this.tblMid.Controls.Add(this.pnlAtivo, 0, 2);
            this.tblMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMid.Location = new System.Drawing.Point(0, 100);
            this.tblMid.Name = "tblMid";
            this.tblMid.RowCount = 4;
            this.tblMid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tblMid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tblMid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tblMid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tblMid.Size = new System.Drawing.Size(508, 250);
            this.tblMid.TabIndex = 2;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalvar.Location = new System.Drawing.Point(430, 63);
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
            this.btnCancelar.Location = new System.Drawing.Point(3, 63);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // pnlNome
            // 
            this.pnlNome.Controls.Add(this.txtNome);
            this.pnlNome.Controls.Add(this.lblNome);
            this.pnlNome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNome.Location = new System.Drawing.Point(3, 70);
            this.pnlNome.Name = "pnlNome";
            this.pnlNome.Size = new System.Drawing.Size(314, 44);
            this.pnlNome.TabIndex = 0;
            // 
            // lblNome
            // 
            this.lblNome.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(3, 14);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNome.Location = new System.Drawing.Point(55, 7);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(256, 20);
            this.txtNome.TabIndex = 1;
            // 
            // pnlValor
            // 
            this.pnlValor.Controls.Add(this.txtValorBase);
            this.pnlValor.Controls.Add(this.lblValor);
            this.pnlValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlValor.Location = new System.Drawing.Point(3, 3);
            this.pnlValor.Name = "pnlValor";
            this.pnlValor.Size = new System.Drawing.Size(313, 25);
            this.pnlValor.TabIndex = 0;
            // 
            // lblValor
            // 
            this.lblValor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(3, 12);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(31, 13);
            this.lblValor.TabIndex = 0;
            this.lblValor.Text = "Valor";
            // 
            // pnlPorcentagem
            // 
            this.pnlPorcentagem.Controls.Add(this.lblPorcentagem);
            this.pnlPorcentagem.Controls.Add(this.numImposto);
            this.pnlPorcentagem.Controls.Add(this.lblImposto);
            this.pnlPorcentagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPorcentagem.Location = new System.Drawing.Point(3, 34);
            this.pnlPorcentagem.Name = "pnlPorcentagem";
            this.pnlPorcentagem.Size = new System.Drawing.Size(313, 26);
            this.pnlPorcentagem.TabIndex = 1;
            // 
            // lblImposto
            // 
            this.lblImposto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblImposto.AutoSize = true;
            this.lblImposto.Location = new System.Drawing.Point(3, 13);
            this.lblImposto.Name = "lblImposto";
            this.lblImposto.Size = new System.Drawing.Size(44, 13);
            this.lblImposto.TabIndex = 0;
            this.lblImposto.Text = "Imposto";
            // 
            // numImposto
            // 
            this.numImposto.Location = new System.Drawing.Point(55, 6);
            this.numImposto.Name = "numImposto";
            this.numImposto.Size = new System.Drawing.Size(46, 20);
            this.numImposto.TabIndex = 1;
            // 
            // lblPorcentagem
            // 
            this.lblPorcentagem.AutoSize = true;
            this.lblPorcentagem.Location = new System.Drawing.Point(107, 8);
            this.lblPorcentagem.Name = "lblPorcentagem";
            this.lblPorcentagem.Size = new System.Drawing.Size(15, 13);
            this.lblPorcentagem.TabIndex = 2;
            this.lblPorcentagem.Text = "%";
            // 
            // pnlAtivo
            // 
            this.pnlAtivo.Controls.Add(this.chkAtivo);
            this.pnlAtivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAtivo.Location = new System.Drawing.Point(3, 66);
            this.pnlAtivo.Name = "pnlAtivo";
            this.pnlAtivo.Size = new System.Drawing.Size(313, 27);
            this.pnlAtivo.TabIndex = 2;
            // 
            // chkAtivo
            // 
            this.chkAtivo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Location = new System.Drawing.Point(6, 10);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(50, 17);
            this.chkAtivo.TabIndex = 0;
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // txtValorBase
            // 
            this.txtValorBase.Location = new System.Drawing.Point(55, 5);
            this.txtValorBase.Name = "txtValorBase";
            this.txtValorBase.Size = new System.Drawing.Size(115, 20);
            this.txtValorBase.TabIndex = 1;
            this.txtValorBase.TextChanged += new System.EventHandler(this.txtValorBase_TextChanged);
            // 
            // FrmCadastroServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 450);
            this.Controls.Add(this.tblMid);
            this.Controls.Add(this.tblBot);
            this.Controls.Add(this.tblTop);
            this.Name = "FrmCadastroServico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Servico";
            this.Load += new System.EventHandler(this.FrmCadastroServico_Load);
            this.tblTop.ResumeLayout(false);
            this.tblBot.ResumeLayout(false);
            this.tblMid.ResumeLayout(false);
            this.pnlNome.ResumeLayout(false);
            this.pnlNome.PerformLayout();
            this.pnlValor.ResumeLayout(false);
            this.pnlValor.PerformLayout();
            this.pnlPorcentagem.ResumeLayout(false);
            this.pnlPorcentagem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImposto)).EndInit();
            this.pnlAtivo.ResumeLayout(false);
            this.pnlAtivo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblTop;
        private System.Windows.Forms.TableLayoutPanel tblBot;
        private System.Windows.Forms.TableLayoutPanel tblMid;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Panel pnlValor;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Panel pnlPorcentagem;
        private System.Windows.Forms.Label lblImposto;
        private System.Windows.Forms.Label lblPorcentagem;
        private System.Windows.Forms.NumericUpDown numImposto;
        private System.Windows.Forms.Panel pnlAtivo;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.TextBox txtValorBase;
    }
}