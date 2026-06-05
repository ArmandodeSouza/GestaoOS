using GestaoOS.Infrastructure.Data;
using GestaoOS.Services.DTORelatorio;
using GestaoOS.Services.Interface;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOS.Infrastructure.Repositories {
    public class RelatorioOsRepository : IRelatorioOsRepository {

        private readonly IDbConnectionFactory _connectionFactory;

        public RelatorioOsRepository(IDbConnectionFactory connectionFactory) {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<RelatorioOrdemServicoDto>> ListarOrdensServicoAsync(
    RelatorioOrdemServicoFiltroDto filtro) {

            var lista = new List<RelatorioOrdemServicoDto>();

            using (var connection = _connectionFactory.CriarConexao())
            using (var command = connection.CreateCommand()) {

                command.CommandText = @"
            SELECT
                os.ordem_servico_id,
                c.cliente_id,
                c.nome,
                os.data_abertura,
                os.status,
                os.valor_total,
                COALESCE(
                    SUM(
                        (osi.quantidade * osi.valor_unitario) +
                        (osi.percentual_imposto_aplicado)
                    ),
                    0
                ) AS total_imposto
            FROM gestao.ordem_servico os
            INNER JOIN gestao.cliente c
                ON c.cliente_id = os.cliente_id
            LEFT JOIN gestao.ordem_servico_item osi
                ON osi.ordem_servico_id = os.ordem_servico_id
            WHERE os.data_abertura >= @dataInicial
              AND os.data_abertura < @dataFinal
              AND (@clienteId IS NULL OR os.cliente_id = @clienteId)
              AND (@status IS NULL OR os.status = @status)
            GROUP BY
                os.ordem_servico_id,
                c.cliente_id,
                c.nome,
                os.data_abertura,
                os.status,
                os.valor_total
            ORDER BY
                c.nome,
                os.data_abertura,
                os.ordem_servico_id;";

                command.Parameters.Add(new NpgsqlParameter("@dataInicial", NpgsqlDbType.Timestamp) {
                    Value = filtro.DataInicial.Date
                });

                command.Parameters.Add(new NpgsqlParameter("@dataFinal", NpgsqlDbType.Timestamp) {
                    Value = filtro.DataFinal.Date.AddDays(1)
                });

                command.Parameters.Add(new NpgsqlParameter("@clienteId", NpgsqlDbType.Integer) {
                    Value = filtro.ClienteId.HasValue
        ? (object)filtro.ClienteId.Value
        : DBNull.Value
                });

                command.Parameters.Add(new NpgsqlParameter("@status", NpgsqlDbType.Integer) {
                    Value = filtro.Status.HasValue
                        ? (object)filtro.Status.Value
                        : DBNull.Value
                });

                connection.Open();

                using (var reader = await command.ExecuteReaderAsync()) {

                    while (await reader.ReadAsync()) {

                        lista.Add(new RelatorioOrdemServicoDto {
                            OrdemServicoId = reader.GetInt32(0),
                            ClienteId = reader.GetInt32(1),
                            Cliente = reader.GetString(2),
                            DataAbertura = reader.GetDateTime(3),
                            Status = ObterDescricaoStatus(
                                Convert.ToInt32(reader.GetValue(4))),
                            ValorTotal = reader.GetDecimal(5),
                            TotalImposto = reader.GetDecimal(6)
                        });
                    }
                }
            }

            return lista;
        }

        private string ObterDescricaoStatus(int status) {
            switch (status) {
                case 1:
                    return "Aberta";

                case 2:
                    return "Em Andamento";

                case 3:
                    return "Concluída";

                case 4:
                    return "Cancelada";

                default:
                    return string.Empty;
            }
        }

    }
}


