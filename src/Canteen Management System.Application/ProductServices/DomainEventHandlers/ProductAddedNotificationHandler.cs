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
    public class ProductAddedNotificationHandler : INotificationHandler<DomainEventNotification<ProductAdded>>
    {
        private readonly IEmailSender _emailSender;
        private readonly IUnitOfWork _unitOfWork;
        public ProductAddedNotificationHandler(IEmailSender emailSender,IUnitOfWork unitOfWork)
        {
            _emailSender = emailSender;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DomainEventNotification<ProductAdded> notification, CancellationToken cancellationToken)
        {
            var email = _unitOfWork.BrandRepository.GetById(notification.DomainEvent.Product.BrandId).Result.Email;
            return _emailSender.SendEmailAsync(email, "Product Activation", $"Your brand product {notification.DomainEvent.Product.Name} has been entered in our system.");
        }
    }
}
