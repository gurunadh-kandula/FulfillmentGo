using FulfillmentGo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FulfillmentGo.ViewModels
{
    public class RejectedOrders : INotifyPropertyChanged
    {
        private ObservableCollection<OrderDetails> rejectedOrderCollection;
        Random rand = new Random();
      public event PropertyChangedEventHandler PropertyChanged;
      public ObservableCollection<OrderDetails> OrderCollection
        {
            get { return rejectedOrderCollection; }
            set { this.rejectedOrderCollection = value; OnPropertyChanged(nameof(OrderCollection)); }
    }


        public RejectedOrders()
        {
            Task.Run(async () =>
            {

                OrderCollection = await GenerateRejectedOrders();
            });

        }

        private async Task<ObservableCollection<OrderDetails>> GenerateRejectedOrders()
        {
            HttpClient client = new HttpClient();
            try
            {
                var response = await client.GetStringAsync("http://10.156.11.183:8080/getOpenOrderDetails/venu/Rejected");

                Console.Write(response);
                return JsonConvert.DeserializeObject<ObservableCollection<OrderDetails>>(response);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return new ObservableCollection<OrderDetails>();
        }
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
