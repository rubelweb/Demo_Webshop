using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string OrderRef { get; set; }
        public decimal OrderPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
    }
}