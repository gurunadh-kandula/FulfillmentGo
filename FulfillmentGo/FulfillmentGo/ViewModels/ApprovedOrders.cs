using FulfillmentGo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FulfillmentGo.ViewModels
{
    public class ApprovedOrders
    {
        private ObservableCollection<OrderDetails> approvedOrderCollection;
        Random rand = new Random();
        public ObservableCollection<OrderDetails> OrderCollection
        {
            get { return approvedOrderCollection; }
            set { this.approvedOrderCollection = value; }
        }

        public ApprovedOrders()
        {


        }

        public ApprovedOrders(OrderDetails order)
        {
            if (approvedOrderCollection!=null)
              approvedOrderCollection = new ObservableCollection<OrderDetails>();
              approvedOrderCollection.Add(order);
         }

       
    }
}
