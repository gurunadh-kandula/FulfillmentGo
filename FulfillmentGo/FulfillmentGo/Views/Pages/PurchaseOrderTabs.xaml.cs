using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace FulfillmentGo.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PurchaseOrderTabs : TabbedPage
    {
        public PurchaseOrderTabs ()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzY2NzZAMzEzNjJlMzQyZTMwSjRNT1Rub3U1TS9QSDdWaTZxL2tlVGw3bVdoczlvVHFuYnR4UlhkNFFMTT0=");
            InitializeComponent();
  
         }

     }
}