using FulfillmentGo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Text;

namespace FulfillmentGo.ViewModels
{
    public class Orders
    {
        private ObservableCollection<OrderDetails> orderCollection;
        Random rand = new Random();
        public ObservableCollection<OrderDetails> OrderCollection
        {
            get { return orderCollection; }
            set { this.orderCollection = value; }
        }


        public Orders()
        {
            orderCollection = new ObservableCollection<OrderDetails>();
            this.GenerateOrders();
        }

        private void GenerateOrders()
        {
            /*String response;
            StreamReader strm = new StreamReader("Orders.json");
            response = strm.ReadToEnd();
            ObservableCollection<OrderDetails> sample = JsonConvert.DeserializeObject<ObservableCollection<OrderDetails>>(response);
            */

            //orderInfo.Add(new OrderInfo(1001, new DateTime(2014, 1, 1).AddDays(rand.Next(0, 60)), "Vendor4", 10, "Due"));
           
           /* HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://vdmi-gurram:8080/getOpenOrderDetails");
            orderCollection= JsonConvert.DeserializeObject<ObservableCollection<OrderDetails>>(response);*/
           orderCollection.Add(new OrderDetails("91075022877", "OOPT - BAO139.16 - V1", "OOPT - BAO139.16 - DC60", 10000.0, "Open", "2019-03-20", "Buying additional quantity of 800 due to future price increase", 6, 2, 3, 4, 200.0, "Open", 20.0, 20.0, 30.0, 10, 10));
           orderCollection.Add(new OrderDetails("91074975362", "OOPT-SUP50.05-V1", "OOPT-SUP50.05-DC1", 20000.0, "Open", "2019-03-20", "Buying additional quantity of 2000 due to discount  and promotions", -5, 2, 3, 4, 1000.0, "Open", 20.0, 20.0, 30.0, 20, 20));
           orderCollection.Add(new OrderDetails("91075022805", "OOPT-SUP50.05-V1", "OOPT-BAO139.15-V1", 19000.0, "Open", "2019-03-22", "It is an urgent order due to increase in sales ", 3, 10, 11, 12, 800.0, "Open", 20.0, 20.0, 30.0, 30, 30));
          

        }
    }
}