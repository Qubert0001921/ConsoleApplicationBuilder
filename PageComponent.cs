using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationBuilder
{
    abstract class PageComponent
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public abstract void Display();
        protected Navigation _navigation { get; set; } = new Navigation();

        public PageComponent(string name)
        {
            Name = name;
            _navigation = new Navigation();
            _navigation.SetCurrentPage(this);
        }

        public void DisplayHeaders()
        {
            _navigation.ShowNavigationText();

            if (Title is not null)
                Console.WriteLine(Title + "\n");
        }
        public void BackToPreviousPage()
        {
            Console.Clear();
            _navigation.DisplayPrevious();
        }

        public void BackToMainPage()
        {
            Console.Clear();
            _navigation.DisplayMain();
        }
    }
}
