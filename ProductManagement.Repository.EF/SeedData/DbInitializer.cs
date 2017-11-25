using ProductManagement.Repository.EF.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductManagement.Repository.EF.SeedData
{
    public class DbInitializer
    {
        public static void Initialize(ProductsContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;
            }

            var product = new Product()
            {
                Number = "01",
                Price = 219.99m,
                Title = "Dummy Product"
            };

            context.Products.Add(product);
            
            context.SaveChanges();
        }
    }
}
