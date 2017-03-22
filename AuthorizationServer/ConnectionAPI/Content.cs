using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AuthorizationServer
{
    public class Content
    {
        public string Action { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string NameDialog { get; set; }
        public string Message { get; set; }

        public Content()
        {

        }

        public Content(string action, string name, string login, string password, string message)
        {
            this.Action = action;
            this.Name = name;
            this.Login = login;
            this.Password = password;
            this.Role = "";
            this.NameDialog = "";
            this.Message = message;
        }

        public Content SetContent(string message)
        {
            return JsonConvert.DeserializeObject<Content>(message);
        }

        public string GetContent(Content content)
        {
            return JsonConvert.SerializeObject(content);
        }
    }
}
