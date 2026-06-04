using System;
using System.Net.Http.Json;
using System.Text.Json;
using Config;

namespace Service
{
    class RegistrationService
    {
        public void Register(Register register)
        {
            try
            {
                RegisterAccountAsync(register);
                Console.WriteLine("Registered account");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void RegisterAccountAsync(Register register)
        {
            var response = await Http.SharedClient.PostAsJsonAsync("auth/register", register);

            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseBody);
        }
    }
}