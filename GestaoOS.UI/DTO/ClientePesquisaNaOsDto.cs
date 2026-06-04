using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOS.UI.DTO {
    public class ClientePesquisaNaOsDto {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }

        public string Descricao {
            get { return Nome + " - " + Documento; }
        }
    }
}
