using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOServer.Authentification
{
    public class AuthRegContent
    {
        public string Action { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string NameDialog { get; set; }

        public string Message { get; set; }

        public AuthRegContent()
        {

        }

        public AuthRegContent(string action, string name, string login, string password)
        {
            this.Action = action;
            this.Name = name;
            this.Login = login;
            this.Password = password;
            this.Role = "";
            this.NameDialog = "";
            this.Message = "";
        }

        public AuthRegContent GetContent(string message)
        {
            return JsonConvert.DeserializeObject<AuthRegContent>(message);
        }

        public string SetContent(AuthRegContent content)
        {
            return JsonConvert.SerializeObject(content);
        }
    }
}
