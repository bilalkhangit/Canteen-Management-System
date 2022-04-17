using Canteen_Management_System.Application.Interfaces;
using Canteen_Management_System.Core;
using Canteen_Management_System.Core.Aggregates.BrandAggregate;
using Canteen_Management_System.Core.Common.Interfaces;
using Canteen_Management_System.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Canteen_Management_System.Application.BrandServices
{
    public class BrandAppService : IBrandAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BrandAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<Brand>> All()
        {
            return _unitOfWork.BrandRepository.All();
        }

        public async Task<int> Add(BrandDto brandDto)
        {
            var brand = new Brand();
            var address = new Address(brandDto.Street, brandDto.City, brandDto.State, brandDto.Country, brandDto.Zipcode);
            await _unitOfWork.BrandRepository.Add(brand.AddBrand(brandDto.Name, address, brandDto.Email));
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task Update(int id, BrandDto brandDto)
        {
            var brand = await _unitOfWork.BrandRepository.GetById(id);

            if (brand == null)
                throw new Exception($"brand against this id = {id} does not exist");

            var address = new Address(brandDto.Street, brandDto.City, brandDto.State, brandDto.Country, brandDto.Zipcode);
            _unitOfWork.BrandRepository.Update(brand.UpdateBrand(brand, brandDto.Name, address, brandDto.Email));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _unitOfWork.BrandRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
