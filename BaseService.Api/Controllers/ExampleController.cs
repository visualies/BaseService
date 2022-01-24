using System.Threading.Tasks;
using BaseService.Core;
using BaseService.Core.Entities;
using BaseService.Core.Messages;
using BaseService.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaseService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly IExampleService _exampleService;
        private readonly IMessageService _messageService;

        public ExampleController(IExampleService exampleService, IMessageService messageService)
        {
            _exampleService = exampleService;
            _messageService = messageService;
        }

        [HttpGet("{id:ulong}")]
        public async Task<Example> Get(ulong id)
        {
            var example = await _exampleService.GetAsync(id);

            _messageService.PublishMessage(example,"hello","hello");
            return example;
        }
    }
}
