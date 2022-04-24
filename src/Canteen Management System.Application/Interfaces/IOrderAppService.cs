using Canteen_Management_System.Application.OrderServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Canteen_Management_System.Application.Interfaces
{
    public interface IOrderAppService
    {
        Task<int> Add(OrderDto orderDto);
    }
}
