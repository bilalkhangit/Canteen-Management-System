using Canteen_Management_System.Core.Aggregates.ProductAggregate;
using Canteen_Management_System.Core.Common;
using Canteen_Management_System.Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen_Management_System.Core.Aggregates.OrderAggregate
{
    public class OrderItem : BaseEntity
    {
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Total { get; private set; }

        public OrderItem()
        {

        }
        private OrderItem(int productId, int quantity, decimal unitPrice)
        {
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Total = unitPrice * quantity;
        }
        internal OrderItem AddOrderItem(int productId, int quantity, decimal unitPrice)
        {
            if (unitPrice == 0 || unitPrice < 0)
                throw new PriceException();

            if (quantity == 0 || quantity < 0)
                throw new QuantityException();

            if (productId == 0)
                throw new ArgumentNullException("Product id not found");

            return new OrderItem(productId, quantity, unitPrice);
        }
    }
}
