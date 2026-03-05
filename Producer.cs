using System;
using System.Text;
using RabbitMQ.Client;

class Program
{
    static void Main(string[] args)
    {
        // 1. Connect to RabbitMQ
        var factory = new ConnectionFactory()
        {
            HostName = "localhost"
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        // 2. Message to send
        string message = "Hello from Producer";
        var body = Encoding.UTF8.GetBytes(message);

        // 3. Send message
        channel.BasicPublish(
            exchange: "",
            routingKey: "demo-pc",
            basicProperties: null,
            body: body
        );

        Console.WriteLine("✅ Message sent");
    }
}
