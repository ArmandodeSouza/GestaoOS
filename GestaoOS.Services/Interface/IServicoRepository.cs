using GestaoOS.Application;
using GestaoOS.Entities.Entities;
using GestaoOS.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOS.Services.Interface {
    public interface IServicoRepository {

        Task AdicionarAsync(Servico servico);

        Task AtualizarAsync(Servico servico);

        Task ExcluirAsync(int servicoId);

        Task<Servico> ObterPorIdAsync(int clienteId);

        Task<IReadOnlyCollection<Servico>> PesquisarAsync(string nome, bool? ativo);

        Task<List<ServicoPesquisaDto>> ListarServicoAsync();
    }
}
