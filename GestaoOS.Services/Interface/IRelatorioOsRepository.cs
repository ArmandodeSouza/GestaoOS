using GestaoOS.Services.DTORelatorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOS.Services.Interface {
    public interface IRelatorioOsRepository {

        Task<IEnumerable<RelatorioOrdemServicoDto>> ListarOrdensServicoAsync(RelatorioOrdemServicoFiltroDto filtro);

    }
}
