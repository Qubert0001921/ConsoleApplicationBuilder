using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationBuilder
{
    class SelectOptionHandler
    {
        public List<Option> Options { get; set; }

        private readonly OptionsManager _optionsManager;

        public SelectOptionHandler(List<Option> options, Menu optionsMenu)
        {
            Options = options;
            _optionsManager = new OptionsManager(Options, optionsMenu);
        }

        public void Handle()
        {
            var key = Console.ReadKey().Key;
            var selectedOption = _optionsManager.GetSelectedOption();
            int id = selectedOption.Id;

            switch(key)
            {
                case ConsoleKey.UpArrow:
                    _optionsManager.SelectOption(id - 1);
                    break;

                case ConsoleKey.DownArrow:
                    _optionsManager.SelectOption(id + 1);
                    break;

                case ConsoleKey.Enter:
                    _optionsManager.RunFunc(selectedOption);
                    break;
            }
        }
    }
}
