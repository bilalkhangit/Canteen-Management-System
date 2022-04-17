using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen_Management_System.Core.Aggregates.OrderAggregate
{
    public class OrderItemException : Exception
    {
        public OrderItemException() : base("There should be at least one item in the list.")
        {

        }
    }
}
