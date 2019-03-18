using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FulfillmentGo.ViewModels
{
    public class OrderInfoRepository
    {
        private ObservableCollection<OrderInfo> orderInfo;
        Random rand = new Random();
        public ObservableCollection<OrderInfo> OrderInfoCollection
        {
            get { return orderInfo; }
            set { this.orderInfo = value; }
        }


        public OrderInfoRepository()
        {
            orderInfo = new ObservableCollection<OrderInfo>();
            this.GenerateOrders();
        }

        private void GenerateOrders()
        {
            orderInfo.Add(new OrderInfo(1001, new DateTime(2014, 1, 1).AddDays(rand.Next(0, 60)), "Vendor4", 10, "Due"));
            orderInfo.Add(new OrderInfo(1002, new DateTime(2014, 1, 1).AddDays(rand.Next(0, 60)), "Vendor1", 40, "Due"));
            orderInfo.Add(new OrderInfo(1003, new DateTime(2014, 1, 1).AddDays(rand.Next(0, 60)), "Vendor1", 50, "Due"));
            orderInfo.Add(new OrderInfo(1004, new DateTime(2014, 1, 1).AddDays(rand.Next(0, 60)), "Vendor1", 60, "Due"));
            orderInfo.Add(new OrderInfo(1005, new DateTime(2014, 1, 1).AddDays(rand.Next(0, 60)), "Vendor2", 70, "Due"));
            orderInfo.Add(new OrderInfo(1006, new DateTime(2014, 1, 1).AddDays(rand.Next(0, 60)), "Vendor2", 20, "Due"));
            orderInfo.Add(new OrderInfo(1007, new DateTime(2014, 1, 1).AddDays(rand.Next(0, 60)), "Vendor2", 10, "Due"));
            orderInfo.Add(new OrderInfo(1008, new DateTime(2014, 1, 1).AddDays(rand.Next(0, 60)), "Vendor2", 5, "Due"));
            orderInfo.Add(new OrderInfo(1009, new DateTime(2014, 1, 1).AddDays(rand.Next(0, 60)), "Vendor3", 2, "Due"));
            orderInfo.Add(new OrderInfo(1010, new DateTime(2014, 1, 1).AddDays(rand.Next(0, 60)), "Vendor3", 21, "Due"));
            orderInfo.Add(new OrderInfo(1011, new DateTime(2014, 1, 1).AddDays(rand.Next(0, 60)), "Vendor3", 32, "Due"));
            orderInfo.Add(new OrderInfo(1012, new DateTime(2014, 1, 1).AddDays(rand.Next(0, 60)), "Vendor3", 42, "Due"));
            orderInfo.Add(new OrderInfo(1013, new DateTime(2014, 1, 1).AddDays(rand.Next(0, 60)), "Vendor4", 40, "Due"));
            orderInfo.Add(new OrderInfo(1014, new DateTime(2014, 1, 1).AddDays(rand.Next(0, 60)), "Vendor4", 90, "Due"));
        }
    }
}
