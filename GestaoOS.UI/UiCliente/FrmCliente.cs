using GestaoOS.Application.Interface;
using GestaoOS.Services.DTOs;
using GestaoOS.UI.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoOS.UI.UiCliente {
    public partial class FrmCliente : Form {

        private readonly IClienteService _clienteService;
        private readonly IServiceProvider _serviceProvider;
        private readonly BindingSource _bindingSource = new BindingSource();
        public FrmCliente(IServiceProvider serviceProvider, IClienteService clienteService) {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _clienteService = clienteService;
        }
        private void AbrirFormulario<T>() where T : Form {
            using (var form = _serviceProvider.GetRequiredService<T>()) {
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog(this);
            }
        }
        private void btnNovo_Click(object sender, EventArgs e) {
            AbrirFormulario<FrmCadastroCliente>();
        }

        private void FrmCliente_Load(object sender, EventArgs e) {
            cmbTipoPessoa.DataSource = Enum.GetValues(typeof(TipoPessoaDto));

            cmbTipoPessoa.SelectedItem = TipoPessoaDto.Fisica;

            cmbTipoPessoa_SelectedIndexChanged(null, EventArgs.Empty);
            mskDocumentoPesquisa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            cmbStatusCliente.DataSource = Enum.GetValues(typeof(StatusCliente));
            cmbStatusCliente.SelectedItem = StatusCliente.Todos;

            ConfigurarGridClientes();

        }

        private void cmbTipoPessoa_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbTipoPessoa.SelectedItem == null)
                return;

            ConfigurarMascaraDocumento();
        }

        private void ConfigurarMascaraDocumento() {
            if (cmbTipoPessoa.SelectedItem == null)
                return;
            var tipoPessoa = (TipoPessoaDto)cmbTipoPessoa.SelectedItem;
            mskDocumentoPesquisa.Clear();
            if (tipoPessoa == TipoPessoaDto.Fisica) {
                mskDocumentoPesquisa.Mask = "000.000.000-00";
            } else {
                mskDocumentoPesquisa.Mask = "00.000.000/0000-00";
            }
        }

        private async void btnPesquisar_Click(object sender, EventArgs e) {

            await PesquisarAsync();
        }

        private async Task PesquisarAsync() {
            var nome = txtNomePesquisa.Text.Trim();
            var documento = mskDocumentoPesquisa.Text.Trim();

            var status = (StatusCliente)cmbStatusCliente.SelectedItem;

            bool? ativo = null;

            if (status == StatusCliente.Ativos)
                ativo = true;
            else if (status == StatusCliente.Inativos)
                ativo = false;

            var clientes = await _clienteService.PesquisarAsync(nome, documento, ativo);

            _bindingSource.DataSource = clientes.Value;
        }

        private void ConfigurarGridClientes() {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.ReadOnly = true;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;
            dgvClientes.RowHeadersVisible = false;

            dgvClientes.Columns.Clear();

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "colClienteId",
                HeaderText = "Código",
                DataPropertyName = "ClienteId",
                Width = 70
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "colNome",
                HeaderText = "Nome",
                DataPropertyName = "Nome",
                Width = 220
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "colDocumento",
                HeaderText = "Documento",
                DataPropertyName = "Documento",
                Width = 130
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "colEmail",
                HeaderText = "E-mail",
                DataPropertyName = "Email",
                Width = 180
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "colTelefone",
                HeaderText = "Telefone",
                DataPropertyName = "Telefone",
                Width = 120
            });

            dgvClientes.Columns.Add(new DataGridViewCheckBoxColumn {
                Name = "colAtivo",
                HeaderText = "Ativo",
                DataPropertyName = "Ativo",
                Width = 60
            });

            dgvClientes.DataSource = _bindingSource;
        }

        private async void btnEditar_Click(object sender, EventArgs e) {
            await EditarClienteSelecionadoAsync();
        }

        private async Task EditarClienteSelecionadoAsync() {
            if (_bindingSource.Current == null) {
                MessageBox.Show("Selecione um cliente para editar.");
                return;
            }

            var cliente = (ClientePesquisaDto)_bindingSource.Current;

            using (var form = _serviceProvider.GetRequiredService<FrmCadastroCliente>()) {
                form.CarregarParaEdicao(cliente.ClienteId);

                if (form.ShowDialog(this) == DialogResult.OK) {
                    await PesquisarAsync();
                }
            }
        }
    }
}
