using Canteen_Management_System.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen_Management_System.Core.Aggregates.CustomerAggregate
{
    public class CustomerAdded : BaseDomainEvent
    {
        public Customer Customer { get; set; }
        public CustomerAdded(Customer customer)
        {
            Customer = customer;
        }
    }
}
