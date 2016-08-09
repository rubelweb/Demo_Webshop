using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoViewModelBase;
using System.Net.Http;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace WebShopWinApp.Model
{
    public class Repository : ViewModelBase
    {
        private string localUri = "http://localhost:2888/";
        private string remoteUri = "http://sayednewtonshop.azurewebsites.net/";

        private static Repository instancerepository = new Repository();
        public static Repository InstanceRepository
        {
            get { return instancerepository; }
        }

        private ObservableCollection<OrderItem> orderitems;
        public ObservableCollection<OrderItem> OrderItems
        {
            get { return orderitems; }
            set
            {
                orderitems = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<OProduct> oproducts;
        public ObservableCollection<OProduct> OProducts
        {
            get { return oproducts; }
            set
            {
                oproducts = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Product> tproducts;
        public ObservableCollection<Product> TProducts
        {
            get { return tproducts; }
            set
            {
                tproducts = value;
                OnPropertyChanged();
            }
        }

        private string orderref;
        public string OrderRef
        {
            get { return orderref; }
            set
            {
                orderref = value;
                OnPropertyChanged();
            }
        }
        private decimal total;
        public decimal Total
        {
            get { return total; }
            set
            {
                total = value;
                OnPropertyChanged();
            }
        }
        public Repository()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {

                var olocalproducts = new List<OProduct>(){new OProduct(){product= new Product()
                   { ProductName="Test", ProductNumber="T-200", ProductDescription="Test Description",
                     ProductPrice=100m, ProductImagePath=""}}};
                OProducts = new ObservableCollection<OProduct>(olocalproducts);

                var localorderitems = new List<OrderItem>(){new OrderItem()
                   { OrderItemName="Test Order", OrderItemProductNumber= "Task-200", OrderItemDescription= "Test Order Description",
                     OrderItemPrice= 100m, OrderItemImagePath= "", OrderCount=0}};
                OrderItems = new ObservableCollection<OrderItem>(localorderitems);
            }

            else
            {
                Initialize();
            }
        }
        private async void Initialize()
        {

            var productlist = await GetProducts();

            OrderItems = new ObservableCollection<OrderItem>();
            OProducts = new ObservableCollection<OProduct>(productlist);
            TProducts = new ObservableCollection<Product>();
        }
        private async Task<List<OProduct>> GetProducts()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(localUri);
            var response = await client.GetStringAsync("odata/ProductsOData");
            var odata = JsonConvert.DeserializeObject<OData<Product>>(response);
            List<Product> listofproducts = odata.Value.ToList<Product>();

            var oproducts = listofproducts.Select(p => new OProduct() { product = p }).ToList<OProduct>();

            return oproducts;

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(remoteUri);
            //HttpResponseMessage response = await client.GetAsync("api/ProductsApi");
            //var products = await response.Content.ReadAsAsync<List<Product>>();

            //var oproducts = products.Select(p => new OProduct() { product = p }).ToList<OProduct>();

            //return oproducts;
        }

        public async void SaveOrder(Order order)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(localUri);
            await client.PostAsJsonAsync<Order>("api/OrdersApi", order);
        }
        public void EditProduct(List<Product> Productlist)
        {
            foreach (Product pro in Productlist)
            {

                var PQuantity = Productlist.Select(i => i.ProductQuantity).Last();
                var PId = Productlist.Select(i => i.ProductID).Last();
                if (pro.ProductID == PId)
                {
                    pro.ProductQuantity = PQuantity;
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(localUri);
                    client.PutAsJsonAsync("api/ProductsApi/" + pro.ProductID, pro);
                }
                else
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(localUri);
                    client.PutAsJsonAsync("api/ProductsApi/" + pro.ProductID, pro);
                }


            }
        }
    }
}
