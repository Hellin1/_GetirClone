using GetirClone.Application.Interfaces;
using Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace GetirClone.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddMessagingServices(this IServiceCollection services)
        {
            services.AddSingleton<RabbitMQService>();
            services.AddScoped<IMessageProducer, MessageProducer>();
            services.AddHostedService<MessageConsumerService>();
        }
    }
}