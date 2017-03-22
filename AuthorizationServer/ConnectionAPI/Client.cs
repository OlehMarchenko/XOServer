using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationServer
{
    public class Client
    {

        public TcpClient client;

        public Client(TcpClient client)
        {
            this.client = client;
        }
    }
}
