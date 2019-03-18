using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FulfillmentGo.ViewModels
{
    public class Books
    {
        public ObservableCollection<Book>Data{ get;set; }
        public Books()
        {
            Data = new ObservableCollection<Book>();
            FillData();
        }
        private void FillData()
        {
            Book obj = new Book()
            { Name = "Cowboy",
                Quantity = 23
            };
            Data.Add(obj);
            Book obj1 = new Book()
            {
                Name = "sherlock",
                Quantity = 12
            };
            Data.Add(obj1);
            Book obj2 = new Book()
            {
                Name = "Marvel",
                Quantity = 4
            };
            Data.Add(obj2);
            Book obj3 = new Book()
            {
                Name = "Agathe christe",
                Quantity = 2
            };
            Data.Add(obj3);

        }
    }
}
