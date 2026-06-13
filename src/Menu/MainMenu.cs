using System;
using Service;

namespace Menu
{
    class MainMenu
    {
        bool isRunning = true;

        public async Task ShowMenu(string[] args)
        {
            AuthService authService = new AuthService();
            while (isRunning)
            {
                MenuText();
                string? input = Console.ReadLine();

                switch(input) {
                    case "1":
                        Console.WriteLine("you are going to Login.");
                        await authService.LoginAccount();
                        break;
                    case "2":
                        Console.WriteLine("you are going to Register.");
                        await authService.RegisterAccount();
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

        private async Task ShowLoggedinMenu()
        {
            
        }

        private void LoggedinMenuText()
        {
            Console.WriteLine("Welcome to my real time chat. What do you want to do?");
            Console.WriteLine("1. Chat");
            Console.WriteLine("2. Logout");
            Console.WriteLine("3. Quit");
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