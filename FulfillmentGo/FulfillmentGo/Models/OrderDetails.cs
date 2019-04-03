using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private String urgency;
        private String orderType;
        private long type1Qty;

        private long type2Qty;

        private long type3Qty;
        private double unRoundedQty;
        private double totalOrdersValue;

        private String approvalNotes;
        // private string company;
        public OrderDetails()
        {
        }

        public OrderDetails(String orderId, String source, String destination, double qty, String status, String arrivalDate,
            String notes, long delayDur, long needCovDur, long networkMinCovDur, long finalCovDur, double orderValue,
            String networkMinStatus, double uom, double suppOrderQty, double fwdBuyQty, long noOfTrucks, long noOfSKUs, String urgency, String orderType, long type1Qty, long type2Qty, long type3Qty, double unRoundedQty , double totalOrdersValue, String approvalNotes)
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
            this.noOfTrucks = noOfTrucks;
            this.noOfSKUs = noOfSKUs;
            this.urgency = urgency;
            this.orderType = orderType;
            this.type1Qty = type1Qty;
            this.type2Qty = type2Qty;
            this.type3Qty = type3Qty;
            this.unRoundedQty = unRoundedQty;
            this.totalOrdersValue = totalOrdersValue;
            this.approvalNotes = approvalNotes;
        }
        public String OrderID { get => orderId; set => orderId = value; }
        public String Source { get => source; set => source = value; }
        public String Destination { get => destination; set => destination = value; }
        public Double Qty { get => qty; set => qty = value; }
        public String Status { get => status; set => status = value; }

        public String ArrivalDate { get => arrivalDate; set => arrivalDate = value; }
        public String Notes { get => notes; set => notes = value; }

        public long DelayDur { get => delayDur; set => delayDur = value; }
        public long NeedCovDur { get => needCovDur; set => needCovDur = value; }

        public long NetworkMinCovDur { get => networkMinCovDur; set => networkMinCovDur = value; }
        public long FinalCovDur { get => finalCovDur; set => finalCovDur = value; }

        public Double OrderValue { get => orderValue; set => orderValue = value; }

        public String NetworkMinStatus { get => networkMinStatus; set => networkMinStatus = value; }

        public Double Uom { get => uom; set => uom = value; }
        public Double SuppOrderQty { get => suppOrderQty; set => suppOrderQty = value; }
        public Double FwdBuyQty { get => fwdBuyQty; set => fwdBuyQty = value; }
        public long NoOfTrucks { get => noOfTrucks; set => noOfTrucks = value; }
        public long NoOfSKUs { get => noOfSKUs; set => noOfSKUs = value; }

        public String Urgency { get => urgency; set => urgency = value; }

        public String OrderType { get => orderType; set => orderType = value; }
        public long Type1Qty { get => type1Qty; set => type1Qty = value; }
        public long Type2Qty { get => type2Qty; set => type2Qty = value; }
        public long Type3Qty { get => type3Qty; set => type3Qty = value; }


       
        public Double UnRoundedQty { get => unRoundedQty; set => unRoundedQty = value; }
        public Double TotalOrdersValue { get => totalOrdersValue; set => totalOrdersValue = value; }
        public String ApprovalNotes { get => approvalNotes; set => approvalNotes = value; }

        public ObservableCollection<Quantitytype> Quantitytypes
        {
            get
            {
                return new ObservableCollection<Quantitytype>
                {
                    new Quantitytype("Order value",this.OrderValue),
                    new Quantitytype("SuppOrderQty",this.SuppOrderQty),
                    new Quantitytype("FwdBuyQty",this.FwdBuyQty),
                };
            }
        }
    }
}
