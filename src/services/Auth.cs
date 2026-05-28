using System;

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
            return Console.ReadLine() ?? string.Empty;
        }

        private string InputRegister(string label, Func<string, bool> verify)
        {
            Console.Write($"{label}:");
            string value = Console.ReadLine() ?? string.Empty;

            if (!verify(value))
            {
                value = InputRegister(label, verify);
            }

            return value;
        }

        public void RegisterAccount()
        {
            string email = InputRegister("Email", verificationService.verifyEmail);
            string username = InputRegister("Username", verificationService.verifyUsername);
            string password = InputRegister("Password", verificationService.verifyPassword);

            Register register = new Register(email, username, password);

            registrationService.Register(register);
        }

        public void LoginAccount()
        {
            string email = InputLogin("Email");
            string password = InputLogin("Password");

            Login login = new Login(email, password);
            
            loginService.Login(login);
        }
    }
}