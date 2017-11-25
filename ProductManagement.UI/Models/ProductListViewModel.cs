using ProductManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.UI.Models
{
    public class ProductListViewModel
    {
        public DataStorageOption DataStorage { get; set; }
        public IList<Product> Products { get; set; }
    }
}
