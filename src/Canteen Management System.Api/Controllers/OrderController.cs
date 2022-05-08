using Canteen_Management_System.Application.Interfaces;
using Canteen_Management_System.Application.OrderServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Canteen_Management_System.Api.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class OrderController : BaseController
    {
        private readonly IOrderAppService _orderAppService;
        public OrderController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }
        [HttpPost]
        public async Task<ActionResult> Add(OrderDto orderDto)
        {
            await _orderAppService.Add(orderDto);
            return Ok();
        }
    }
}
