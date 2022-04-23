using Canteen_Management_System.Core.Aggregates.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen_Management_System.Infrastructure.Repos
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDBContext appDBContext) : base(appDBContext)
        {

        }
    }
}
