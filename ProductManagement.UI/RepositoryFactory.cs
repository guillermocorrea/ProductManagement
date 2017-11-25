using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain;
using ProductManagement.Repository.EF;
using ProductManagement.Repository.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.UI
{
    public class RepositoryFactory
    {
        private readonly AppSettings _appState;
        private readonly ProductsContext _productsContext;
        private readonly IMapper _mapper;

        public RepositoryFactory(AppSettings appState, ProductsContext productsContext, IMapper mapper)
        {
            _appState = appState;
            _productsContext = productsContext;
            _mapper = mapper;
        }

        public IProductsRepository Build()
        {
            return _appState.CurrentDataStorage == DataStorageOption.InMemory ?
                (IProductsRepository) new ProductsInMemoryRepository() : (IProductsRepository) new ProductsEFRepository(_productsContext, _mapper);
        }
    }
}
