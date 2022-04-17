using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen_Management_System.Core.Aggregates.OrderAggregate
{
    public class QuantityException : Exception
    {
        public QuantityException() : base("Quantity cannot be equal or less than zero")
        {

        }
    }
}
