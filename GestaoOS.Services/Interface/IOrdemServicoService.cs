using GestaoOS.Application;
using GestaoOS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoOS.Services.Interface {
    public interface IOrdemServicoService {
        Task<Result<int>> AdicionarAsync(OrdemServico ordemServico);

        Task<Result> AtualizarAsync(OrdemServico ordemServico);

        Task<Result<OrdemServico>> ObterPorIdAsync(int ordemServicoId);

        Task<Result<IList<OrdemServico>>> ListarAsync(int? clienteId, int? status, int pagina, int tamanhoPagina);
    }
}
