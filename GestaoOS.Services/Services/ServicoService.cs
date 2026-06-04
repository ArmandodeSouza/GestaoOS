using GestaoOS.Application;
using GestaoOS.Services.Interface;
using System.Threading.Tasks;
using System.Linq;
using GestaoOS.Entities.Entities;
using GestaoOS.Services.DTOs;
using System.Collections.Generic;

namespace GestaoOS.Services.Services {
    public sealed class ServicoService : IServicoService {

        public readonly IServicoRepository _servicoRepository;

        public ServicoService(IServicoRepository servicoRepository) {
            _servicoRepository = servicoRepository;
        }

        public async Task<Result> AdicionarAsync(string nome, decimal valorBase, decimal PercentualImposto) {
            var ServicoResult = Servico.Criar(nome, valorBase, PercentualImposto);

            if (!ServicoResult.Success)
                return Result.Fail(ServicoResult.Error);

            await _servicoRepository.AdicionarAsync(ServicoResult.Value);

            return Result.Ok();
        }

        public async Task<Result> AtualizarAsync(int servicoId, string nome, decimal valorBase, decimal PercentualImposto, bool ativo) {
            var servico = Servico.Reconstruir(servicoId, nome, valorBase, PercentualImposto, ativo);
            await _servicoRepository.AtualizarAsync(servico);
            return Result.Ok();
        }

        public Task<Result> ExcluirAsync(int servicoId) {
            throw new System.NotImplementedException();
        }

        public async Task<Result<List<ServicoPesquisaDto>>> ListarServicoAsync() {
            var servicos = await _servicoRepository.ListarServicoAsync();

            if (servicos == null || servicos.Count == 0)
                return Result<List<ServicoPesquisaDto>>.Fail("Nenhum serviço encontrado.");

            return Result<List<ServicoPesquisaDto>>.Ok(servicos);
        }

        public async Task<Result<ServicoPesquisaDto>> ObterPorIdAsync(int servicoId) {
            var servico = await _servicoRepository.ObterPorIdAsync(servicoId);

            if (servico == null)
                return Result<ServicoPesquisaDto>.Fail("Servico não encontrado.");

            var dto = new ServicoPesquisaDto {
                ServicoId = servico.ServicoId,
                Nome = servico.Nome,
                ValorBase = servico.ValorBase,
                PercentualImposto = servico.PercentualImposto,
                Ativo = servico.Ativo
            };

            return Result<ServicoPesquisaDto>.Ok(dto);
        }

        public async Task<Result<IReadOnlyCollection<ServicoPesquisaDto>>> PesquisarAsync(string nome, bool? ativo) {
            var servicos = await _servicoRepository.PesquisarAsync(nome, ativo);

            var dto = servicos.Select(s => new ServicoPesquisaDto {
                ServicoId = s.ServicoId,
                Nome = s.Nome,
                ValorBase = s.ValorBase,
                PercentualImposto = s.PercentualImposto,
                Ativo = s.Ativo
            }).ToList();

            return Result<IReadOnlyCollection<ServicoPesquisaDto>>.Ok(dto);
        }
    }
}
