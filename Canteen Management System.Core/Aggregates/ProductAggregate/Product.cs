using Canteen_Management_System.Core.Common;
using Canteen_Management_System.Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen_Management_System.Core.Aggregates.ProductAggregate
{
    public class Product : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int BrandId { get;private set; }

        public Product()
        {

        }
        private Product(string name, string desc, decimal price)
        {
            Name = name;
            Description = desc;
            Price = price;
        }

        public Product AddProduct(string name, string desc, decimal price = 0)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            if (string.IsNullOrEmpty(desc))
                throw new ArgumentNullException("desc");

            if (price == 0 || price < 0)
                throw new PriceException();


            var product = new Product(name, desc, price);

            var productAdded = new ProductAdded(product);
            Events.Add(productAdded);

            return product;
        }

        public Product UpdateProduct(Product product, string name, string desc, decimal price = 0)
        {
            if (product == null)
                throw new ArgumentNullException("Product");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
             
            if (string.IsNullOrEmpty(desc))
                throw new ArgumentNullException("desc");

            if (price == 0 || price < 0)
                throw new PriceException();


            product.Name = name;
            product.Description = desc;
            product.Price = price;

            var productUpdated = new ProductUpdated(product);
            Events.Add(productUpdated);

            return product;
        }
    }
}
