using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace MessageLib
{
  [Serializable]
  public class Message
  {
    public string From { get; set; }
    public string Body { get; set; }

    public string Text
    {
      get
      {
        return String.Format("From: {0}\nBody: {1}", From, Body);
      }
    }

    public static byte[] Serialize(Message message)
    {
      using (var ms = new MemoryStream())
      {
        var bf = new BinaryFormatter();
        bf.Serialize(ms, message);
        return ms.ToArray();
      }
    }

    public static Message Deserialize(byte[] data)
    {
      using (var ms = new MemoryStream(data))
      {
        var bf = new BinaryFormatter();
        return (Message)bf.Deserialize(ms);
      }
    }
  }
}
