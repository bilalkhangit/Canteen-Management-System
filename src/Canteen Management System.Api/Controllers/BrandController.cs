using Canteen_Management_System.Application.BrandServices;
using Canteen_Management_System.Application.Interfaces;
using Canteen_Management_System.Core.Aggregates.BrandAggregate;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Canteen_Management_System.Api.Controllers
{
    public class BrandController : BaseController
    {
        private readonly IBrandAppService _brandAppService;
        public BrandController(IBrandAppService brandAppService)
        {
            _brandAppService = brandAppService;
        }
        public async Task<IEnumerable<Brand>> All()
        {
            return await _brandAppService.All();
        }

        [HttpPost]
        public async Task<ActionResult> Add(BrandDto brandDto)
        {
            await _brandAppService.Add(brandDto);
            return Ok();
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> Update(int id, BrandDto brandDto)
        {
            await _brandAppService.Update(id, brandDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _brandAppService.Delete(id);
            return NoContent();
        }
    }
}
