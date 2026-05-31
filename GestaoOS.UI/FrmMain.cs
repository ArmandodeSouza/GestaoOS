using GestaoOS.Application.Interface;
using GestaoOS.UI.UiCliente;
using GestaoOS.UI.UiServico;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace GestaoOS.UI {

    public partial class FrmMain : Form {

        private readonly IServiceProvider _serviceProvider;
        private readonly IClienteService _clienteService;

        public FrmMain(IClienteService clienteService, IServiceProvider serviceProvider) {

            InitializeComponent();
            _clienteService = clienteService;
            Load += FrmMain_Load;
            _serviceProvider = serviceProvider;
        }
        private void AbrirFormulario<T>() where T : Form {
            using (var form = _serviceProvider.GetRequiredService<T>()) {
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog(this);
            }
        }

        private void FrmMain_Load(object sender, System.EventArgs e) {

        }
        private void FrmMain_Load1(object sender, System.EventArgs e) {
            throw new System.NotImplementedException();
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
    }
}