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
    internal class BrandUpdatedNotificationHandler : INotificationHandler<DomainEventNotification<BrandUpdated>>
    {
        private readonly IEmailSender _emailSender;
        public BrandUpdatedNotificationHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public Task Handle(DomainEventNotification<BrandUpdated> notification, CancellationToken cancellationToken)
        {
            return _emailSender.SendEmailAsync(notification.DomainEvent.Brand.Email, "Brand Updation", "Your brand info has been updated.");
        }
    }
}
