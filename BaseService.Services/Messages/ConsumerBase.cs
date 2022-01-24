using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BaseService.Core.Assembly;
using BaseService.Core.Entities;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BaseService.Services.Messages
{
    public class ConsumerBase<T> : IHostedService, IDisposable where T : class

    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _queueName;

        protected ConsumerBase(IConnectionFactory factory, string queueName)
        {
            _queueName = queueName;
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _channel.QueueDeclare(queue: _queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (model, args) =>
            {
                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var assembly = typeof(CoreAssembly).Assembly;
                var type = assembly.ExportedTypes.FirstOrDefault(a => a.Name == args.BasicProperties.Type);
                
                if (type != typeof(T)) return;
                var o = JsonConvert.DeserializeObject(message, type);
                if (o == null) return;
                Subscribe(o as T);
            };

            _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }

        protected virtual void Subscribe(T param)
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _connection.Close();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _channel.Dispose();
            _connection.Dispose();
        }
    }
}
