using BaseService.Core.Entities;
using BaseService.Core.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseService.Core.Services
{
    public interface IExampleService : IServiceBase<Example, ExampleParameters, ulong>
    {

    }
}
