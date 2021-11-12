using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationBuilder
{
    static class Input
    {
        public static string Read()
        {
            string text = Console.ReadLine();
            return text;
        }

        public static string Read(string fieldInfo, ConsoleColor fg = ConsoleColor.Gray, ConsoleColor bg = ConsoleColor.Black)
        {
            Output.Write(fieldInfo, fg, bg);
            return Read();
        }

        public static string ReadPassword(string fieldInfo = "", char passwordChar = '*', ConsoleColor fg = ConsoleColor.Gray, ConsoleColor bg = ConsoleColor.Black)
        {
            string password = string.Empty;
            ConsoleKeyInfo input;

            Output.Write(fieldInfo, fg, bg);

            while (true)
            {
                input = Console.ReadKey(true);

                if (input.Key is ConsoleKey.Enter) break;
                else if (input.Key is ConsoleKey.Backspace)
                {
                    if (string.IsNullOrEmpty(password)) continue;

                    password = password.Remove(password.Length - 1);

                    Console.SetCursorPosition($"{fieldInfo}{password}".Length, Console.CursorTop);
                    Console.Write(" ");
                    Console.SetCursorPosition($"{fieldInfo}{password}".Length, Console.CursorTop);
                    
                    continue;
                }

                password += input.KeyChar.ToString();
                Console.Write(passwordChar);
            }
            Console.WriteLine();

            return password;
        }
    }
}
