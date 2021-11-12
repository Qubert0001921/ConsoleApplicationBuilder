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

        public OptionsManager()
        {
            Options = new List<Option>();
        }

        public Option GetSelectedOption()
        {
            var option = Options.FirstOrDefault(r => r.IsSelected == true);
            return option;
        }

        public Option GetOption(int index)
        {
            if (index < 0 || index >= Options.Count)
                return null;

            var option = Options[index];
            return option;
        }

        public void SetOptionSelection(int index, bool selection)
        {
            if(Options.Count > 0)
            {
                var option = GetOption(index);

                if (option is not null)
                    option.IsSelected = selection;
            }
        }
        public void SelectOption(int index) => SetOptionSelection(index, true);

        public void UnSelectOption(int index) => SetOptionSelection(index, false);

        public void AddOption(Option option)
        {
            if (option is not null)
                Options.Add(option);
            else
                throw new Exception("Can't add option to the menu because the option is empty");
        }

        public void DeleteOption(string name)
        {
            var option = Options.FirstOrDefault(x => x.Name == name);
            if (option is not null)
                Options.Remove(option);
        }
    }
}
