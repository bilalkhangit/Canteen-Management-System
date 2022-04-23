using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen_Management_System.Core.Aggregates.BrandAggregate
{
    public class BrandIdException: Exception
    {
        public BrandIdException() : base("Brand id must be provided")
        {

        }
    }
}
