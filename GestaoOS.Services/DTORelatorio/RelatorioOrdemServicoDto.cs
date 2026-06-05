using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOS.Services.DTORelatorio {
    public sealed class RelatorioOrdemServicoDto {
        public int OrdemServicoId { get; set; }
        public int ClienteId { get; set; }
        public string Cliente { get; set; }
        public DateTime DataAbertura { get; set; }
        public string Status { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal TotalImposto { get; set; }
    }
}
