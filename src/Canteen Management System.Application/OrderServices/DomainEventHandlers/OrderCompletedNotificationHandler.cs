using Canteen_Management_System.Core.Aggregates.OrderAggregate;
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
        public Task Handle(DomainEventNotification<OrderCompleted> notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
