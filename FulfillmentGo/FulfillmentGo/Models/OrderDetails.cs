using System;
using System.Collections.Generic;
using System.Text;

namespace FulfillmentGo.Models
{
   public class OrderDetails
    {
        private String orderId;

        private String source;

        private String destination;

        private double qty; 

        private String status;

        private String arrivalDate;

        private String notes;

        private long delayDur;

        private long needCovDur;

        private long networkMinCovDur;

        private long finalCovDur;

        private double orderValue;

        private String networkMinStatus;

        private double uom;

        private double suppOrderQty;

        private double fwdBuyQty;
        private long noOfTrucks;
        private long noOfSKUs;


       // private string company;
        public OrderDetails()
        {

        }

        public OrderDetails(String orderId, String source, String destination, double qty, String status, String arrivalDate,
            String notes, long delayDur, long needCovDur, long networkMinCovDur, long finalCovDur, double orderValue,
            String networkMinStatus, double uom, double suppOrderQty, double fwdBuyQty, long noOfTrucks, long noOfSKUs)
        {
            this.orderId = orderId;
            this.source = source;
            this.destination = destination;
            this.qty = qty;
            this.status = status;
            this.arrivalDate = arrivalDate;
            this.notes = notes;
            this.delayDur = delayDur;
            this.needCovDur = needCovDur;
            this.networkMinCovDur = networkMinCovDur;
            this.finalCovDur = finalCovDur;
            this.orderValue = orderValue;
            this.networkMinStatus = networkMinStatus;
            this.uom = uom;
            this.suppOrderQty = suppOrderQty;
            this.fwdBuyQty = fwdBuyQty;
            this.noOfTrucks=noOfTrucks;
            this.noOfSKUs = noOfSKUs;
        }
        public String OrderID { get => orderId; set => orderId = value; }
        public String Source { get => source; set => source = value; }
        public String Destination { get => destination; set => destination = value; }
        public Double Qty { get => qty; set => qty=value; }
        public String Status { get => status; set => status = value; }

        public String ArrivalDate { get => arrivalDate; set => arrivalDate = value; }
        public String Notes { get => notes; set => notes = value; }

        public long DelayDur { get => delayDur; set => delayDur= value; }
        public long NeedCovDur { get => needCovDur; set => needCovDur = value; }

        public long NetworkMinCovDur { get =>networkMinCovDur; set => networkMinCovDur = value; }
        public long FinalCovDur { get =>finalCovDur; set => finalCovDur = value; }

        public Double OrderValue { get => orderValue; set => orderValue = value; }

        public String NetworkMinStatus { get => networkMinStatus; set =>networkMinStatus=value; }

        public Double Uom { get => uom; set => uom = value; }
        public Double SuppOrderQty{ get => suppOrderQty; set => suppOrderQty = value; }
        public Double FwdBuyQty{ get => fwdBuyQty; set => fwdBuyQty = value; }
        public long NoOfTrucks { get => noOfTrucks; set => noOfTrucks = value; }
        public long NoOfSKUs { get => noOfSKUs; set => noOfSKUs = value; }





    }
}
