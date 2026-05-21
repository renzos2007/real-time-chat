using System;

namespace MainMenu
{
    class Menu
    {
        bool isRunning = true;

        public void ShowMenu(string[] args)
        {
            Auth.AuthService authService = new Auth.AuthService();
            while (isRunning)
            {
                MenuText();
                string? input = Console.ReadLine();

                switch(input) {
                    case "1":
                        Console.WriteLine("you are going to Login.");
                        authService.LoginAccount();
                        break;
                    case "2":
                        Console.WriteLine("you are going to Register.");
                        authService.RegisterAccount();
                        break;
                    case "3":
                        Console.WriteLine("Thank you for using my real time chat.");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("This is not a option");
                        break;
                }
            }
        }

        private void MenuText()
        {
            Console.WriteLine("Welcome to my real time chat. What do you want to do?");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Quit");
        }
    }
}