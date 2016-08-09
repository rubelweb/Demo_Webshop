using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoViewModelBase;

namespace WebShopWinApp.Model
{
    public class OrderItem: ViewModelBase
    {
        public string OrderItemProductNumber { get; set; }
        public string OrderItemName { get; set; }
        public string OrderItemDescription { get; set; }
        public decimal OrderItemPrice { get; set; }
        public string OrderItemImagePath { get; set; }
        private int ordercount;
        public int OrderCount
        {
            get { return ordercount; }
            set 
            {
                ordercount = value;
                OnPropertyChanged();    
            }
        }
    }
}
