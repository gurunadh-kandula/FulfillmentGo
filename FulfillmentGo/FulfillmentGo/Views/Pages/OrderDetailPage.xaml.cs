using System;
using System.Collections.Generic;
using System.Linq;
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
        private OrderDetails order { get; set; }
        public OrderDetails order1 { get; set; }
        private Double noOfSKUs;

        public OrderDetailPage ()
		{
			InitializeComponent ();
           
            //var order=new OrderDetails("91075022877", "OOPT - BAO139.16 - V1", "OOPT - BAO139.16 - DC60", 10.0, "Open", "2019-03-20", "TestNote", 1, 2, 3, 4, 200.0, "Open", 20.0, 20.0, 30.0,"IKEA");
        }
       
        public OrderDetailPage(OrderDetails order)
        {

            //this.order = order;
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzY2NzZAMzEzNjJlMzQyZTMwSjRNT1Rub3U1TS9QSDdWaTZxL2tlVGw3bVdoczlvVHFuYnR4UlhkNFFMTT0=");
            BindingContext = this.order = order;
            noOfSKUs = order.SuppOrderQty + order.FwdBuyQty;
        }

        private void Approve_Button_Clicked(object sender, EventArgs e)
        {
            /*var order = this.order;
            new ApprovedOrders(order);*/
        }

        private void Review_Button_Clicked(object sender, EventArgs e)
        {

        }

        private void Reject_Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}