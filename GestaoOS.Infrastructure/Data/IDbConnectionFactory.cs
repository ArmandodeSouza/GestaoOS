using Npgsql;

namespace GestaoOS.Infrastructure.Data {

    public interface IDbConnectionFactory {
        NpgsqlConnection CriarConexao();
    }
}