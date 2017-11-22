using System;

namespace ProductManagement.Domain
{
    public class Product
    {
        public string Number { get; set; }
        public string Title { get; set; }

        private double _price;
        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value < 0) throw new ArgumentException("Price cannot be less than zero.");
                _price = value;
            }
        }

        public Product(string number, string title, double price)
        {
            if (string.IsNullOrEmpty(number)) throw new ArgumentNullException("Product Number");
            if (string.IsNullOrEmpty(title)) throw new ArgumentNullException("Product Title");
            Number = number;
            Title = title;
        }
    }
}
