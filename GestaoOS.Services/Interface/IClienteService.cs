using GestaoOS.Application;
using GestaoOS.Domain.Entities.Cliente;
using GestaoOS.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoOS.Application.Interface {
    public interface IClienteService {
        Task<Result> AdicionarAsync(string nome, string documento, int tipoPessoa, string email, string telefone, bool? ativo);
        Task<Result<ClientePesquisaDto>> ObterPorIdAsync(int clienteId);
        Task<Result> AtualizarAsync(int clienteId, string nome, string documento, int tipoPessoa, string email, string telefone, bool ativo);
        Task<Result> ExcluirAsync(int clienteId);
        Task<Result<IReadOnlyCollection<ClientePesquisaDto>>> PesquisarAsync(string nome, string documento, bool? ativo);
        Task<Result<List<ClientePesquisaDto>>> ListarClienteAsync();
    }
}