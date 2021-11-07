using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationBuilder
{
    static class Output
    {
        public static void WriteLine(string message, Menu menu)
        {
            Menu menu1 = new Menu();
            menu1.Content = message;
            menu1.UseParentMenu(menu);
            menu1.Display();
        }
    }
}
