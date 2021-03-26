using System;
using System.Collections.Generic;

namespace Dozen2Models
{
    public class Order
    {
        private int orderID; 
        public int OrderID 
        {
            get{return orderID;}
            set{orderID = value;}
        }
        private decimal total;

        //list of order items aka collection

        

        //public string DrinkName { get; set; }
        public int CustomerID { get; set; }

        public virtual Customer Customer { get; set; }

        public int LocationID { get; set; }

        public virtual Location Location { get; set; }
        public decimal Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
            }
        }

        public DateTime OrderDateTime { get; set; }

        public virtual List<DrinkOrder> DrinkOrders { get; set; }

        public Order()
        {
            OrderDateTime = DateTime.Now;
        }




        public override string ToString()
        {
            return $"Order ID: {this.OrderID} \n\tTotal: ${this.Total}";
        }

    }
}