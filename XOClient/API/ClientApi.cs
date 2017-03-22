using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XOClient.API
{
    public class ClientApi
    {
        public ClientApi(EventHandler FreePlayersHandler, EventHandler InviteHandler, 
            EventHandler SuccessHandler, Action<bool> Auth, Action<bool> Reg, Action<string> ChangePassword)
        {
            Client = new TcpClient("localhost", Port);

            FreePlayresListChanged += FreePlayersHandler;
            InviteOccur += InviteHandler;
            SuccessOccur += SuccessHandler;
            Authentification += Auth;
            Registration += Reg;
            ChangePass += ChangePassword;

            threadListener = new Thread(new ThreadStart(ListenLoop));
            threadListener.Start();
        }


        private const int Port = 8080;
        private Thread threadListener;
        private NetworkStream ns;
        public EventHandler FreePlayresListChanged;
        public EventHandler InviteOccur;
        public EventHandler SuccessOccur;
        private Action<bool> Authentification;
        private Action<bool> Registration;
        private Action<string> ChangePass;
        public TcpClient Client { get; private set; }

        private void ListenLoop()
        {
            ns = Client.GetStream();
            StreamReader sr = new StreamReader(ns);

            while (true)
            {
                if (ns.DataAvailable)
                {
                    string message = sr.ReadLine();
                    var modifier = message.Remove(message.IndexOf(":"));
                    var args = message.Replace(modifier + ":", "").Split(',');

                    switch (modifier)
                    {
                        case "broadcast":
                            {
                                FreePlayresListChanged(args, null);
                                break;
                            }
                        case "invite":
                            {
                                InviteOccur(args[0], null);
                                break;
                            }
                        case "success":
                            {
                                SuccessOccur(args, null);
                                break;
                            }
                        case "auth":
                            {
                                if (args[0].Equals("yes"))
                                {
                                    Authentification(true);
                                }
                                else
                                {
                                    Authentification(false);
                                }
                                break;
                            }
                        case "reg":
                            {
                                if (args[0].Equals("yes"))
                                {
                                    Registration(true);
                                }

                                else
                                {
                                    Registration(false);
                                }
                                break;
                            }
                        case "changepass":
                            {
                                var msg = "";
                                if (args[0].Equals("yes"))
                                {
                                    msg = "Password successfully changed!";
                                }
                                else
                                {
                                    msg = "Invalid login or/and password";
                                }
                                ChangePass(msg);
                                break;
                            }
                    }
                }
            }
        }

        public void SendSocialLogin(string login)
        {
            Send("auth:" + login + ",social");
        }

        public void SendChangePassword(string login, string password, string newPassword)
        {
            Send(String.Format("changepass:{0},{1},{2}", login, password, newPassword));
        }

        public void SendForgotPassword(string username, string email)
        {
            Send(String.Format("forgotpass:{0},{1}", username, email));
        }

        public void SendLogout(string message)
        {
            Send(message);
        }

        public void SendInviteResponse(string response)
        {
            Send(response);
        }

        public void SendInviteRequest(string response)
        {
            Send(response);
        }

        public void SendAuth(string name, string password)
        {
            Send("auth:" + name + "," + password);
        }

        public void SendReg(string name, string password)
        {
            Send("reg:" + name + "," + password);
        }

        private void Send(string response)
        {
            while (ns == null) { }

            StreamWriter sw = new StreamWriter(ns);
            sw.WriteLine(response);
            sw.Flush();
        }

    }
}
