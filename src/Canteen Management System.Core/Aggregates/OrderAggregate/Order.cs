using Canteen_Management_System.Core.Common;
using Canteen_Management_System.Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Canteen_Management_System.Core.Aggregates.OrderAggregate
{
    public class Order : BaseEntity, IAggregateRoot
    {
        public int CustomerId { get; private set; }
        public int TotalQuantity { get; private set; }
        public decimal TotalPrice { get; private set; }
        public decimal Total { get; private set; }

        private readonly List<OrderItem> _orderItems = new List<OrderItem>();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public Order()
        {

        }
        private Order(int customerId)
        {

            CustomerId = customerId;
        }

        public Order AddOrder(int customerId)
        {
            if (customerId == 0)
                throw new ArgumentNullException("Please add the customer first.");

            var order = new Order();

            order.CustomerId = customerId;

            var orderCreated = new OrderCreated(order);
            order.Events.Add(orderCreated);

            return order;
        }

        public void AddOrderItem(int productId, int quantity, decimal unitprice)
        {
            _orderItems.Add(new OrderItem().AddOrderItem(productId, quantity, unitprice));

            TotalQuantity = _orderItems.Sum(o => o.Quantity);
            TotalPrice = _orderItems.Sum(o => o.UnitPrice);
            Total = _orderItems.Sum(o => o.Total);
        }

        public void OrderCompleted()
        {
            var orderCompleted = new OrderCompleted(this);
            Events.Add(orderCompleted);
        }
    }
}
