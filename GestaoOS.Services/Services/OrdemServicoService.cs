using GestaoOS.Application;
using GestaoOS.Domain.Entities;
using GestaoOS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoOS.Services.Services {
    public sealed class OrdemServicoService : IOrdemServicoService {

        private readonly IOrdemServicoRepository _ordemServicoRepository;

        public OrdemServicoService(IOrdemServicoRepository ordemServicoRepository) {
            _ordemServicoRepository = ordemServicoRepository;
        }

        public async Task<Result<int>> AdicionarAsync(OrdemServico ordemServico) {
            if (ordemServico == null)
                return Result<int>.Fail("Ordem de Serviço inválida.");

            try {
                var id = await _ordemServicoRepository.AdicionarAsync(ordemServico);

                return Result<int>.Ok(id);
            } catch (Exception) {
                return Result<int>.Fail("Erro ao salvar a Ordem de Serviço.");
            }
        }

        public async Task<Result> AtualizarAsync(OrdemServico ordemServico) {
            if (ordemServico == null)
                return Result.Fail("Ordem de Serviço inválida.");

            try {
                await _ordemServicoRepository.AtualizarAsync(ordemServico);

                return Result.Ok();
            } catch (InvalidOperationException ex) {
                return Result.Fail(ex.Message);
            } catch (Exception) {
                return Result.Fail("Erro ao atualizar a Ordem de Serviço.");
            }
        }

        public async Task<Result<OrdemServico>> ObterPorIdAsync(int ordemServicoId) {
            if (ordemServicoId <= 0)
                return Result<OrdemServico>.Fail("Ordem de Serviço inválida.");

            try {
                var ordemServico = await _ordemServicoRepository.ObterPorIdAsync(ordemServicoId);

                if (ordemServico == null)
                    return Result<OrdemServico>.Fail("Ordem de Serviço não encontrada.");

                return Result<OrdemServico>.Ok(ordemServico);
            } catch (Exception) {
                return Result<OrdemServico>.Fail("Erro ao buscar a Ordem de Serviço.");
            }
        }

        public async Task<Result<IList<OrdemServico>>> ListarAsync(int? clienteId, int? status, int pagina, int tamanhoPagina) {
            try {
                var ordens = await _ordemServicoRepository.ListarAsync(clienteId, status, pagina, tamanhoPagina);

                return Result<IList<OrdemServico>>.Ok(ordens);
            } catch (Exception) {
                return Result<IList<OrdemServico>>.Fail("Erro ao listar Ordens de Serviço.");
            }
        }
    }
}
