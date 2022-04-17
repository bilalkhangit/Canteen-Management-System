using Canteen_Management_System.Core.Common;

namespace Canteen_Management_System.Core.Aggregates.BrandAggregate
{
    public class BrandAdded : BaseDomainEvent 
    {
        public Brand Brand { get; set; }
        public BrandAdded(Brand brand)
        {
            Brand = brand;
        }
    }
}
