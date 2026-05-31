using GestaoOS.Application.Interface;
using GestaoOS.Domain.Entities.Cliente;
using GestaoOS.Domain.Entities.Enum;
using GestaoOS.Domain.ValueObject;
using GestaoOS.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoOS.Application.Services {
    public sealed class ClienteService : IClienteService {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository) {
            _clienteRepository = clienteRepository;
        }

        public async Task<Result> AdicionarAsync(string nome, string documento, int tipoPessoa, string email, string telefone, bool? ativo) {


            var documentoResult = Documento.Criar(documento);

            if (!documentoResult.Success)
                return Result.Fail(documentoResult.Error);

            var emailResult = Email.Criar(email);

            if (!emailResult.Success)
                return Result.Fail(emailResult.Error);

            var telefoneResult = Telefone.Criar(telefone);

            if (!telefoneResult.Success)
                return Result.Fail(telefoneResult.Error);

            if (!Enum.IsDefined(typeof(TipoPessoa), tipoPessoa))
                return Result.Fail("Tipo de pessoa inválido.");

            var tipoPessoaEnum = (TipoPessoa)tipoPessoa;

            var clienteResult = Cliente.Criar(
                nome,
                documentoResult.Value,
                tipoPessoaEnum,
                emailResult.Value,
                telefoneResult.Value);

            if (!clienteResult.Success)
                return Result.Fail(clienteResult.Error);

            await _clienteRepository.AdicionarAsync(clienteResult.Value);

            return Result.Ok();


        }

        public async Task<Result> AtualizarAsync(int clienteId, string nome, string documento, int tipoPessoa, string email, string telefone, bool ativo) {
            var documentoResult = Documento.Criar(documento);
            if (!documentoResult.Success)
                return Result.Fail(documentoResult.Error);

            var emailResult = Email.Criar(email);
            if (!emailResult.Success)
                return Result.Fail(emailResult.Error);

            var telefoneResult = Telefone.Criar(telefone);
            if (!telefoneResult.Success)
                return Result.Fail(telefoneResult.Error);

            if (!Enum.IsDefined(typeof(TipoPessoa), tipoPessoa))
                return Result.Fail("Tipo de pessoa inválido.");

            var tipoPessoaEnum = (TipoPessoa)tipoPessoa;

            var cliente = Cliente.Reconstruir(clienteId, nome, documentoResult.Value, tipoPessoaEnum, emailResult.Value, telefoneResult.Value, ativo);

            await _clienteRepository.AtualizarAsync(cliente);

            return Result.Ok();
        }

        public Task<Result> ExcluirAsync(int clienteId) {
            throw new NotImplementedException();
        }

        public async Task<Result<ClientePesquisaDto>> ObterPorIdAsync(int clienteId) {
            var cliente = await _clienteRepository.ObterPorIdAsync(clienteId);

            if (cliente == null)
                return Result<ClientePesquisaDto>.Fail("Cliente não encontrado.");

            var dto = new ClientePesquisaDto {
                ClienteId = cliente.ClienteId,
                Nome = cliente.Nome,
                Documento = cliente.Documento.Valor,
                TipoPessoa = (int)cliente.TipoPessoa,
                Email = cliente.Email.Valor,
                Telefone = cliente.Telefone.Valor,
                Ativo = cliente.Ativo
            };

            return Result<ClientePesquisaDto>.Ok(dto);
        }

        public async Task<Result<IReadOnlyCollection<ClientePesquisaDto>>> PesquisarAsync(string nome, string documento, bool? ativo) {
            var clientes = await _clienteRepository.PesquisarAsync(nome, documento, ativo);

            var dto = clientes.Select(c => new ClientePesquisaDto {
                ClienteId = c.ClienteId,
                Nome = c.Nome,
                Documento = c.Documento.Valor,
                Email = c.Email.Valor,
                Telefone = c.Telefone.Valor,
                Ativo = c.Ativo
            }).ToList();

            return Result<IReadOnlyCollection<ClientePesquisaDto>>.Ok(dto);
        }
    }
}