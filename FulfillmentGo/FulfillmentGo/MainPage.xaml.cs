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
            MenuPages.Add((int)MenuItemType.Purchasing, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    
                    case (int)MenuItemType.Purchasing:
                        MenuPages.Add(id, new NavigationPage(new PurchaseOrderTabs()));
                        break;
                    case (int)MenuItemType.ListEnhanced:
                        MenuPages.Add(id, new NavigationPage(new ListEnhanced()));
                        break;
                    case (int)MenuItemType.Pricing:
                        MenuPages.Add(id, new NavigationPage(new Pricing()));
                        break;
                    case (int)MenuItemType.Promotion:
                        MenuPages.Add(id, new NavigationPage(new Promotion()));
                        break;
                    case (int)MenuItemType.Markdown:
                        MenuPages.Add(id, new NavigationPage(new Markdown()));
                        break;
                    case (int)MenuItemType.Transportation:
                        MenuPages.Add(id, new NavigationPage(new Transportation()));
                        break;
                    case (int)MenuItemType.Sales:
                        MenuPages.Add(id, new NavigationPage(new Sales()));
                        break;
                    case (int)MenuItemType.Logout:
                        await DisplayAlert("Alert", "Logged out successfully", "OK");
                        MenuPages.Add(id, new NavigationPage(new LoginPage()));
                        break;
                    case (int)MenuItemType.Mainmenu:
                        MenuPages.Add(id, new NavigationPage(new Mainmenu()));
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
