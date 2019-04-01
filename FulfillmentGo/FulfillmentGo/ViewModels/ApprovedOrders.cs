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
    public class ApprovedOrders : INotifyPropertyChanged
    {
        private ObservableCollection<OrderDetails> approvedOrderCollection;
        Random rand = new Random();
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<OrderDetails> OrderCollection
        {
            get { return approvedOrderCollection; }
            set { this.approvedOrderCollection = value; OnPropertyChanged(nameof(OrderCollection)); }
        }

        public ApprovedOrders()
        {
            Task.Run(async () =>
            {

                OrderCollection = await GenerateApprovedOrders();
            });

        }
        public async Task<ObservableCollection<OrderDetails>> GenerateApprovedOrders()
        {



            HttpClient client = new HttpClient();
            try
            {
                var response = await client.GetStringAsync("http://10.156.11.183:8080/getOpenOrderDetails/venu/Approved");

                Console.Write(response);
                return JsonConvert.DeserializeObject<ObservableCollection<OrderDetails>>(response);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return new ObservableCollection<OrderDetails>();

            

        }

        public ApprovedOrders(OrderDetails order)
        {
            if (approvedOrderCollection!=null)
              approvedOrderCollection = new ObservableCollection<OrderDetails>();
              approvedOrderCollection.Add(order);
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
