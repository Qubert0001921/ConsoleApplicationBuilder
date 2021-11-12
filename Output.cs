using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationBuilder
{
    static class Output
    {
        public static void Write(string text, ConsoleColor fg = ConsoleColor.White, ConsoleColor bg = ConsoleColor.Black)
        {
            Console.ForegroundColor = fg;
            Console.BackgroundColor = bg;

            Console.Write(text);

            Console.ResetColor();
        }

        public static void WriteLine(string text, ConsoleColor fg = ConsoleColor.White, ConsoleColor bg = ConsoleColor.Black)
        {
            Write(text + "\n", fg, bg);
        }

        public static void DisplayPagePrompt(string prompt)
        {
            Menu menu = new Menu("message");
            menu.Title = prompt;
            menu.AddBackOption();
            menu.Display();
        }
    }
}
