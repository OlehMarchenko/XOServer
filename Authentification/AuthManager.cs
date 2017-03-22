using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net.UniversalSockets;
using XOServer.DAO;
using XOServer.DAO.Model;
using XOServer.API;

namespace XOServer.Authentification
{
    public static class AuthManager
    {
        static AuthManager()
        {
            passManager = new PasswordManager();
        }

        private static PasswordManager passManager;

        public static string ConnectionProcessing(TcpClient socket, string command, ConnectionList connList, UniversalStream us)
        {
            try
            {
                var modifier = command.Remove(command.IndexOf(":"));
                var args = command.Replace(Environment.NewLine, "").Replace(modifier + ":", "").Split(',');
                PlayerDAO_XML dao = new PlayerDAO_XML();
                string result = null;
                switch (modifier)
                {
                    case "reg":
                        {
                            bool exist = dao.Read().Any(p => p.Name.Equals(args[0]));
                            if (!exist)
                            {
                                dao.Create(new Player() { Name = args[0], Password = args[1], WinRate = 0.0f });
                                result = args[0];
                                us.Write("reg:yes");
                            }
                            else
                            {
                                us.Write("reg:no");
                            }

                            break;
                        }
                    case "auth":
                        {
                            bool exist = dao.Read().Any(p => p.Name.Equals(args[0]));
                            if (exist) exist = !connList.Any(p => p.Name.Equals(args[0]));
                            if (exist)
                            {
                                result = args[0];
                                us.Write("auth:yes");
                            }
                            else
                            {
                                us.Write("auth:no");
                            }
                            break;
                        }
                    case "changepass":
                        {
                            passManager.ChangePassword(us, args[0], args[1], args[2]);
                            break;
                        }
                    case "forgotpass":
                        {
                            passManager.SendEmailToRetrievePassword(args[0], args[1]);
                            break;
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
