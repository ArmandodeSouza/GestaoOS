using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOS.Services.DTOs {
    public class ServicoPesquisaDto {

        public int ServicoId { get; set; }
        public string Nome { get; set; }
        public decimal ValorBase { get; set; }
        public decimal PercentualImposto { get; set; }
        public bool Ativo { get; set; }
    }
}
