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
        public bool IsSelected { get; set; }
        public static int Count { get; set; }
        public int Id { get; set; }

        public Option(string name, Action func)
        {
            Count++;
            Id = Count;
            Name = name;
            Func = func;
        }
    }
}
