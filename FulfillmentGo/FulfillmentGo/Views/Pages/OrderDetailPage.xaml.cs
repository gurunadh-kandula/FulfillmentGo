using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FulfillmentGo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FulfillmentGo.Views.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderDetailPage : ContentPage
	{
        private OrderDetails order;

        public OrderDetailPage ()
		{
			InitializeComponent ();
            var order=new OrderDetails("91075022877", "OOPT - BAO139.16 - V1", "OOPT - BAO139.16 - DC60", 10.0, "Open", "2019-03-20", "TestNote", 1, 2, 3, 4, 200.0, "Open", 20.0, 20.0, 30.0);
        }

        public OrderDetailPage(OrderDetails order)
        {

            //this.order = order;
            InitializeComponent();
            BindingContext = this.order = order;
           

        }
    }
}