using System;
using Menu;

class Program
{
    static async Task Main(string[] args)
    {
        MainMenu mainMenu = new MainMenu();
        await mainMenu.ShowMenu(args);
    }
}

