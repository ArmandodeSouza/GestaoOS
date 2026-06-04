using GestaoOS.Application.Enum;
using GestaoOS.Domain.Entities;
using GestaoOS.Domain.Enum;
using GestaoOS.Infrastructure.Data;
using GestaoOS.Services.DTOs;
using GestaoOS.Services.Interface;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoOS.Infra.Repositories {
    public sealed class OrdemServicoRepository : IOrdemServicoRepository {
        private readonly IDbConnectionFactory _connectionFactory;

        public OrdemServicoRepository(IDbConnectionFactory connectionFactory) {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AdicionarAsync(OrdemServico ordemServico) {
            if (ordemServico == null)
                throw new ArgumentNullException("ordemServico");

            using (var connection = _connectionFactory.CriarConexao()) {
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction()) {
                    try {
                        var ordemServicoId = await InserirOrdemServicoAsync(connection, transaction, ordemServico);

                        await InserirItensAsync(connection, transaction, ordemServicoId, ordemServico);

                        await InserirHistoricosAsync(connection, transaction, ordemServicoId, ordemServico);

                        transaction.Commit();

                        return ordemServicoId;
                    } catch {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private async Task<int> InserirOrdemServicoAsync(NpgsqlConnection connection, NpgsqlTransaction transaction, OrdemServico ordemServico) {
            const string sql = @"
                INSERT INTO gestao.ordem_servico
                (
                    cliente_id,
                    data_abertura,
                    data_conclusao,
                    status,
                    observacao,
                    valor_total,
                    versao
                )
                VALUES
                (
                    @cliente_id,
                    @data_abertura,
                    @data_conclusao,
                    @status,
                    @observacao,
                    @valor_total,
                    @versao
                )
                RETURNING ordem_servico_id;
            ";

            using (var command = new NpgsqlCommand(sql, connection, transaction)) {
                command.Parameters.AddWithValue("@cliente_id", ordemServico.ClienteId);
                command.Parameters.AddWithValue("@data_abertura", ordemServico.DataAbertura);
                command.Parameters.AddWithValue("@data_conclusao", (object)ordemServico.DataConclusao ?? DBNull.Value);
                command.Parameters.AddWithValue("@status", (int)ordemServico.Status);
                command.Parameters.AddWithValue("@observacao", (object)ordemServico.Observacao ?? DBNull.Value);
                command.Parameters.AddWithValue("@valor_total", ordemServico.ValorTotal);
                command.Parameters.AddWithValue("@versao", ordemServico.Versao);

                var id = await command.ExecuteScalarAsync();

                return Convert.ToInt32(id);
            }
        }

        private async Task InserirItensAsync(NpgsqlConnection connection, NpgsqlTransaction transaction, int ordemServicoId, OrdemServico ordemServico) {
            const string sql = @"
                INSERT INTO gestao.ordem_servico_item
                (
                    ordem_servico_id,
                    servico_id,
                    quantidade,
                    valor_unitario,
                    percentual_imposto_aplicado,
                    valor_total_item
                )
                VALUES
                (
                    @ordem_servico_id,
                    @servico_id,
                    @quantidade,
                    @valor_unitario,
                    @percentual_imposto_aplicado,
                    @valor_total_item
                );
            ";

            foreach (var item in ordemServico.Itens) {
                using (var command = new NpgsqlCommand(sql, connection, transaction)) {
                    command.Parameters.AddWithValue("@ordem_servico_id", ordemServicoId);
                    command.Parameters.AddWithValue("@servico_id", item.ServicoId);
                    command.Parameters.AddWithValue("@quantidade", item.Quantidade);
                    command.Parameters.AddWithValue("@valor_unitario", item.ValorUnitario);
                    command.Parameters.AddWithValue("@percentual_imposto_aplicado", item.PercentualImpostoAplicado);
                    command.Parameters.AddWithValue("@valor_total_item", item.ValorTotalItem);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        private async Task InserirHistoricosAsync(NpgsqlConnection connection, NpgsqlTransaction transaction, int ordemServicoId, OrdemServico ordemServico) {
            const string sql = @"
                INSERT INTO gestao.historico_status
                (
                    ordem_servico_id,
                    status_anterior,
                    status_novo,
                    data_hora,
                    usuario
                )
                VALUES
                (
                    @ordem_servico_id,
                    @status_anterior,
                    @status_novo,
                    @data_hora,
                    @usuario
                );
            ";

            foreach (var historico in ordemServico.Historicos) {
                using (var command = new NpgsqlCommand(sql, connection, transaction)) {
                    command.Parameters.AddWithValue("@ordem_servico_id", ordemServicoId);
                    command.Parameters.AddWithValue("@status_anterior", historico.StatusAnterior.HasValue ? (object)(int)historico.StatusAnterior.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@status_novo", (int)historico.StatusNovo);
                    command.Parameters.AddWithValue("@data_hora", historico.DataHora);
                    command.Parameters.AddWithValue("@usuario", (object)historico.Usuario ?? DBNull.Value);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task AtualizarAsync(OrdemServico ordemServico) {
            if (ordemServico == null)
                throw new ArgumentNullException("ordemServico");

            using (var connection = _connectionFactory.CriarConexao()) {
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction()) {
                    try {
                        await AtualizarOrdemServicoAsync(connection, transaction, ordemServico);

                        await RemoverItensAsync(connection, transaction, ordemServico.OrdemServicoId);

                        await InserirItensAsync(connection, transaction, ordemServico.OrdemServicoId, ordemServico);

                        await InserirHistoricosNovosAsync(connection, transaction, ordemServico.OrdemServicoId, ordemServico);

                        transaction.Commit();

                        ordemServico.IncrementarVersao();
                    } catch {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private async Task AtualizarOrdemServicoAsync(NpgsqlConnection connection, NpgsqlTransaction transaction, OrdemServico ordemServico) {
            const string sql = @"
        UPDATE gestao.ordem_servico
        SET
            cliente_id = @cliente_id,
            data_conclusao = @data_conclusao,
            status = @status,
            observacao = @observacao,
            valor_total = @valor_total,
            versao = versao + 1
        WHERE ordem_servico_id = @ordem_servico_id
        AND versao = @versao;
    ";

            using (var command = new NpgsqlCommand(sql, connection, transaction)) {
                command.Parameters.AddWithValue("@ordem_servico_id", ordemServico.OrdemServicoId);
                command.Parameters.AddWithValue("@cliente_id", ordemServico.ClienteId);
                command.Parameters.AddWithValue("@data_conclusao", (object)ordemServico.DataConclusao ?? DBNull.Value);
                command.Parameters.AddWithValue("@status", (int)ordemServico.Status);
                command.Parameters.AddWithValue("@observacao", (object)ordemServico.Observacao ?? DBNull.Value);
                command.Parameters.AddWithValue("@valor_total", ordemServico.ValorTotal);
                command.Parameters.AddWithValue("@versao", ordemServico.Versao);

                var linhasAfetadas = await command.ExecuteNonQueryAsync();

                if (linhasAfetadas == 0)
                    throw new InvalidOperationException("Esta Ordem de Serviço foi alterada por outro usuário. Reabra a tela e tente novamente.");
            }
        }

        private async Task RemoverItensAsync(NpgsqlConnection connection, NpgsqlTransaction transaction, int ordemServicoId) {
            const string sql = @"
        DELETE FROM gestao.ordem_servico_item
        WHERE ordem_servico_id = @ordem_servico_id;
    ";

            using (var command = new NpgsqlCommand(sql, connection, transaction)) {
                command.Parameters.AddWithValue("@ordem_servico_id", ordemServicoId);

                await command.ExecuteNonQueryAsync();
            }
        }
        public async Task<OrdemServico> ObterPorIdAsync(int ordemServicoId) {
            using (var connection = _connectionFactory.CriarConexao()) {
                await connection.OpenAsync();

                var ordemServico = await ObterOrdemServicoAsync(connection, ordemServicoId);

                if (ordemServico == null)
                    return null;

                await CarregarItensAsync(connection, ordemServico);
                await CarregarHistoricosAsync(connection, ordemServico);

                return ordemServico;
            }
        }

        private async Task<OrdemServico> ObterOrdemServicoAsync(NpgsqlConnection connection, int ordemServicoId) {
            const string sql = @"
        SELECT
            ordem_servico_id,
            cliente_id,
            data_abertura,
            data_conclusao,
            status,
            observacao,
            valor_total,
            versao
        FROM gestao.ordem_servico
        WHERE ordem_servico_id = @ordem_servico_id;
    ";

            using (var command = new NpgsqlCommand(sql, connection)) {
                command.Parameters.AddWithValue("@ordem_servico_id", ordemServicoId);

                using (var reader = await command.ExecuteReaderAsync()) {
                    if (await reader.ReadAsync())
                        return MapearOrdemServico(reader);
                }
            }

            return null;
        }

        private async Task CarregarItensAsync(NpgsqlConnection connection, OrdemServico ordemServico) {
            const string sql = @"
        SELECT
            ordem_servico_item_id,
            ordem_servico_id,
            servico_id,
            quantidade,
            valor_unitario,
            percentual_imposto_aplicado,
            valor_total_item
        FROM gestao.ordem_servico_item
        WHERE ordem_servico_id = @ordem_servico_id
        ORDER BY ordem_servico_item_id;
    ";

            using (var command = new NpgsqlCommand(sql, connection)) {
                command.Parameters.AddWithValue("@ordem_servico_id", ordemServico.OrdemServicoId);

                using (var reader = await command.ExecuteReaderAsync()) {
                    while (await reader.ReadAsync()) {
                        var item = OrdemServicoItem.Reconstruir(
                            Convert.ToInt32(reader["ordem_servico_item_id"]),
                            Convert.ToInt32(reader["ordem_servico_id"]),
                            Convert.ToInt32(reader["servico_id"]),
                            Convert.ToDecimal(reader["quantidade"]),
                            Convert.ToDecimal(reader["valor_unitario"]),
                            Convert.ToDecimal(reader["percentual_imposto_aplicado"]),
                            Convert.ToDecimal(reader["valor_total_item"]));

                        ordemServico.AdicionarItemCarregado(item);
                    }
                }
            }
        }

        private async Task CarregarHistoricosAsync(NpgsqlConnection connection, OrdemServico ordemServico) {
            const string sql = @"
        SELECT
            historico_status_id,
            ordem_servico_id,
            status_anterior,
            status_novo,
            data_hora,
            usuario
        FROM gestao.historico_status
        WHERE ordem_servico_id = @ordem_servico_id
        ORDER BY historico_status_id;
    ";

            using (var command = new NpgsqlCommand(sql, connection)) {
                command.Parameters.AddWithValue("@ordem_servico_id", ordemServico.OrdemServicoId);

                using (var reader = await command.ExecuteReaderAsync()) {
                    while (await reader.ReadAsync()) {
                        var historico = OrdemServicoHistoricoStatus.Reconstruir(
                            Convert.ToInt32(reader["historico_status_id"]),
                            Convert.ToInt32(reader["ordem_servico_id"]),
                            reader["status_anterior"] == DBNull.Value ? (StatusOrdemServicoDom?)null : (StatusOrdemServicoDom)Convert.ToInt32(reader["status_anterior"]),
                            (StatusOrdemServicoDom)Convert.ToInt32(reader["status_novo"]),
                            Convert.ToDateTime(reader["data_hora"]),
                            reader["usuario"] == DBNull.Value ? null : reader["usuario"].ToString());

                        ordemServico.AdicionarHistoricoCarregado(historico);
                    }
                }
            }
        }

        public async Task<IList<OrdemServico>> ListarAsync(int? clienteId, int? status, int pagina, int tamanhoPagina) {
            var ordens = new List<OrdemServico>();

            var offset = (pagina - 1) * tamanhoPagina;

            const string sql = @"
        SELECT
            ordem_servico_id,
            cliente_id,
            data_abertura,
            data_conclusao,
            status,
            observacao,
            valor_total,
            versao
        FROM gestao.ordem_servico
        WHERE (@cliente_id IS NULL OR cliente_id = @cliente_id)
          AND (@status IS NULL OR status = @status)
        ORDER BY ordem_servico_id DESC
        LIMIT @limit
        OFFSET @offset;
    ";

            using (var connection = _connectionFactory.CriarConexao()) {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand(sql, connection)) {
                    command.Parameters.AddWithValue("@cliente_id", (object)clienteId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@status", (object)status ?? DBNull.Value);
                    command.Parameters.AddWithValue("@limit", tamanhoPagina);
                    command.Parameters.AddWithValue("@offset", offset);

                    using (var reader = await command.ExecuteReaderAsync()) {
                        while (await reader.ReadAsync()) {
                            ordens.Add(MapearOrdemServico(reader));
                        }
                    }
                }
            }

            return ordens;
        }

        private OrdemServico MapearOrdemServico(NpgsqlDataReader reader) {
            return OrdemServico.Reconstruir(
                Convert.ToInt32(reader["ordem_servico_id"]),
                Convert.ToInt32(reader["cliente_id"]),
                Convert.ToDateTime(reader["data_abertura"]),
                reader["data_conclusao"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["data_conclusao"]),
                (StatusOrdemServicoDom)Convert.ToInt32(reader["status"]),
                reader["observacao"] == DBNull.Value ? null : reader["observacao"].ToString(),
                Convert.ToDecimal(reader["valor_total"]),
                Convert.ToInt32(reader["versao"]));
        }

        private async Task InserirHistoricosNovosAsync(NpgsqlConnection connection, NpgsqlTransaction transaction, int ordemServicoId, OrdemServico ordemServico) {

            const string sql = @"
        INSERT INTO gestao.historico_status
        (
            ordem_servico_id,
            status_anterior,
            status_novo,
            data_hora,
            usuario
        )
        VALUES
        (
            @ordem_servico_id,
            @status_anterior,
            @status_novo,
            @data_hora,
            @usuario
        );
    ";

            foreach (var historico in ordemServico.Historicos) {
                if (historico.OrdemServicoHistoricoStatusId > 0)
                    continue;

                using (var command = new NpgsqlCommand(sql, connection, transaction)) {
                    command.Parameters.AddWithValue("@ordem_servico_id", ordemServicoId);
                    command.Parameters.AddWithValue("@status_anterior", historico.StatusAnterior.HasValue ? (object)(int)historico.StatusAnterior.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@status_novo", (int)historico.StatusNovo);
                    command.Parameters.AddWithValue("@data_hora", historico.DataHora);
                    command.Parameters.AddWithValue("@usuario", (object)historico.Usuario ?? DBNull.Value);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<IList<OrdemServicoPesquisaDto>> PesquisarAsync(OrdemServicoFiltroDto filtro) {
            var ordens = new List<OrdemServicoPesquisaDto>();

            var offset = (filtro.Pagina - 1) * filtro.TamanhoPagina;

            var sql = @"
        SELECT
            os.ordem_servico_id,
            c.nome AS cliente,
            os.data_abertura,
            os.status,
            os.valor_total
        FROM gestao.ordem_servico os
        INNER JOIN gestao.cliente c
            ON c.cliente_id = os.cliente_id
        WHERE os.data_abertura >= @data_inicial
          AND os.data_abertura < @data_final
    ";

            if (filtro.TipoPesquisa == TipoPesquisaOrdemServico.OS) {
                sql += " AND os.ordem_servico_id = @ordem_servico_id ";
            }

            if (filtro.TipoPesquisa == TipoPesquisaOrdemServico.Cliente) {
                sql += " AND os.cliente_id = @cliente_id ";
            }

            if (filtro.TipoPesquisa == TipoPesquisaOrdemServico.Status) {
                sql += " AND os.status = @status ";
            }

            sql += @"
        ORDER BY os.ordem_servico_id DESC
        LIMIT @limit
        OFFSET @offset;
    ";

            using (var connection = _connectionFactory.CriarConexao()) {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand(sql, connection)) {
                    command.Parameters.AddWithValue("@data_inicial", filtro.DataInicial.Date);
                    command.Parameters.AddWithValue("@data_final", filtro.DataFinal.Date.AddDays(1));
                    command.Parameters.AddWithValue("@limit", filtro.TamanhoPagina);
                    command.Parameters.AddWithValue("@offset", offset);

                    if (filtro.TipoPesquisa == TipoPesquisaOrdemServico.OS) {
                        command.Parameters.AddWithValue(
                            "@ordem_servico_id",
                            filtro.OrdemServicoId.Value
                        );
                    }

                    if (filtro.TipoPesquisa == TipoPesquisaOrdemServico.Cliente) {
                        command.Parameters.AddWithValue(
                            "@cliente_id",
                            filtro.ClienteId.Value
                        );
                    }

                    if (filtro.TipoPesquisa == TipoPesquisaOrdemServico.Status) {
                        command.Parameters.AddWithValue(
                            "@status",
                            filtro.Status.Value
                        );
                    }

                    using (var reader = await command.ExecuteReaderAsync()) {
                        while (await reader.ReadAsync()) {
                            ordens.Add(new OrdemServicoPesquisaDto {
                                OrdemServicoId = Convert.ToInt32(reader["ordem_servico_id"]),
                                Cliente = reader["cliente"].ToString(),
                                DataAbertura = Convert.ToDateTime(reader["data_abertura"]),
                                Status = ((StatusOrdemServico)Convert.ToInt32(reader["status"])).ToString(),
                                ValorTotal = Convert.ToDecimal(reader["valor_total"])
                            });
                        }
                    }
                }
            }

            return ordens;
        }
    }
}