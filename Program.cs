using System;
using Menu;

class Program
{
    static void Main(string[] args)
    {
        MainMenu mainMenu = new MainMenu();
        mainMenu.ShowMenu(args);
    }
}

