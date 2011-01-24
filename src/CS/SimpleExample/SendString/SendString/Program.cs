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
          var messages = Enumerable.Range(1, 10).Select(x => String.Format("Hello from .NET! Message No. {0}", x));

          foreach (var message in messages)
          {
            Console.WriteLine("Sending: {0}", message);
            ch.BasicPublish("", queueName, null, Encoding.ASCII.GetBytes(message));
          }
        }
      }
    }
  }
}
