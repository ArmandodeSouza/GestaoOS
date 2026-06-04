using GestaoOS.Application.Enum;
using GestaoOS.UI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOS.UI.DTO {
    public sealed class PesquisaOrdemServicoDto {

        public TipoPesquisaOrdemServico TipoPesquisa { get; set; }

        public int? OrdemServicoId { get; set; }

        public int? ClienteId { get; set; }

        public StatusOrdemServico? Status { get; set; }

        public int Pagina { get; set; }

        public int TamanhoPagina { get; set; }

        public PesquisaOrdemServicoDto() {
            TipoPesquisa = TipoPesquisaOrdemServico.Todas;
            Pagina = 1;
            TamanhoPagina = 20;
        }
    }
}
