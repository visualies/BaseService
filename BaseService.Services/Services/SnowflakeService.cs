using BaseService.Core.Services;
using IdGen;
using Microsoft.Extensions.Configuration;

namespace BaseService.Services.Services
{
    public class SnowflakeService : ISnowflakeService
    {
        private readonly IdGenerator _generator;
        public SnowflakeService(IConfiguration configuration)
        {
            _generator = new IdGenerator(configuration.GetSection("Snowflake").GetValue<int>("Id"));
        }

        public ulong GenerateId()
        {
            return (ulong)_generator.CreateId();
        }
    }
}
