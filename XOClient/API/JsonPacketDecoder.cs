using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace XOClient.API
{
    public static class JsonPacketDecoder
    {
        public static TTTPacket Decode(string jsonStr)
        {
            TTTPacket inPacket = null;
            inPacket = JsonConvert.DeserializeObject<TTTPacket>(jsonStr.Replace(";", ","));
            return inPacket;
        }

        public static string Encode(TTTPacket packet)
        {
            string result = null;
            result = JsonConvert.SerializeObject(packet);
            return result.Replace(",", ";");
        }
    }
}
