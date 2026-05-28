using System;

namespace Service
{
    class RegistrationService
    {
        public void Register(Register register)
        {
            RegisterAccount(register);
        }

        private void RegisterAccount(Register register)
        {
            // http request to server
        }
    }
}