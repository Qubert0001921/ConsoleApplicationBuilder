using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationBuilder
{
    class Option
    {
        public string Name { get; set; }
        public Action Func { get; set; }
        public bool IsSelected { get; set; } = false;

        public Option(string name, Action func)
        {
            Name = name;
            Func = func;
        }
    }
}
