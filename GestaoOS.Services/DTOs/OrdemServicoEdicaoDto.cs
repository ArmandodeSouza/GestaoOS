using GestaoOS.Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOS.Services.DTOs {
    public class OrdemServicoEdicaoDto {
        public int OrdemServicoId { get; set; }
        public int ClienteId { get; set; }
        public string Cliente { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public StatusOrdemServico Status { get; set; }
        public string Observacao { get; set; }
        public decimal ValorTotal { get; set; }
        public int Versao { get; set; }
        public List<OrdemServicoItemEdicaoDto> Itens { get; set; }
    }
}
