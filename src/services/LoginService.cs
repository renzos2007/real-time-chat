using System;
using System.Net;
using System.Net.Http.Json;
using Config;

namespace Service
{
    class LoginService
    {
        private async Task<bool> ExecuteAsync(Func<Task> action, string successMessage)
        {
            try
            {
                await action();
                Console.WriteLine(successMessage);
                return true;
            }
            catch
            {
                Console.WriteLine("Something went wrong");
                return false;
            }
        }

        public async Task<bool> Login(Login login)
        {
            var response = await Http.SharedClient.PostAsJsonAsync("auth/login", login);

            return response.IsSuccessStatusCode;
        }
            

        public async Task<bool> Logout() =>
            await ExecuteAsync(LogoutAccount, "Logged out");

        private async Task<bool> LoginAccount(Login login)
        {
            var response = await Http.SharedClient.PostAsJsonAsync("auth/login", login);
            var loginResponse = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode;
        }

        private async Task LogoutAccount()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "auth/logout");
        }
    }
}