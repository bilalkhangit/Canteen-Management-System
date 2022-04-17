using Canteen_Management_System.Core.Aggregates.BrandAggregate;
using Canteen_Management_System.Core.Aggregates.CustomerAggregate;
using Canteen_Management_System.Core.Aggregates.OrderAggregate;
using Canteen_Management_System.Core.Aggregates.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Canteen_Management_System.Core.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IBrandRepository BrandRepository { get; }
        Task<int> SaveChangesAsync();
        void Dispose();
    }
}
