namespace Auth
{
    class LoginService
    {
        public void Login (Login login)
        {
            Console.WriteLine(login.GetEmail());
            Console.WriteLine(login.GetPassword());
        }
    }
}