using GestaoOS.Services.DTOs;
using System.Collections.Generic;

namespace GestaoOS.Services.Interface {
    public sealed class OrdemServicoCadastroDto {
        public int ClienteId { get; set; }
        public string Observacao { get; set; }
        public IList<OrdemServicoItemCadastroDto> Itens { get; set; }

        public OrdemServicoCadastroDto() {
            Itens = new List<OrdemServicoItemCadastroDto>();
        }
    }
}