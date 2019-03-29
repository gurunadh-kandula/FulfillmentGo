using FulfillmentGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FulfillmentGo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {   new HomeMenuItem{Id = MenuItemType.Mainmenu, Title="Main menu" },
                new HomeMenuItem{Id = MenuItemType.Purchasing, Title="Purchasing" },
                new HomeMenuItem{Id = MenuItemType.Pricing, Title="Pricing" },
                new HomeMenuItem{Id = MenuItemType.Promotion, Title="Promotion" },
                new HomeMenuItem{Id = MenuItemType.Markdown, Title="Mark down" },
                new HomeMenuItem{Id = MenuItemType.Sales, Title="Sales" },
                new HomeMenuItem {Id = MenuItemType.Logout, Title="LOGOUT" },
                
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) => {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}
