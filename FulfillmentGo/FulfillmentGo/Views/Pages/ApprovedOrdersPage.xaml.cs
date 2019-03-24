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
	public partial class ApprovedOrdersPage : ContentPage
	{
        private OrderDetails order;

        public ApprovedOrdersPage ()
		{
			InitializeComponent ();
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

    }
}