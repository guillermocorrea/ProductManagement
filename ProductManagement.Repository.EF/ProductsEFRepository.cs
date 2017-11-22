using ProductManagement.Domain;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace ProductManagement.Repository.EF
{
    public class ProductsEFRepository : IProductsRepository
    {
        private readonly ProductsContext _productsContext;
        private Mapper _mapper;

        public ProductsEFRepository(ProductsContext productsContext)
        {
            _productsContext = productsContext;
            var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<DataModel.Product, ProductManagement.Domain.Product>());
            _mapper = new Mapper(mapperConfig);
        }

        public void AddProduct(Product product)
        {
            _productsContext.Add(product);
        }

        public IList<Product> GetProducts()
        {
            return _mapper.DefaultContext.Mapper.Map<IList<Product>>(_productsContext.Products.ToList());
        }
    }
}
