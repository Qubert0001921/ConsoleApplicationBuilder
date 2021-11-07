using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplicationBuilder.Exceptions;

namespace ConsoleApplicationBuilder
{
    class Menu
    {
        public string Content { get; set; }
        public string Navigation { get; set; }
        public List<Option> Options { get; set; }

        private Menu _parentMenu { get; set; }
        private readonly SelectOptionHandler _selectOptionHandler;

        public Menu()
        {
            Options = new List<Option>();
            AddOption("test", () => Display());
            Options[0].IsSelected = true;
            _selectOptionHandler = new SelectOptionHandler(Options, this);
        }

        public void UseParentMenu(Menu parentMenu)
        {
            _parentMenu = parentMenu;
            AddOption("Back", () => _parentMenu.Display());
        }

        public void UseExit()
        {
            AddOption("Exit", () => Environment.Exit(0));
        }

        public void Display()
        {
            Console.Clear();

            bool isContentNotEmpty = !string.IsNullOrEmpty(Content);

            if (isContentNotEmpty)
            {
                Console.WriteLine(Content);
                Console.WriteLine();
            }

            foreach (var option in Options)
            {
                if(option.IsSelected)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine($"< {option.Name} >");

                Console.ResetColor();
            }

            _selectOptionHandler.Handle();
        }

        public void AddOption(string name, Action func)
        {
            bool isNameNotNull = !string.IsNullOrEmpty(name);

            if (isNameNotNull)
                Options.Add(new Option(name, func));
            else
                throw new AddOptionException();
        }

        public void AddOption(Option option)
        {
            bool isOptionNotNull = option is not null;

            if (isOptionNotNull)
                Options.Add(option);
            else
                throw new AddOptionException();
        }
    }
}
