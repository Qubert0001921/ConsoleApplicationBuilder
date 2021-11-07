using System;

namespace ConsoleApplicationBuilder
{
    class Program
    {
        public static Menu menu;
        public static Menu menu1;

        static void Main(string[] args)
        {
            menu = new Menu();
            menu.Content = "Main Menu";

            menu.AddOption("First Option", () => Output.WriteLine("Hello World", menu));
            menu.AddOption("Second Option", () => SecondOptionHandel());
            menu.UseExit();

            menu.Display();
        }

        static void InputValueTest()
        {
            Console.Write("Type text here: ");
            string text = Console.ReadLine();

            Output.WriteLine($"Hello {text}", menu1);
        }

        static void SecondOptionHandel()
        {
            menu1 = new Menu();
            menu1.Content = "Menu1 content";

            menu1.AddOption("First option in menu1", () => Output.WriteLine("Hello", menu1));
            menu1.AddOption("Second option in menu1", () => Output.WriteLine("Hello from second option menu", menu1));
            menu1.AddOption("Input value test", () => InputValueTest());
            menu1.UseParentMenu(menu);

            menu1.Display();
        }
    }
}
