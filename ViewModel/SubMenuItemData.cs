using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;

namespace NavegationMenu.ViewModel
{
    class SubMenuItemData
    {
        public PathGeometry PathData { get; set; }
        public string SubMenuText { get; set; }
        public SubMenuItemData()
        {
            SubMenuCommand = new CommandViewModel(Execute);
        }

        public ICommand SubMenuCommand { get; }

        private void Execute()
        {
            //our logic comes here
            string SMT = SubMenuText.Replace(" ", string.Empty);
            if (!string.IsNullOrEmpty(SMT))
                navigateToPage(SMT);
        }

        private void navigateToPage(string Menu)
        {
            //We will search for our Main Window in open windows and then will access the frame inside it to set the navigation to desired page..
            //lets see how... ;)
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "Pages/", Menu, ".xaml"), UriKind.RelativeOrAbsolute));
                }
            }
        }
    }
}
