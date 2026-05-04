using MySql.Data.MySqlClient;

namespace kursovoy_proekt
{
    public static class DatabaseConnection
    {
        public static string ConnectionString { get; private set; } = "Server=localhost;Database=hotel_management;Uid=root;Pwd=Root123;";

        public static string GetConnectionString()
        {
            return ConnectionString;
        }

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public static void UpdateConnectionString(string newConnectionString)
        {
            ConnectionString = newConnectionString;
        }

        public static bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}