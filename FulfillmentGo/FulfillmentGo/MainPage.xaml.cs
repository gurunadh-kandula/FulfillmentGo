using FulfillmentGo.Models;
using FulfillmentGo.Views;
using FulfillmentGo.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FulfillmentGo
{
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            MasterBehavior = MasterBehavior.Popover;
            ((NavigationPage)Detail).BarBackgroundColor = Color.FromHex("#1F3138");
            MenuPages.Add((int)MenuItemType.PurchaseOrderApproval, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.PurchaseOrderApproval:
                        MenuPages.Add(id, new NavigationPage(new PurchaseOrderApprovalPage()));
                        break;
                    case (int)MenuItemType.AllocationApproval:
                        MenuPages.Add(id, new NavigationPage(new AllocationApprovalPage()));
                        break;
                    case (int)MenuItemType.StockTransferOrderApproval:
                        MenuPages.Add(id, new NavigationPage(new StockTransferOrderApprovalPage()));
                        break;
                    case (int)MenuItemType.BusinessNotification:
                        MenuPages.Add(id, new NavigationPage(new BusinessNotificationPage()));
                        break;
                    case (int)MenuItemType.GridPage:
                        MenuPages.Add(id, new NavigationPage(new GridPage()));
                        break;
                    case (int)MenuItemType.ApprovalOrdersPage:
                        MenuPages.Add(id, new NavigationPage(new PurchaseOrderTabs()));
                        break;
                    case (int)MenuItemType.OrderDetailPage:
                        MenuPages.Add(id, new NavigationPage(new OrderDetailPage()));
                        break;
                    case (int)MenuItemType.Logout:
                        await DisplayAlert("Alert", "Logged out successfully", "OK");
                        MenuPages.Add(id, new NavigationPage(new LoginPage()));
                        break;
                        

}
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;
                newPage.BarBackgroundColor = Color.FromHex("#1F3138");
                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}
