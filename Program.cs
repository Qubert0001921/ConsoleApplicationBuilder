using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApplicationBuilder
{
    class Program
    {
        public static void ShowSomeMenu()
        {
            Menu someMenu = new Menu("SOme menu");

            someMenu.AddOption("Log out", () =>
            {
                if (MessageBox.DisplayMessageBox("Do you really want to log out?"))
                {
                    Console.Clear();
                    Output.WriteLine("Logging out...", ConsoleColor.Yellow);
                    Thread.Sleep(2000);
                    someMenu.BackToMainPage();
                }
                else someMenu.Display();
            });
            someMenu.Display();
        }

        public static void Login()
        {
            Page page1 = new Page("Login form");
            page1.OnDisplay = () =>
            {
                string name = Input.Read("name: ");
                string password = Input.ReadPassword("password: ");

                if (name == "Admin" && password == "password")
                {
                    Console.Clear();
                    Output.WriteLine("You logged in!", ConsoleColor.Green);
                    Thread.Sleep(1500);
                    ShowSomeMenu();
                }
                else
                {
                    Console.Clear();
                    Output.WriteLine("Wrong name or password", ConsoleColor.Red);
                    Thread.Sleep(1500);
                    page1.BackToMainPage();
                }
            };

            page1.Display();
        }

        public static void Main(string[] args)
        {
            Navigation.ShowNavigation = false;

            Menu mainMenu = new Menu("Main menu");
            mainMenu.AddOption("Login", Login);
            mainMenu.AddOption("Exit", () => Environment.Exit(0));
            mainMenu.Display();
        }
    }
}
