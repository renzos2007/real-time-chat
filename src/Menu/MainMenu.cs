using System;
using Service;

namespace Menu
{
    class MainMenu
    {
        bool isRunning = true;
        bool isLoggedin = false;

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
                        bool successfulLogin = await authService.LoginAccount();

                        if (successfulLogin)
                        {
                            isLoggedin = true;
                            await ShowLoggedinMenu(authService);
                        }
                        break;
                    case "2":
                        Console.WriteLine("you are going to Register.");
                        bool successfulRegistery = await authService.RegisterAccount();
                        isLoggedin = true;
                        await AuthSuccessful(successfulRegistery, () => ShowLoggedinMenu(authService));
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

        private async Task AuthSuccessful(bool success, Func<Task> func)
        {
            if (success)
            {
                await func();
            }
        }

        private async Task ShowLoggedinMenu(AuthService authService)
        {
            ChatService chatService = new ChatService();

            while (isLoggedin)
            {
                LoggedinMenuText();
                string? input = Console.ReadLine();

                switch(input) {
                    case "1":
                        await chatService.Connect();
                        break;
                    case "2":
                        await authService.LogoutAccount();
                        isLoggedin = false;
                        break;
                    default:
                        Console.WriteLine("This is not a option");
                        break;
                }
            }
        }

        private void LoggedinMenuText()
        {
            Console.WriteLine("Welcome to my real time chat. What do you want to do?");
            Console.WriteLine("1. Chat");
            Console.WriteLine("2. Logout");
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