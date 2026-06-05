namespace GestaoOS.UI.UiOrdemServicoCadastro {
    partial class FrmOrdemServicoCadastro {
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
            this.pnlPesquisa1 = new System.Windows.Forms.Panel();
            this.cmbStatusOs = new System.Windows.Forms.ComboBox();
            this.mskDataConclusao = new System.Windows.Forms.MaskedTextBox();
            this.lblStatusOs = new System.Windows.Forms.Label();
            this.lblDataConclusao = new System.Windows.Forms.Label();
            this.mskDataInclusao = new System.Windows.Forms.MaskedTextBox();
            this.lblDataInclusao = new System.Windows.Forms.Label();
            this.NumeroOs = new System.Windows.Forms.Label();
            this.lblNumOs = new System.Windows.Forms.Label();
            this.pnlPesquisa2 = new System.Windows.Forms.Panel();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.lblValorImposto = new System.Windows.Forms.Label();
            this.lblImposto = new System.Windows.Forms.Label();
            this.lblValorSubTotal = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.numQuantidade = new System.Windows.Forms.NumericUpDown();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.lstClientes = new System.Windows.Forms.ListBox();
            this.lstServicos = new System.Windows.Forms.ListBox();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.txtServico = new System.Windows.Forms.TextBox();
            this.lblObservacoes = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblServico = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.tblBot = new System.Windows.Forms.TableLayoutPanel();
            this.pnlValorTotal = new System.Windows.Forms.Panel();
            this.lblValorTotalNum = new System.Windows.Forms.Label();
            this.btnCancelarOs = new System.Windows.Forms.Button();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.pnlBtnSalvar = new System.Windows.Forms.Panel();
            this.btnReabrirOs = new System.Windows.Forms.Button();
            this.btnFinalizarOs = new System.Windows.Forms.Button();
            this.btnSalvarOs = new System.Windows.Forms.Button();
            this.tblMid = new System.Windows.Forms.TableLayoutPanel();
            this.dgvItensOS = new System.Windows.Forms.DataGridView();
            this.tblTop.SuspendLayout();
            this.pnlPesquisa1.SuspendLayout();
            this.pnlPesquisa2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidade)).BeginInit();
            this.tblBot.SuspendLayout();
            this.pnlValorTotal.SuspendLayout();
            this.pnlBtnSalvar.SuspendLayout();
            this.tblMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensOS)).BeginInit();
            this.SuspendLayout();
            // 
            // tblTop
            // 
            this.tblTop.ColumnCount = 2;
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblTop.Controls.Add(this.pnlPesquisa1, 0, 0);
            this.tblTop.Controls.Add(this.pnlPesquisa2, 1, 0);
            this.tblTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblTop.Location = new System.Drawing.Point(0, 0);
            this.tblTop.Name = "tblTop";
            this.tblTop.RowCount = 1;
            this.tblTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblTop.Size = new System.Drawing.Size(800, 224);
            this.tblTop.TabIndex = 0;
            // 
            // pnlPesquisa1
            // 
            this.pnlPesquisa1.Controls.Add(this.cmbStatusOs);
            this.pnlPesquisa1.Controls.Add(this.mskDataConclusao);
            this.pnlPesquisa1.Controls.Add(this.lblStatusOs);
            this.pnlPesquisa1.Controls.Add(this.lblDataConclusao);
            this.pnlPesquisa1.Controls.Add(this.mskDataInclusao);
            this.pnlPesquisa1.Controls.Add(this.lblDataInclusao);
            this.pnlPesquisa1.Controls.Add(this.NumeroOs);
            this.pnlPesquisa1.Controls.Add(this.lblNumOs);
            this.pnlPesquisa1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPesquisa1.Location = new System.Drawing.Point(3, 3);
            this.pnlPesquisa1.Name = "pnlPesquisa1";
            this.pnlPesquisa1.Size = new System.Drawing.Size(394, 218);
            this.pnlPesquisa1.TabIndex = 0;
            // 
            // cmbStatusOs
            // 
            this.cmbStatusOs.FormattingEnabled = true;
            this.cmbStatusOs.Location = new System.Drawing.Point(99, 58);
            this.cmbStatusOs.Name = "cmbStatusOs";
            this.cmbStatusOs.Size = new System.Drawing.Size(121, 21);
            this.cmbStatusOs.TabIndex = 8;
            this.cmbStatusOs.SelectedIndexChanged += new System.EventHandler(this.cmbStatusOs_SelectedIndexChanged);
            // 
            // mskDataConclusao
            // 
            this.mskDataConclusao.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mskDataConclusao.Enabled = false;
            this.mskDataConclusao.Location = new System.Drawing.Point(16, 167);
            this.mskDataConclusao.Mask = "00/00/0000";
            this.mskDataConclusao.Name = "mskDataConclusao";
            this.mskDataConclusao.Size = new System.Drawing.Size(72, 20);
            this.mskDataConclusao.TabIndex = 9;
            this.mskDataConclusao.ValidatingType = typeof(System.DateTime);
            // 
            // lblStatusOs
            // 
            this.lblStatusOs.AutoSize = true;
            this.lblStatusOs.Location = new System.Drawing.Point(13, 61);
            this.lblStatusOs.Name = "lblStatusOs";
            this.lblStatusOs.Size = new System.Drawing.Size(70, 13);
            this.lblStatusOs.TabIndex = 7;
            this.lblStatusOs.Text = "Status da OS";
            // 
            // lblDataConclusao
            // 
            this.lblDataConclusao.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDataConclusao.AutoSize = true;
            this.lblDataConclusao.Location = new System.Drawing.Point(13, 151);
            this.lblDataConclusao.Name = "lblDataConclusao";
            this.lblDataConclusao.Size = new System.Drawing.Size(98, 13);
            this.lblDataConclusao.TabIndex = 10;
            this.lblDataConclusao.Text = "Data de Conclusão";
            // 
            // mskDataInclusao
            // 
            this.mskDataInclusao.Enabled = false;
            this.mskDataInclusao.Location = new System.Drawing.Point(18, 117);
            this.mskDataInclusao.Mask = "00/00/0000";
            this.mskDataInclusao.Name = "mskDataInclusao";
            this.mskDataInclusao.Size = new System.Drawing.Size(72, 20);
            this.mskDataInclusao.TabIndex = 8;
            this.mskDataInclusao.ValidatingType = typeof(System.DateTime);
            // 
            // lblDataInclusao
            // 
            this.lblDataInclusao.AutoSize = true;
            this.lblDataInclusao.Location = new System.Drawing.Point(13, 101);
            this.lblDataInclusao.Name = "lblDataInclusao";
            this.lblDataInclusao.Size = new System.Drawing.Size(90, 13);
            this.lblDataInclusao.TabIndex = 7;
            this.lblDataInclusao.Text = "Data  de inclusão";
            // 
            // NumeroOs
            // 
            this.NumeroOs.AutoSize = true;
            this.NumeroOs.Location = new System.Drawing.Point(96, 15);
            this.NumeroOs.Name = "NumeroOs";
            this.NumeroOs.Size = new System.Drawing.Size(0, 13);
            this.NumeroOs.TabIndex = 6;
            // 
            // lblNumOs
            // 
            this.lblNumOs.AutoSize = true;
            this.lblNumOs.Location = new System.Drawing.Point(13, 15);
            this.lblNumOs.Name = "lblNumOs";
            this.lblNumOs.Size = new System.Drawing.Size(77, 13);
            this.lblNumOs.TabIndex = 5;
            this.lblNumOs.Text = "Numero da OS";
            // 
            // pnlPesquisa2
            // 
            this.pnlPesquisa2.Controls.Add(this.btnAddItem);
            this.pnlPesquisa2.Controls.Add(this.lblValorImposto);
            this.pnlPesquisa2.Controls.Add(this.lblImposto);
            this.pnlPesquisa2.Controls.Add(this.lblValorSubTotal);
            this.pnlPesquisa2.Controls.Add(this.lblSubTotal);
            this.pnlPesquisa2.Controls.Add(this.numQuantidade);
            this.pnlPesquisa2.Controls.Add(this.lblQuantidade);
            this.pnlPesquisa2.Controls.Add(this.lstClientes);
            this.pnlPesquisa2.Controls.Add(this.lstServicos);
            this.pnlPesquisa2.Controls.Add(this.txtObservacoes);
            this.pnlPesquisa2.Controls.Add(this.txtServico);
            this.pnlPesquisa2.Controls.Add(this.lblObservacoes);
            this.pnlPesquisa2.Controls.Add(this.txtCliente);
            this.pnlPesquisa2.Controls.Add(this.lblServico);
            this.pnlPesquisa2.Controls.Add(this.lblCliente);
            this.pnlPesquisa2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPesquisa2.Location = new System.Drawing.Point(403, 3);
            this.pnlPesquisa2.Name = "pnlPesquisa2";
            this.pnlPesquisa2.Size = new System.Drawing.Size(394, 218);
            this.pnlPesquisa2.TabIndex = 1;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddItem.Location = new System.Drawing.Point(3, 167);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(82, 23);
            this.btnAddItem.TabIndex = 4;
            this.btnAddItem.Text = "Adicionar Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // lblValorImposto
            // 
            this.lblValorImposto.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblValorImposto.AutoSize = true;
            this.lblValorImposto.Location = new System.Drawing.Point(310, 167);
            this.lblValorImposto.Name = "lblValorImposto";
            this.lblValorImposto.Size = new System.Drawing.Size(27, 13);
            this.lblValorImposto.TabIndex = 8;
            this.lblValorImposto.Text = "R$: ";
            // 
            // lblImposto
            // 
            this.lblImposto.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblImposto.AutoSize = true;
            this.lblImposto.Location = new System.Drawing.Point(246, 167);
            this.lblImposto.Name = "lblImposto";
            this.lblImposto.Size = new System.Drawing.Size(44, 13);
            this.lblImposto.TabIndex = 7;
            this.lblImposto.Text = "Imposto";
            // 
            // lblValorSubTotal
            // 
            this.lblValorSubTotal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblValorSubTotal.AutoSize = true;
            this.lblValorSubTotal.Location = new System.Drawing.Point(310, 196);
            this.lblValorSubTotal.Name = "lblValorSubTotal";
            this.lblValorSubTotal.Size = new System.Drawing.Size(27, 13);
            this.lblValorSubTotal.TabIndex = 6;
            this.lblValorSubTotal.Text = "R$: ";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Location = new System.Drawing.Point(246, 196);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(50, 13);
            this.lblSubTotal.TabIndex = 5;
            this.lblSubTotal.Text = "SubTotal";
            // 
            // numQuantidade
            // 
            this.numQuantidade.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.numQuantidade.Location = new System.Drawing.Point(297, 117);
            this.numQuantidade.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantidade.Name = "numQuantidade";
            this.numQuantidade.Size = new System.Drawing.Size(47, 20);
            this.numQuantidade.TabIndex = 3;
            this.numQuantidade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantidade.ValueChanged += new System.EventHandler(this.numQuantidade_ValueChanged);
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(294, 101);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(62, 13);
            this.lblQuantidade.TabIndex = 3;
            this.lblQuantidade.Text = "Quantidade";
            // 
            // lstClientes
            // 
            this.lstClientes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lstClientes.FormattingEnabled = true;
            this.lstClientes.Location = new System.Drawing.Point(83, 31);
            this.lstClientes.Name = "lstClientes";
            this.lstClientes.Size = new System.Drawing.Size(273, 82);
            this.lstClientes.TabIndex = 3;
            this.lstClientes.Visible = false;
            this.lstClientes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstClientes_MouseDoubleClick);
            // 
            // lstServicos
            // 
            this.lstServicos.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lstServicos.FormattingEnabled = true;
            this.lstServicos.Location = new System.Drawing.Point(83, 117);
            this.lstServicos.Name = "lstServicos";
            this.lstServicos.Size = new System.Drawing.Size(196, 95);
            this.lstServicos.TabIndex = 2;
            this.lstServicos.Visible = false;
            this.lstServicos.SelectedIndexChanged += new System.EventHandler(this.lstServicos_SelectedIndexChanged);
            this.lstServicos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstServicos_MouseDoubleClick);
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtObservacoes.Location = new System.Drawing.Point(83, 58);
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.Size = new System.Drawing.Size(273, 20);
            this.txtObservacoes.TabIndex = 0;
            // 
            // txtServico
            // 
            this.txtServico.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtServico.Location = new System.Drawing.Point(83, 98);
            this.txtServico.Name = "txtServico";
            this.txtServico.Size = new System.Drawing.Size(196, 20);
            this.txtServico.TabIndex = 2;
            this.txtServico.TextChanged += new System.EventHandler(this.txtServico_TextChanged);
            // 
            // lblObservacoes
            // 
            this.lblObservacoes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblObservacoes.AutoSize = true;
            this.lblObservacoes.Location = new System.Drawing.Point(7, 61);
            this.lblObservacoes.Name = "lblObservacoes";
            this.lblObservacoes.Size = new System.Drawing.Size(70, 13);
            this.lblObservacoes.TabIndex = 1;
            this.lblObservacoes.Text = "Observações";
            // 
            // txtCliente
            // 
            this.txtCliente.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCliente.Location = new System.Drawing.Point(83, 12);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(273, 20);
            this.txtCliente.TabIndex = 1;
            this.txtCliente.TextChanged += new System.EventHandler(this.txtCliente_TextChanged);
            // 
            // lblServico
            // 
            this.lblServico.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblServico.AutoSize = true;
            this.lblServico.Location = new System.Drawing.Point(7, 101);
            this.lblServico.Name = "lblServico";
            this.lblServico.Size = new System.Drawing.Size(43, 13);
            this.lblServico.TabIndex = 0;
            this.lblServico.Text = "Serviço";
            // 
            // lblCliente
            // 
            this.lblCliente.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(7, 15);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente";
            // 
            // tblBot
            // 
            this.tblBot.ColumnCount = 2;
            this.tblBot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblBot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblBot.Controls.Add(this.pnlValorTotal, 1, 0);
            this.tblBot.Controls.Add(this.btnVoltar, 0, 1);
            this.tblBot.Controls.Add(this.pnlBtnSalvar, 1, 1);
            this.tblBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tblBot.Location = new System.Drawing.Point(0, 350);
            this.tblBot.Name = "tblBot";
            this.tblBot.RowCount = 2;
            this.tblBot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblBot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblBot.Size = new System.Drawing.Size(800, 100);
            this.tblBot.TabIndex = 1;
            // 
            // pnlValorTotal
            // 
            this.pnlValorTotal.Controls.Add(this.lblValorTotalNum);
            this.pnlValorTotal.Controls.Add(this.btnCancelarOs);
            this.pnlValorTotal.Controls.Add(this.lblValorTotal);
            this.pnlValorTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlValorTotal.Location = new System.Drawing.Point(403, 3);
            this.pnlValorTotal.Name = "pnlValorTotal";
            this.pnlValorTotal.Size = new System.Drawing.Size(394, 44);
            this.pnlValorTotal.TabIndex = 0;
            // 
            // lblValorTotalNum
            // 
            this.lblValorTotalNum.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblValorTotalNum.AutoSize = true;
            this.lblValorTotalNum.Location = new System.Drawing.Point(310, 14);
            this.lblValorTotalNum.Name = "lblValorTotalNum";
            this.lblValorTotalNum.Size = new System.Drawing.Size(24, 13);
            this.lblValorTotalNum.TabIndex = 1;
            this.lblValorTotalNum.Text = "R$:";
            // 
            // btnCancelarOs
            // 
            this.btnCancelarOs.Location = new System.Drawing.Point(3, 18);
            this.btnCancelarOs.Name = "btnCancelarOs";
            this.btnCancelarOs.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarOs.TabIndex = 7;
            this.btnCancelarOs.Text = "Cancelar OS";
            this.btnCancelarOs.UseVisualStyleBackColor = true;
            this.btnCancelarOs.Click += new System.EventHandler(this.btnCancelarOs_Click);
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Location = new System.Drawing.Point(246, 14);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(58, 13);
            this.lblValorTotal.TabIndex = 0;
            this.lblValorTotal.Text = "Valor Total";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnVoltar.Location = new System.Drawing.Point(3, 63);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(82, 23);
            this.btnVoltar.TabIndex = 6;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            // 
            // pnlBtnSalvar
            // 
            this.pnlBtnSalvar.Controls.Add(this.btnReabrirOs);
            this.pnlBtnSalvar.Controls.Add(this.btnFinalizarOs);
            this.pnlBtnSalvar.Controls.Add(this.btnSalvarOs);
            this.pnlBtnSalvar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBtnSalvar.Location = new System.Drawing.Point(403, 53);
            this.pnlBtnSalvar.Name = "pnlBtnSalvar";
            this.pnlBtnSalvar.Size = new System.Drawing.Size(394, 44);
            this.pnlBtnSalvar.TabIndex = 7;
            // 
            // btnReabrirOs
            // 
            this.btnReabrirOs.Enabled = false;
            this.btnReabrirOs.Location = new System.Drawing.Point(84, 12);
            this.btnReabrirOs.Name = "btnReabrirOs";
            this.btnReabrirOs.Size = new System.Drawing.Size(75, 23);
            this.btnReabrirOs.TabIndex = 8;
            this.btnReabrirOs.Text = "Reabrir OS";
            this.btnReabrirOs.UseVisualStyleBackColor = true;
            // 
            // btnFinalizarOs
            // 
            this.btnFinalizarOs.Enabled = false;
            this.btnFinalizarOs.Location = new System.Drawing.Point(3, 12);
            this.btnFinalizarOs.Name = "btnFinalizarOs";
            this.btnFinalizarOs.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizarOs.TabIndex = 6;
            this.btnFinalizarOs.Text = "Finalizar OS";
            this.btnFinalizarOs.UseVisualStyleBackColor = true;
            this.btnFinalizarOs.Click += new System.EventHandler(this.btnFinalizarOs_Click);
            // 
            // btnSalvarOs
            // 
            this.btnSalvarOs.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalvarOs.Location = new System.Drawing.Point(309, 12);
            this.btnSalvarOs.Name = "btnSalvarOs";
            this.btnSalvarOs.Size = new System.Drawing.Size(82, 23);
            this.btnSalvarOs.TabIndex = 5;
            this.btnSalvarOs.Text = "Salvar OS";
            this.btnSalvarOs.UseVisualStyleBackColor = true;
            this.btnSalvarOs.Click += new System.EventHandler(this.btnSalvarOs_Click);
            // 
            // tblMid
            // 
            this.tblMid.ColumnCount = 1;
            this.tblMid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMid.Controls.Add(this.dgvItensOS, 0, 0);
            this.tblMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMid.Location = new System.Drawing.Point(0, 224);
            this.tblMid.Name = "tblMid";
            this.tblMid.RowCount = 1;
            this.tblMid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMid.Size = new System.Drawing.Size(800, 126);
            this.tblMid.TabIndex = 2;
            // 
            // dgvItensOS
            // 
            this.dgvItensOS.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvItensOS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItensOS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItensOS.Location = new System.Drawing.Point(3, 3);
            this.dgvItensOS.Name = "dgvItensOS";
            this.dgvItensOS.Size = new System.Drawing.Size(794, 120);
            this.dgvItensOS.TabIndex = 0;
            // 
            // FrmOrdemServicoCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tblMid);
            this.Controls.Add(this.tblBot);
            this.Controls.Add(this.tblTop);
            this.Name = "FrmOrdemServicoCadastro";
            this.Text = "Inclusao de Ordem de Serviço";
            this.Load += new System.EventHandler(this.FrmOrdemServicoCadastro_Load);
            this.tblTop.ResumeLayout(false);
            this.pnlPesquisa1.ResumeLayout(false);
            this.pnlPesquisa1.PerformLayout();
            this.pnlPesquisa2.ResumeLayout(false);
            this.pnlPesquisa2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidade)).EndInit();
            this.tblBot.ResumeLayout(false);
            this.pnlValorTotal.ResumeLayout(false);
            this.pnlValorTotal.PerformLayout();
            this.pnlBtnSalvar.ResumeLayout(false);
            this.tblMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensOS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblTop;
        private System.Windows.Forms.TableLayoutPanel tblBot;
        private System.Windows.Forms.TableLayoutPanel tblMid;
        private System.Windows.Forms.Panel pnlPesquisa1;
        private System.Windows.Forms.Label lblObservacoes;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Panel pnlPesquisa2;
        private System.Windows.Forms.DataGridView dgvItensOS;
        private System.Windows.Forms.ListBox lstClientes;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.ListBox lstServicos;
        private System.Windows.Forms.TextBox txtServico;
        private System.Windows.Forms.Label lblServico;
        private System.Windows.Forms.ComboBox cmbStatusOs;
        private System.Windows.Forms.Label lblStatusOs;
        private System.Windows.Forms.Label lblValorSubTotal;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.NumericUpDown numQuantidade;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.Label lblDataInclusao;
        private System.Windows.Forms.Label NumeroOs;
        private System.Windows.Forms.Label lblNumOs;
        private System.Windows.Forms.MaskedTextBox mskDataInclusao;
        private System.Windows.Forms.Label lblDataConclusao;
        private System.Windows.Forms.MaskedTextBox mskDataConclusao;
        private System.Windows.Forms.Panel pnlValorTotal;
        private System.Windows.Forms.Label lblValorTotalNum;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Button btnSalvarOs;
        private System.Windows.Forms.Label lblValorImposto;
        private System.Windows.Forms.Label lblImposto;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Panel pnlBtnSalvar;
        private System.Windows.Forms.Button btnFinalizarOs;
        private System.Windows.Forms.Button btnReabrirOs;
        private System.Windows.Forms.Button btnCancelarOs;
    }
}