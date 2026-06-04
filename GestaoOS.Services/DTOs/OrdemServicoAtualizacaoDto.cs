using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOS.Services.DTOs {
    public class OrdemServicoAtualizacaoDto {
        public int OrdemServicoId { get; set; }

        public int ClienteId { get; set; }

        public string Observacao { get; set; }

        public List<OrdemServicoItemCadastroDto> Itens { get; set; }
    }
}
