using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoViewModelBase;
using WebShopWinApp.Service;
using System.Collections.ObjectModel;

namespace WebShopWinApp.Model
{
    public class OProduct: ViewModelBase
    {

        private static OProduct instanceoproduct = new OProduct();
        public static OProduct InstanceOProduct
        {
            get { return instanceoproduct; }
        }

        public Product product { get; set; }
        
        
        private OrderService orderservice = new OrderService();

        private List<Product> productitems;
        public List<Product> ProductItems
        {
            get { return productitems; }
            set
            {
                productitems = value;
            }
        }


        private int ordercount;
        public int OrderCount
        {
            get { return ordercount; }
            set
            {
               
                ordercount = value++;
                OnPropertyChanged();
                Product p=orderservice.ProcessOrder(this.product);
                Repository.InstanceRepository.TProducts.Add(p);
                CalculateOrder();
                
            }
        }


        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged();
            }
        }
        public void CalculateOrder()
        {          
            Product p = new Product();
            p.ProductQuantity = product.ProductQuantity - ordercount;

            if (p.ProductQuantity == 0)
            {
                Message = "Slut";
            }
            else if (p.ProductQuantity < 5 && p.ProductQuantity>0)
            {
                Message = "<5";
            }
            else
            {
                Message = "I lagar";
            }
        
        }

    }
}
