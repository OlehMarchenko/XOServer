using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.UniversalSockets;
using XOServer.Authentification;
using XOServer.Sessions;
using System.Text.RegularExpressions;
using XOServer.Debug;

namespace XOServer.API
{
    public class ServerApi
    {
        private const int Port = 8080;
        private TcpListener serverListener;
        private Thread threadConnection;
        private ConnectionList connList;
        private RequestLoop requestLoop;
        private AuthRegModule authRegModule;

        public ServerApi()
        {
            authRegModule = new AuthRegModule();
            connList = new ConnectionList(this);
            requestLoop = new RequestLoop(connList, this);
            serverListener = new TcpListener(IPAddress.Any, Port);
            threadConnection = new Thread(new ThreadStart(ConnectionLoop));
            authRegModule.ConnectoToAuthRegServer();
            threadConnection.Start();
        }

        private void ConnectionLoop()
        {
            try
            {
                serverListener.Start();

                while (true)
                {
                    var connectedClient = serverListener.AcceptTcpClient();
                    var client = GetClient(connectedClient);
                    if (client != null) connList.AddUser(client);
                }
            }
            catch (Exception ex)
            {
                // CRASH
                CrashReport.WriteCrash(ex.Message, ex.InnerException?.ToString());
            }
        }

        private Client GetClient(TcpClient clientSocket)
        {
            try
            {
                UniversalStream us = new UniversalStream(clientSocket);
                string name = String.Empty;
                Client result = null;
                ClientType type = ClientType.Desktop;

                while (true)
                {
                    if (clientSocket.GetStream().DataAvailable)
                    {
                        // make handshake
                        var message = us.Read();

                        if (new Regex("^GET").IsMatch(message))
                        {
                            us.WriteHandshake(message);
                            type = ClientType.Web;
                            us.Type = type;
                            continue;
                        }

                        name = AuthManager.ConnectionProcessing(
                            clientSocket,
                            (type == ClientType.Web) ? us.Decode() : message,
                            connList,
                            us,
                            authRegModule
                        );
                        break;
                    }

                    Thread.Sleep(10);
                }

                if (name != null)
                {
                    result = new Client(name, clientSocket);
                    result.Us = us;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
