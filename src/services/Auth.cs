using System;
using Config;

namespace Service
{
    class AuthService
    {
        private RegistrationService registrationService = new RegistrationService();
        private LoginService loginService = new LoginService();
        private VerificationService verificationService = new VerificationService();

        private string InputLogin(string label)
        {
            Console.Write($"{label}:");
            if (label == "Password")
            {
                return InputPassword();
            }
            return Console.ReadLine() ?? string.Empty;
        }

        private string InputRegister(string label, Func<string, bool> verify)
        {
            string value;
            Console.Write($"{label}:");
            if (label == "Password")
            {
                value = InputPassword();
            }
            else
            {
                value = Console.ReadLine() ?? string.Empty;
            }

            if (!verify(value))
            {
                value = InputRegister(label, verify);
            }

            return value;
        }

        public async Task<bool> RegisterAccount()
        {
            string email = InputRegister("Email", verificationService.verifyEmail);
            string username = InputRegister("Username", verificationService.verifyUsername);
            string password = InputRegister("Password", verificationService.verifyPassword);

            Register register = new Register(email, username, password);

            return await registrationService.Register(register);
        }

        public async Task<bool> LoginAccount()
        {
            string email = InputLogin("Email or username");
            string password = InputLogin("Password");

            Login login = new Login(email, password);

            return await loginService.Login(login);
        }

        public async Task LogoutAccount()
        {
            bool success = await loginService.Logout();

            if (!success)
            {
                Http.ClearCookies();
            }
        }

        private string InputPassword()
        {
            string password = string.Empty;
            ConsoleKeyInfo key;
            
            do
            {
                key = Console.ReadKey(intercept: true);
                
                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password[..^1];
                    Console.Write("\b \b");
                }
                else if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter);
            
            Console.WriteLine();
            return password;
        }
    }
}