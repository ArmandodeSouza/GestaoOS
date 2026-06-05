using GestaoOS.Application;
using GestaoOS.Domain.Entities;
using GestaoOS.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoOS.Services.Interface {
    public interface IOrdemServicoService {
        Task<Result<int>> AdicionarAsync(OrdemServicoCadastroDto dto);

        Task<Result> AtualizarAsync(OrdemServicoCadastroDto dto);

        Task<Result<OrdemServicoEdicaoDto>> ObterPorIdAsync(int ordemServicoId);
        Task<Result<IList<OrdemServico>>> ListarAsync(int? clienteId, int? status, int pagina, int tamanhoPagina);

        Task<Result> ConcluirAsync(int ordemServicoId, string usuario);
        Task<Result> CancelarAsync(int ordemServicoId, string usuario);

        Task<Result<IList<OrdemServicoPesquisaDto>>> PesquisarAsync(OrdemServicoFiltroDto filtro);
    }
}
