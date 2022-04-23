using Canteen_Management_System.Application.Interfaces;
using Canteen_Management_System.Application.ProductServices;
using Canteen_Management_System.Core.Aggregates.ProductAggregate;
using Canteen_Management_System.Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Canteen_Management_System.Application.ProductServices
{
    public class ProductAppService : IProductAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Add(ProductDto productDto)
        {
            var product = new Product();
            await _unitOfWork.ProductRepository.Add(product.AddProduct(productDto.Name, productDto.Description, productDto.BrandId, productDto.Price));
            return await _unitOfWork.SaveChangesAsync();
        }

        public Task<IEnumerable<Product>> All()
        {
            return _unitOfWork.ProductRepository.All();
        }

        public async Task Delete(int id)
        {
            _unitOfWork.ProductRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Update(int id, ProductDto productDto)
        {
            var product = await _unitOfWork.ProductRepository.GetById(id);

            if (product == null)
                throw new Exception($"product against this id = {id} does not exist");

            _unitOfWork.ProductRepository.Update(product.UpdateProduct(product, productDto.Name, productDto.Description, productDto.Price));
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
