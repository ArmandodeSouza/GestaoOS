using System;

namespace GestaoOS.Domain.ValueObject {
    public sealed class Documento {

        public string Valor { get; private set; }
        public bool EhCpf => Valor.Length == 11;
        public bool EhCnpj => Valor.Length == 14;

        private Documento(string numero) {
            Valor = numero;
        }

        public static Result<Documento> Criar(string numero) {
            numero = numero?.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

            if (string.IsNullOrWhiteSpace(numero))
                return Result<Documento>.Fail("Documento obrigatório");

            foreach (var c in numero) {
                if (!char.IsDigit(c))
                    return Result<Documento>.Fail("Documento inválido");
            }

            if (numero.Length != 11 && numero.Length != 14)
                return Result<Documento>.Fail("Documento inválido");

            return Result<Documento>.Ok(new Documento(numero));
        }

        public static Documento Reconstruir(string numero) {

            return new Documento(numero);
        }

    }
}