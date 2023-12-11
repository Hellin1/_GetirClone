using GetirClone.Application.Dto;
using GetirClone.Application.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Messaging;

public class MessageProducer : IMessageProducer
{
    private readonly RabbitMQService _rabbitMQService;

    public MessageProducer(RabbitMQService rabbitMQService)
    {
        _rabbitMQService = rabbitMQService;
    }

    public void SendMessage(RabbitMQMessageDto message)
    {
        using (var channel = _rabbitMQService.CreateModel())
        {
            channel.QueueDeclare(queue: "General",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);


            var serializedMessage = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(serializedMessage);

            channel.BasicPublish(exchange: "",
                                 routingKey: "General",
                                 basicProperties: null,
                                 body: body);
        }
    }
}
