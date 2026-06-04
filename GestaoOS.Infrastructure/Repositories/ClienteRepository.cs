using GestaoOS.Application.Interface;
using GestaoOS.Domain.Entities.Cliente;
using GestaoOS.Domain.Entities.Enum;
using GestaoOS.Domain.ValueObject;
using GestaoOS.Infrastructure.Data;
using GestaoOS.Services.DTOs;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOS.Infrastructure.Repositories {
    public sealed class ClienteRepository : IClienteRepository {
        private readonly IDbConnectionFactory _connectionFactory;

        public ClienteRepository(IDbConnectionFactory connectionFactory) {
            _connectionFactory = connectionFactory;
        }

        public async Task AdicionarAsync(Cliente cliente) {
            const string sql = @"
                INSERT INTO gestao.cliente
                (
                    nome,
                    documento,
                    tipo_pessoa,
                    email,
                    telefone,
                    data_cadastro,
                    ativo
                )
                VALUES
                (
                    @nome,
                    @documento,
                    @tipoPessoa,
                    @email,
                    @telefone,
                    @dataCadastro,
                    @ativo
                )
                RETURNING cliente_id;";

            using (var connection = _connectionFactory.CriarConexao()) {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand(sql, connection)) {
                    command.Parameters.AddWithValue("nome", cliente.Nome);
                    command.Parameters.AddWithValue("documento", cliente.Documento.Valor);
                    command.Parameters.AddWithValue("tipoPessoa", (short)cliente.TipoPessoa);
                    command.Parameters.AddWithValue("email", cliente.Email.Valor);
                    command.Parameters.AddWithValue("telefone", cliente.Telefone.Valor);
                    command.Parameters.AddWithValue("dataCadastro", cliente.DataCadastro);
                    command.Parameters.AddWithValue("ativo", cliente.Ativo);

                    var id = await command.ExecuteScalarAsync();

                    if (id == null)
                        throw new InvalidOperationException("Não foi possível obter o ID do cliente cadastrado.");
                }
            }
        }

        public async Task AtualizarAsync(Cliente cliente) {
            const string sql = @"
                UPDATE gestao.cliente
                SET
                    nome = @nome,
                    documento = @documento,
                    tipo_pessoa = @tipoPessoa,
                    email = @email,
                    telefone = @telefone,
                    ativo = @ativo
                WHERE cliente_id = @clienteId;";

            using (var connection = _connectionFactory.CriarConexao()) {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand(sql, connection)) {
                    command.Parameters.AddWithValue("clienteId", cliente.ClienteId);
                    command.Parameters.AddWithValue("nome", cliente.Nome);
                    command.Parameters.AddWithValue("documento", cliente.Documento.Valor);
                    command.Parameters.AddWithValue("tipoPessoa", (short)cliente.TipoPessoa);
                    command.Parameters.AddWithValue("email", cliente.Email.Valor);
                    command.Parameters.AddWithValue("telefone", cliente.Telefone.Valor);
                    command.Parameters.AddWithValue("ativo", cliente.Ativo);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ExcluirAsync(int clienteId) {
            const string sql = @"
                DELETE FROM gestao.cliente
                WHERE cliente_id = @clienteId;";

            using (var connection = _connectionFactory.CriarConexao()) {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand(sql, connection)) {
                    command.Parameters.AddWithValue("clienteId", clienteId);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<Cliente> ObterPorIdAsync(int clienteId) {
            const string sql = @"
                SELECT
                    cliente_id,
                    nome,
                    documento,
                    tipo_pessoa,
                    email,
                    telefone,
                    ativo,
                    data_cadastro
                FROM gestao.cliente
                WHERE cliente_id = @clienteId;";

            using (var connection = _connectionFactory.CriarConexao()) {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand(sql, connection)) {
                    command.Parameters.AddWithValue("clienteId", clienteId);

                    using (var reader = await command.ExecuteReaderAsync()) {
                        if (!await reader.ReadAsync())
                            return null;

                        return MapearCliente(reader);
                    }
                }
            }
        }

        public async Task<IReadOnlyCollection<Cliente>> PesquisarAsync(string nome, string documento, bool? ativo) {
            var sql = new StringBuilder(@"
                SELECT
                    cliente_id,
                    nome,
                    documento,
                    tipo_pessoa,
                    email,
                    telefone,
                    ativo
                FROM gestao.cliente
                WHERE 1=1 ");

            var parametros = new List<NpgsqlParameter>();

            if (!string.IsNullOrWhiteSpace(nome)) {
                sql.Append(" AND nome ILIKE @nome ");
                parametros.Add(new NpgsqlParameter("nome", "%" + nome.Trim() + "%"));
            }

            if (!string.IsNullOrWhiteSpace(documento)) {
                sql.Append(" AND documento = @documento ");
                parametros.Add(new NpgsqlParameter("documento", documento.Trim()));
            }

            if (ativo.HasValue) {
                sql.Append(" AND ativo = @ativo ");
                parametros.Add(new NpgsqlParameter("ativo", ativo.Value));
            }

            sql.Append(" ORDER BY nome;");

            var clientes = new List<Cliente>();

            using (var connection = _connectionFactory.CriarConexao()) {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand(sql.ToString(), connection)) {
                    command.Parameters.AddRange(parametros.ToArray());

                    using (var reader = await command.ExecuteReaderAsync()) {
                        while (await reader.ReadAsync()) {
                            clientes.Add(MapearCliente(reader));
                        }
                    }
                }
            }

            return clientes;
        }

        public async Task<List<ClientePesquisaDto>> ListarClienteAsync() {
            var clientes = new List<ClientePesquisaDto>();

            const string sql = @"
        SELECT
            cliente_id,
            nome,
            documento,
            tipo_pessoa,
            email,
            telefone,
            ativo
        FROM gestao.cliente
        WHERE ativo = TRUE
        ORDER BY nome";

            using (var connection = _connectionFactory.CriarConexao()) {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand(sql, connection))
                using (var reader = await command.ExecuteReaderAsync()) {

                    while (await reader.ReadAsync()) {
                        clientes.Add(new ClientePesquisaDto {
                            ClienteId = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Documento = reader.GetString(2),
                            TipoPessoa = reader.GetInt16(3),
                            Email = reader.GetString(4),
                            Telefone = reader.GetString(5),
                            Ativo = reader.GetBoolean(6)
                        });
                    }
                }
            }
            return clientes;
        }
        private static Cliente MapearCliente(NpgsqlDataReader reader) {
            var documento = Documento.Reconstruir(
                reader.GetString(reader.GetOrdinal("documento")));

            var email = Email.Reconstruir(
                reader.GetString(reader.GetOrdinal("email")));

            var telefone = Telefone.Reconstruir(
                reader.GetString(reader.GetOrdinal("telefone")));

            return Cliente.Reconstruir(
                reader.GetInt32(reader.GetOrdinal("cliente_id")),
                reader.GetString(reader.GetOrdinal("nome")),
                documento,
                (TipoPessoa)reader.GetInt16(reader.GetOrdinal("tipo_pessoa")),
                email,
                telefone,
                reader.GetBoolean(reader.GetOrdinal("ativo")));
        }


    }
}