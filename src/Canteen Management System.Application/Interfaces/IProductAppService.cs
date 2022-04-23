using Canteen_Management_System.Application.ProductServices;
using Canteen_Management_System.Core.Aggregates.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Canteen_Management_System.Application.Interfaces
{
    public interface IProductAppService
    {
        Task<IEnumerable<Product>> All();
        Task<int> Add(ProductDto productDto);
        Task Update(int id, ProductDto productDto);
        Task Delete(int id);
    }
}
