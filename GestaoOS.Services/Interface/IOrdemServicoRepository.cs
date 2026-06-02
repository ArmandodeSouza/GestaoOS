using GestaoOS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOS.Services.Interface {
    public interface IOrdemServicoRepository {
        Task<int> AdicionarAsync(OrdemServico ordemServico);

        Task AtualizarAsync(OrdemServico ordemServico);

        Task<OrdemServico> ObterPorIdAsync(int ordemServicoId);

        Task<IList<OrdemServico>> ListarAsync(int? clienteId, int? status, int pagina, int tamanhoPagina);
    }
}
