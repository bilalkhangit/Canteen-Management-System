using Canteen_Management_System.Application.Interfaces;
using Canteen_Management_System.Application.ProductServices;
using Canteen_Management_System.Core.Aggregates.ProductAggregate;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Canteen_Management_System.Api.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductAppService _productAppService;
        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }
        public async Task<IEnumerable<Product>> All()
        {
            return await _productAppService.All();
        }

        [HttpPost]
        public async Task<ActionResult> Add(ProductDto productDto)
        {
            await _productAppService.Add(productDto);
            return Ok();
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> Update(int id, ProductDto productDto)
        {
            await _productAppService.Update(id, productDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productAppService.Delete(id);
            return NoContent();
        }
    }
}
