using Canteen_Management_System.Core.Aggregates.BrandAggregate;
using Canteen_Management_System.Core.Aggregates.ProductAggregate;
using Canteen_Management_System.Core.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Canteen_Management_System.Application.ProductServices.DomainEventHandlers
{
    internal class ProductUpdatedNotificationHandler : INotificationHandler<DomainEventNotification<ProductUpdated>>
    {
        private readonly IEmailSender _emailSender;
        private readonly IUnitOfWork _unitOfWork;
        public ProductUpdatedNotificationHandler(IEmailSender emailSender, IUnitOfWork unitOfWork)
        {
            _emailSender = emailSender;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DomainEventNotification<ProductUpdated> notification, CancellationToken cancellationToken)
        {
            var email = _unitOfWork.BrandRepository.GetById(notification.DomainEvent.Product.BrandId).Result.Email;
            return _emailSender.SendEmailAsync(email, "Product Updation", $"Your brand product {notification.DomainEvent.Product.Name} info has been updated in our system.");
        }
    }
}
