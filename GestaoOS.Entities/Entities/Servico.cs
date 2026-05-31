using GestaoOS.Domain;
using GestaoOS.Domain.Entities.ClienteData;
using GestaoOS.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOS.Entities.Entities {
    public sealed class Servico {

        private const int NomeMinimo = 3;
        private const int NomeMaximo = 150;
        private const string NomeInvalido = "Nome não pode ser vazio ou menor que 3 dígitos";
        private const string NomeMaiorQuePermitido = "Nome maior que o permitido";
        private const string ValorMaiorQue = "Valor base deve ser maior que zero.";
        private const string PercentualEntre = "Percentual de imposto deve estar entre 0 e 100.";


        public int ServicoId { get; private set; }
        public string Nome { get; private set; }
        public decimal ValorBase { get; private set; }
        public decimal PercentualImposto { get; private set; }
        public bool Ativo { get; private set; }


        private Servico(ServicoValidacaoData dados) {
            Nome = dados.Nome;
            ValorBase = dados.ValorBase;
            PercentualImposto = dados.PercentualImposto;
            Ativo = true;
        }

        private Servico(int servicoId, string nome, decimal valorBase, decimal percentualImposto, bool ativo) {
            ServicoId = servicoId;
            Nome = nome;
            ValorBase = valorBase;
            PercentualImposto = percentualImposto;
            Ativo = ativo;
        }

        public static Result<Servico> Criar(string nome, decimal valorBase, decimal percentualImposto) {
            var validacao = Validar(nome, valorBase, percentualImposto);

            if (!validacao.Success)
                return Result<Servico>.Fail(validacao.Error);

            var servico = new Servico(validacao.Value);

            return Result<Servico>.Ok(servico);
        }

        public static Servico Reconstruir(int servicoId, string nome, decimal valorBase, decimal percentualImposto, bool ativo) {
            return new Servico(servicoId, nome, valorBase, percentualImposto, ativo);
        }

        public Result AtualizarDados(string nome, decimal valorBase, decimal percentualImposto, bool ativo) {
            var validacao = Validar(nome, valorBase, percentualImposto);

            if (!validacao.Success)
                return validacao;

            Nome = nome.Trim();
            ValorBase = valorBase;
            PercentualImposto = percentualImposto;
            Ativo = ativo;

            return Result.Ok();
        }

        private static Result<ServicoValidacaoData> Validar(string nome, decimal valorBase, decimal percentualImposto) {

            nome = nome?.Trim();

            if (string.IsNullOrWhiteSpace(nome) || nome.Length < NomeMinimo) {
                return Result<ServicoValidacaoData>.Fail(NomeInvalido);
            }

            if (nome.Length > NomeMaximo) {
                return Result<ServicoValidacaoData>.Fail(NomeMaiorQuePermitido);
            }

            if (valorBase <= 0)
                return Result<ServicoValidacaoData>.Fail(ValorMaiorQue);

            if (percentualImposto < 0 || percentualImposto > 100)
                return Result<ServicoValidacaoData>.Fail(PercentualEntre);


            return Result<ServicoValidacaoData>.Ok(new ServicoValidacaoData(nome, valorBase, percentualImposto));
        }
    }
}
