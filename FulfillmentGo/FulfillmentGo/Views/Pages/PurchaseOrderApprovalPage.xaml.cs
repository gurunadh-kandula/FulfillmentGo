using System;
using Microcharts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microcharts.Forms;
using Xamarin.Forms.Xaml;
using FulfillmentGo.ViewModels;
using Syncfusion.SfChart.XForms;
using System.Collections.ObjectModel;

namespace FulfillmentGo.Views.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PurchaseOrderApprovalPage : ContentPage
    {
        public PurchaseOrderApprovalPage()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzY2NzZAMzEzNjJlMzQyZTMwSjRNT1Rub3U1TS9QSDdWaTZxL2tlVGw3bVdoczlvVHFuYnR4UlhkNFFMTT0=");
            InitializeComponent();
            BindingContext = new Books();
        }
       /* private async void Chart_SelectionChanged(object sender, ChartSelectionEventArgs e)
        {
            await DisplayAlert("Alert", "Don't touch my pie piece", "kneeled");
            
        }*/
    }
}