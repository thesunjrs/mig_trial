using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

class Program
{
    static void Main(string[] args)
    {
        // Connect to RabbitMQ
        var factory = new ConnectionFactory()
        {
            HostName = "localhost"
        };

        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        // Create consumer
        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            Console.WriteLine("✅ Received: " + message);
        };

        // Consume messages from queue
        channel.BasicConsume(
            queue: "demo-pc",
            autoAck: true,
            consumer: consumer
        );

        Console.WriteLine("⏳ Waiting for messages...");
        Console.ReadLine();
    }
}
