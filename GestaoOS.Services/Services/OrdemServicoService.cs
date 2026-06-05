using GestaoOS.Application;
using GestaoOS.Application.Enum;
using GestaoOS.Application.Interface;
using GestaoOS.Domain.Entities;
using GestaoOS.Services.DTOs;
using GestaoOS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoOS.Services.Services {
    public sealed class OrdemServicoService : IOrdemServicoService {

        private readonly IOrdemServicoRepository _ordemServicoRepository;
        private readonly IClienteService _clienteService;
        private readonly IServicoService _servicoService;

        public OrdemServicoService(IOrdemServicoRepository ordemServicoRepository, IClienteService clienteService, IServicoService servicoService) {
            _ordemServicoRepository = ordemServicoRepository;
            _clienteService = clienteService;
            _servicoService = servicoService;
        }

        public async Task<Result<int>> AdicionarAsync(OrdemServicoCadastroDto dto) {
            if (dto == null)
                return Result<int>.Fail("Ordem de Serviço inválida.");

            if (dto.ClienteId <= 0)
                return Result<int>.Fail("Cliente inválido.");

            if (dto.Itens == null || dto.Itens.Count == 0)
                return Result<int>.Fail("Adicione ao menos um item.");

            try {
                var ordemServico = new OrdemServico(
                    dto.ClienteId,
                    dto.Observacao
                );

                foreach (var itemDto in dto.Itens) {
                    var item = new OrdemServicoItem(
                        itemDto.ServicoId,
                        itemDto.Quantidade,
                        itemDto.ValorUnitario,
                        itemDto.ImpostoAplicado
                    );

                    ordemServico.AdicionarItem(item);

                }
                var ordemservicoId = await _ordemServicoRepository.AdicionarAsync(ordemServico);

                return Result<int>.Ok(ordemservicoId);
            } catch (Exception ex) {
                return Result<int>.Fail(ex.ToString());
            }
        }

        public async Task<Result> AtualizarAsync(OrdemServicoCadastroDto dto) {
            if (dto == null)
                return Result.Fail("Ordem de Serviço inválida.");

            if (dto.OrdemServicoId <= 0)
                return Result.Fail("Ordem de Serviço inválida.");

            if (dto.ClienteId <= 0)
                return Result.Fail("Cliente inválido.");

            if (dto.Itens == null || dto.Itens.Count == 0)
                return Result.Fail("Adicione ao menos um item.");

            try {
                var ordemServico = await _ordemServicoRepository.ObterPorIdAsync(dto.OrdemServicoId);

                if (ordemServico == null)
                    return Result.Fail("Ordem de Serviço não encontrada.");

                if (ordemServico.Versao != dto.Versao)
                    return Result.Fail("Esta Ordem de Serviço foi alterada por outro usuário. Reabra a tela e tente novamente.");

                ordemServico.AtualizarObservacao(dto.Observacao);

                foreach (var itemAtual in ordemServico.Itens.ToList()) {
                    ordemServico.RemoverItem(itemAtual);
                }

                foreach (var itemDto in dto.Itens) {
                    var item = new OrdemServicoItem(
                        itemDto.ServicoId,
                        itemDto.Quantidade,
                        itemDto.ValorUnitario,
                        itemDto.ImpostoAplicado
                    );

                    ordemServico.AdicionarItem(item);
                }

                await _ordemServicoRepository.AtualizarAsync(ordemServico);

                return Result.Ok();
            } catch (Exception ex) {
                return Result.Fail(ex.ToString());
            }
        }

        public async Task<Result<OrdemServicoEdicaoDto>> ObterPorIdAsync(int ordemServicoId) {
            if (ordemServicoId <= 0)
                return Result<OrdemServicoEdicaoDto>.Fail("Ordem de Serviço inválida.");

            try {
                var ordemServico = await _ordemServicoRepository.ObterPorIdAsync(ordemServicoId);

                if (ordemServico == null)
                    return Result<OrdemServicoEdicaoDto>.Fail("Ordem de Serviço não encontrada.");

                var clientes = await _clienteService.ListarClienteAsync();

                if (!clientes.Success)
                    return Result<OrdemServicoEdicaoDto>.Fail(clientes.Error);

                var servicos = await _servicoService.ListarServicoAsync();

                if (!servicos.Success)
                    return Result<OrdemServicoEdicaoDto>.Fail(servicos.Error);

                var cliente = clientes.Value.FirstOrDefault(x => x.ClienteId == ordemServico.ClienteId);

                var dto = new OrdemServicoEdicaoDto {
                    OrdemServicoId = ordemServico.OrdemServicoId,
                    ClienteId = ordemServico.ClienteId,
                    Cliente = cliente == null ? string.Empty : cliente.Nome,
                    DataAbertura = ordemServico.DataAbertura,
                    DataFechamento = ordemServico.DataConclusao,
                    Status = (StatusOrdemServico)(int)ordemServico.Status,
                    Observacao = ordemServico.Observacao,
                    ValorTotal = ordemServico.ValorTotal,
                    Versao = ordemServico.Versao,
                    Itens = ordemServico.Itens.Select(x => {
                        var servico = servicos.Value.FirstOrDefault(s => s.ServicoId == x.ServicoId);

                        return new OrdemServicoItemEdicaoDto {
                            OrdemServicoItemId = x.OrdemServicoItemId,
                            ServicoId = x.ServicoId,
                            NomeServico = servico == null ? string.Empty : servico.Nome,
                            Quantidade = x.Quantidade,
                            ValorUnitario = x.ValorUnitario,
                            ImpostoAplicado = x.PercentualImpostoAplicado,
                            ValorTotalItem = x.ValorTotalItem
                        };
                    }).ToList()
                };

                return Result<OrdemServicoEdicaoDto>.Ok(dto);
            } catch (Exception ex) {
                return Result<OrdemServicoEdicaoDto>.Fail(ex.ToString());
            }
        }

        public async Task<Result<IList<OrdemServico>>> ListarAsync(int? clienteId, int? status, int pagina, int tamanhoPagina) {

            if (pagina <= 0)
                return Result<IList<OrdemServico>>.Fail("Página inválida.");

            if (tamanhoPagina <= 0)
                return Result<IList<OrdemServico>>.Fail("Tamanho da página inválido.");

            try {
                var ordens = await _ordemServicoRepository.ListarAsync(clienteId, status, pagina, tamanhoPagina);

                return Result<IList<OrdemServico>>.Ok(ordens);
            } catch (Exception) {
                return Result<IList<OrdemServico>>.Fail("Erro ao listar Ordens de Serviço.");
            }
        }
        public async Task<Result> CancelarAsync(int ordemServicoId, string usuario) {
            if (ordemServicoId <= 0)
                return Result.Fail("Código da Ordem de Serviço inválido.");

            if (string.IsNullOrWhiteSpace(usuario))
                return Result.Fail("Usuário é obrigatório para cancelar a OS.");

            try {
                var ordemServico = await _ordemServicoRepository.ObterPorIdAsync(ordemServicoId);

                if (ordemServico == null)
                    return Result.Fail("Ordem de Serviço não encontrada.");

                ordemServico.Cancelar(usuario);

                await _ordemServicoRepository.AtualizarAsync(ordemServico);

                return Result.Ok();
            } catch (Exception ex) {
                return Result.Fail(ex.Message);
            }
        }
        public async Task<Result> ConcluirAsync(int ordemServicoId, string usuario) {
            if (ordemServicoId <= 0)
                return Result.Fail("Código da Ordem de Serviço inválido.");

            if (string.IsNullOrWhiteSpace(usuario))
                return Result.Fail("Usuário é obrigatório para finalizar a OS.");

            try {
                var ordemServico = await _ordemServicoRepository.ObterPorIdAsync(ordemServicoId);

                if (ordemServico == null)
                    return Result.Fail("Ordem de Serviço não encontrada.");

                ordemServico.Concluir(usuario);

                await _ordemServicoRepository.AtualizarAsync(ordemServico);

                return Result.Ok();
            } catch (Exception ex) {
                return Result.Fail(ex.Message);
            }
        }

        public async Task<Result<IList<OrdemServicoPesquisaDto>>> PesquisarAsync(OrdemServicoFiltroDto filtro) {
            if (filtro == null)
                return Result<IList<OrdemServicoPesquisaDto>>
                    .Fail("Filtro inválido.");

            if (filtro.Pagina <= 0)
                return Result<IList<OrdemServicoPesquisaDto>>
                    .Fail("Página inválida.");

            if (filtro.TamanhoPagina <= 0)
                return Result<IList<OrdemServicoPesquisaDto>>
                    .Fail("Tamanho da página inválido.");

            try {
                var ordens = await _ordemServicoRepository.PesquisarAsync(filtro);

                return Result<IList<OrdemServicoPesquisaDto>>
                    .Ok(ordens);
            } catch (Exception ex) {
                return Result<IList<OrdemServicoPesquisaDto>>
                    .Fail(ex.Message);
            }
        }
    }
}
