using GestaoOS.Application;
using GestaoOS.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOS.Services.Interface {
    public interface IServicoService {

        Task<Result> AdicionarAsync(string nome, decimal valorBase, decimal PercentualImposto);
        Task<Result> AtualizarAsync(int servicoId, string nome, decimal valorBase, decimal PercentualImposto, bool ativo);
        Task<Result> ExcluirAsync(int servicoId);
        Task<Result<ServicoPesquisaDto>> ObterPorIdAsync(int servicoId);
        Task<Result<IReadOnlyCollection<ServicoPesquisaDto>>> PesquisarAsync(string nome, bool? ativo);

    }
}
