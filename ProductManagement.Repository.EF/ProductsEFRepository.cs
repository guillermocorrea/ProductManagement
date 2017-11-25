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
        private IMapper _mapper;

        public ProductsEFRepository(ProductsContext productsContext, IMapper mapper)
        {
            _productsContext = productsContext;
            _mapper = mapper;
        }

        public void AddProduct(Product product)
        {
            _productsContext.Products.Add(_mapper.Map<DataModel.Product>(product));
            _productsContext.SaveChanges();
        }

        public IList<Product> GetProducts()
        {
            return _mapper.Map<IList<Product>>(_productsContext.Products.ToList());
        }
    }
}
