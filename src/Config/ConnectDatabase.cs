using DotNetEnv;
using Npgsql;

namespace Database
{
    class ConnectDatabaseService
    {
        public NpgsqlConnection Connect()
        {
            string conString = loadEnv();
            NpgsqlConnection con = new NpgsqlConnection(conString);

            return con;
        }

        private string loadEnv()
        {
            Env.Load();
            
            string? server = Environment.GetEnvironmentVariable("DB_HOST");
            string? name = Environment.GetEnvironmentVariable("DB_NAME");
            string? username = Environment.GetEnvironmentVariable("DB_USER");
            string? password = Environment.GetEnvironmentVariable("DB_PASSWORD");

            string conString = $"server={server};userid={username};password={password};database={name}";
            return conString;
        }
    }
}