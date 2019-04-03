using System;
using System.Collections.Generic;
using System.Text;

namespace FulfillmentGo.Models
{
   public  class Quantitytype
    {
        public String Name { get; set; }
        public Double value { get; set; }
        public Quantitytype(String Name, Double value)
        {
            this.Name = Name;
            this.value = value;

        }
    }
   
}
