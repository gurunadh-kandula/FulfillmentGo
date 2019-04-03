using FulfillmentGo.Models;
using FulfillmentGo.ViewModels;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FulfillmentGo.Views.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RejectedOrdersPage : ContentPage
	{
        public static RejectedOrders rejectedOrders { get; set; }
        private SearchBar searchBar;
        public RejectedOrdersPage ()
		{
			InitializeComponent ();
            BindingContext = rejectedOrders = new RejectedOrders();
        }
        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            searchBar = (sender as SearchBar);
            if (listView.DataSource != null)
            {
                this.listView.DataSource.Filter = FilterOrders;
                this.listView.DataSource.RefreshFilter();
            }
        }
        private bool FilterOrders(object obj)
        {
            if (searchBar == null || searchBar.Text == null)
                return true;

            var orderDetails = obj as OrderDetails;
            if (orderDetails.Status.ToLower().Contains(searchBar.Text.ToLower())
                || orderDetails.Source.ToLower().Contains(searchBar.Text.ToLower()) || orderDetails.OrderID.ToLower().Contains(searchBar.Text.ToLower()) || orderDetails.OrderValue.ToString("0.").Contains(searchBar.Text) || orderDetails.Qty.ToString("0.").Contains(searchBar.Text))
                return true;
            else
                return false;
        }

        void OnSelectionAsync(object sender, SelectedItemChangedEventArgs e)
        {
            /* if (e.SelectedItem == null)
             {
                 return;
             }
             var order = e.SelectedItem as OrderDetails;
             Navigation.PushModalAsync(new OrderDetailPage(order));
             listView.SelectedItem = null;*/
        }
        private async void ListView_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            var orderDetails = (e.ItemData) as OrderDetails;
            String orderid = orderDetails.OrderID;
            HttpClient client = new HttpClient();
            if (e.SwipeOffset >= 360)
            {
                if (e.SwipeDirection.Equals(Syncfusion.ListView.XForms.SwipeDirection.Left))
                {

                    var url = "http://10.156.11.183:8080/updateStatus/venu/" + orderid + "/Opened/" + "Notes";
                    HttpContent content = null;

                    var result = await client.PostAsync(url, content);
                    if (result.StatusCode == HttpStatusCode.Created)
                    {
                        await DisplayAlert("Hey!", "Your record has been approved", "Alright");
                    }
                    //await  Navigation.PopAsync();
                    //await Navigation.PopModalAsync();
                    //await Navigation.PopAsync();
                    for (int i = 0; i < RejectedOrdersPage.rejectedOrders.OrderCollection.Count; i++)
                    {
                        if (RejectedOrdersPage.rejectedOrders.OrderCollection[i].OrderID.Equals(orderid))
                        {
                            //ListEnhanced.orders.OrderCollection.Add(RejectedOrdersPage.rejectedOrders.OrderCollection[i]);
                            ListEnhanced.orders.OrderCollection.Insert(0,RejectedOrdersPage.rejectedOrders.OrderCollection[i]);
                            RejectedOrdersPage.rejectedOrders.OrderCollection.Remove(RejectedOrdersPage.rejectedOrders.OrderCollection[i]);
                            

                        }
                    }

                }

                listView.ResetSwipe();
            }
        }
        private void listView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            OrderDetailPageNoButtons newPage = new OrderDetailPageNoButtons();
            newPage.BindingContext = e.ItemData;
            newPage.order1 = (e.ItemData) as OrderDetails;

            Navigation.PushModalAsync(newPage);





            listView.SelectedItem = null;
        }

    }
}