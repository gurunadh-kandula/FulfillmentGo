using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FulfillmentGo.Models;
using FulfillmentGo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FulfillmentGo.Views.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderDetailPage : ContentPage
    {
       // bool _collapsed = true ;
        private OrderDetails order { get; set; }
        private String orderId { get; set; }
        public OrderDetails order1 { get; set; }
        //private Double noOfSKUs;

        public OrderDetailPage ()
		{
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzY2NzZAMzEzNjJlMzQyZTMwSjRNT1Rub3U1TS9QSDdWaTZxL2tlVGw3bVdoczlvVHFuYnR4UlhkNFFMTT0=");
            InitializeComponent ();
           
            //var order=new OrderDetails("91075022877", "OOPT - BAO139.16 - V1", "OOPT - BAO139.16 - DC60", 10.0, "Open", "2019-03-20", "TestNote", 1, 2, 3, 4, 200.0, "Open", 20.0, 20.0, 30.0,"IKEA");
        }
       


      //This constructor call is not happening
        public OrderDetailPage(OrderDetails order)
        {

            //this.order = order;
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzY2NzZAMzEzNjJlMzQyZTMwSjRNT1Rub3U1TS9QSDdWaTZxL2tlVGw3bVdoczlvVHFuYnR4UlhkNFFMTT0=");
            BindingContext = this.order=order;
            //noOfSKUs = order.SuppOrderQty + order.FwdBuyQty;
        }

        private async void Approve_Button_Clicked(object sender, EventArgs e)
        {
            /*var order = this.order;
            new ApprovedOrders(order);*/
            orderId = this.order1.OrderID;
            HttpClient client = new HttpClient();
            var url = "http://10.156.11.183:8080/updateStatus/venu/"+orderId+"/Approved/"+"Notes";
            HttpContent content = null;

            var result = await client.PostAsync(url,content);
            if (result.StatusCode == HttpStatusCode.Created)
            {
                await DisplayAlert("Hey!", "Your record has been approved", "Alright");
            }
            //await  Navigation.PopAsync();
            //await Navigation.PopModalAsync();
            //await Navigation.PopAsync();
            for (int i = 0; i < ListEnhanced.orders.OrderCollection.Count; i++)
            {
                if (ListEnhanced.orders.OrderCollection[i].OrderID.Equals(orderId))
                {
                    ApprovedOrdersPage.approvedOrders.OrderCollection.Add(ListEnhanced.orders.OrderCollection[i]);
                    ListEnhanced.orders.OrderCollection.Remove(ListEnhanced.orders.OrderCollection[i]);
                    
                }
            }
            //ListEnhanced.orders.OrderCollection.RemoveAt(0);
            //await Navigation.PushModalAsync(new PurchaseOrderTabs());
            await Navigation.PopModalAsync();
        }

        private void Review_Button_Clicked(object sender, EventArgs e)
        {
            
        }

        private async void Reject_Button_Clicked(object sender, EventArgs e)
        {
            orderId = this.order1.OrderID;
            HttpClient client = new HttpClient();
            var url = "http://10.156.11.183:8080/updateStatus/venu/" + orderId + "/Rejected/" + "Notes";
            HttpContent content = null;

            var result = await client.PostAsync(url, content);
            if (result.StatusCode == HttpStatusCode.Created)
            {
                await DisplayAlert("Hey!", "Your record has been rejected", "Alright");
            }
            for (int i = 0; i < ListEnhanced.orders.OrderCollection.Count; i++)
            {
                if (ListEnhanced.orders.OrderCollection[i].OrderID.Equals(orderId))
                {
                    RejectedOrdersPage.rejectedOrders.OrderCollection.Add(ListEnhanced.orders.OrderCollection[i]);
                    ListEnhanced.orders.OrderCollection.Remove(ListEnhanced.orders.OrderCollection[i]);

                }
            }
            //await  Navigation.PopAsync();
            //await Navigation.PopModalAsync();
            //await Navigation.PopAsync();
            //await Navigation.PushModalAsync(new PurchaseOrderTabs());
            await Navigation.PopModalAsync();
        }
        /*async void Rotate_Clicked(object sender, EventArgs e)
        {
            if (_collapsed)
            {
                await Task.WhenAll(new List<Task> { MyContent.LayoutTo(new Rectangle(MyContent.Bounds.X, MyContent.Bounds.Y, MyContent.Bounds.Width, 100), 500, Easing.CubicOut), MyButton.RotateTo(180, 500, Easing.SpringOut) });
                _collapsed = false;
            }
            else
            {
                await Task.WhenAll(new List<Task> { MyContent.LayoutTo(new Rectangle(MyContent.Bounds.X, MyContent.Bounds.Y, MyContent.Bounds.Width, 0), 500, Easing.CubicIn), MyButton.RotateTo(360, 500, Easing.SpringOut) });
                MyButton.Rotation = 0;
                _collapsed = true;
            }
        }*/
    }
}