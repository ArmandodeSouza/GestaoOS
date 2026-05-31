using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOS.Entities.Data {
    public sealed class ServicoValidacaoData {

        public string Nome { get; }
        public decimal ValorBase { get; }
        public decimal PercentualImposto { get; }

        public ServicoValidacaoData(
            string nome,
            decimal valorBase,
            decimal percentualImposto) {
            Nome = nome;
            ValorBase = valorBase;
            PercentualImposto = percentualImposto;
        }

    }
}
