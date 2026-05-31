using System;

namespace GestaoOS.Domain.ValueObject {
    public sealed class Email {

        public string Valor { get; private set; }

        private Email(string endereco) {
            Valor = endereco;
        }

        public static Result<Email> Criar(string endereco) {
            endereco = endereco?.Trim();

            if (string.IsNullOrWhiteSpace(endereco))
                return Result<Email>.Fail("Email obrigatório");

            if (!endereco.Contains("@") || !endereco.Contains("."))
                return Result<Email>.Fail("Email inválido");

            return Result<Email>.Ok(new Email(endereco));
        }

        public static Email Reconstruir(string endereco) {

            return new Email(endereco);
        }
    }
}