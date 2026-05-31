namespace GestaoOS.UI.UiServico {
    partial class FrmServico {
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
            this.pnlNome = new System.Windows.Forms.Panel();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.tblBot = new System.Windows.Forms.TableLayoutPanel();
            this.tblMid = new System.Windows.Forms.TableLayoutPanel();
            this.dgvServico = new System.Windows.Forms.DataGridView();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.tblTop.SuspendLayout();
            this.pnlNome.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.tblBot.SuspendLayout();
            this.tblMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServico)).BeginInit();
            this.SuspendLayout();
            // 
            // tblTop
            // 
            this.tblTop.ColumnCount = 2;
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 399F));
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 401F));
            this.tblTop.Controls.Add(this.pnlNome, 0, 0);
            this.tblTop.Controls.Add(this.pnlStatus, 1, 0);
            this.tblTop.Controls.Add(this.btnPesquisar, 1, 1);
            this.tblTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblTop.Location = new System.Drawing.Point(0, 0);
            this.tblTop.Name = "tblTop";
            this.tblTop.RowCount = 2;
            this.tblTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tblTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tblTop.Size = new System.Drawing.Size(800, 100);
            this.tblTop.TabIndex = 0;
            // 
            // pnlNome
            // 
            this.pnlNome.Controls.Add(this.txtNome);
            this.pnlNome.Controls.Add(this.lblNome);
            this.pnlNome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNome.Location = new System.Drawing.Point(3, 3);
            this.pnlNome.Name = "pnlNome";
            this.pnlNome.Size = new System.Drawing.Size(393, 44);
            this.pnlNome.TabIndex = 0;
            // 
            // txtNome
            // 
            this.txtNome.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNome.Location = new System.Drawing.Point(61, 14);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(332, 20);
            this.txtNome.TabIndex = 1;
            // 
            // lblNome
            // 
            this.lblNome.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(9, 17);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome";
            // 
            // pnlStatus
            // 
            this.pnlStatus.Controls.Add(this.cmbStatus);
            this.pnlStatus.Controls.Add(this.lblStatus);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatus.Location = new System.Drawing.Point(402, 3);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(395, 44);
            this.pnlStatus.TabIndex = 1;
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Todos",
            "Ativos",
            "Inativos"});
            this.cmbStatus.Location = new System.Drawing.Point(271, 13);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(223, 17);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPesquisar.Location = new System.Drawing.Point(722, 63);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 2;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // tblBot
            // 
            this.tblBot.ColumnCount = 2;
            this.tblBot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblBot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblBot.Controls.Add(this.btnEditar, 1, 0);
            this.tblBot.Controls.Add(this.btnNovo, 1, 1);
            this.tblBot.Controls.Add(this.btnExcluir, 0, 1);
            this.tblBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tblBot.Location = new System.Drawing.Point(0, 350);
            this.tblBot.Name = "tblBot";
            this.tblBot.RowCount = 2;
            this.tblBot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblBot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblBot.Size = new System.Drawing.Size(800, 100);
            this.tblBot.TabIndex = 1;
            // 
            // tblMid
            // 
            this.tblMid.ColumnCount = 1;
            this.tblMid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMid.Controls.Add(this.dgvServico, 0, 0);
            this.tblMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMid.Location = new System.Drawing.Point(0, 100);
            this.tblMid.Name = "tblMid";
            this.tblMid.RowCount = 1;
            this.tblMid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMid.Size = new System.Drawing.Size(800, 250);
            this.tblMid.TabIndex = 2;
            // 
            // dgvServico
            // 
            this.dgvServico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServico.Location = new System.Drawing.Point(3, 3);
            this.dgvServico.Name = "dgvServico";
            this.dgvServico.Size = new System.Drawing.Size(794, 244);
            this.dgvServico.TabIndex = 0;
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnEditar.Location = new System.Drawing.Point(722, 13);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 0;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNovo.Location = new System.Drawing.Point(722, 63);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
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
            // FrmServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tblMid);
            this.Controls.Add(this.tblBot);
            this.Controls.Add(this.tblTop);
            this.Name = "FrmServico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmServico";
            this.Load += new System.EventHandler(this.FrmServico_Load);
            this.tblTop.ResumeLayout(false);
            this.pnlNome.ResumeLayout(false);
            this.pnlNome.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.tblBot.ResumeLayout(false);
            this.tblMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblTop;
        private System.Windows.Forms.TableLayoutPanel tblBot;
        private System.Windows.Forms.TableLayoutPanel tblMid;
        private System.Windows.Forms.DataGridView dgvServico;
        private System.Windows.Forms.Panel pnlNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnExcluir;
    }
}