using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;

namespace ReceiveString
{
  class Program
  {
    static void Main(string[] args)
    {
      var serverAddress = @"192.168.0.196";
      var queueName = "string_data";

      var conn = new ConnectionFactory().CreateConnection(serverAddress);
      using (var ch = conn.CreateModel())
      {
        conn.AutoClose = true;
        ch.QueueDeclare(queueName, true);

        BasicGetResult result = null;
        while ((result = ch.BasicGet(queueName, false)) != null)
        {
          ch.BasicAck(result.DeliveryTag, false);
          Console.WriteLine("Message: {0}", Encoding.ASCII.GetString(result.Body));
        }
      }

      Console.ReadKey();
    }
  }
}
