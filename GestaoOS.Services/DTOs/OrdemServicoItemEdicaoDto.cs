using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOS.Services.DTOs {
    public class OrdemServicoItemEdicaoDto {
        public int OrdemServicoItemId { get; set; }
        public int ServicoId { get; set; }
        public string NomeServico { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ImpostoAplicado { get; set; }
        public decimal ValorTotalItem { get; set; }
    }
}
