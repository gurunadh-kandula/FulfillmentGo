using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FulfillmentGo.Views.Pages;
using FulfillmentGo.Models;
using FulfillmentGo.ViewModels;

namespace FulfillmentGo.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListEnhanced : ContentPage
    {
        public ListEnhanced()
        {
            InitializeComponent();
            BindingContext = new Orders();
        }
        private void listView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            OrderDetailPage newPage = new OrderDetailPage();
            newPage.BindingContext = e.ItemData;
            newPage.order1 = (e.ItemData) as OrderDetails;
            Navigation.PushModalAsync(newPage);


           
            
           // Navigation.PushModalAsync(new OrderDetailPage(order));
            listView.SelectedItem = null;
        }

        private void ListView_ItemHolding(object sender, Syncfusion.ListView.XForms.ItemHoldingEventArgs e)
        {   var orderDetails = (e.ItemData) as OrderDetails;
            
          
            popupLayout.PopupView.BindingContext= orderDetails;
            popupLayout.Show();

        }
    }
}