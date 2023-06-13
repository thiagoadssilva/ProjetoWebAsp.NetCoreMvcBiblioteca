using MySqlConnector;

namespace Biblioteca.Models.Contracts.Repositories
{
    public interface IConnectionManager
    {
        MySqlConnection GetConnection();
    }
}
