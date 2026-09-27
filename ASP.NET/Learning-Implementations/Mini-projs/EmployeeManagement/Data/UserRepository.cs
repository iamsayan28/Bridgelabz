using MySqlConnector;
using Microsoft.Extensions.Configuration;

namespace EmployeeManagement.Data
{
    /// <summary>
    /// Handles login authentication against a simple Users table using ADO.NET.
    /// </summary>
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool ValidateUser(string username, string password)
        {
            const string sql = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

            using (var connection = new MySqlConnection(_connectionString))
            using (var command = new MySqlCommand(sql, connection))
            {
                command.Parameters.Add(new MySqlParameter("@Username", username));
                command.Parameters.Add(new MySqlParameter("@Password", password));

                connection.Open();
                long matchCount = (long)command.ExecuteScalar();
                return matchCount > 0;
            }
        }
    }
}
