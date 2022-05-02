using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen_Management_System.Application.OrderServices
{
    public class OrderDto
    {
        public string Name { get; set; }
        public string Cnic { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }

    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
