using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationServer
{
    public class Dispatcher
    {

        private object block = new object();
        Content contentFromClient;


        public Dispatcher()
        {

        }

        public void AddClient(TcpClient tcpClient)
        {
            var client = tcpClient;
            ReadClient(client);
            //new Task(() => ReadClient(client)).Start();
        }

        private void ReadClient(TcpClient client)
        {
            var tcpClient = client;
            NetworkStream networkStream = tcpClient.GetStream();
            while (true)
            {
                if (networkStream.DataAvailable)
                {
                    StreamReader streamReader = new StreamReader(networkStream);
                    var content = streamReader.ReadLine();
                    GetMessage(content, client);
                }
            }
        }

        private void GetMessage(string content, TcpClient client)
        {
            contentFromClient = new Content();
            contentFromClient = contentFromClient.SetContent(content);

            switch (contentFromClient.Action)
            {
                case "Authorization" : ClientComands.Authorization(contentFromClient.Login, contentFromClient.Password, client); break;
                case "SignUP"        : ClientComands.SignUP(contentFromClient.Name, contentFromClient.Login, contentFromClient.Password, client); break;
                case "ForgotPassword": ClientComands.ForgotPassword(contentFromClient.Login, client); break;
                case "ChangePassword": ClientComands.ChangePassword(contentFromClient.Login, contentFromClient.Password, client); break;

                default: break;
            }

            contentFromClient = null;
        }
    }
}