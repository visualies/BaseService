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
        private readonly IUnitOfWork _context;
        private readonly ISnowflakeService _snowflakeService;

        public ExampleService(IUnitOfWork unitOfWork, ISnowflakeService snowflakeService)
        {
            _context = unitOfWork;
            _snowflakeService = snowflakeService;
        }

        public async Task<Example> GetAsync(ulong key)
        {
            return await _context.ExampleRepository.GetAsync(key);
        }

        public async Task CreateAsync(Example entity)
        {
            entity.Id = _snowflakeService.GenerateId();

            await _context.ExampleRepository.CreateAsync(entity);

            _context.Commit();
        }

        public async Task UpdateAsync(Example entity)
        {
            await _context.ExampleRepository.UpdateAsync(entity);

            _context.Commit();
        }

        public async Task DeleteAsync(ulong key)
        {
            await _context.ExampleRepository.DeleteAsync(key);

            _context.Commit();
        }

    }
}
