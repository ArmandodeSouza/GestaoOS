using System;

namespace GestaoOS.Domain.ValueObject {
    public sealed class Telefone {

        public string Valor { get; private set; }

        private Telefone(string numero) {
            Valor = numero;
        }

        public static Result<Telefone> Criar(string numero) {
            numero = numero?.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

            if (string.IsNullOrWhiteSpace(numero))
                return Result<Telefone>.Fail("Telefone obrigatório");

            foreach (var c in numero) {
                if (!char.IsDigit(c))
                    return Result<Telefone>.Fail("Telefone inválido");
            }

            if (numero.Length < 10 || numero.Length > 11)
                return Result<Telefone>.Fail("Telefone inválido");

            return Result<Telefone>.Ok(new Telefone(numero));
        }

        public static Telefone Reconstruir(string numero) {

            return new Telefone(numero);
        }
    }
}