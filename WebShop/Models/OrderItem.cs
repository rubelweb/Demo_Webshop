using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemID { get; set; }
        public string OrderItemProductNumber { get; set; }
        public string OrderItemName { get; set; }
        public string OrderItemDescription { get; set; }
        public decimal OrderItemPrice { get; set; }
        public string OrderItemImagePath { get; set; }
        public int OrderCount { get; set; }

        //[ForeignKey("Order")]
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }

    }
}