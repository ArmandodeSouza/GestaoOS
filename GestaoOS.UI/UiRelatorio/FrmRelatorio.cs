using GestaoOS.Application.Enum;
using GestaoOS.Application.Interface;
using GestaoOS.Services.DTORelatorio;
using GestaoOS.Services.Interface;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoOS.UI.UiRelatorio {
    public partial class FrmRelatorio : Form {

        private readonly IRelatorioOsService _relatorioOsService;
        private readonly IClienteService _clienteService;


        public FrmRelatorio(IRelatorioOsService relatorioOsService, IClienteService clienteService) {
            InitializeComponent();

            _relatorioOsService = relatorioOsService;
            _clienteService = clienteService;
        }

        private async void FrmRelatorio_Load(object sender, EventArgs e) {

            await CarregarClientesAsync();
            CarregarStatus();

        }



        private async void btnGerarRelatorio_Click(object sender, EventArgs e) {
            try {
                await GerarRelatorioAsync();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            WindowState = FormWindowState.Maximized;

            rpvRelatorio.ZoomMode = ZoomMode.PageWidth;
            rpvRelatorio.SetDisplayMode(DisplayMode.PrintLayout);
            rpvRelatorio.LocalReport.ReportEmbeddedResource = "GestaoOS.UI.Rdlc.RelatorioOsRdlc.rdlc";
            btnSalvarPdf.Enabled = true;
        }

        private async Task GerarRelatorioAsync() {

            var clienteSelecionado = cmbClientes.SelectedItem as ComboBoxItemDto;
            var statusSelecionado = cmbStatus.SelectedItem as ComboBoxItemDto;

            var filtro = new RelatorioOrdemServicoFiltroDto {
                DataInicial = dtpDataInicial.Value.Date,
                DataFinal = dtpDataFinal.Value.Date,
                ClienteId = clienteSelecionado != null ? clienteSelecionado.Id : null,
                Status = statusSelecionado != null ? statusSelecionado.Id : null
            };

            var dados = await _relatorioOsService.ListarOrdensServicoAsync(filtro);

            rpvRelatorio.LocalReport.DataSources.Clear();

            rpvRelatorio.LocalReport.ReportEmbeddedResource =
                "GestaoOS.UI.Rdlc.RelatorioOsRdlc.rdlc";

            rpvRelatorio.LocalReport.DataSources.Add(
                new ReportDataSource(
                    "DsOrdensServico",
                    dados));

            rpvRelatorio.LocalReport.SetParameters(
                new ReportParameter[] {
            new ReportParameter("DataInicial", filtro.DataInicial.ToString("dd/MM/yyyy")),
            new ReportParameter("DataFinal", filtro.DataFinal.ToString("dd/MM/yyyy"))
                });

            rpvRelatorio.RefreshReport();
        }

        private void CarregarStatus() {

            var lista = new List<ComboBoxItemDto>();

            lista.Add(new ComboBoxItemDto {
                Id = null,
                Nome = "Todos"
            });

            lista.Add(new ComboBoxItemDto {
                Id = (int)StatusOrdemServico.Aberta,
                Nome = "Aberta"
            });

            lista.Add(new ComboBoxItemDto {
                Id = (int)StatusOrdemServico.EmAndamento,
                Nome = "Em Andamento"
            });

            lista.Add(new ComboBoxItemDto {
                Id = (int)StatusOrdemServico.Concluida,
                Nome = "Concluída"
            });

            lista.Add(new ComboBoxItemDto {
                Id = (int)StatusOrdemServico.Cancelada,
                Nome = "Cancelada"
            });

            cmbStatus.DataSource = lista;
            cmbStatus.DisplayMember = "Nome";
            cmbStatus.ValueMember = "Id";
        }

        private async Task CarregarClientesAsync() {
            var resultado = await _clienteService.ListarClienteAsync();

            if (!resultado.Success) {
                MessageBox.Show(resultado.Error);
                return;
            }

            var lista = new List<ComboBoxItemDto>();

            lista.Add(new ComboBoxItemDto {
                Id = null,
                Nome = "Todos"
            });

            foreach (var cliente in resultado.Value) {
                lista.Add(new ComboBoxItemDto {
                    Id = cliente.ClienteId,
                    Nome = cliente.Nome
                });
            }

            cmbClientes.DataSource = lista;
            cmbClientes.DisplayMember = "Nome";
            cmbClientes.ValueMember = "Id";
        }

        private void btnSalvarPdf_Click(object sender, EventArgs e) {
            try {
                rpvRelatorio.RefreshReport();

                byte[] bytes = rpvRelatorio.LocalReport.Render(
                    "PDF",
                    "<DeviceInfo><EmbedFonts>None</EmbedFonts></DeviceInfo>",
                    out string mimeType,
                    out string encoding,
                    out string extension,
                    out string[] streams,
                    out Warning[] warnings);

                using (var saveFileDialog = new SaveFileDialog()) {
                    saveFileDialog.Filter = "Arquivo PDF (*.pdf)|*.pdf";
                    saveFileDialog.FileName = "RelatorioOrdensServico.pdf";

                    if (saveFileDialog.ShowDialog() != DialogResult.OK)
                        return;

                    System.IO.File.WriteAllBytes(saveFileDialog.FileName, bytes);
                }

                MessageBox.Show("PDF salvo com sucesso.");
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
