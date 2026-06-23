using System;
using System.Net.Http.Json;
using System.Text.Json;
using Config;

namespace Service
{
    class RegistrationService
    {
        public async Task<bool> Register(Register register)
        {
            try
            {
                await RegisterAccountAsync(register);
                Console.WriteLine("Registered account");
                return true;
            }
            catch
            {
                Console.WriteLine("Something went wrong, try again later.");
                return false;
            }
        }

        private async Task RegisterAccountAsync(Register register)
        {
            var response = await Http.SharedClient.PostAsJsonAsync("auth/register", register);
            var responseBody = await response.Content.ReadAsStringAsync();
        }
    }
}