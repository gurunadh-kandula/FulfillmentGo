using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.XForms.PopupLayout;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FulfillmentGo.Views.Pages;
using FulfillmentGo.Models;
using FulfillmentGo.ViewModels;
using Syncfusion.ListView.XForms;
using System.Globalization;
using System.Net.Http;
using System.Net;
using Syncfusion.SfChart.XForms;

namespace FulfillmentGo.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListEnhanced : ContentPage
    {
        public static Orders orders { get; set; }
        public List<String> urgencyColor { get; set; }
        private SearchBar searchBar;
      
        public ListEnhanced()
        {
            InitializeComponent();
            BindingContext = orders = new Orders();
            //for (int i = 0; i < orders.OrderCollection.Count; i++)
            //{ switch (orders.OrderCollection[i].Urgency)
            //    {
            //        case "High":
            //            urgencyColor.Add("Red");
            //            break;
            //        case "Medium":
            //            urgencyColor.Add("Yellow");
            //            break;
            //        case "Low":
            //            urgencyColor.Add("Green");
            //            break;
            //     }
            //  }
            //Box.ItemsSource = urgencyColor;
           
             popupLayout.PopupView.AppearanceMode = Syncfusion.XForms.PopupLayout.AppearanceMode.OneButton;
            //popupLayout.PopupView.HeaderTitle = "Details";
            //popupLayout.PopupView.AcceptButtonText = "Continue...";
            popupLayout.PopupView.HeightRequest = 200;

        }

        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
         {
             searchBar = (sender as SearchBar);
             if (listView.DataSource != null)
             {
                 this.listView.DataSource.Filter = FilterOrders;
                 this.listView.DataSource.RefreshFilter();
             }
         }
        private void ListView_Swiping(object sender, SwipingEventArgs e)
        {
            //if (e.ItemIndex == 1 && e.SwipeOffSet > 70)
            //    e.Handled = true;
            //if((e.SwipeDirection).Equals(""))

            //    if (e.SwipeOffSet >= 200)
            //{
            //    this.orders.OrderCollection.RemoveAt(e.ItemIndex);
            //    //listView.ResetSwipe();
            //}
            //if (e.SwipeDirection.Equals(Syncfusion.ListView.XForms.SwipeDirection.Right) && e.SwipeOffSet >= 150)
            //{
            //    orders.OrderCollection.RemoveAt(e.ItemIndex);
            //}
           
        }
        private async  void ListView_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            var orderDetails =(e.ItemData) as OrderDetails;
            String orderid = orderDetails.OrderID;
            HttpClient client = new HttpClient();
            if (e.SwipeOffset >= 360)
            {
                if (e.SwipeDirection.Equals(Syncfusion.ListView.XForms.SwipeDirection.Right))
                    {
                    
                    var url = "http://10.156.11.183:8080/updateStatus/venu/" + orderid + "/Approved/" + "Notes";
                    HttpContent content = null;

                    var result = await client.PostAsync(url, content);
                    if (result.StatusCode == HttpStatusCode.Created)
                    {
                        await DisplayAlert("Hey!", "Your record has been approved", "Alright");
                    }
                    //await  Navigation.PopAsync();
                    //await Navigation.PopModalAsync();
                    //await Navigation.PopAsync();
                    for (int i = 0; i < ListEnhanced.orders.OrderCollection.Count; i++)
                    {
                        if (ListEnhanced.orders.OrderCollection[i].OrderID.Equals(orderid))
                        {
                            //ApprovedOrdersPage.approvedOrders.OrderCollection.Add(ListEnhanced.orders.OrderCollection[i]);
                            ApprovedOrdersPage.approvedOrders.OrderCollection.Insert(0,ListEnhanced.orders.OrderCollection[i]);
                            ListEnhanced.orders.OrderCollection.Remove(ListEnhanced.orders.OrderCollection[i]);

                        }
                    }

                }
                else

                {
                    var url = "http://10.156.11.183:8080/updateStatus/venu/" + orderid + "/Rejected/" + "Notes";
                    HttpContent content = null;

                    var result = await client.PostAsync(url, content);
                    if (result.StatusCode == HttpStatusCode.Created)
                    {
                        await DisplayAlert("Hey!", "Your record has been rejected", "Alright");
                    }
                    for (int i = 0; i < ListEnhanced.orders.OrderCollection.Count; i++)
                    {
                        if (ListEnhanced.orders.OrderCollection[i].OrderID.Equals(orderid))
                        {
                            //RejectedOrdersPage.rejectedOrders.OrderCollection.Add(ListEnhanced.orders.OrderCollection[i]);
                            RejectedOrdersPage.rejectedOrders.OrderCollection.Insert(0,ListEnhanced.orders.OrderCollection[i]);
                            ListEnhanced.orders.OrderCollection.Remove(ListEnhanced.orders.OrderCollection[i]);

                        }
                    }
                }
 


                //orders.OrderCollection.RemoveAt(e.ItemIndex);
                listView.ResetSwipe();
            }
        }
        private bool FilterOrders(object obj)
        {
            if (searchBar == null || searchBar.Text == null)
                return true;

            var orderDetails= obj as OrderDetails;
            if (orderDetails.Status.ToLower().Contains(searchBar.Text.ToLower())
                || orderDetails.Source.ToLower().Contains(searchBar.Text.ToLower())|| orderDetails.OrderID.ToLower().Contains(searchBar.Text.ToLower()) || orderDetails.OrderValue.ToString("0.").Contains(searchBar.Text)|| orderDetails.Qty.ToString("0.").Contains(searchBar.Text))
                return true;
            else
                return false;
        }
        private void listView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            OrderDetailPage newPage = new OrderDetailPage();
            
            newPage.BindingContext = (e.ItemData) as OrderDetails;
            newPage.order1 = (e.ItemData) as OrderDetails;
           
            Navigation.PushModalAsync(newPage);


           
            
           // Navigation.PushModalAsync(new OrderDetailPage(order));
            listView.SelectedItem = null;
        }

        private void ListView_ItemHolding(object sender, Syncfusion.ListView.XForms.ItemHoldingEventArgs e)
        {   var orderDetails = (e.ItemData) as OrderDetails;
            if (orderDetails != null)
            {
                popupLayout.PopupView.BindingContext = orderDetails;
                popupLayout.PopupView.HeaderTitle = "Notes";
                popupLayout.PopupView.ShowFooter = false;

                var customTemplate = new DataTemplate(() =>
                {
                    var notes = new Label();
                    notes.SetBinding(Label.TextProperty, new Binding("Notes", BindingMode.Default, null, null, null, orderDetails));

                    
                    var stack = new StackLayout();
                    stack.Padding = new Thickness(10, 20, 10, 0);
                    stack.Children.Add(notes);
                    

                    var viewcell = new ViewCell()
                    {
                        View = stack,
                    };

                    return viewcell;

                });

                popupLayout.PopupView.ContentTemplate = customTemplate;
                popupLayout.Show();
            }
            //popupLayout.BindingContext= orderDetails;
            //popupLayout.Show();

        }
    }
    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {   if(value!=null)
            { 
            string valueAsString = value.ToString();
            switch (valueAsString)
            {
                case (""):
                    {
                        return Color.Default;
                    }
                case ("Accent"):
                    {
                        return Color.Accent;
                    }
                default:
                    {
                        return Color.FromHex(value.ToString());
                    }
            }
            }
            return Color.Green;
        }

       
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

       
    }
}