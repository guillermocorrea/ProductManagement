using Microsoft.EntityFrameworkCore;
using ProductManagement.Repository.EF.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagement.Repository.EF
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
        }
    }
}
