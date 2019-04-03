using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FulfillmentGo.Models;
using FulfillmentGo.ViewModels;
using SkiaSharp;
using Syncfusion.SfChart.XForms;
using Syncfusion.XForms.PopupLayout;
using Syncfusion.XForms.TextInputLayout;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FulfillmentGo.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetailPage : ContentPage
    {
       
        private OrderDetails order { get; set; }
        private String orderId { get; set; }
        public OrderDetails order1 { get; set; }
        private Editor customEntry;
        //public SfChart chart = new SfChart();


        public OrderDetailPage()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzY2NzZAMzEzNjJlMzQyZTMwSjRNT1Rub3U1TS9QSDdWaTZxL2tlVGw3bVdoczlvVHFuYnR4UlhkNFFMTT0=");
            InitializeComponent();
        }
        public OrderDetailPage(OrderDetails order)
        {

            //this.order = order;
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzY2NzZAMzEzNjJlMzQyZTMwSjRNT1Rub3U1TS9QSDdWaTZxL2tlVGw3bVdoczlvVHFuYnR4UlhkNFFMTT0=");
            BindingContext = this.order = order;
            
        //noOfSKUs = order.SuppOrderQty + order.FwdBuyQty;
        }

        private void Approve_Button_Clicked(object sender, EventArgs e)
        {
            customEntry = new Editor { HeightRequest = 100 };
            //this.BindingContext = new PopupViewModel();

            //customEntry.SetBinding(Editor.TextProperty, new Binding("Notes", BindingMode.Default, null, null, null, this.BindingContext));
            popupLayout.PopupView.ContentTemplate = new DataTemplate(() =>
            {
                StackLayout stackLayout = new StackLayout();
                stackLayout.Orientation = StackOrientation.Vertical;

                SfTextInputLayout inputLayout = new SfTextInputLayout();
                inputLayout.Hint = "Notes";
                inputLayout.InputView = customEntry;


                Button button = new Button();
                button.Text = "APPROVE";
                button.BackgroundColor = Color.Transparent;
                button.TextColor = Color.Black;
                button.Image = "approve.png";
                button.HorizontalOptions=LayoutOptions.End;
                button.Clicked += Button_Clicked_approved;

                stackLayout.Children.Add(inputLayout);
                stackLayout.Children.Add(button);

                return stackLayout;
            });
            popupLayout.PopupView.ShowFooter = false;
            popupLayout.PopupView.ShowHeader = false;
            popupLayout.PopupView.WidthRequest = 350;
            popupLayout.PopupView.HeightRequest = 180;
            popupLayout.PopupView.AnimationMode = AnimationMode.SlideOnBottom;
            //popupLayout.PopupView.HorizontalOptions = LayoutOptions.FillAndExpand;
            popupLayout.Show();
        }

        private void Review_Button_Clicked(object sender, EventArgs e)
        {
            customEntry = new Editor { HeightRequest = 100 };
            // this.BindingContext = new PopupViewModel();

            // customEntry.SetBinding(Editor.TextProperty, new Binding("PopupText", BindingMode.Default, null, null, null, this.BindingContext));
            popupLayout.PopupView.ContentTemplate = new DataTemplate(() =>
            {
                StackLayout stackLayout = new StackLayout();
                stackLayout.Orientation = StackOrientation.Vertical;

                SfTextInputLayout inputLayout = new SfTextInputLayout();
                inputLayout.Hint = "Notes";
                inputLayout.InputView = customEntry;


                Button button = new Button();
                button.Text = "REVIEW";
                button.BackgroundColor = Color.Transparent;
                button.TextColor = Color.Black;
                button.Clicked += Button_Clicked_review;
                button.Image = "review.png";
                button.HorizontalOptions = LayoutOptions.End;
                stackLayout.Children.Add(inputLayout);
                stackLayout.Children.Add(button);

                return stackLayout;
            });
            popupLayout.PopupView.ShowFooter = false;
            popupLayout.PopupView.ShowHeader = false;
            popupLayout.PopupView.WidthRequest = 350;
            popupLayout.PopupView.HeightRequest = 180;
            popupLayout.PopupView.AnimationMode = AnimationMode.SlideOnBottom;
            popupLayout.Show();

        }
        private void Reject_Button_Clicked(object sender, EventArgs e)
        {
            customEntry = new Editor { HeightRequest = 100 };
            // this.BindingContext = new PopupViewModel();

            //customEntry.SetBinding(Editor.TextProperty, new Binding("PopupText", BindingMode.Default, null, null, null, this.BindingContext));
            popupLayout.PopupView.ContentTemplate = new DataTemplate(() =>
            {
                StackLayout stackLayout = new StackLayout();
                stackLayout.Orientation = StackOrientation.Vertical;

                SfTextInputLayout inputLayout = new SfTextInputLayout();
                inputLayout.Hint = "Notes";
                inputLayout.InputView = customEntry;


                Button button = new Button();
                button.Text = "REJECT";
                button.BackgroundColor = Color.Transparent;
                button.TextColor = Color.Black;
                button.Clicked += Button_Clicked_rejected;
                button.HorizontalOptions = LayoutOptions.End;
                button.Image = "reject.png";
                stackLayout.Children.Add(inputLayout);
                stackLayout.Children.Add(button);

                return stackLayout;
            });
            popupLayout.PopupView.ShowFooter = false;
            popupLayout.PopupView.ShowHeader = false;
            popupLayout.PopupView.WidthRequest = 350;
            popupLayout.PopupView.HeightRequest = 180;
            popupLayout.PopupView.AnimationMode = AnimationMode.SlideOnBottom;
            popupLayout.Show();
        }
       
        private void Button_Clicked_approved(object sender, EventArgs e)
        {
            this.EnteredApprovedText(customEntry.Text);
            popupLayout.IsOpen = false;
        }
        private void Button_Clicked_review(object sender, EventArgs e)
        {
            this.EnteredReviewText(customEntry.Text);
            popupLayout.IsOpen = false;
        }
        private void Button_Clicked_rejected(object sender, EventArgs e)
        {
            this.EnteredRejectText(customEntry.Text);
            popupLayout.IsOpen = false;
        }


        private async void EnteredApprovedText(string text)
        {

          
            orderId = this.order1.OrderID;
            HttpClient client = new HttpClient();
            var url = "http://10.156.11.183:8080/updateStatus/venu/" + orderId + "/Approved/" + text;
            HttpContent content = null;

            var result = await client.PostAsync(url, content);
            if (result.StatusCode == HttpStatusCode.Created)
            {
                await DisplayAlert("Hey!", "Your record has been approved", "Alright");
            }
           
            for (int i = 0; i < ListEnhanced.orders.OrderCollection.Count; i++)
            {
                if (ListEnhanced.orders.OrderCollection[i].OrderID.Equals(orderId))
                {
                    ApprovedOrdersPage.approvedOrders.OrderCollection.Add(ListEnhanced.orders.OrderCollection[i]);
                    ListEnhanced.orders.OrderCollection.Remove(ListEnhanced.orders.OrderCollection[i]);

                }
            }
           
            await Navigation.PopModalAsync();
        }

        private  void EnteredReviewText(string text)
        {
            
        }
        private async void EnteredRejectText(string text)
        {
           
            orderId = this.order1.OrderID;
            HttpClient client = new HttpClient();
            var url = "http://10.156.11.183:8080/updateStatus/venu/" + orderId + "/Rejected/" + text;
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
          
            await Navigation.PopModalAsync();
        }
       
        
      
    }
}