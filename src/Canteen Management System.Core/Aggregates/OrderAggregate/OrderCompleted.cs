using Canteen_Management_System.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen_Management_System.Core.Aggregates.OrderAggregate
{
    public class OrderCompleted : BaseDomainEvent
    {
        public Order Order { get; set; }
        public OrderCompleted(Order order)
        {
            Order = order;
        }
    }
}
