using System;
using System.Collections.Generic;
using System.Text;

namespace FulfillmentGo.Models
{
    public enum MenuItemType
    {
        PurchaseOrderApproval,
        AllocationApproval,
        StockTransferOrderApproval,
        BusinessNotification,
        GridPage,
        ApprovalOrdersPage,
        OrderDetailPage,
        Logout
    }

    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }
        public string Title { get; set; }
    }
}
