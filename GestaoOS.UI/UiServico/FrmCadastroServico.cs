using GestaoOS.Services.Interface;
using GestaoOS.UI.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoOS.UI.UiServico {
    public partial class FrmCadastroServico : Form {

        private readonly IServicoService _servicoService;
        private int? _servicoId;
        private bool _formatandoValor;
        public FrmCadastroServico(IServicoService servicoService) {
            InitializeComponent();

            _servicoService = servicoService;
        }

        public void CarregarParaEdicao(int servicoId) {
            _servicoId = servicoId;
        }

        private async void btnSalvar_Click(object sender, EventArgs e) {
            var valorBase = CampoMonetarioHelper.ObterValor(txtValorBase);

            try {

                await SalvarAsync();

                DialogResult = DialogResult.OK;
                Close();

            } catch (Exception ex) {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async Task SalvarAsync() {
            var valorBase = CampoMonetarioHelper.ObterValor(txtValorBase);
            if (_servicoId.HasValue) {
                var resultadoEdicao = await _servicoService.AtualizarAsync(
                    _servicoId.Value,
                    txtNome.Text.Trim(),
                    valorBase,
                    numImposto.Value,
                    chkAtivo.Checked);

                if (!resultadoEdicao.Success) {
                    MessageBox.Show(resultadoEdicao.Error);
                    return;
                }
                MessageBox.Show("Servico atualizado com sucesso.");
                return;

            }

            var resultadoCadastro = await _servicoService.AdicionarAsync(
                txtNome.Text.Trim(),
                valorBase,
                numImposto.Value
                );
            if (!resultadoCadastro.Success) {
                MessageBox.Show(resultadoCadastro.Error);
                return;
            }
            MessageBox.Show("Servico cadastrado com sucesso.");
        }


        private void FrmCadastroServico_Load(object sender, EventArgs e) {
            if (_servicoId.HasValue)
                CarregarServicoAsync(_servicoId.Value);

            chkAtivo.Checked = true;
        }

        private void txtValorBase_TextChanged(object sender, EventArgs e) {
            if (_formatandoValor)
                return;

            _formatandoValor = true;

            CampoMonetarioHelper.Formatar(txtValorBase);

            _formatandoValor = false;
        }


        private async Task CarregarServicoAsync(int servicoId) {

            var resultado = await _servicoService.ObterPorIdAsync(servicoId);

            if (!resultado.Success) {

                MessageBox.Show(resultado.Error);
                Close();
                return;
            }

            var servico = resultado.Value;

            txtNome.Text = servico.Nome;
            txtValorBase.Text = servico.ValorBase.ToString("N2");
            numImposto.Value = servico.PercentualImposto;
            chkAtivo.Checked = servico.Ativo;

            Text = $"Editando Serviço: {servico.Nome}";
        }
    }
}
