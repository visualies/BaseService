using BaseService.Core;
using BaseService.Core.Entities;
using BaseService.Core.Parameters;
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

        public async Task<IEnumerable<Example>> FindAsync(ExampleParameters parameters)
        {
            return await _context.ExampleRepository.FindAsync(parameters);
        }

        public async Task<Example> GetAsync(ulong key)
        {
            return await _context.ExampleRepository.GetAsync(key);
        }

        public async Task CreateAsync(ExampleParameters parameters)
        {
            var example = new Example()
            {
                id = _snowflakeService.GenerateId(),
                name = parameters.name,
                description = parameters.description,
            };

            await _context.ExampleRepository.CreateAsync(example);
            _context.Commit();
        }

        public async Task UpdateAsync(ulong key, ExampleParameters parameters)
        {
            var example = await _context.ExampleRepository.GetAsync(key);

            if (parameters.name != null)
            {
                example.name = parameters.name;
            }
            if (parameters.description != null)
            {
                example.description = parameters.description;
            }

            await _context.ExampleRepository.UpdateAsync(example);

            _context.Commit();
        }

        public async Task DeleteAsync(ulong key)
        {
            await _context.ExampleRepository.DeleteAsync(key);

            _context.Commit();
        }
    }
}
