using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationBuilder
{
    class Page : PageComponent
    {
        public Action OnDisplay { get; set; }
        public Page(string name) : base(name)
        {
            
        }

        public override void Display()
        {
            DisplayHeaders();
            OnDisplay();
        }
    }
}
