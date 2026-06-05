using GestaoOS.Domain.Entities.Cliente;
using GestaoOS.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoOS.Application.Interface {
    public interface IClienteRepository {
        Task<Cliente> ObterPorIdAsync(int clienteId);

        Task AdicionarAsync(Cliente cliente);

        Task AtualizarAsync(Cliente cliente);

        Task ExcluirAsync(int clienteId);

        Task<IReadOnlyCollection<Cliente>> PesquisarAsync(string nome, string documento, bool? ativo);

        Task<List<ClientePesquisaDto>> ListarClienteAsync();

        Task<bool> PossuiOrdemServicoAsync(int clienteId);
    }
}