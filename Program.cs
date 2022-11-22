
using System;

using RabbitMQ.Client;
using System.Text;

namespace RProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            bool verify = false;
            string text;
            int contador;

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "filaTeste",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                while (verify)
                {
                    
                    string message = "Hello World! ";
                   
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "filaTeste",
                                         basicProperties: null,
                                         body: body);
                  
                   // Console.WriteLine(" [x] Sent {0}", message);
                    Console.WriteLine(" para continuar digite Y");
                  text =  Console.ReadLine();

                  //  if (text != "y") { verify = false; } else { verify = true; }
                    
                }

            }

         //   Console.WriteLine(" Press [enter] to exit.");
          //  Console.ReadLine();
          //@
        }
    }
}
