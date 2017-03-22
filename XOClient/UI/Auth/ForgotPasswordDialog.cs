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
    public partial class ForgotPasswordDialog : Form
    {
        public ForgotPasswordDialog()
        {
            InitializeComponent();
        }

        public string Email { get; internal set; }

        private void B_Send_Click(object sender, EventArgs e)
        {
            Email = this.T_Login.Text;
        }
    }
}
