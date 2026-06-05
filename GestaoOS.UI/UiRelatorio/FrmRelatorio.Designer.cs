namespace GestaoOS.UI.UiRelatorio {
    partial class FrmRelatorio {
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
            this.tblRdlc = new System.Windows.Forms.TableLayoutPanel();
            this.rpvRelatorio = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlBot = new System.Windows.Forms.Panel();
            this.btnGerarRelatorio = new System.Windows.Forms.Button();
            this.dtpDataFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpDataInicial = new System.Windows.Forms.DateTimePicker();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblDataInicial = new System.Windows.Forms.Label();
            this.lblDataFinal = new System.Windows.Forms.Label();
            this.lblStatusOs = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.btnSalvarPdf = new System.Windows.Forms.Button();
            this.tblTop.SuspendLayout();
            this.tblRdlc.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlBot.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblTop
            // 
            this.tblTop.ColumnCount = 1;
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblTop.Controls.Add(this.pnlTop, 0, 0);
            this.tblTop.Controls.Add(this.pnlBot, 0, 1);
            this.tblTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblTop.Location = new System.Drawing.Point(0, 0);
            this.tblTop.Name = "tblTop";
            this.tblTop.RowCount = 2;
            this.tblTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblTop.Size = new System.Drawing.Size(800, 100);
            this.tblTop.TabIndex = 1;
            // 
            // tblRdlc
            // 
            this.tblRdlc.ColumnCount = 1;
            this.tblRdlc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblRdlc.Controls.Add(this.rpvRelatorio, 0, 0);
            this.tblRdlc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblRdlc.Location = new System.Drawing.Point(0, 100);
            this.tblRdlc.Name = "tblRdlc";
            this.tblRdlc.RowCount = 1;
            this.tblRdlc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblRdlc.Size = new System.Drawing.Size(800, 350);
            this.tblRdlc.TabIndex = 2;
            // 
            // rpvRelatorio
            // 
            this.rpvRelatorio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvRelatorio.Location = new System.Drawing.Point(3, 3);
            this.rpvRelatorio.Name = "rpvRelatorio";
            this.rpvRelatorio.ServerReport.BearerToken = null;
            this.rpvRelatorio.Size = new System.Drawing.Size(794, 344);
            this.rpvRelatorio.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnSalvarPdf);
            this.pnlTop.Controls.Add(this.lblCliente);
            this.pnlTop.Controls.Add(this.lblStatusOs);
            this.pnlTop.Controls.Add(this.lblDataInicial);
            this.pnlTop.Controls.Add(this.dtpDataInicial);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Location = new System.Drawing.Point(3, 3);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(794, 44);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlBot
            // 
            this.pnlBot.Controls.Add(this.lblDataFinal);
            this.pnlBot.Controls.Add(this.cmbStatus);
            this.pnlBot.Controls.Add(this.cmbClientes);
            this.pnlBot.Controls.Add(this.dtpDataFinal);
            this.pnlBot.Controls.Add(this.btnGerarRelatorio);
            this.pnlBot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBot.Location = new System.Drawing.Point(3, 53);
            this.pnlBot.Name = "pnlBot";
            this.pnlBot.Size = new System.Drawing.Size(794, 44);
            this.pnlBot.TabIndex = 1;
            // 
            // btnGerarRelatorio
            // 
            this.btnGerarRelatorio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGerarRelatorio.Location = new System.Drawing.Point(716, 18);
            this.btnGerarRelatorio.Name = "btnGerarRelatorio";
            this.btnGerarRelatorio.Size = new System.Drawing.Size(75, 23);
            this.btnGerarRelatorio.TabIndex = 0;
            this.btnGerarRelatorio.Text = "Gerar relatório";
            this.btnGerarRelatorio.UseVisualStyleBackColor = true;
            this.btnGerarRelatorio.Click += new System.EventHandler(this.btnGerarRelatorio_Click);
            // 
            // dtpDataFinal
            // 
            this.dtpDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFinal.Location = new System.Drawing.Point(537, 3);
            this.dtpDataFinal.Name = "dtpDataFinal";
            this.dtpDataFinal.Size = new System.Drawing.Size(85, 20);
            this.dtpDataFinal.TabIndex = 1;
            // 
            // dtpDataInicial
            // 
            this.dtpDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataInicial.Location = new System.Drawing.Point(537, 21);
            this.dtpDataInicial.Name = "dtpDataInicial";
            this.dtpDataInicial.Size = new System.Drawing.Size(85, 20);
            this.dtpDataInicial.TabIndex = 0;
            // 
            // cmbClientes
            // 
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(3, 0);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(234, 21);
            this.cmbClientes.TabIndex = 2;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(270, 0);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 3;
            // 
            // lblDataInicial
            // 
            this.lblDataInicial.AutoSize = true;
            this.lblDataInicial.Location = new System.Drawing.Point(471, 21);
            this.lblDataInicial.Name = "lblDataInicial";
            this.lblDataInicial.Size = new System.Drawing.Size(60, 13);
            this.lblDataInicial.TabIndex = 1;
            this.lblDataInicial.Text = "Data Inicial";
            // 
            // lblDataFinal
            // 
            this.lblDataFinal.AutoSize = true;
            this.lblDataFinal.Location = new System.Drawing.Point(471, 8);
            this.lblDataFinal.Name = "lblDataFinal";
            this.lblDataFinal.Size = new System.Drawing.Size(55, 13);
            this.lblDataFinal.TabIndex = 4;
            this.lblDataFinal.Text = "Data Final";
            // 
            // lblStatusOs
            // 
            this.lblStatusOs.AutoSize = true;
            this.lblStatusOs.Location = new System.Drawing.Point(294, 21);
            this.lblStatusOs.Name = "lblStatusOs";
            this.lblStatusOs.Size = new System.Drawing.Size(70, 13);
            this.lblStatusOs.TabIndex = 2;
            this.lblStatusOs.Text = "Status da OS";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(98, 21);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 3;
            this.lblCliente.Text = "Cliente";
            // 
            // btnSalvarPdf
            // 
            this.btnSalvarPdf.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalvarPdf.Enabled = false;
            this.btnSalvarPdf.Location = new System.Drawing.Point(716, 18);
            this.btnSalvarPdf.Name = "btnSalvarPdf";
            this.btnSalvarPdf.Size = new System.Drawing.Size(75, 23);
            this.btnSalvarPdf.TabIndex = 4;
            this.btnSalvarPdf.Text = "Salvar PDF";
            this.btnSalvarPdf.UseVisualStyleBackColor = true;
            this.btnSalvarPdf.Click += new System.EventHandler(this.btnSalvarPdf_Click);
            // 
            // FrmRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tblRdlc);
            this.Controls.Add(this.tblTop);
            this.Name = "FrmRelatorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRelatorio_Load);
            this.tblTop.ResumeLayout(false);
            this.tblRdlc.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBot.ResumeLayout(false);
            this.pnlBot.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblTop;
        private System.Windows.Forms.TableLayoutPanel tblRdlc;
        private Microsoft.Reporting.WinForms.ReportViewer rpvRelatorio;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBot;
        private System.Windows.Forms.Button btnGerarRelatorio;
        private System.Windows.Forms.DateTimePicker dtpDataInicial;
        private System.Windows.Forms.DateTimePicker dtpDataFinal;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblDataInicial;
        private System.Windows.Forms.Label lblDataFinal;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblStatusOs;
        private System.Windows.Forms.Button btnSalvarPdf;
    }
}