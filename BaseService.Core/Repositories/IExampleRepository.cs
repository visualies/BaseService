using BaseService.Core.Entities;
using BaseService.Core.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseService.Core.Repositories
{
    public interface IExampleRepository : IRepositoryBase<Example, ExampleParameters, ulong>
    {

    }
}
