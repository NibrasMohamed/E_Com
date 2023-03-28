using MySql.Data.MySqlClient;
using System.Data;

namespace LapShop.DataBaseConnection
{
    public class DataBaseConnection
    {
        private readonly IConfiguration _config;
        public DataBaseConnection(IConfiguration config)
        {
            _config = config;

        }

        public static IDbConnection DbConnect()
        {
            string connectionString = _config.GetConnectionString("DefaultConnection");

            IDbConnection connection = new MySqlConnection(connectionString);

            return connection;   
        }
    }
}
