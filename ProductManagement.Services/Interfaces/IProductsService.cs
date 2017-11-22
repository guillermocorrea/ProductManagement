using ProductManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Services.Interfaces
{
    public interface IProductsService
    {
        Task<IList<Product>> GetProducts();
        Task AddProduct(Product product);
    }
}
