using Canteen_Management_System.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen_Management_System.Core.Aggregates.ProductAggregate
{
    public class ProductUpdated : BaseDomainEvent
    {
        public Product Product { get; set; }
        public ProductUpdated(Product product)
        {
            Product = product;
        }
    }
}
