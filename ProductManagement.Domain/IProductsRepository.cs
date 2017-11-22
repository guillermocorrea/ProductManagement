using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagement.Domain
{
    public interface IProductsRepository
    {
        IList<Product> GetProducts();
        void AddProduct(Product product);
    }
}
