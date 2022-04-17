using Canteen_Management_System.Core.Common;
using Canteen_Management_System.Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen_Management_System.Core.Aggregates.ProductAggregate
{
    public class ProductAdded : BaseDomainEvent
    {
        public Product Product { get; set; }
        public ProductAdded(Product product)
        {
            Product = product;
        }
    }
}
