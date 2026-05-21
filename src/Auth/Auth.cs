using System;

namespace Auth
{
    class AuthService
    {
        RegistrationService registrationService = new RegistrationService();
        LoginService loginService = new LoginService();
        public string InputEmail()
        {
            Console.Write("Email:");
            return Console.ReadLine() ?? string.Empty;
        }

        public string InputUsername()
        {
            Console.Write("Username:");
            return Console.ReadLine() ?? string.Empty;
        }
        public string InputPassword()
        {
            Console.Write("Password:");
            return Console.ReadLine() ?? string.Empty;
        }

        public void RegisterAccount()
        {
            string email = InputEmail();
            string username = InputUsername();
            string password = InputPassword();

            Register register = new Register(email, username, password);

            registrationService.Register(register);
        }

        public void LoginAccount()
        {
            string email = InputEmail();
            string password = InputPassword();

            Login login = new Login(email, password);
            
            loginService.Login(login);
        }
    }
}