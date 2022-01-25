using System.Threading.Tasks;
using BaseService.Core.Entities;
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
        [Route("/example/{id:ulong}")]
        public async Task<IActionResult> GetAsync(ulong id)
        {
            var example = await _exampleService.GetAsync(id);
            System.Console.WriteLine(example.Id);
            return Ok(example);
        }

        [HttpPost()]
        [Route("/example/")]
        public async Task<IActionResult> PostAsync(Example example)
        {
            await _exampleService.CreateAsync(example);

            return Ok();
        }

        [HttpPatch()]
        [Route("/example/")]
        public async Task<IActionResult> PatchAsync(Example example)
        {
            await _exampleService.UpdateAsync(example);

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
