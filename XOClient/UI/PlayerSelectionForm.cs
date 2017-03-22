using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XOClient.API;
using XOClient.UI.Auth;
using XOClient.UI.Games;

namespace XOClient.UI
{
    public partial class PlayerSelectionForm : Form
    {
        public PlayerSelectionForm()
        {
            InitializeComponent();
            CB_GameSelection.SelectedIndex = 0;
            changePassD = new ChangePasswordDialog();
            forgotPassD = new ForgotPasswordDialog();
        }

        private string name;
        private ClientApi clientApi;

        private ChangePasswordDialog changePassD;
        private ForgotPasswordDialog forgotPassD;

        #region OnClick Listeners
        private void B_Connection_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.name != null) return;
                NameDialog dlg = new NameDialog();
                var dlgRes = dlg.ShowDialog();

                if (dlgRes == DialogResult.OK || dlgRes == DialogResult.Yes || dlgRes == DialogResult.Retry 
                    || dlgRes == DialogResult.No || dlgRes == DialogResult.Ignore)
                {
                    // Creating connection to server
                    clientApi = new ClientApi(new EventHandler(FreePlayersListChanged), new EventHandler(InviteOccur), new EventHandler(SuccessOccur),
                        AuthProcessing, RegProcessing, ChangePasswordException);
                }

                switch (dlgRes)
                {
                    case DialogResult.OK:
                        {
                            name = dlg.Nickname;
                            clientApi.SendReg(name, dlg.Password);
                            break;
                        }
                    case DialogResult.Yes:
                        {
                            name = dlg.Nickname;
                            clientApi.SendAuth(name, dlg.Password);
                            break;
                        }
                    case DialogResult.Retry:
                        {
                            if (!dlg.Nickname.Equals(""))
                            {
                                forgotPassD.ShowDialog();
                                clientApi.SendForgotPassword(dlg.Nickname, forgotPassD.Email);
                            }
                            else
                            {
                                MessageBox.Show("You should insert your login first!", "Password retrieval issue", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            break;
                        }
                    case DialogResult.No:
                        {
                            changePassD.ShowDialog();
                            clientApi.SendChangePassword(changePassD.Login, changePassD.Password, changePassD.NewPassword);
                            break;
                        }
                    case DialogResult.Ignore:
                        {
                            name = dlg.Nickname;
                            clientApi.SendSocialLogin(name);
                            break;
                        }
                }
                dlg.Dispose();
            }
            catch(SocketException)
            {
                MessageBox.Show("Unable to establish a connection to the server!\nProbably, server is offline.", "Connection issue", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void B_Logout_Click(object sender, EventArgs e)
        {
            if (this.name == null)
            {
                MessageBox.Show("You are not connected to the server!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Action logout = new Action(() => {
                    StatusBar_PlayerName.Text = StatusBar_PlayerName.Text.Replace(name, "");
                    StatusBar_Label.Text = "Waiting for connection to server...";
                    LB_FreePlayers.Items.Clear();
                    name = null;
                });

                if (this.InvokeRequired) this.Invoke(logout);
                else logout();

                clientApi.SendLogout("logout:");
            }
        }

        private void PlayerSelectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.name != null)
            {
                clientApi.SendLogout("logout:");
            }
        }

        private void B_Invite_Click(object sender, EventArgs e)
        {
            // Sending an invitation notification to server
            try
            {
                if (LB_FreePlayers.SelectedItem == null)
                {
                    throw new Exception();
                }
                string message = "invite:" + (LB_FreePlayers.SelectedItem as string);
                clientApi.SendInviteRequest(message);
            }
            catch
            {
                MessageBox.Show("Player haven't been choosen!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region EventHandles
        private void RegProcessing(bool isReg)
        {
            if (isReg)
            {
                if (StatusBar.InvokeRequired)
                {
                    StatusBar.Invoke(new Action(() =>
                    {
                        StatusBar_PlayerName.Text += name;
                        StatusBar_Label.Text = "Connected to server";
                    }));
                }
            }
            else
            {
                name = null;
                MessageBox.Show("Login already exists!", "Registration issue.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AuthProcessing(bool isAuth)
        {
            if (isAuth)
            {
                if (StatusBar.InvokeRequired)
                {
                    StatusBar.Invoke(new Action(() =>
                    {
                        StatusBar_PlayerName.Text += name;
                        StatusBar_Label.Text = "Connected to server";
                    }));
                }
            }
            else
            {
                name = null;
                MessageBox.Show("Invalid login or/and password!", "Authorization issue", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangePasswordException(string message)
        {
            MessageBox.Show(message, "Password change", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FreePlayersListChanged(object sender, EventArgs e)
        {
            List<string> message = (sender as string[]).ToList();
            message.Remove(message.First(n => n.Equals(name)));

            if (LB_FreePlayers.InvokeRequired)
            {
                LB_FreePlayers.Invoke(new Action(() => 
                {
                    LB_FreePlayers.Items.Clear();
                    LB_FreePlayers.Items.AddRange(message.ToArray());
                }));
            }
        }

        private void InviteOccur(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Player " + (sender as string) + " want to play with you", "Invite", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            string message = String.Empty;
            if (result == DialogResult.OK)
            {
                message = "inviteYes:";
            }
            else
            {
                message = "inviteNo:";
            }
            message += name + "," + (sender as string);

            clientApi.SendInviteResponse(message);
        }

        private void SuccessOccur(object sender, EventArgs e)
        {
            var cmd = (sender as string[]);

            if (cmd[0].StartsWith("yes"))
            {
                TicTacToeGame game = new TicTacToeGame(cmd[1], clientApi.Client);
             
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => this.Visible = false));
                }
                game.ShowDialog();
                game.Dispose();

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => this.Visible = true));
                }

            }
            else
            {
                MessageBox.Show("Connection denied.", "Respone", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

    }
}
