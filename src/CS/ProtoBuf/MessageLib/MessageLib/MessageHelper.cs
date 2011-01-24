using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ProtoBuf;

namespace MessageLib
{
  public static class MessageHelper
  {
    public static byte[] Serialize(Message message)
    {
      using (var ms = new MemoryStream())
      {
        Serializer.Serialize(ms, message);
        return ms.ToArray();
      }
    }

    public static Message Deserialize(byte[] data)
    {
      using (var ms = new MemoryStream(data))
      {
        return Serializer.Deserialize<Message>(ms);
      }
    }
  }
}
