using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoViewModelBase;

namespace WebShopWinApp.Model
{
    public class Product: ViewModelBase
    {
        public int ProductID { get; set; }
        public int productquantity { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImagePath { get; set; }
                   
        
        public int ProductQuantity
        {
            get { return productquantity; }
            set { productquantity = value;
                  OnPropertyChanged();
                }
        }
    }
}
