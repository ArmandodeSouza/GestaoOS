using GestaoOS.Application.Enum;
using GestaoOS.Application.Interface;
using GestaoOS.Services.DTOs;
using GestaoOS.Services.Interface;
using GestaoOS.Services.Services;
using GestaoOS.UI.Enums;
using GestaoOS.UI.UiCliente;
using GestaoOS.UI.UiOrdemServicoCadastro;
using GestaoOS.UI.UiServico;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoOS.UI {

    public partial class FrmMain : Form {

        private readonly IServiceProvider _serviceProvider;
        private readonly IClienteService _clienteService;
        private readonly IOrdemServicoService _ordemServicoService;
        private readonly BindingSource _bindingSource = new BindingSource();

        private IList<ClientePesquisaDto> _clientes = new List<ClientePesquisaDto>();
        private int _paginaAtual = 1;
        private const int _tamanhoPagina = 20;

        public FrmMain(IClienteService clienteService, IServiceProvider serviceProvider, IOrdemServicoService ordemServicoService) {

            InitializeComponent();
            _clienteService = clienteService;
            Load += FrmMain_Load;
            _serviceProvider = serviceProvider;
            _ordemServicoService = ordemServicoService;
        }



        private void AbrirFormulario<T>() where T : Form {
            using (var form = _serviceProvider.GetRequiredService<T>()) {
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog(this);
            }
        }

        private void FrmMain_Load(object sender, System.EventArgs e) {
            cmbTipoPesquisaOs.DataSource = Enum.GetValues(typeof(TipoPesquisaOrdemServico));
            cmbTipoPesquisaOs.SelectedItem = TipoPesquisaOrdemServico.Todas;
            txtPesquisa.Enabled = false;

            cmbStatusOs.Visible = false;

            dtpDataInicial.Value = DateTime.UtcNow;
            dtpDataFinal.Value = DateTime.UtcNow;

            ConfigurarGridOs();
        }

        private void pesquisarToolStripMenuItem_Click(object sender, System.EventArgs e) {
            AbrirFormulario<FrmCliente>();
        }

        private void incluirToolStripMenuItem_Click(object sender, EventArgs e) {
            AbrirFormulario<FrmCadastroCliente>();
        }

        private void pesquisarToolStripMenuItem1_Click(object sender, EventArgs e) {
            AbrirFormulario<FrmServico>();
        }

        private void incluirToolStripMenuItem1_Click(object sender, EventArgs e) {
            AbrirFormulario<FrmCadastroServico>();
        }

        private void cmbTipoPesquisaOs_SelectedIndexChanged(object sender, EventArgs e) {
            var tipoPesquisa = (TipoPesquisaOrdemServico)cmbTipoPesquisaOs.SelectedItem;

            cmbStatusOs.Visible = tipoPesquisa == TipoPesquisaOrdemServico.Status;
            txtPesquisa.Visible = tipoPesquisa != TipoPesquisaOrdemServico.Status;

            if (cmbTipoPesquisaOs.SelectedItem.Equals(TipoPesquisaOrdemServico.Todas)) {
                txtPesquisa.Enabled = false;
            } else {
                txtPesquisa.Enabled = true;
            }

            cmbStatusOs.DataSource = Enum.GetValues(typeof(StatusOrdemServico));
            cmbStatusOs.SelectedItem = StatusOrdemServico.Aberta;


        }

        private void VerificarData() {
            if (dtpDataInicial.Value > dtpDataFinal.Value) {
                MessageBox.Show("A data inicial não pode ser maior que a data final.", "Erro de Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dtpDataInicial_ValueChanged(object sender, EventArgs e) {
            VerificarData();
        }

        private void ConfigurarGridOs() {
            dgvOs.AutoGenerateColumns = false;
            dgvOs.AllowUserToAddRows = false;
            dgvOs.AllowUserToDeleteRows = false;
            dgvOs.ReadOnly = true;
            dgvOs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOs.MultiSelect = false;
            dgvOs.RowHeadersVisible = false;

            dgvOs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOs.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dgvOs.Columns.Clear();

            dgvOs.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "colOrdemServicoId",
                HeaderText = "OS",
                DataPropertyName = "OrdemServicoId",
                FillWeight = 10
            });

            dgvOs.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "colCliente",
                HeaderText = "Cliente",
                DataPropertyName = "Cliente",
                FillWeight = 30
            });

            dgvOs.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "colDataAbertura",
                HeaderText = "Abertura",
                DataPropertyName = "DataAbertura",
                FillWeight = 15,
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            });

            dgvOs.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "colDataConclusao",
                HeaderText = "Conclusão",
                DataPropertyName = "DataFechamento",
                FillWeight = 15,
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            });

            dgvOs.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "colStatus",
                HeaderText = "Status",
                DataPropertyName = "Status",
                FillWeight = 15
            });

            dgvOs.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "colValorTotal",
                HeaderText = "Valor Total",
                DataPropertyName = "ValorTotal",
                FillWeight = 15,
                DefaultCellStyle = { Format = "C2" }
            });

        }

        private void btnNovaOs_Click(object sender, EventArgs e) {
            AbrirFormulario<FrmOrdemServicoCadastro>();
        }

        private async void btnPesquisar_Click(object sender, EventArgs e) {
            _paginaAtual = 1;
            await PesquisarAsync();
        }

        private async Task PesquisarAsync() {
            var tipoPesquisa = (TipoPesquisaOrdemServico)cmbTipoPesquisaOs.SelectedItem;

            var filtro = new OrdemServicoFiltroDto {
                TipoPesquisa = tipoPesquisa,
                DataInicial = dtpDataInicial.Value.Date,
                DataFinal = dtpDataFinal.Value.Date,
                Pagina = _paginaAtual,
                TamanhoPagina = _tamanhoPagina
            };

            if (tipoPesquisa == TipoPesquisaOrdemServico.OS) {
                int ordemServicoId;

                if (!int.TryParse(txtPesquisa.Text.Trim(), out ordemServicoId)) {
                    MessageBox.Show("Informe um número de OS válido.");
                    return;
                }

                filtro.OrdemServicoId = ordemServicoId;
            }

            if (tipoPesquisa == TipoPesquisaOrdemServico.Cliente) {
                var nomeCliente = txtPesquisa.Text.Trim();

                if (string.IsNullOrWhiteSpace(nomeCliente)) {
                    MessageBox.Show("Informe o nome do cliente.");
                    return;
                }

                filtro.Cliente = nomeCliente;
            }

            if (tipoPesquisa == TipoPesquisaOrdemServico.Status) {
                if (cmbStatusOs.SelectedItem == null) {
                    MessageBox.Show("Selecione um status.");
                    return;
                }

                filtro.Status = (StatusOrdemServico)cmbStatusOs.SelectedItem;
            }

            var resultado = await _ordemServicoService.PesquisarAsync(filtro);

            if (!resultado.Success) {
                MessageBox.Show(resultado.Error);
                return;
            }

            _bindingSource.DataSource = resultado.Value;
            dgvOs.DataSource = _bindingSource;
        }

        private async void btnEditarOs_Click(object sender, EventArgs e) {
            await EditarOrdemServicoAsync();
        }

        private async Task EditarOrdemServicoAsync() {
            var ordemServico = _bindingSource.Current as OrdemServicoPesquisaDto;

            if (ordemServico == null) {
                MessageBox.Show("Selecione uma OS para editar.");
                return;
            }

            var form = _serviceProvider.GetRequiredService<FrmOrdemServicoCadastro>();

            form.CarregarParaEdicao(ordemServico.OrdemServicoId);

            form.ShowDialog();

            _ = PesquisarAsync();
        }

    }
}