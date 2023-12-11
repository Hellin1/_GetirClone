using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace Messaging
{
    public class RabbitMQService
    {
        private readonly IConfiguration _configuration;
        private IConnection _connection;


        public RabbitMQService(IConfiguration configuration)
        {
            _configuration = configuration;
            InitializeRabbitMQ();
        }

        private void InitializeRabbitMQ()
        {
            var factory = new ConnectionFactory
            {
                HostName = _configuration.GetConnectionString("Redis"),
            };

            _connection = factory.CreateConnection();
        }

        public IModel CreateModel()
        {
            return _connection.CreateModel();
        }

    }
}
