using FulfillmentGo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FulfillmentGo.ViewModels;

namespace FulfillmentGo.Services
{
    public class RestServices
    {
        Orders orderViewModel = new Orders();

        public async Task<Orders> GenerateOrders()
        {

            /* HttpClient client = new HttpClient();
              var response = await client.GetStringAsync("http://vdmi-gurram:8080/getOpenOrderDetails");
             orderCollection= JsonConvert.DeserializeObject<ObservableCollection<OrderDetails>>(response);*/


            
            HttpClient client = new HttpClient();
            try
            {
                var response = await client.GetStringAsync("http://10.156.11.183:8080/getOpenOrderDetails");

                Console.Write(response);
                orderViewModel.OrderCollection = JsonConvert.DeserializeObject<ObservableCollection<OrderDetails>>(response);
                return orderViewModel;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return orderViewModel;
            }
        }
    }
}
