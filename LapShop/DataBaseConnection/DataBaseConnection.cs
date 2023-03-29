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
         //   string connectionString = _config.GetConnectionString("DefaultConnection");
            string connectionString = "server=127.0.0.1;database=e_com_db;user=root;password=;port=3306;";

            IDbConnection connection = new MySqlConnection(connectionString);

            return connection;   
        }
    }
}
