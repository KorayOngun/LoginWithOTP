using Microsoft.Extensions.Options;
using OrganikHaberlesme.Application.Interfaces.Messages.AsyncMessage;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Infrastructure.MessageService.AsyncMessage
{
    public class RabbitMQMessagePublisher : IMessageBus
    {
        private readonly IModel channel;
        public RabbitMQMessagePublisher(IOptions<RabbitMQSettings> settings)
        {
            var factory = new ConnectionFactory
            {
                HostName = settings.Value.Host,
                Port = settings.Value.Port
            };
            var connection = factory.CreateConnection();
            channel = connection.CreateModel();
        }

        public void AddQueue<T>(T message, string queueName)
        {
            channel.QueueDeclare(queue:queueName,exclusive:false,autoDelete:false);
            var jsonData = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonData);
            channel.BasicPublish(exchange: "", routingKey: queueName, body: body);
        }
    }
}
