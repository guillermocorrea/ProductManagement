using ProductManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ProductManagement.Domain;
using System.Threading.Tasks;

namespace ProductManagement.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task AddProduct(Product product)
        {
            await Task.Run(() => _productsRepository.AddProduct(product));
        }

        public async Task<IList<Product>> GetProducts()
        {
            return await Task.Run(() => _productsRepository.GetProducts());
        }
    }
}
