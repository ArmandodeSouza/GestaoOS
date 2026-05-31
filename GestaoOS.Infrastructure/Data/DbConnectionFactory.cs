using Npgsql;
using System.Configuration;

namespace GestaoOS.Infrastructure.Data {
    public sealed class DbConnectionFactory : IDbConnectionFactory {
        private readonly string _connectionString;

        public DbConnectionFactory() {
            var connectionString =
                ConfigurationManager.ConnectionStrings["DefaultConnection"];

            if (connectionString == null)
                throw new ConfigurationErrorsException("Connection string 'DefaultConnection' não encontrada.");

            _connectionString = connectionString.ConnectionString;
        }

        public NpgsqlConnection CriarConexao() {
            return new NpgsqlConnection(_connectionString);
        }
    }
}