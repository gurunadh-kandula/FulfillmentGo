using System;
using System.Collections.Generic;
using System.Text;

namespace FulfillmentGo.Models
{
    public enum MenuItemType
    {
        Mainmenu,
        Purchasing,
        Pricing,
        Promotion,
        Markdown,
        Transportation,
        Sales,
        Logout
    }

    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }
        public string Title { get; set; }
    }
}
