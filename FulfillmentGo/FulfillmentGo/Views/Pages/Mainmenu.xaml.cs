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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzY2NzZAMzEzNjJlMzQyZTMwSjRNT1Rub3U1TS9QSDdWaTZxL2tlVGw3bVdoczlvVHFuYnR4UlhkNFFMTT0=");
            InitializeComponent ();
		}
        public async void Purchasing_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PurchaseOrderTabs());
            //await new MainPage().NavigateFromMenu(2);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}