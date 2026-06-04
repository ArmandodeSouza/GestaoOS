using GestaoOS.Application.Enum;
using GestaoOS.Application.Interface;
using GestaoOS.Services.DTOs;
using GestaoOS.Services.Interface;
using GestaoOS.UI.DTO;
using GestaoOS.UI.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoOS.UI.UiOrdemServicoCadastro {
    public partial class FrmOrdemServicoCadastro : Form {

        private readonly IOrdemServicoService _ordemServicoService;
        private readonly IClienteService _clienteService;
        private readonly IServicoService _servicoService;

        private readonly BindingSource _bindingSource = new BindingSource();
        private readonly List<OrdemServicoItemGridDto> _itensGrid = new List<OrdemServicoItemGridDto>();

        private ClientePesquisaDto _clienteSelecionado;
        private List<ClientePesquisaDto> _clientes = new List<ClientePesquisaDto>();

        private List<ServicoPesquisaDto> _servicos = new List<ServicoPesquisaDto>();
        private ServicoPesquisaDto _servicoSelecionado;

        private int _ordemServicoId = 0;

        public FrmOrdemServicoCadastro(IOrdemServicoService ordemServicoService, IClienteService clienteService, IServicoService servicoService) {
            InitializeComponent();

            _ordemServicoService = ordemServicoService;
            _clienteService = clienteService;
            _servicoService = servicoService;
        }

        private async void FrmOrdemServicoCadastro_Load(object sender, EventArgs e) {
            cmbStatusOs.DataSource = Enum.GetValues(typeof(StatusOrdemServico));
            cmbStatusOs.SelectedItem = StatusOrdemServico.Aberta;

            mskDataInclusao.Text = DateTime.UtcNow.ToString("dd/MM/yyyy");

            ListaClientes();

            ListaServicos();

            ConfigurarGrid();

        }

        private async Task ListaServicos() {
            var ListaServicos = await _servicoService.ListarServicoAsync();
            _servicos = ListaServicos.Value;
        }

        private async Task ListaClientes() {
            var ListaClientes = await _clienteService.ListarClienteAsync();
            _clientes = ListaClientes.Value;
        }


        private void ConfigurarGrid() {
            dgvItensOS.AutoGenerateColumns = false;
            dgvItensOS.AllowUserToAddRows = false;
            dgvItensOS.AllowUserToDeleteRows = false;
            dgvItensOS.ReadOnly = true;
            dgvItensOS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItensOS.MultiSelect = false;
            dgvItensOS.RowHeadersVisible = false;
            dgvItensOS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgvItensOS.Anchor = AnchorStyles.Top
                | AnchorStyles.Bottom
                | AnchorStyles.Left
                | AnchorStyles.Right;

            dgvItensOS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvItensOS.Columns.Clear();

            dgvItensOS.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "colServico",
                HeaderText = "Serviço",
                DataPropertyName = "NomeServico",
                FillWeight = 35
            });

            dgvItensOS.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "colQuantidade",
                HeaderText = "Qtd.",
                DataPropertyName = "Quantidade",
                FillWeight = 10
            });

            dgvItensOS.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "colValorUnitario",
                HeaderText = "Valor Unit.",
                DataPropertyName = "ValorUnitario",
                FillWeight = 15,
                DefaultCellStyle = new DataGridViewCellStyle {
                    Format = "C2"
                }
            });

            dgvItensOS.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "colImposto",
                HeaderText = "Imposto %",
                DataPropertyName = "PercentualImpostoAplicado",
                FillWeight = 15,
                DefaultCellStyle = new DataGridViewCellStyle {
                    Format = "N2"
                }
            });

            dgvItensOS.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "colValorTotalItem",
                HeaderText = "Total",
                DataPropertyName = "ValorTotalItem",
                FillWeight = 15,
                DefaultCellStyle = new DataGridViewCellStyle {
                    Format = "C2"
                }
            });

            dgvItensOS.Columns.Add(new DataGridViewButtonColumn {
                Name = "colRemover",
                HeaderText = "",
                Text = "Remover",
                UseColumnTextForButtonValue = true,
                FillWeight = 10
            });

            dgvItensOS.DataSource = _bindingSource;
        }
        private void CarregarGridItens() {
            dgvItensOS.DataSource = null;
            dgvItensOS.DataSource = _itensGrid;
        }
        private async void btnSalvarOs_Click(object sender, EventArgs e) {
            await SalvarAsync();
            cmbStatusOs.SelectedItem = StatusOrdemServico.EmAndamento;

        }

        private void cmbStatusOs_SelectedIndexChanged(object sender, EventArgs e) {
            btnFinalizarOs.Enabled = true == cmbStatusOs.SelectedItem?.Equals(StatusOrdemServico.EmAndamento);
        }

        private void txtCliente_TextChanged(object sender, EventArgs e) {
            var texto = txtCliente.Text.Trim();

            if (texto.Length < 2) {
                lstClientes.DataSource = null;
                lstClientes.Visible = false;
                return;
            }

            var clientesFiltrados = _clientes
                .Where(c => c.Nome.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0)
                .OrderBy(c => c.Nome)
                .ToList();

            lstClientes.DataSource = clientesFiltrados;
            lstClientes.DisplayMember = "Nome";
            lstClientes.Visible = clientesFiltrados.Any();
        }

        private void lstClientes_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (lstClientes.SelectedItem == null)
                return;

            var cliente = (ClientePesquisaDto)lstClientes.SelectedItem;

            _clienteSelecionado = cliente;

            txtCliente.Text = cliente.Nome;

            lstClientes.Visible = false;
        }

        private void txtServico_TextChanged(object sender, EventArgs e) {
            var texto = txtServico.Text.Trim();

            if (texto.Length < 2) {

                lstServicos.DataSource = null;
                lstServicos.Visible = false;
                return;
            }

            var servicosFiltrados = _servicos
                .Where(s => s.Nome.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0)
                .OrderBy(s => s.Nome)
                .ToList();

            lstServicos.DataSource = servicosFiltrados;
            lstServicos.DisplayMember = "Nome";
            lstServicos.Visible = servicosFiltrados.Any();


        }

        private void lstServicos_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (lstServicos.SelectedItems == null)
                return;

            var servico = (ServicoPesquisaDto)lstServicos.SelectedItem;

            _servicoSelecionado = servico;
            txtServico.Text = servico.Nome;
            lstServicos.Visible = false;


        }

        private void CalcularValorItem() {
            if (_servicoSelecionado == null)
                return;

            var subtotal = numQuantidade.Value * _servicoSelecionado.ValorBase;

            var imposto = _servicoSelecionado.PercentualImposto;

            var total = subtotal + imposto;

            lblValorImposto.Text = imposto.ToString("N2");
            lblValorSubTotal.Text = total.ToString("N2");
        }

        private void lstServicos_SelectedIndexChanged(object sender, EventArgs e) {
            var servico = lstServicos.SelectedItem as ServicoPesquisaDto;

            if (servico == null)
                return;

            _servicoSelecionado = servico;

            lblValorSubTotal.Text = servico.ValorBase.ToString("N2");
            lblValorImposto.Text = servico.PercentualImposto.ToString("N2");

            CalcularValorItem();
        }

        private void numQuantidade_ValueChanged(object sender, EventArgs e) {
            CalcularValorItem();
        }

        private void adicionarItem() {

            if (_clienteSelecionado == null) {
                MessageBox.Show("Selecione um cliente para adicionar itens à ordem de serviço.", "Cliente não selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_servicoSelecionado == null) {
                MessageBox.Show("Selecione um serviço para adicionar à ordem de serviço.", "Serviço não selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = new OrdemServicoItemGridDto {
                ServicoId = _servicoSelecionado.ServicoId,
                NomeServico = _servicoSelecionado.Nome,
                Quantidade = numQuantidade.Value,
                ValorUnitario = _servicoSelecionado.ValorBase,
                PercentualImpostoAplicado = _servicoSelecionado.PercentualImposto,
                ValorTotalItem = (numQuantidade.Value * _servicoSelecionado.ValorBase) + _servicoSelecionado.PercentualImposto
            };

            _itensGrid.Add(item);

            AtualizarTotalOs();
        }

        private void AtualizarTotalOs() {
            var total = _itensGrid.Sum(x => x.ValorTotalItem);

            lblValorTotalNum.Text = total.ToString("N2");
        }

        private void limparCamposItem() {
            txtServico.Text = string.Empty;
            numQuantidade.Value = 1;
            lblValorSubTotal.Text = "0,00";
            lblValorImposto.Text = "0,00";
        }

        private void AddItem_Click(object sender, EventArgs e) {
            if (_itensGrid.Count != 0) {
                txtCliente.Enabled = false;
            }
            adicionarItem();
            CarregarGridItens();
            limparCamposItem();
        }

        private async Task SalvarAsync() {
            if (_itensGrid.Count == 0) {
                MessageBox.Show("Adicione ao menos um item.");
                return;
            }

            var dto = new OrdemServicoCadastroDto {
                ClienteId = _clienteSelecionado.ClienteId,
                Observacao = txtObservacoes.Text,
                Itens = _itensGrid.Select(x => new OrdemServicoItemCadastroDto {
                    ServicoId = x.ServicoId,
                    Quantidade = x.Quantidade
                }).ToList()
            };

            var resultado = await _ordemServicoService.AdicionarAsync(dto);
            _ordemServicoId = resultado.Value;
            if (!resultado.Success) {
                MessageBox.Show(resultado.Error);
                return;
            }

            MessageBox.Show("Ordem de Serviço cadastrada com sucesso.");

            DialogResult = DialogResult.OK;
            Close();


        }

        private async void btnFinalizarOs_Click(object sender, EventArgs e) {
            await FinalizarOsAsync();

            cmbStatusOs.SelectedItem = StatusOrdemServico.Concluida;
            mskDataConclusao.Text = DateTime.Now.ToString("dd/MM/yyyy");

            DesabilitarCamposOs();

            MessageBox.Show("Ordem de Serviço finalizada com sucesso.");
        }

        private async Task FinalizarOsAsync() {
            if (_ordemServicoId <= 0) {
                MessageBox.Show("Salve a OS antes de finalizar.");
                return;
            }

            var resultado = await _ordemServicoService.ConcluirAsync(
                _ordemServicoId,
                Environment.UserName
            );

            if (!resultado.Success) {
                MessageBox.Show(resultado.Error);
                return;
            }

            cmbStatusOs.SelectedItem = StatusOrdemServico.Concluida;

            DesabilitarCamposOs();

            MessageBox.Show("Ordem de Serviço finalizada com sucesso.");


        }

        private void DesabilitarCamposOs() {
            txtCliente.Enabled = false;
            txtObservacoes.Enabled = false;
            txtServico.Enabled = false;
            numQuantidade.Enabled = false;

            btnAddItem.Enabled = false;
            btnSalvarOs.Enabled = false;
            btnFinalizarOs.Enabled = false;

            dgvItensOS.Enabled = false;
            cmbStatusOs.Enabled = false;
        }
    }
}
