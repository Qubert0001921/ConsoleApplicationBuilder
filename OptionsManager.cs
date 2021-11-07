using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationBuilder
{
    class OptionsManager
    {
        public List<Option> Options { get; set; }
        public Menu OptionsMenu { get; set; }

        public OptionsManager(List<Option> options, Menu optionsMenu)
        {
            Options = options;
            OptionsMenu = optionsMenu;
        }

        public Option GetSelectedOption()
        {
            var option = Options.FirstOrDefault(r => r.IsSelected == true);
            return option;
        }

        public Option GetOption(int id)
        {
            var option = Options.FirstOrDefault(r => r.Id == id);
            return option;
        }

        public void RunFunc(Option option)
        {
            Console.Clear();
            option.Func();
        }

        public void SelectOption(int id)
        {
            var selectedOption = GetSelectedOption();
            var option = GetOption(id);

            bool isOptionNotNull = option is not null;

            if (isOptionNotNull)
            {
                selectedOption.IsSelected = false;
                option.IsSelected = true;
            }

            OptionsMenu.Display();
        }
    }
}
