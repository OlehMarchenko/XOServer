using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOServer.DAO.Model;
using System.Xml.Serialization;
using System.IO;

namespace XOServer.DAO
{
    public class IOManager
    {
        private const string ConnectionString = "PlayerList.xml";

        public IOManager()
        {

        }

        public void Serialize(IEnumerable<Player> playerList)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Player>));
                using (StreamWriter writer = new StreamWriter(ConnectionString))
                {
                    xml.Serialize(writer, playerList);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }

        public IEnumerable<Player> Deserialize()
        {
            try
            {
                List<Player> result = new List<Player>();
                if (File.Exists(ConnectionString))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<Player>));
                    using (StreamReader reader = new StreamReader(ConnectionString))
                    {
                        result = (List<Player>)xml.Deserialize(reader);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }
    }
}
