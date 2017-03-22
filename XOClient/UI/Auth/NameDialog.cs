using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XOClient.API;
using XOClient.UI.Auth;

namespace XOClient.UI
{
    public partial class NameDialog : Form
    {
        public NameDialog()
        {
            InitializeComponent();
            Nickname = "";
            Password = "";
        }

        public string Nickname { get; private set; }
        public string Password { get; private set; }

        private void OnReg_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Nickname = TB_Nickname.Text;
            Password = TB_Password.Text;
        }

        private void OnAuth_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Nickname = TB_Nickname.Text;
            Password = TB_Password.Text;
        }

        private void B_ForgotPassword_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
            Nickname = TB_Nickname.Text;
        }

        private void B_ChangePassword_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void B_GoogleLogin_Click(object sender, EventArgs e)
        {
            ExternalAuth auth = new ExternalAuth();
            string[] info = auth.Google_Auth();
            if (info[0] != null && info[1] != null)
            {
                DialogResult = DialogResult.Ignore;
                Nickname = auth.Tr(info[0]) + info[1];
            }
            else
            {
                MessageBox.Show("Google authorization issue", "Authorization issue", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void B_FacebookLogin_Click(object sender, EventArgs e)
        {
            ExternalAuth auth = new ExternalAuth();
            string[] info = auth.Facebook_Auth();
            if (info[0] != null && info[1] != null)
            {
                DialogResult = DialogResult.Ignore;
                Nickname = auth.Tr(info[0]) + info[1];
            }
            else
            {
                MessageBox.Show("Facebook authorization issue", "Authorization issue", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
