
using System;

using RabbitMQ.Client;
using System.Text;
using System.Collections.Generic;

namespace RProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            bool verify = true;
            string text;
            //sortear essas palavras
            List<string> palavras;
            palavras = new List<string>() { "itemA", "itemB" , "itemC","itemD" };  

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
                    int v = new Random().Next(0, 3);
                    int randomN = v;
                       
                    string message = palavras[v];
                   
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

           Console.WriteLine(" Press [enter] to exit.");
           Console.ReadLine();
          //@
        }
    }
}
