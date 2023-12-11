using GetirClone.Application.Dto;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MimeKit;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
namespace Messaging;

public class MessageConsumerService : BackgroundService
{
    private readonly RabbitMQService _rabbitMQService;
    private readonly IConfiguration _configuration;

    public MessageConsumerService(RabbitMQService rabbitMQService, IConfiguration configuration)
    {
        _rabbitMQService = rabbitMQService;
        _configuration = configuration;
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using (var channel = _rabbitMQService.CreateModel())
        {
            channel.QueueDeclare(queue: "General",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var readMessage = Encoding.UTF8.GetString(body);
                var dto = JsonSerializer.Deserialize<RabbitMQMessageDto>(readMessage);
                await ProcessMessageAsync(dto);
                channel.BasicAck(ea.DeliveryTag, multiple: false);
            };

            channel.BasicConsume(queue: "General",
                                 autoAck: false,
                                 consumer: consumer);

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }
    }
    private async Task ProcessMessageAsync(RabbitMQMessageDto dto)
    {
        await SendEmailAsync(dto);
    }
    private async Task SendEmailAsync(RabbitMQMessageDto dto)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress($"{_configuration["MailSettings:Sender:Title"]}", $"{_configuration["MailSettings:Sender:MailAddress"]}"));
        emailMessage.To.Add(new MailboxAddress("Kullanıcı", $"{dto.Email}"));
        emailMessage.Subject = "Giris Dogrulama";
        emailMessage.Body = new TextPart("plain")
        {
            Text = $"{dto.LastGeneratedCode} dogrulama kodu ile Getir kullanici hesabiniza giris yapmaktasiniz. Kodunuzu kimseyle paylasmayin. B021"
        };

        using (var client = new SmtpClient())
        {
            client.ServerCertificateValidationCallback = (s, c, h, e) => true;
            await client.ConnectAsync($"{_configuration["MailSettings:Sender:MailServiceHost"]}", int.Parse($"{_configuration["MailSettings:Sender:MailServicePort"]}"), useSsl: false);
            client.Authenticate($"{_configuration["MailSettings:Sender:MailAddress"]}", $"{_configuration["MailSettings:Sender:Password"]}");

            client.Send(emailMessage);
            client.Disconnect(true);
        }
    }
}