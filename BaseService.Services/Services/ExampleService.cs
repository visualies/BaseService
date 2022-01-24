using BaseService.Core;
using BaseService.Core.Entities;
using BaseService.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseService.Services.Services
{
    public class ExampleService : IExampleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExampleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Example> GetAsync(ulong key)
        {
            return await _unitOfWork.ExampleRepository.GetAsync(key);
        }

        public async Task CreateAsync(Example entity)
        {
            await _unitOfWork.ExampleRepository.CreateAsync(entity);
        }

        public Task DeleteAsync(ulong key)
        {
            throw new NotImplementedException();
        }


        public Task UpdateAsync(Example entity)
        {
            throw new NotImplementedException();
        }
    }
}
