using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopWinApp.Model
{
    public class OData<T>
    {
        public T[] Value { get; set; }
    }
}
