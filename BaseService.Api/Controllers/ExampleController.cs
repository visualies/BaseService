﻿using System.Threading.Tasks;
using BaseService.Core.Entities;
using BaseService.Core.Parameters;
using BaseService.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaseService.Api.Controllers
{
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly IExampleService _exampleService;

        public ExampleController(IExampleService exampleService)
        {
            _exampleService = exampleService;
        }

        [HttpGet()]
        [Route("/example/")]
        public async Task<IActionResult> FindAsync(ExampleParameters @params)
        {
            var examples = await _exampleService.FindAsync(@params);
            return Ok(examples);
        }

        [HttpGet()]
        [Route("/example/{id:ulong}")]
        public async Task<IActionResult> GetAsync(ulong id)
        {
            var example = await _exampleService.GetAsync(id);
            return Ok(example);
        }

        [HttpPost()]
        [Route("/example/")]
        public async Task<IActionResult> PostAsync(ExampleParameters @params)
        {
            await _exampleService.CreateAsync(@params);
            return Ok();
        }

        [HttpPatch()]
        [Route("/example/{id:ulong}")]
        public async Task<IActionResult> PatchAsync(ulong id, ExampleParameters @params)
        {
            await _exampleService.UpdateAsync(id, @params);
            return Ok();
        }

        [HttpDelete()]
        [Route("/example/{id:ulong}")]
        public async Task<IActionResult> DeleteAsync(ulong id)
        {
            await _exampleService.DeleteAsync(id);
            return Ok();
        }
    }
}
