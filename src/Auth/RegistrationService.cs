using System;
using Database;
using Npgsql;

namespace Auth
{
    class RegistrationService
    {
        public void Register(Register register)
        {
            Console.WriteLine(register.GetEmail());
            Console.WriteLine(register.GetUsername());
            Console.WriteLine(register.GetPassword());
        }

        private void RegisterAccount(Register register)
        {
            NpgsqlConnection con = connectDatabase();
            string query = $"INSERT INTO public.user_table(email, username, password) VALUES (@email, @username, @password);";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.Parameters.AddWithValue("@email", register.GetEmail());
            cmd.Parameters.AddWithValue("@username", register.GetUsername());
            cmd.Parameters.AddWithValue("@password", register.GetPassword());
            cmd.ExecuteNonQuery();
            closeConnectionDatabase(con);
        }

        private NpgsqlConnection connectDatabase()
        {
            ConnectDatabaseService connectDatabaseService = new ConnectDatabaseService();
            NpgsqlConnection con = connectDatabaseService.Connect();

            con.Open();
            return con;
        }

        private void closeConnectionDatabase(NpgsqlConnection con)
        {
            con.Close();
        }
    }
}