
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace WebsiteFirstDraft.Data.Models
{
    // AuthService handles authentication-related database operations
    public class AuthService
    {
        // IConfiguration is used to access app settings like connection strings
        private readonly IConfiguration _config;

        // Constructor injection allows IConfiguration to be provided
        // by ASP.NET Cores dependency injection system
        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        // Attempts to log a user in by checking their credentials against the database
        // Returns true if the username and password match exactly one record
        public async Task<bool> LoginAsync(string username, string password)
        {
            // Create a SQL Server connection using the connection string
            // stored in appsettings.json under "DefaultConnection"
            using var conn = new SqlConnection(
                _config.GetConnectionString("DefaultConnection")
            );

            // SQL query that checks whether a user exists with the given
            // username and hashed password
            var cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Users WHERE Username=@myuser AND PasswordHash=@mypassword",
                conn
            );

            // Add parameters to prevent SQL injection attacks
            cmd.Parameters.AddWithValue("@myuser", username);

            // Hash the entered password before comparing it to the stored hash
            cmd.Parameters.AddWithValue(
                "@mypassword",
                PasswordHelper.HashPassword(password)
            );

            // Open the database connection asynchronously
            await conn.OpenAsync();

            // Execute the query and retrieve the number of matching rows
            int count = (int)await cmd.ExecuteScalarAsync();

            // Login is successful only if exactly one matching user is found
            return count == 1;
        }
    }
}

