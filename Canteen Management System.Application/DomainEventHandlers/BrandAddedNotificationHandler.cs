using Canteen_Management_System.Core.Aggregates.BrandAggregate;
using Canteen_Management_System.Core.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Canteen_Management_System.Application.DomainEventHandlers
{
    public class BrandAddedNotificationHandler : INotificationHandler<DomainEventNotification<BrandAdded>>
    {
        private readonly IEmailSender _emailSender;
        public BrandAddedNotificationHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public Task Handle(DomainEventNotification<BrandAdded> notification, CancellationToken cancellationToken)
        {
            return _emailSender.SendEmailAsync(notification.DomainEvent.Brand.Email, "Brand Activation", "Your brand has been entered in our system. We will sell your products from now on.");
        }
    }
}
