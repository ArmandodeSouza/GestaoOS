
using GestaoOS.Domain.Entities.ClienteData;
using GestaoOS.Domain.Entities.Enum;
using GestaoOS.Domain.ValueObject;
using System;


namespace GestaoOS.Domain.Entities.Cliente {
    public sealed class Cliente {

        private const int NomeMinimo = 3;
        private const int NomeMaximo = 150;
        private const string NomeInvalido = "Nome não pode ser vazio ou menor que 3 dígitos";
        private const string NomeMaiorQuePermitido = "Nome maior que o permitido";
        private const string DocumentoObrigatorio = "Documento é obrigatório";
        private const string CpfObrigatorioPessoaFisica = "Pessoa física deve possuir CPF";
        private const string CnpjObrigatorioPessoaJuridica = "Pessoa jurídica deve possuir CNPJ";
        private const string EmailObrigatorio = "Email é obrigatório";
        private const string TelefoneObrigatorio = "Telefone é obrigatório";
        private const string ClienteJaAtivo = "Cliente já está ativo";
        private const string ClienteJaInativo = "Cliente já está inativo";

        public int ClienteId { get; private set; }
        public string Nome { get; private set; }
        public Documento Documento { get; private set; }
        public TipoPessoa TipoPessoa { get; private set; }
        public Email Email { get; private set; }
        public Telefone Telefone { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCadastro { get; private set; }


        private Cliente(ClienteValidacaoData dados) {
            Nome = dados.Nome;
            Documento = dados.Documento;
            TipoPessoa = dados.TipoPessoa;
            Email = dados.Email;
            Telefone = dados.Telefone;
            Ativo = true;
            DataCadastro = DateTime.UtcNow;
        }

        private Cliente(int clienteId, string nome, Documento documento, TipoPessoa tipoPessoa, Email email, Telefone telefone, bool ativo) {
            ClienteId = clienteId;
            Nome = nome;
            Documento = documento;
            TipoPessoa = tipoPessoa;
            Email = email;
            Telefone = telefone;
            Ativo = ativo;

        }

        public static Result<Cliente> Criar(string nome, Documento documento, TipoPessoa tipoPessoa, Email email, Telefone telefone) {
            var validacao = Validar(nome, documento, tipoPessoa, email, telefone);

            if (!validacao.Success)
                return Result<Cliente>.Fail(validacao.Error);

            var cliente = new Cliente(validacao.Value);

            return Result<Cliente>.Ok(cliente);
        }

        public Result AtualizarDados(string nome, Documento documento, TipoPessoa tipoPessoa, Email email, Telefone telefone) {
            var validacao = Validar(nome, documento, tipoPessoa, email, telefone);

            if (!validacao.Success)
                return Result.Fail(validacao.Error);

            Nome = validacao.Value.Nome;
            Documento = validacao.Value.Documento;
            TipoPessoa = validacao.Value.TipoPessoa;
            Email = validacao.Value.Email;
            Telefone = validacao.Value.Telefone;

            return Result.Ok();
        }

        public static Cliente Reconstruir(int clienteId, string nome, Documento documento, TipoPessoa tipoPessoa, Email email, Telefone telefone, bool ativo) {
            return new Cliente(clienteId, nome, documento, tipoPessoa, email, telefone, ativo);
        }

        public Result Ativar() {
            if (Ativo)
                return Result.Fail(ClienteJaAtivo);

            Ativo = true;

            return Result.Ok();
        }

        public Result Desativar() {
            if (!Ativo)
                return Result.Fail(ClienteJaInativo);

            Ativo = false;

            return Result.Ok();
        }

        private static Result<ClienteValidacaoData> Validar(string nome, Documento documento, TipoPessoa tipoPessoa, Email email, Telefone telefone) {

            nome = nome?.Trim();

            if (string.IsNullOrWhiteSpace(nome) || nome.Length < NomeMinimo) {
                return Result<ClienteValidacaoData>.Fail(NomeInvalido);
            }

            if (nome.Length > NomeMaximo) {
                return Result<ClienteValidacaoData>.Fail(NomeMaiorQuePermitido);
            }

            if (documento == null) {
                return Result<ClienteValidacaoData>.Fail(DocumentoObrigatorio);
            }

            if (tipoPessoa == TipoPessoa.Fisica && !documento.EhCpf) {
                return Result<ClienteValidacaoData>.Fail(CpfObrigatorioPessoaFisica);
            }

            if (tipoPessoa == TipoPessoa.Juridica && !documento.EhCnpj) {
                return Result<ClienteValidacaoData>.Fail(CnpjObrigatorioPessoaJuridica);
            }

            if (email == null) {
                return Result<ClienteValidacaoData>.Fail(EmailObrigatorio);
            }

            if (telefone == null) {
                return Result<ClienteValidacaoData>.Fail(TelefoneObrigatorio);
            }

            return Result<ClienteValidacaoData>.Ok(new ClienteValidacaoData(nome, documento, tipoPessoa, email, telefone));
        }
    }
}