using Canteen_Management_System.Application.Interfaces;
using Canteen_Management_System.Core.Aggregates.CustomerAggregate;
using Canteen_Management_System.Core.Aggregates.OrderAggregate;
using Canteen_Management_System.Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Canteen_Management_System.Application.OrderServices
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Add(OrderDto orderDto)
        {
            var checkForExistingCustomer = await _unitOfWork.CustomerRepository.GetByCriteria(o => o.Cnic == orderDto.Cnic);
            var customerId = 0;
            if (checkForExistingCustomer == null)
            {
                var addedCustomer = await _unitOfWork.CustomerRepository.AddAndReturnEntity(new Customer().AddCustomer(orderDto.Name, orderDto.Cnic, orderDto.MobileNumber, orderDto.Email));
                await _unitOfWork.SaveChangesAsync();
                customerId = addedCustomer.Id;
            }
            else
                customerId = checkForExistingCustomer.Id;


            var order = new Order().AddOrder(customerId);


            foreach (var item in orderDto.Items)
            {
                var product = await _unitOfWork.ProductRepository.GetById(item.ProductId);
                order.AddOrderItem(item.ProductId, item.Quantity, product.Price);
            }

            order.OrderCompleted();

            await _unitOfWork.OrderRepository.Add(order);
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
