using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FulfillmentGo.Views.Pages;
using FulfillmentGo.Models;

namespace FulfillmentGo.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListEnhanced : ContentPage
    {
        public ListEnhanced()
        {
            InitializeComponent();
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            OrderDetailPage newPage = new OrderDetailPage();
            newPage.BindingContext = (sender as Grid).BindingContext;
            newPage.order1 = (sender as Grid).BindingContext as OrderDetails;
            Navigation.PushAsync(newPage);


           
            
           // Navigation.PushModalAsync(new OrderDetailPage(order));
          //listView.SelectedItem = null;
        }
    }
}