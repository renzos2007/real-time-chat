using System;

namespace Service
{
    class LoginService
    {
        public void Login (Login login)
        {
            LoginAccount (login);
        }

        private void LoginAccount(Login login)
        {
            // http request to server
        }
    }
}