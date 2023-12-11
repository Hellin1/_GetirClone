using GetirClone.Application.Dto;

namespace GetirClone.Application.Interfaces
{
    public interface IMessageProducer
    {
        void SendMessage(RabbitMQMessageDto message);
    }
}
