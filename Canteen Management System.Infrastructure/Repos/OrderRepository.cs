using Canteen_Management_System.Core.Aggregates.OrderAggregate;

namespace Canteen_Management_System.Infrastructure.Repos
{
    public class OrderRepository : Repository<Order> , IOrderRepository
    {
        public OrderRepository(AppDBContext appDBContext) : base(appDBContext)
        {

        }
    }
}
