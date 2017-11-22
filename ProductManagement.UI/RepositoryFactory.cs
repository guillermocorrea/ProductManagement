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
        private static ProductsEFRepository _efRepository = null;
        private static ProductsInMemoryRepository _inMemoryRepository = null;

        private static readonly object _inMemoryPadlock = new object();
        private static readonly object _efPadlock = new object();

        private readonly AppState _appState;

        private readonly string _connectionString;

        public RepositoryFactory(AppState appState, string connectionString)
        {
            _appState = appState;
            _connectionString = connectionString;
        }

        public IProductsRepository Build()
        {
            //return _appState.CurrentDataStorage == DataStorageOption.InMemory ? 
            throw new NotImplementedException();
        }

        private static ProductsEFRepository EFRepository
        {
            get
            {
                lock (_efPadlock)
                {
                    if (_efRepository == null)
                    {
                        var optionsBuilder = new DbContextOptionsBuilder<ProductsContext>();
                        // optionsBuilder.UseSqlServer(_connectionString);

                        _efRepository = new ProductsEFRepository(new ProductsContext(optionsBuilder.Options));
                    }
                    return _efRepository;
                }
            }
        }
    }
}
