using GestaoOS.Application.Interface;
using GestaoOS.Application;
using GestaoOS.Services.DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoOS.UI.UiCliente {
    public partial class FrmCadastroCliente : Form {

        private readonly IClienteService _clienteService;
        private int? _clienteId;
        public FrmCadastroCliente(IClienteService clienteService) {
            InitializeComponent();

            _clienteService = clienteService;
        }
        public void CarregarParaEdicao(int clienteId) {
            _clienteId = clienteId;
        }
        private async void FrmCadastroCliente_Load(object sender, EventArgs e) {
            cmbTipoPessoa.DataSource = Enum.GetValues(typeof(TipoPessoaDto));
            cmbTipoPessoa.SelectedItem = TipoPessoaDto.Fisica;

            ckbAtivo.Checked = true;

            mskDocumento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            cmbTipoPessoa_SelectedIndexChanged(null, EventArgs.Empty);

            if (_clienteId.HasValue)
                await CarregarClienteAsync(_clienteId.Value);

        }

        private async void btnSalvar_Click(object sender, EventArgs e) {
            try {
                await SalvarAsync();

                DialogResult = DialogResult.OK;
                Close();

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task SalvarAsync() {

            var tipoPessoa = (int)cmbTipoPessoa.SelectedValue;

            if (_clienteId.HasValue) {
                var resultadoEdicao = await _clienteService.AtualizarAsync(
                    _clienteId.Value,
                    txtNome.Text.Trim(),
                    mskDocumento.Text,
                    tipoPessoa,
                    txtEmail.Text.Trim(),
                    mskTelefone.Text,
                    ckbAtivo.Checked);

                if (!resultadoEdicao.Success) {
                    MessageBox.Show(resultadoEdicao.Error);
                    return;
                }

                MessageBox.Show("Cliente atualizado com sucesso.");
                return;
            }

            var resultadoCadastro = await _clienteService.AdicionarAsync(
                txtNome.Text.Trim(),
                mskDocumento.Text,
                tipoPessoa,
                txtEmail.Text.Trim(),
                mskTelefone.Text,
                true);

            if (!resultadoCadastro.Success) {
                MessageBox.Show(resultadoCadastro.Error);
                return;
            }

            MessageBox.Show("Cliente cadastrado com sucesso.");
        }

        private void cmbTipoPessoa_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbTipoPessoa.SelectedItem == null)
                return;

            var tipoPessoa = (TipoPessoaDto)cmbTipoPessoa.SelectedItem;

            mskDocumento.Clear();

            if (tipoPessoa == TipoPessoaDto.Fisica) {
                mskDocumento.Mask = "000.000.000-00";
            } else {
                mskDocumento.Mask = "00.000.000/0000-00";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) {

            DialogResult = DialogResult.Cancel;
            Close();
        }

        private async Task CarregarClienteAsync(int clienteId) {
            var resultado = await _clienteService.ObterPorIdAsync(clienteId);

            if (!resultado.Success) {
                MessageBox.Show(resultado.Error);
                Close();
                return;
            }

            var cliente = resultado.Value;

            txtNome.Text = cliente.Nome;
            cmbTipoPessoa.SelectedItem = (TipoPessoaDto)cliente.TipoPessoa; ;
            mskDocumento.Text = cliente.Documento;
            txtEmail.Text = cliente.Email;
            mskTelefone.Text = cliente.Telefone;
            ckbAtivo.Checked = cliente.Ativo;

            Text = $"Editando Cliente: {cliente.Nome}";
        }
    }
}
