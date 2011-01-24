using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;

namespace SendString
{
  class Program
  {
    static void Main(string[] args)
    {
      var serverAddress = "192.168.0.196";
      var queueName = "string_data";

      using (var conn = new ConnectionFactory().CreateConnection(serverAddress))
      {
        using (var ch = conn.CreateModel())
        {
          ch.QueueDeclare(queueName, true);
          var properties = ch.CreateBasicProperties();
          properties.SetPersistent(true);

          for (int i = 0; i < 10; i++)
          {
            var message = String.Format("Hello from .NET! Message No. {0}", i);
            Console.WriteLine("Sending: {0}", message);
            ch.BasicPublish("", queueName, (i % 2 == 1) ? properties : null, Encoding.ASCII.GetBytes(message));
          }
        }
      }
    }
  }
}
