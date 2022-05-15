using BaseService.Core;
using BaseService.Core.Entities;
using BaseService.Core.Messages;
using BaseService.Core.Services;
using BaseService.Data;
using BaseService.Services.Messages;
using BaseService.Services.Services;
using BattlepassService.Api.Routing.Constraints;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace BaseService.Api.Extensions
{
    public static class ServiceExtension
    {
        public static void AddUnitOfWork(this IServiceCollection services, DatabaseConfig config)
        {
            services.AddScoped<IUnitOfWork>(a => new UnitOfWork(config.GetConnectionString()));
        }

        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddSingleton<ISnowflakeService, SnowflakeService>();
            services.AddScoped<IExampleService, ExampleService>();
        }

        public static void AddRabbitMQ(this IServiceCollection services, RabbitMqConfig config)
        {
            var factory = new ConnectionFactory()
            {
                HostName = config.Host,
                UserName = config.Username,
                Password = config.Password,
                Port = config.Port
            };

            services.AddSingleton<IConnectionFactory>(factory);
            services.AddTransient<IMessageService, MessageService>();
            services.AddHostedService<ExampleConsumer>();
        }

        public static void AddRouteConstraints(this IServiceCollection services)
        {
            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add(UlongRouteConstraint.Name, typeof(UlongRouteConstraint));
            });
        }
    }

}
