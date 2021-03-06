﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;
using MessageLib;

namespace ReceiveString
{
  class Program
  {
    static void Main(string[] args)
    {
      var serverAddress = @"192.168.0.196";
      var queueName = "message_data";

      var conn = new ConnectionFactory().CreateConnection(serverAddress);
      using (var ch = conn.CreateModel())
      {
        conn.AutoClose = true;
        ch.QueueDeclare(queueName, true);

        BasicGetResult result = null;
        while ((result = ch.BasicGet(queueName, false)) != null)
        {
          ch.BasicAck(result.DeliveryTag, false);
          var message = MessageHelper.Deserialize(result.Body);
          Console.WriteLine("Id: {0}\nFrom: {1}\nBody: {2}", message.Id, message.From, message.Body);
        }
      }

      Console.ReadKey();
    }
  }
}
