﻿using BaseService.Core;
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
        private readonly ISnowflakeService _snowflakeService;

        public ExampleService(IUnitOfWork unitOfWork, ISnowflakeService snowflakeService)
        {
            _unitOfWork = unitOfWork;
            _snowflakeService = snowflakeService;
        }
        public async Task<Example> GetAsync(ulong key)
        {
            return await _unitOfWork.ExampleRepository.GetAsync(key);
        }

        public async Task CreateAsync(Example entity)
        {
            entity.Id = _snowflakeService.GenerateId();

            await _unitOfWork.ExampleRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(Example entity)
        {
            await _unitOfWork.ExampleRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(ulong key)
        {
            await _unitOfWork.ExampleRepository.DeleteAsync(key);
        }

    }
}
