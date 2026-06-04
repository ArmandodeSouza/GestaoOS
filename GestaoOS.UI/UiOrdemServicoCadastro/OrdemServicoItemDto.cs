namespace GestaoOS.UI.UiOrdemServicoCadastro {
    internal class OrdemServicoItemDto {
        public int ServicoId { get; set; }
        public string NomeServico { get; set; }
        public object Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal PercentualImposto { get; set; }
    }
}