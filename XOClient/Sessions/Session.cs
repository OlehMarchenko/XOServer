using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XOClient.API;

namespace XOClient.Sessions
{
    public class Session
    {
        public Session(TcpClient client, EventHandler InitHandler, EventHandler TurnHandler, EventHandler PlayerQuitedHandler)
        {
            IsConnection = true;
            this.client = client;
            this.InitHandle += InitHandler;
            this.TurnOccured += TurnHandler;
            this.PlayerQuited += PlayerQuitedHandler;
            threadListener = new Thread(new ThreadStart(ListenLoop));
            threadListener.Start();
        }
        

        private TcpClient client;
        private StreamWriter sw;
        private Thread threadListener;
        private EventHandler InitHandle;
        private EventHandler TurnOccured;
        private EventHandler PlayerQuited;

        public bool IsConnection { set; get; }


        private void ListenLoop()
        {
            NetworkStream ns = client.GetStream();
            StreamReader sr = new StreamReader(ns);
            sw = new StreamWriter(ns);
            string xmlStr = String.Empty;

            while (true)
            {
                if (ns.DataAvailable)
                {
                    xmlStr = sr.ReadLine();
                    break;
                }
            }

            InitHandle(JsonPacketDecoder.Decode(xmlStr), null);
            xmlStr = String.Empty;

            while (IsConnection)
            {
                if (ns.DataAvailable)
                {
                    xmlStr = sr.ReadLine();
                    if (xmlStr.Equals("game:quit"))
                    {
                        PlayerQuited(null, null);
                    }
                    else
                    {
                        TurnOccured(JsonPacketDecoder.Decode(xmlStr), null);
                    }
                }
            }
        }

        public void Send(string key, TTTPacket packet)
        {
            string xmlStr = JsonPacketDecoder.Encode(packet);
            sw.WriteLine("game:" + key + "," + xmlStr);
            sw.Flush();
        }

        public void SendQuitGame(string key)
        {
            sw.WriteLine("game:" + key + ",quit");
            sw.Flush();
        }
    }
}
