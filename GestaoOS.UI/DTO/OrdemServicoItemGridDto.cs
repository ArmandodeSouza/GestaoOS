using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOS.UI.DTO {
    public class OrdemServicoItemGridDto {

        public int ServicoId { get; set; }

        public string NomeServico { get; set; }

        public decimal Quantidade { get; set; }

        public decimal ValorUnitario { get; set; }

        public decimal PercentualImpostoAplicado { get; set; }

        public decimal ValorTotalItem { get; set; }

    }



}

