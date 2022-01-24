namespace BaseService.Core.Messages
{
    public interface IMessageService
    {
        void PublishMessage<T>(T payload, string queue, string routingKey);
        void PublishMessage<T>(T payload, string queue, string routingKey, string exchange);
    }
}