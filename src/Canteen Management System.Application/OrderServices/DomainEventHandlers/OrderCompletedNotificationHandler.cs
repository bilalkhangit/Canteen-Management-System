using Canteen_Management_System.Core.Aggregates.OrderAggregate;
using Canteen_Management_System.Core.Aggregates.ProductAggregate;
using Canteen_Management_System.Core.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Canteen_Management_System.Application.OrderServices.DomainEventHandlers
{
    public class OrderCompletedNotificationHandler : INotificationHandler<DomainEventNotification<OrderCompleted>>
    {
        private readonly IEmailSender _emailSender;
        private readonly IUnitOfWork _unitOfWork;
        public OrderCompletedNotificationHandler(IEmailSender emailSender, IUnitOfWork unitOfWork)
        {
            _emailSender = emailSender;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DomainEventNotification<OrderCompleted> notification, CancellationToken cancellationToken)
        {
            var html = "";
            html += "<!DOCTYPE html><html><head><style>table {font-family: arial, sans-serif;border-collapse: collapse;width: 100%;}td, th {border: 1px solid #dddddd;text-align: left;padding: 8px;}tr:nth-child(even) {background-color: #dddddd;}</style></head><body><h2>Your Order</h2>";
            html += "<table><tr><th>Product</th><th>Qty</th><th>Unit Price</th><th>Total</th></tr>";
            foreach (var item in notification.DomainEvent.Order.OrderItems)
            {
                var product = await _unitOfWork.ProductRepository.GetById(item.ProductId);
                html += $"<tr><td>{product.Name}</td><td>{item.Quantity}</td><td>{item.UnitPrice}</td><td>{item.Total}</td></tr>";
            }
            html += "</table></body></html>";
            var customer = await _unitOfWork.CustomerRepository.GetById(notification.DomainEvent.Order.CustomerId);
            await _emailSender.SendEmailAsync(customer.Email, "Order Details", html);
        }
    }
}
