using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationBuilder
{
    class Navigation
    {
        private static List<PageComponent> _pages { get; set; } = new List<PageComponent>();
        public static bool ShowNavigation { get; set; } = true;

        public void SetCurrentPage(PageComponent page) => _pages.Add(page);

        public void DisplayPrevious()
        {
            if(_pages.Count > 0)
            {
                var previousPage = _pages[^2];
                _pages.Remove(_pages[^1]);
                previousPage.Display();
            }
        }

        public void DisplayMain()
        {
            if (_pages.Count > 0)
            {
                var homePage = _pages[0];
                for (int i = _pages.Count-1; i > 0; i--)
                {
                    if (_pages[i] == _pages[0]) break;
                    _pages.Remove(_pages[i]);

                }
                homePage.Display();
            }
        }

        public void ShowNavigationText()
        {
            string navText = GetNavText();

            if (!string.IsNullOrEmpty(navText) && ShowNavigation)
            {
                Console.WriteLine(navText);
                Console.WriteLine("---");
            }
        }

        public string GetNavText()
        {
            string navText = "";

            if(ShowNavigation)
            {
                for (int i = 0; i < _pages.Count; i++)
                {
                    if (i == 0) navText += _pages[i].Name;
                    else navText += " > " + _pages[i].Name;
                }
            }
            return navText;
        }
    }
}
