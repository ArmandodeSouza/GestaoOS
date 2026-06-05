using GestaoOS.Application.Enum;
using GestaoOS.Domain.Enum;
using System;


namespace GestaoOS.Services.DTOs {
    public class OrdemServicoFiltroDto {
        public TipoPesquisaOrdemServico TipoPesquisa { get; set; }

        public int? OrdemServicoId { get; set; }

        public string Cliente { get; set; }

        public StatusOrdemServico? Status { get; set; }

        public DateTime DataInicial { get; set; }

        public DateTime DataFinal { get; set; }

        public int Pagina { get; set; }

        public int TamanhoPagina { get; set; }
    }
}
