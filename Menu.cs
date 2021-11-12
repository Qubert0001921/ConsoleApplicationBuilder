using System;

namespace ConsoleApplicationBuilder
{
    class Menu : PageComponent
    {
        private SelectOptionHandler _selectOptionHandler { get; set; }
        private OptionsManager _optionsManager { get; set; }

        public Menu(string name) : base(name)
        {
            _optionsManager = new OptionsManager();
            _selectOptionHandler = new SelectOptionHandler(_optionsManager, this);

            Console.Clear();
        }

        public override void Display()
        {
            Console.SetCursorPosition(0, 0);

            var selectedOption = _optionsManager.GetSelectedOption();

            if (selectedOption is null)
                _optionsManager.SelectOption(0);

            DisplayHeaders();

            foreach (Option option in _optionsManager.Options)
            {
                if(option.IsSelected)
                    Output.WriteLine($"< {option.Name} >", fg:ConsoleColor.Black, bg:ConsoleColor.White);
                else
                    Console.WriteLine($"< {option.Name} >");
            }

            _selectOptionHandler.Handle();
        }

        public void AddOption(Option option) => _optionsManager.AddOption(option);
        public void AddOption(string name, Action func) => _optionsManager.AddOption(new Option(name, func));
        public void DeleteOption(string name) => _optionsManager.DeleteOption(name);
        public void AddBackOption() => AddOption("Back", _navigation.DisplayPrevious);
    }
}
