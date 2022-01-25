using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseService.Core.Services
{
    public interface ISnowflakeService
    {
        ulong GenerateId();
    }
}
