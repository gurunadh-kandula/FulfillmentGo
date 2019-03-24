using FulfillmentGo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FulfillmentGo.ViewModels
{
    public class RejectedOrders
    {
        private ObservableCollection<OrderDetails> rejectedOrderCollection;
        Random rand = new Random();
        public ObservableCollection<OrderDetails> OrderCollection
        {
            get { return rejectedOrderCollection; }
            set { this.rejectedOrderCollection = value; }
        }


        public RejectedOrders()
        {
            rejectedOrderCollection = new ObservableCollection<OrderDetails>();
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
           rejectedOrderCollection.Add(new OrderDetails("910750225678", "OOPT - BAO139.16 - V1", "OOPT - BAO139.16 - DC60", 10.0, "Rejected", "2019-03-20", "TestNote", 6, 2, 3, 4, 200.0, "Open", 20.0, 20.0, 30.0,0,0));
     }
    }
}
