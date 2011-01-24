using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;
using MessageLib;

namespace SendString
{
  class Program
  {
    static void Main(string[] args)
    {
      var serverAddress = "192.168.0.196";
      var queueName = "message_data_cs";

      using (var conn = new ConnectionFactory().CreateConnection(serverAddress))
      {
        using (var ch = conn.CreateModel())
        {
          ch.QueueDeclare(queueName, true);
          var properties = ch.CreateBasicProperties();
          properties.SetPersistent(true);

          for (int i = 0; i < 10; i++)
          {
            var message = new Message()
            {
              From = "C# Sample", 
              Body = String.Format("Message No. {0}", i)
            };
              
            Console.WriteLine("Sending: {0}", i);
            ch.BasicPublish("", queueName, properties, Message.Serialize(message));
          }
        }
      }
    }
  }
}
