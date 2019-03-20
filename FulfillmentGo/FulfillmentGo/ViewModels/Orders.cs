using FulfillmentGo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
            orderCollection.Add(new OrderDetails("91075022877", "OOPT - BAO139.16 - V1", "OOPT - BAO139.16 - DC60",10.0,"Open", "2019-03-20", "TestNote",1,2,3,4, 200.0, "Open", 20.0, 20.0, 30.0));
            orderCollection.Add(new OrderDetails("91074975362", "OOPT-SUP50.05-V1", "OOPT-SUP50.05-DC1", 10.0, "Open", "2019-03-20", "TestNote", 1, 2, 3, 4, 200.0, "Open", 20.0, 20.0, 30.0));
        }
    }
}

