using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen_Management_System.Core
{
    public class PriceException : Exception
    {
        public PriceException() : base("Price cannot be equal or less than zero")
        {
        }
    }
}
