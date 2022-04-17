using Canteen_Management_System.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen_Management_System.Core.Aggregates.BrandAggregate
{
    public class BrandUpdated : BaseDomainEvent
    {
        public Brand Brand { get; set; }
        public BrandUpdated(Brand brand)
        {
            Brand = brand;
        }
    }
}
