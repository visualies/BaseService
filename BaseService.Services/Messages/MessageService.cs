﻿using BaseService.Core.Entities;
using BaseService.Core.Messages;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseService.Services.Services
{
    public class MessageService : IMessageService
    {
        private readonly IConnection connection;
        private readonly IModel channel;

        public MessageService(ConnectionFactory factory)
        {
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
        }

        public void PublishMessage(string queue, string message, string routingKey)
        {
            {
                channel.QueueDeclare(queue: queue,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: routingKey,
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine(" [x] Sent {0}", message);
            }
        }
    }
}