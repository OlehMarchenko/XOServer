using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AuthorizationServer
{  
    class ServerAPI
    {
        private const int Port = 11111;
        private TcpListener listener;

        private Thread threadListen;
        private Dispatcher dispatcher;

        public ServerAPI()
        {
            try
            {
                Init();
                ThreadInit();
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        private void Init()
        {
            dispatcher = new Dispatcher();
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), Port);
        }

        private void ThreadInit()
        {
            threadListen = new Thread(new ThreadStart(Listen));
            threadListen.Start();
        }

        public void Listen()
        {
            listener.Start();
            TcpClient client = listener.AcceptTcpClient();
            dispatcher.AddClient(client);
        }
    }
}
