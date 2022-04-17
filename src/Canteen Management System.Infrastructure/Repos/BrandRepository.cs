using Canteen_Management_System.Core.Aggregates.BrandAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen_Management_System.Infrastructure.Repos
{
    public class BrandRepository : Repository<Brand> , IBrandRepository
    {
        public BrandRepository(AppDBContext appDBContext) : base(appDBContext)
        {
                
        }
    }
}
