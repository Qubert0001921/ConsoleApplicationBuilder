using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationBuilder.Exceptions
{
    class AddOptionException : Exception
    {
        public AddOptionException() : base("Can't add option to the menu because is empty")
        {

        }
    }
}
