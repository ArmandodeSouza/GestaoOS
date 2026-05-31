using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOS.Services.DTOs {
    public class ClientePesquisaDto {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int TipoPessoa { get; set; }
        public bool Ativo { get; set; }
    }
}
