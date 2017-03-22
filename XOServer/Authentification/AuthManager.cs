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
        /*
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
                */

        public static string ConnectionProcessing(TcpClient socket, string command, ConnectionList connList, UniversalStream us, AuthRegModule module)
        {
            try
            {
                var modifier = command.Remove(command.IndexOf(":"));
                var args = command.Replace(Environment.NewLine, "").Replace(modifier + ":", "").Split(',');
                string result = null;
                switch (modifier)
                {
                    case "reg":
                        {

                            AuthRegContent content = new AuthRegContent("SignUP", "", args[0], args[1]);
                            var message = content.SetContent(content);
                            var response = module.SyncSendCommandGetResponse(message);
                            content = content.GetContent(response);

                            if (content.Message.Equals("Success"))
                            {
                                // send yes
                                us.Write("reg:yes");
                                result = args[0];
                            }
                            else if (content.Message.Equals("No success"))
                            {
                                // send no
                                us.Write("reg:no");
                            }

                            break;
                        }
                    case "auth":
                        {
                            if (args[1].Equals("social"))
                            {
                                us.Write("auth:yes");
                                result = args[0];
                            }
                            else
                            {
                                AuthRegContent content = new AuthRegContent("Authorization", "", args[0], args[1]);
                                var message = content.SetContent(content);
                                var response = module.SyncSendCommandGetResponse(message);
                                content = content.GetContent(response);
                                if (!(content.Name.Equals("Not registred")))
                                {
                                    // send yes
                                    us.Write("auth:yes");
                                    result = args[0];
                                }
                                else
                                {
                                    // send no
                                    us.Write("auth:no");
                                }
                            }
                            
                            break;
                        }
                    case "changepass":
                        {

                            AuthRegContent content = new AuthRegContent("ChangePassword", "", args[0], args[2]);
                            var message = content.SetContent(content);
                            var response = module.SyncSendCommandGetResponse(message);
                            content = content.GetContent(response);

                            if (content.Message.Equals("OK"))
                            {
                                // send yes
                                us.Write("changepass:yes");
                            }
                            else if (content.Message.Equals("ERROR"))
                            {
                                // send no
                                us.Write("changepass:no");
                            }

                            break;
                        }
                    case "forgotpass":
                        {
                            AuthRegContent content = new AuthRegContent("ForgotPassword", "", args[0], "");
                            var message = content.SetContent(content);
                            var response = module.SyncSendCommandGetResponse(message);
                            content = content.GetContent(response);

                            if (content.Message.Equals("OK"))
                            {
                                //get pass and send to email
                                passManager.SendEmailToRetrievePassword(args[0], args[1], content.Password);
                            }

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
