using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen_Management_System.Application.ProductServices
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }
    }
}
