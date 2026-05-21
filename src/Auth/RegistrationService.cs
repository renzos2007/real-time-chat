namespace Auth
{
    class RegistrationService
    {
        public void Register(Register register)
        {
            Console.WriteLine(register.GetEmail());
            Console.WriteLine(register.GetUsername());
            Console.WriteLine(register.GetPassword());
        }
    }
}