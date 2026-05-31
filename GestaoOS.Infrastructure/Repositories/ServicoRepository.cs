using GestaoOS.Application.Interface;
using GestaoOS.Domain.Entities;
using GestaoOS.Entities.Entities;
using GestaoOS.Infrastructure.Data;
using GestaoOS.Services.Interface;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoOS.Infrastructure.Repositories {
    public sealed class ServicoRepository : IServicoRepository {
        private readonly IDbConnectionFactory _connectionFactory;

        public ServicoRepository(IDbConnectionFactory connectionFactory) {
            _connectionFactory = connectionFactory;
        }

        public async Task AdicionarAsync(Servico servico) {
            const string sql = @"
                INSERT INTO gestao.servico
                (
                    nome,
                    valor_base,
                    percentual_imposto,
                    ativo
                )
                VALUES
                (
                    @nome,
                    @valorBase,
                    @percentualImposto,
                    @ativo
                );";

            using (var connection = _connectionFactory.CriarConexao()) {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand(sql, connection)) {
                    command.Parameters.AddWithValue("nome", servico.Nome);
                    command.Parameters.AddWithValue("valorBase", servico.ValorBase);
                    command.Parameters.AddWithValue("percentualImposto", servico.PercentualImposto);
                    command.Parameters.AddWithValue("ativo", servico.Ativo);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task AtualizarAsync(Servico servico) {
            const string sql = @"
                UPDATE gestao.servico
                SET
                    nome = @nome,
                    valor_base = @valorBase,
                    percentual_imposto = @percentualImposto,
                    ativo = @ativo
                WHERE servico_id = @servicoId;";

            using (var connection = _connectionFactory.CriarConexao()) {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand(sql, connection)) {
                    command.Parameters.AddWithValue("servicoId", servico.ServicoId);
                    command.Parameters.AddWithValue("nome", servico.Nome);
                    command.Parameters.AddWithValue("valorBase", servico.ValorBase);
                    command.Parameters.AddWithValue("percentualImposto", servico.PercentualImposto);
                    command.Parameters.AddWithValue("ativo", servico.Ativo);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ExcluirAsync(int servicoId) {
            const string sql = @"
                DELETE FROM gestao.servico
                WHERE servico_id = @servicoId;";

            using (var connection = _connectionFactory.CriarConexao()) {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand(sql, connection)) {
                    command.Parameters.AddWithValue("servicoId", servicoId);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<Servico> ObterPorIdAsync(int servicoId) {
            const string sql = @"
                SELECT
                    servico_id,
                    nome,
                    valor_base,
                    percentual_imposto,
                    ativo
                FROM gestao.servico
                WHERE servico_id = @servicoId;";

            using (var connection = _connectionFactory.CriarConexao()) {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand(sql, connection)) {
                    command.Parameters.AddWithValue("servicoId", servicoId);

                    using (var reader = await command.ExecuteReaderAsync()) {
                        if (await reader.ReadAsync())
                            return MapearServico(reader);
                    }
                }
            }

            return null;
        }

        public async Task<IReadOnlyCollection<Servico>> PesquisarAsync(string nome, bool? ativo) {
            var sql = @"
                SELECT
                    servico_id,
                    nome,
                    valor_base,
                    percentual_imposto,
                    ativo
                FROM gestao.servico
                WHERE 1=1 ";

            var parametros = new List<NpgsqlParameter>();

            if (!string.IsNullOrWhiteSpace(nome)) {
                sql += " AND nome ILIKE @nome ";
                parametros.Add(new NpgsqlParameter("nome", "%" + nome.Trim() + "%"));
            }

            if (ativo.HasValue) {
                sql += " AND ativo = @ativo ";
                parametros.Add(new NpgsqlParameter("ativo", ativo.Value));
            }

            sql += " ORDER BY nome;";

            var servicos = new List<Servico>();

            using (var connection = _connectionFactory.CriarConexao()) {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand(sql, connection)) {
                    command.Parameters.AddRange(parametros.ToArray());

                    using (var reader = await command.ExecuteReaderAsync()) {
                        while (await reader.ReadAsync()) {
                            servicos.Add(MapearServico(reader));
                        }
                    }
                }
            }

            return servicos;
        }

        private Servico MapearServico(NpgsqlDataReader reader) {
            return Servico.Reconstruir(
                Convert.ToInt32(reader["servico_id"]),
                reader["nome"].ToString(),
                Convert.ToDecimal(reader["valor_base"]),
                Convert.ToDecimal(reader["percentual_imposto"]),
                Convert.ToBoolean(reader["ativo"]));
        }
    }
}