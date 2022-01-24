using BaseService.Core;
using BaseService.Data.TypeHandlers;
using Dapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BaseService.Api.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void InitializeDatabase(this IApplicationBuilder app)
        {
            SqlMapper.RemoveTypeMap(typeof(ulong));
            SqlMapper.AddTypeHandler(new IdTypeHandler());
            DefaultTypeMap.MatchNamesWithUnderscores = true;

            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            context.ExampleRepository.EnsureCreated();
            context.Commit();
        }
    }
}
