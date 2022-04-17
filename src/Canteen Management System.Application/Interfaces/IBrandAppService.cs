using Canteen_Management_System.Application.BrandServices;
using Canteen_Management_System.Core.Aggregates.BrandAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Canteen_Management_System.Application.Interfaces
{
    public interface IBrandAppService
    {
        Task<IEnumerable<Brand>> All();
        Task<int> Add(BrandDto brandDto);
        Task Update(int id, BrandDto brandDto);
        Task Delete(int id);
    }
}
