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

        public async Task<IEnumerable<Example>> FindAsync(ExampleParameters @params)
        {
            return await _context.ExampleRepository.FindAsync(@params);
        }

        public async Task<Example> GetAsync(ulong key)
        {
            return await _context.ExampleRepository.GetAsync(key);
        }

        public async Task CreateAsync(ExampleParameters @params)
        {
            var example = new Example()
            {
                Id = _snowflakeService.GenerateId(),
                Name = @params.Name,
                Description = @params.Description,
            };

            await _context.ExampleRepository.CreateAsync(example);
            _context.Commit();
        }

        public async Task UpdateAsync(ulong key, ExampleParameters @params)
        {
            var example = await _context.ExampleRepository.GetAsync(key);

            if (@params.Name != null)
            {
                example.Name = @params.Name;
            }
            if (@params.Description != null)
            {
                example.Description = @params.Description;
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
