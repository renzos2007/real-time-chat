using System;
using System.Net.Http.Json;
using System.Text.Json;
using Config;

namespace Service
{
    class LoginService
    {
        public async Task Login (Login login)
        {
            try
            {
                await LoginAccount (login);
                Console.WriteLine("Logged in");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private async Task LoginAccount(Login login)
        {
            var response = await Http.SharedClient.PostAsJsonAsync("auth/login", login);

            var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
        }
    }
}