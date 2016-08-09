using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopWinApp.Model;
using DemoViewModelBase;
using System.Collections.ObjectModel;

namespace WebShopWinApp.Service
{
    public class OrderService: ViewModelBase
    {
        public ObservableCollection<Product> temproduct { get; set; }
        public List<Product> ProductItems = new List<Product>();

        public Product ProcessOrder(Product product)
        {
            OrderItem orderitem = new OrderItem();
            orderitem.OrderItemProductNumber = product.ProductNumber;
            orderitem.OrderItemName = product.ProductName;
            orderitem.OrderItemDescription = product.ProductDescription;
            orderitem.OrderItemPrice = product.ProductPrice;
            orderitem.OrderItemImagePath = product.ProductImagePath;


            if (Repository.InstanceRepository.OrderItems.Count > 0)
            {
                var doublecount = Repository.InstanceRepository.OrderItems.Where(i => i.OrderItemProductNumber == product.ProductNumber).Count();                       

                   if(doublecount!=0)
                   {

                       Repository.InstanceRepository.OrderItems.Where(i=>i.OrderItemProductNumber==product.ProductNumber).First().OrderCount++;
                       product.ProductQuantity--;
                   }

                   else
                     {
                        Repository.InstanceRepository.OrderItems.Add(orderitem);
                        orderitem.OrderCount=1;
                        product.ProductQuantity = product.ProductQuantity - orderitem.OrderCount;
                     }
             }

            else
            {
                Repository.InstanceRepository.OrderItems.Add(orderitem);
                orderitem.OrderCount = 1;
                product.ProductQuantity = product.ProductQuantity - orderitem.OrderCount;
             
            }

            Repository.InstanceRepository.Total = Repository.InstanceRepository.OrderItems.Sum(i => i.OrderItemPrice * i.OrderCount);

            Product p = new Product();

            p.ProductID = product.ProductID;           
            p.ProductQuantity = product.ProductQuantity;            
            p.ProductNumber = product.ProductNumber;
            p.ProductName = product.ProductName;
            p.ProductDescription = product.ProductDescription;
            p.ProductPrice = product.ProductPrice;
            p.ProductImagePath = product.ProductImagePath;
            
            return p;
        }

        public void CheckoutOrder()
        {
            Order order = new Order();
            order.OrderDate = DateTime.Now;
            order.OrderRef = Repository.InstanceRepository.OrderRef;
            order.OrderPrice = Repository.InstanceRepository.Total;
            order.OrderItems = Repository.InstanceRepository.OrderItems.ToList<OrderItem>();
            
            Repository.InstanceRepository.SaveOrder(order);          

            List<Product> plist = new List<Product>();           
            plist = Repository.InstanceRepository.TProducts.ToList<Product>();
            Repository.InstanceRepository.EditProduct(plist);

            Repository.InstanceRepository.OrderRef = "";
            Repository.InstanceRepository.OrderItems.Clear();
            Repository.InstanceRepository.Total = 0;

        }        
        
    }
}
