using GestaoOS.Services.DTORelatorio;
using GestaoOS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOS.Services.Services {
    public class RelatorioOsService : IRelatorioOsService {

        private readonly IRelatorioOsRepository _relatorioRepository;

        public RelatorioOsService(IRelatorioOsRepository relatorioRepository) {
            _relatorioRepository = relatorioRepository;
        }

        public async Task<IEnumerable<RelatorioOrdemServicoDto>> ListarOrdensServicoAsync(RelatorioOrdemServicoFiltroDto filtro) {

            if (filtro.DataInicial > filtro.DataFinal)
                throw new ArgumentException("A data inicial não pode ser maior que a data final.");

            return await _relatorioRepository.ListarOrdensServicoAsync(filtro);
        }

    }
}
