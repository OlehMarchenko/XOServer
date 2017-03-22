using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace XOServer.Authentification
{
    public class AuthRegModule
    {
        private TcpClient client;
        private NetworkStream ns;
        private const int port = 11111;

        public AuthRegModule()
        {
            client = null;
        }

        public string ListenLoop()
        {
            string response = null;
            bool connection = true;
            while (connection)
            {
                if (client.GetStream().DataAvailable)
                {
                    StreamReader reader = new StreamReader(client.GetStream());
                    response = reader.ReadLine();
                    // get response from server
                    connection = false;
                }
            }
            return response;
        }

        public string SyncSendCommandGetResponse(string message)
        {
            var response = String.Empty;

            StreamWriter writer = new StreamWriter(client.GetStream());
            writer.WriteLine(message);
            writer.Flush();

            response = ListenLoop();
            return response;
        }

        public void ConnectoToAuthRegServer()
        {
            client = new TcpClient("localhost", port);
            ns = client.GetStream();
        }

        public void DisconnectFromAuthRegServer()
        {
            ns.Dispose();
            client.Close();
        }
    }
}
