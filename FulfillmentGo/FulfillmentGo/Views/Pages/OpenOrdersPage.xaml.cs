using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FulfillmentGo.ViewModels;
using FulfillmentGo.Models;

namespace FulfillmentGo.Views.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OpenOrdersPage : ContentPage
	{
        private SearchBar searchBar;

        public OpenOrdersPage ()
		{
			InitializeComponent ();
		}
        /*private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            searchBar = (sender as SearchBar);
            if (listView.DataSource != null)
            {
                this.listView.DataSource.Filter = FilterOrders;
                this.listView.DataSource.RefreshFilter();
            }
        }*/

        private bool FilterOrders(object obj)
        {
            if (searchBar == null || searchBar.Text == null)
                return true;

            var OrderInfo = obj as OrderInfo;
            if (OrderInfo.Status.ToLower().Contains(searchBar.Text.ToLower())
                || OrderInfo.Vendor.ToLower().Contains(searchBar.Text.ToLower()))
                return true;
            else
                return false;
        }

        public async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "OrderDatashouldbe shown", "OK");
            var newPage = new OrderDetailPage();
            newPage.BindingContext = sender;
            await Navigation.PushAsync(newPage);
        }
        /* async void onOrderSelected(object sender, SelectedItemChangedEventArgs args)
         {
             var order = args.SelectedItem as OrderInfo;
             if (order == null)
                 return;
             await Navigation.PushModalAsync(new OrderDetailPage(order));

             listView.SelectedItem = null;
         }
         */
        void OnSelectionAsync(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            var order = e.SelectedItem as OrderDetails;
            Navigation.PushModalAsync(new OrderDetailPage(order));
            listView.SelectedItem = null;
       }
        /*void OnTapAsync(object sender, ItemTappedEventArgs e)
        {
            DisplayAlert("Item Selected", e.Item.ToString(), "Ok");
        }*/
    }
}