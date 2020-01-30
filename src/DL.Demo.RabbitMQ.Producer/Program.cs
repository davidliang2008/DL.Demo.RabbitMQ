using RabbitMQ.Client;
using System;
using System.Text;

namespace DL.Demo.RabbitMQ.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    // Create a queue called BasicQueue
                    channel.QueueDeclare("BasicQueue", false, false, false, null);

                    string message = "Getting started with .NET Core RabbitMQ";

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish("", "BasicQueue", null, body);

                    Console.WriteLine("Send message {0}...", message);
                }
            }

            Console.WriteLine("Press [Enter] to exit the Sender app...");
            Console.ReadLine();
        }
    }
}
