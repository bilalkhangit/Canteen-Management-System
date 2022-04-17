using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen_Management_System.Core.Aggregates.BrandAggregate
{
    public class BrandNameException : Exception
    {
        public BrandNameException() : base("Brand name cannot be empty")
        {

        }
    }
}
