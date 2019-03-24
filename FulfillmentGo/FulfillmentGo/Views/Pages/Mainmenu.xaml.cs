using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FulfillmentGo.Views.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Mainmenu : ContentPage
	{
		public Mainmenu ()
		{
			InitializeComponent ();
		}
        public async void Purchasing_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PurchaseOrderTabs());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}