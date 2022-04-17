using Canteen_Management_System.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen_Management_System.Application.BrandServices
{
    public class BrandDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
    }
}
