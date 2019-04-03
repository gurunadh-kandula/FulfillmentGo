using FulfillmentGo.Models;
using FulfillmentGo.ViewModels;
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
	public partial class OrderDetailPageNoButtons : ContentPage
	{
        private OrderDetails order { get; set; }
        private String orderId { get; set; }
        public OrderDetails order1 { get; set; }
        
        
        public OrderDetailPageNoButtons()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzY2NzZAMzEzNjJlMzQyZTMwSjRNT1Rub3U1TS9QSDdWaTZxL2tlVGw3bVdoczlvVHFuYnR4UlhkNFFMTT0=");
            InitializeComponent();
            popupLayoutReview.PopupView.AppearanceMode = Syncfusion.XForms.PopupLayout.AppearanceMode.OneButton;
        }
       
        //This constructor call is not happening
        public OrderDetailPageNoButtons(OrderDetails order)
        {

            //this.order = order;
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzY2NzZAMzEzNjJlMzQyZTMwSjRNT1Rub3U1TS9QSDdWaTZxL2tlVGw3bVdoczlvVHFuYnR4UlhkNFFMTT0=");
            BindingContext = this.order = order;

            //noOfSKUs = order.SuppOrderQty + order.FwdBuyQty;
        }

       
    }
}
