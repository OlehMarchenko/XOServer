using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Net.UniversalSockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XOServer.Authentification;
using XOServer.DAO;
using XOServer.DAO.Model;

namespace XOServer.API
{
    public class PasswordManager
    {
        public PasswordManager()
        {

        }

        private bool CheckValidation(string email)
        {
            return new Regex(@"^[^\s@]+@[^\s@]+\.[^\s@]+$").IsMatch(email);
        }

        public void SendEmailToRetrievePassword(string login, string email, string pass)
        {
            if (CheckValidation(email))
            {
                var fromAddress = new MailAddress("tempuserscreen@gmail.com", "From administration");
                var toAddress = new MailAddress(email, "To " + login);
                string fromPassword = "4815162342qwerty";
                string subject = "Password retrieval";
                string body = String.Format("{0}{1}", pass == "" ? "Wrong login." : "This is your password: ", pass ?? "");

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
        }

        //public void SendEmailToRetrievePassword(string login, string email, string password)
        //{
        //    if (CheckValidation(email))
        //    {
        //        string pass = GetPassByName(login);

        //        var fromAddress = new MailAddress("tempuserscreen@gmail.com", "From administration");
        //        var toAddress = new MailAddress(email, "To " + login);
        //        string fromPassword = "4815162342qwerty";
        //        string subject = "Password retrieval";
        //        string body = String.Format("{0}{1}", pass == null ? "Wrong login." : "This is your password: ", pass ?? "");

        //        var smtp = new SmtpClient
        //        {
        //            Host = "smtp.gmail.com",
        //            Port = 587,
        //            EnableSsl = true,
        //            DeliveryMethod = SmtpDeliveryMethod.Network,
        //            UseDefaultCredentials = false,
        //            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        //        };
        //        using (var message = new MailMessage(fromAddress, toAddress)
        //        {
        //            Subject = subject,
        //            Body = body
        //        })
        //        {
        //            smtp.Send(message);
        //        }
        //    }
        //}

        private string GetPassByName(string name)
        {
            PlayerDAO_XML dao = new PlayerDAO_XML();
            List<Player> players = dao.Read().ToList();

            var player = players.First(p => p.Name.Equals(name));

            var result = String.Empty;
            if (player != null)
            {
                result = player.Password;
            }
            else
            {
                result = null;
            }

            return result;
        }

        public void ChangePassword(UniversalStream us, string login, string oldPass, string newPass)
        {
            PlayerDAO_XML dao = new PlayerDAO_XML();
            List<Player> players = dao.Read().ToList();
            string result = String.Empty;

            try
            {
                var player = players.First(p => p.Name.Equals(login) && p.Password.Equals(oldPass));
                player.Password = newPass;
                dao.Update(player);
                result = "yes";
            }
            catch
            {
                result = "no";
            }

            us.Write("changepass:" + result);
        }

    }
}
