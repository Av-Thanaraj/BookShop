using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using BookShop.Infrastructure.BaseDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookShop.Infrastructure.Services
{
    public class RabbitMqConsumer
    {

        public RabbitMqConsumer()
        {
        }

        public void StartConsuming()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "status_updates",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                //await UpdateDatabaseStatusAsync(message);
            };

            channel.BasicConsume(queue: "status_updates",
                                 autoAck: true,
                                 consumer: consumer);

            //Console.WriteLine("Press [enter] to exit.");
            //Console.ReadLine();
        }
    }
}
