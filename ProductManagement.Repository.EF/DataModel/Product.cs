using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagement.Repository.EF.DataModel
{
    public class Product
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
    }
}
