using GestaoOS.Services.DTOs;
using System.Collections.Generic;

namespace GestaoOS.Services.Interface {
    public class OrdemServicoCadastroDto {
        public int OrdemServicoId { get; set; }
        public int ClienteId { get; set; }
        public string Observacao { get; set; }
        public int Versao { get; set; }
        public List<OrdemServicoItemCadastroDto> Itens { get; set; }
    }
}