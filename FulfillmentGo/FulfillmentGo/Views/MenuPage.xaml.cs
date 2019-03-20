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
            {
                new HomeMenuItem {Id = MenuItemType.PurchaseOrderApproval, Title="Purchase Order Approval" },
                new HomeMenuItem {Id = MenuItemType.AllocationApproval, Title="Allocation Approval" },
                new HomeMenuItem {Id = MenuItemType.StockTransferOrderApproval, Title="Stock Transfer Approval" },
                new HomeMenuItem {Id = MenuItemType.BusinessNotification, Title="Business Notification" },
                new HomeMenuItem{Id = MenuItemType.GridPage, Title="Grid Page" },
                new HomeMenuItem{Id = MenuItemType.ApprovalOrdersPage, Title="ApprovalOrdersPage" },
                new HomeMenuItem{Id = MenuItemType.OrderDetailPage, Title="OrderDetailPage" },
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
