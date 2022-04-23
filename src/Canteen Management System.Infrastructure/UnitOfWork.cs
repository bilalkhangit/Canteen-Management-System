using Canteen_Management_System.Core.Aggregates.BrandAggregate;
using Canteen_Management_System.Core.Aggregates.CustomerAggregate;
using Canteen_Management_System.Core.Aggregates.OrderAggregate;
using Canteen_Management_System.Core.Aggregates.ProductAggregate;
using Canteen_Management_System.Core.Common.Interfaces;
using Canteen_Management_System.Infrastructure.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Canteen_Management_System.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDBContext _context;

        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        private ICustomerRepository _customerRepository;
        private IBrandRepository _brandRepository;

        public UnitOfWork(AppDBContext context)
        {
            _context = context;
        }
        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_context);
                }
                return _orderRepository;
            }
        }

        public IBrandRepository BrandRepository
        {
            get
            {
                if (_brandRepository == null)
                {
                    _brandRepository = new BrandRepository(_context);
                }
                return _brandRepository;
            }
        }
        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_context);
                }
                return _productRepository;
            }
        }

        public ICustomerRepository CustomerRepository => throw new NotImplementedException();

        public async Task<int> SaveChangesAsync()
        {
           return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
