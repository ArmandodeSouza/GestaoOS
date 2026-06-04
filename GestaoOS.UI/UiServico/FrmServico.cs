using GestaoOS.Services.DTOs;
using GestaoOS.Services.Interface;
using GestaoOS.UI.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoOS.UI.UiServico {
    public partial class FrmServico : Form {

        private readonly IServicoService _servicoService;
        private readonly IServiceProvider _serviceProvider;
        private readonly BindingSource _bindingSource = new BindingSource();

        public FrmServico(IServiceProvider serviceProvider, IServicoService servicoService) {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _servicoService = servicoService;
        }
        private void AbrirFormulario<T>() where T : Form {
            using (var form = _serviceProvider.GetRequiredService<T>()) {
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog(this);
            }
        }
        private void btnNovo_Click(object sender, EventArgs e) {
            AbrirFormulario<FrmCadastroServico>();
        }

        private void FrmServico_Load(object sender, EventArgs e) {
            cmbStatus.DataSource = Enum.GetValues(typeof(StatusServico));
            cmbStatus.SelectedItem = StatusServico.Todos;

            ConfigurarGridClientes();
        }

        private async void btnPesquisar_Click(object sender, EventArgs e) {
            await PesquisarAsync();
        }

        private async Task PesquisarAsync() {
            var nome = txtNome.Text.Trim();
            var satus = (StatusServico)cmbStatus.SelectedItem;

            bool? ativo = null;

            if (satus == StatusServico.Ativos) {
                ativo = true;
            } else if (satus == StatusServico.Inativos) {
                ativo = false;
            }

            var servicos = await _servicoService.PesquisarAsync(nome, ativo);

            _bindingSource.DataSource = servicos.Value;
        }


        private void ConfigurarGridClientes() {
            dgvServico.AutoGenerateColumns = false;
            dgvServico.AllowUserToAddRows = false;
            dgvServico.AllowUserToDeleteRows = false;
            dgvServico.ReadOnly = true;
            dgvServico.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServico.MultiSelect = false;
            dgvServico.RowHeadersVisible = false;

            dgvServico.Columns.Clear();

            dgvServico.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "colServicoId",
                HeaderText = "Código",
                DataPropertyName = "ServicoId",
                Width = 70
            });

            dgvServico.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "colNome",
                HeaderText = "Nome",
                DataPropertyName = "Nome",
                Width = 250
            });

            dgvServico.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "colValorBase",
                HeaderText = "Valor Base",
                DataPropertyName = "ValorBase",
                Width = 100,
                DefaultCellStyle = { Format = "N2" }
            });

            dgvServico.Columns.Add(new DataGridViewTextBoxColumn {
                Name = "colPercentualImposto",
                HeaderText = "Imposto (%)",
                DataPropertyName = "PercentualImposto",
                Width = 100,
                DefaultCellStyle = { Format = "N2" }
            });

            dgvServico.Columns.Add(new DataGridViewCheckBoxColumn {
                Name = "colAtivo",
                HeaderText = "Ativo",
                DataPropertyName = "Ativo",
                Width = 60
            });


            dgvServico.DataSource = _bindingSource;
        }

        private async void btnEditar_Click(object sender, EventArgs e) {

            await EditarServicoSelecionadoAsync();
        }

        private async Task EditarServicoSelecionadoAsync() {
            if (_bindingSource.Current == null) {
                MessageBox.Show("Selecione um serviço para editar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var servico = (ServicoPesquisaDto)_bindingSource.Current;

            using (var form = _serviceProvider.GetRequiredService<FrmCadastroServico>()) {
                form.CarregarParaEdicao(servico.ServicoId);

                if (form.ShowDialog(this) == DialogResult.OK) {
                    await PesquisarAsync();
                }
            }
        }
    }
}
