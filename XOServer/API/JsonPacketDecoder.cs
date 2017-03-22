using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XOServer.API
{
    public static class JsonPacketDecoder
    {
        public static TTTPacket Decode(string jsonStr)
        {
            try
            {
                TTTPacket inPacket = null;
                inPacket = JsonConvert.DeserializeObject<TTTPacket>(jsonStr.Replace(";", ","));
                return inPacket;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public static string Encode(TTTPacket packet)
        {
            try
            {
                string result = null;
                result = JsonConvert.SerializeObject(packet);
                return result.Replace(",", ";");
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
