using Canteen_Management_System.Core.Aggregates.CustomerAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen_Management_System.Infrastructure.Repos
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDBContext context) : base(context)
        {
        }
    }
}
