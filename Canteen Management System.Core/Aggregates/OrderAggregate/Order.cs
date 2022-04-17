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
        public decimal Total { get; set; }

        private readonly List<OrderItem> _orderItems = new List<OrderItem>();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public Order()
        {
                
        }
        private Order(int customerId, List<OrderItem> orderItems)
        {
            CustomerId = customerId;
            _orderItems = orderItems;
        }

        public Order AddOrder(int customerId, List<OrderItem> orderItems)
        {
            if (_orderItems.Count == 0)
                throw new OrderItemException();

            if (CustomerId == 0)
                throw new ArgumentNullException("Please add the customer first.");

            var order = new Order(customerId, orderItems);
            order.TotalQuantity = CalculateTotalQuantity();
            order.TotalPrice = CalculateTotalPrice();
            order.Total = order.TotalQuantity * order.TotalPrice;

            var orderCreated = new OrderCreated(order);
            Events.Add(orderCreated);

            return order;
        }

        private decimal CalculateTotalPrice()
        {
            return _orderItems.Sum(o => o.UnitPrice);
        }

        private int CalculateTotalQuantity()
        {
            return _orderItems.Sum(o => o.Quantity);
        }
    }
}
