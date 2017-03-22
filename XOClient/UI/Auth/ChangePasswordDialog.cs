using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XOClient.UI.Auth
{
    public partial class ChangePasswordDialog : Form
    {
        public ChangePasswordDialog()
        {
            InitializeComponent();
        }

        public string Login { get; internal set; }
        public string NewPassword { get; internal set; }
        public string Password { get; internal set; }

        private void B_Confirm_Click(object sender, EventArgs e)
        {
            Login = T_Login.Text;
            Password = T_Password.Text;
            NewPassword = T_NewPassword.Text;
        }
    }
}
