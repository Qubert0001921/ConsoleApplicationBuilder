using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationBuilder
{
    static class MessageBox
    {
        public static bool DisplayMessageBox(string question)
        {
            bool result = false;

            Menu msg = new Menu("Message Box");
            msg.Title = question;
            msg.AddOption("Yes", () => result = true);
            msg.AddOption("No", msg.BackToPreviousPage);

            msg.Display();
            return result;
        }
    }
}
