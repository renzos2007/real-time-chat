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
                var success = await RegisterAccountAsync(register);

                if (success)
                {
                    Console.WriteLine("Registered account");
                    return true;
                }
                
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong: {ex.Message}");
                return false;
            }
        }

        private async Task<bool> RegisterAccountAsync(Register register)
        {
            var response = await Http.SharedClient.PostAsJsonAsync("auth/register", register);

            return response.IsSuccessStatusCode;
        }
    }
}