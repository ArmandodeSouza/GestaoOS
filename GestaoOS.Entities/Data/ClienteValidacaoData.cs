using GestaoOS.Domain.Entities.Enum;
using GestaoOS.Domain.ValueObject;

namespace GestaoOS.Domain.Entities.ClienteData {
    public sealed class ClienteValidacaoData {

        public string Nome { get; }
        public Documento Documento { get; }
        public TipoPessoa TipoPessoa { get; }
        public Email Email { get; }
        public Telefone Telefone { get; }

        public ClienteValidacaoData(

            string nome,
            Documento documento,
            TipoPessoa tipoCliente,
            Email email,
            Telefone telefone) {

            Nome = nome;
            Documento = documento;
            TipoPessoa = tipoCliente;
            Email = email;
            Telefone = telefone;

        }

    }
}
