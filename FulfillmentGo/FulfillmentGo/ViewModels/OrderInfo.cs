using System;
using System.Collections.Generic;
using System.Text;

namespace FulfillmentGo.ViewModels
{
    public class OrderInfo
    {
        private int orderID;
        private DateTime orderPlaceDate;
        private string vendor;
        private int quantity;
        private string status;

        //private string shipCountry;


        public OrderInfo(int orderId, DateTime orderPlaceDate, string vendor, int quantity, string status)
        {
            this.OrderID = orderId;
            this.orderPlaceDate = orderPlaceDate;
            this.vendor = vendor;
            this.quantity = quantity;
            this.status = status;
        }

        public int OrderID { get => orderID; set => orderID = value; }
        public DateTime OrderPlaceDate { get => orderPlaceDate; set => orderPlaceDate = value; }
        public string Vendor { get => vendor; set => vendor = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string Status { get => status; set => status = value; }

    }
}
