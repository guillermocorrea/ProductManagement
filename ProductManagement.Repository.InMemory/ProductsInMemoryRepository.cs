using ProductManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagement.Repository.InMemory
{
    public class ProductsInMemoryRepository : IProductsRepository
    {
        private static IList<Product> _products = new List<Product>();

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public IList<Product> GetProducts()
        {
            return _products;
        }
    }
}
