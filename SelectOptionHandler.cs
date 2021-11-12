using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationBuilder
{
    class SelectOptionHandler
    {
        public Menu OptionsMenu { get; set; }

        private readonly OptionsManager _optionsManager;

        public SelectOptionHandler(OptionsManager optionsManager, Menu optionsMenu)
        {
            OptionsMenu = optionsMenu;
            _optionsManager = optionsManager;
        }

        public void Handle()
        {
            var key = Console.ReadKey(true).Key;
            var selectedOption = _optionsManager.GetSelectedOption();
            var index = _optionsManager.Options.IndexOf(selectedOption);

            if(selectedOption is not null)
            {
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        _optionsManager.UnSelectOption(index);
                        _optionsManager.SelectOption(index - 1);
                        OptionsMenu.Display();
                        break;

                    case ConsoleKey.DownArrow:
                        _optionsManager.UnSelectOption(index);
                        _optionsManager.SelectOption(index + 1);
                        OptionsMenu.Display();
                        break;

                    case ConsoleKey.Enter:
                        Console.Clear();
                        selectedOption.Func();
                        break;

                    default:
                        OptionsMenu.Display();
                        break;
                }
            }
            else
            {
                OptionsMenu.Display();
            }
        }
    }
}
