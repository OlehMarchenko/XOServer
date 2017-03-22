using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationServer
{
    public class ClientComands
    {
        static ClientComands()
        {
            block = new object();
            registredUsers = new RegistredUsers();
        }


        private static object block;
        public static RegistredUsers registredUsers;


        public static void Authorization(string login, string password, TcpClient client)
        {
            string name = registredUsers.Read(login, password);
            Content content = new Content("Authorization", name, "*", "*","*");
            string sms = content.GetContent(content);
            SendMessage(sms, client);
        }

        public static void SignUP(string name, string login, string password, TcpClient client)
        {
            if (registredUsers.Create(name, login, password) == true)
            {
                Content content = new Content("SignUP", "*", "*", "*","Success");
                string sms = content.GetContent(content);
                SendMessage(sms, client);
            }
            else
            {
                Content content = new Content("SignUP", "*", "*", "*", "No success");
                string sms = content.GetContent(content);
                SendMessage(sms, client);
            }
        }

        public static void ChangePassword(string login, string newPass, TcpClient client)
        {
            if (registredUsers.Update(login, newPass))
            {
                Content content = new Content("ChangePassword", "Server", "*", "*", "OK");
                string sms = content.GetContent(content);
                SendMessage(sms, client);
            }
            else
            {
                Content content = new Content("ChangePassword", "Server", "*", "*", "ERROR");
                string sms = content.GetContent(content);
                SendMessage(sms, client);
            }
        }

        public static void ForgotPassword(string login, TcpClient client)
        {
            string pass = registredUsers.GetData(login);
            Content content;

            if (pass != null || pass != "")
            {
                content = new Content("ForgotPassword", "Server", "*", pass, "OK");
            }
            else
            {
                content = new Content("ForgotPassword", "Server", "*", "*", "Error");
            }
            string sms = content.GetContent(content);
            SendMessage(sms, client);
        }

        private static void SendMessage(string message, TcpClient client)
        {
            if (client != null)
            {
                lock (block)
                {
                    StreamWriter streamWriter = new StreamWriter(client.GetStream());
                    streamWriter.WriteLine(message);
                    streamWriter.Flush();
                }
            }
        }

    }
}
