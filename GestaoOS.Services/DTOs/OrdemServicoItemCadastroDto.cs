using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOS.Services.DTOs {
    public class OrdemServicoItemCadastroDto {
        public int ServicoId { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ImpostoAplicado { get; set; }
    }
}
