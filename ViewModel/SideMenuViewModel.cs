using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace NavegationMenu.ViewModel
{
    class SideMenuViewModel
    {
        ResourceDictionary dict = Application.LoadComponent(new Uri("/NavegationMenu;component/Assets/IconDictionary.xaml", UriKind.RelativeOrAbsolute)) as ResourceDictionary;

        public List<MenuItemsData> MenuList
        {
            get
            {
                return new List<MenuItemsData>
                {
                    //MainMenu without SubMenu Button 
                    new MenuItemsData(){ PathData= (PathGeometry)dict["icon_dashboard"], MenuText="Dashboard", SubMenuList=null},
                 
                    //MainMenu Button
                    new MenuItemsData(){ PathData= (PathGeometry)dict["icon_users"], MenuText="Profile"
                    
                    //SubMenu Button
                    , SubMenuList=new List<SubMenuItemData>{
                    new SubMenuItemData(){ PathData=(PathGeometry)dict["icon_adduser"], SubMenuText="New User" },
                    new SubMenuItemData(){ PathData=(PathGeometry)dict["icon_alluser"], SubMenuText="All Users" }}
                    },

                    //MainMenu Button
                    new MenuItemsData(){ PathData= (PathGeometry)dict["icon_mails"], MenuText="Mails"

                    //SubMenu Button
                    , SubMenuList=new List<SubMenuItemData>{
                    new SubMenuItemData(){ PathData=(PathGeometry)dict["icon_inbox"], SubMenuText="Inbox" },
                    new SubMenuItemData(){ PathData=(PathGeometry)dict["icon_outbox"], SubMenuText="Outbox" },
                    new SubMenuItemData(){ PathData=(PathGeometry)dict["icon_sentmail"], SubMenuText="Sent" }}},

                    //MainMenu without SubMenu Button
                    new MenuItemsData(){ PathData= (PathGeometry)dict["icon_settings"], MenuText="Settings", SubMenuList=null}
                };
            }
        }

    }
    class MenuItemsData
    {
        public PathGeometry PathData { get; set; }
        public string MenuText { get; set; }
        public List<SubMenuItemData> SubMenuList { get; set; }

        public MenuItemsData()
        {
            Command = new CommandViewModel(Execute);
        }

        public ICommand Command { get; }

        private void Execute()
        {
            //our logic comes here
            string MT = MenuText.Replace(" ", string.Empty);
            if (!string.IsNullOrEmpty(MT))
                navigateToPage(MT);
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
