using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen_Management_System.Core.Aggregates.BrandAggregate
{
    public class ProductNameException : Exception
    {
        public ProductNameException() : base("Product name must be provided")
        {

        }
    }
}
