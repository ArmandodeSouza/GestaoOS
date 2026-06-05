using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOS.Services.DTORelatorio {
    public sealed class RelatorioOrdemServicoFiltroDto {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public int? ClienteId { get; set; }
        public int? Status { get; set; }
    }
}
