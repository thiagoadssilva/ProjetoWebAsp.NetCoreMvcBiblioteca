using Biblioteca.Models.Contracts.Repositories;
using MySqlConnector;

namespace Biblioteca.Models.Contexts
{
    public class ConnectionManager : IConnectionManager
    {
        private static string _connectionName = "Biblioteca";
        private static MySqlConnection connection = null;

        public ConnectionManager(IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString(_connectionName);
            if (connection == null)
            {
                connection = new MySqlConnection(connString);
            }
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
