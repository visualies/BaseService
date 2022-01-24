using System;
using BaseService.Core.Entities;
using RabbitMQ.Client;

namespace BaseService.Services.Messages
{
    public class ExampleConsumer : ConsumerBase<Example>
    {
        public ExampleConsumer(IConnectionFactory factory) : base(factory, "queue")
        {
            
        }

        protected override void Subscribe(Example example)
        {

        }
    }
}