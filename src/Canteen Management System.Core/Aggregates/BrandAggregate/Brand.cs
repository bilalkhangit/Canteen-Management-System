using Canteen_Management_System.Core.Aggregates.ProductAggregate;
using Canteen_Management_System.Core.Common;
using Canteen_Management_System.Core.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Canteen_Management_System.Core.Aggregates.BrandAggregate
{
    public class Brand : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public string Email { get; private set; }
        public ICollection<Product> Products { get; }
        public Brand()
        {

        }
        private Brand(string name, Address address, string email)
        {
            Name = name;
            Address = address;
            Email = email;
        }

        public Brand AddBrand(string name, Address address, string email)
        {
            if (string.IsNullOrEmpty(name))
                throw new BrandNameException();

            var brand = new Brand(name, address, email);

            var brandAdded = new BrandAdded(brand);
            brand.Events.Add(brandAdded);

            return brand;
        }

        public Brand UpdateBrand(Brand brand, string name, Address address,string email)
        {
            if (brand == null)
                throw new ArgumentNullException("Brand");

            brand.Name = name;
            brand.Address = address;
            brand.Email =  email;

            var brandUpdated = new BrandUpdated(brand);
            brand.Events.Add(brandUpdated);

            return brand;
        }
    }
}
