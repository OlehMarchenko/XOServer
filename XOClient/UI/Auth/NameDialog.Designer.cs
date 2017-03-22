namespace XOClient.UI
{
    partial class NameDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAuth = new System.Windows.Forms.Button();
            this.L_EnterNickname = new System.Windows.Forms.Label();
            this.TB_Nickname = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.TB_Password = new System.Windows.Forms.TextBox();
            this.buttonReg = new System.Windows.Forms.Button();
            this.B_ChangePassword = new System.Windows.Forms.Button();
            this.B_ForgotPassword = new System.Windows.Forms.Button();
            this.B_GoogleLogin = new System.Windows.Forms.Button();
            this.B_FacebookLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAuth
            // 
            this.buttonAuth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAuth.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.buttonAuth.Location = new System.Drawing.Point(473, 150);
            this.buttonAuth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAuth.Name = "buttonAuth";
            this.buttonAuth.Size = new System.Drawing.Size(127, 28);
            this.buttonAuth.TabIndex = 0;
            this.buttonAuth.Text = "&Login";
            this.buttonAuth.UseVisualStyleBackColor = true;
            this.buttonAuth.Click += new System.EventHandler(this.OnAuth_Click);
            // 
            // L_EnterNickname
            // 
            this.L_EnterNickname.Dock = System.Windows.Forms.DockStyle.Top;
            this.L_EnterNickname.Location = new System.Drawing.Point(0, 0);
            this.L_EnterNickname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.L_EnterNickname.Name = "L_EnterNickname";
            this.L_EnterNickname.Padding = new System.Windows.Forms.Padding(13, 6, 0, 0);
            this.L_EnterNickname.Size = new System.Drawing.Size(613, 28);
            this.L_EnterNickname.TabIndex = 1;
            this.L_EnterNickname.Text = "Enter your nickname:";
            // 
            // TB_Nickname
            // 
            this.TB_Nickname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Nickname.Location = new System.Drawing.Point(17, 36);
            this.TB_Nickname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_Nickname.MaxLength = 32;
            this.TB_Nickname.Name = "TB_Nickname";
            this.TB_Nickname.Size = new System.Drawing.Size(579, 22);
            this.TB_Nickname.TabIndex = 2;
            // 
            // labelPassword
            // 
            this.labelPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPassword.Location = new System.Drawing.Point(0, 68);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Padding = new System.Windows.Forms.Padding(13, 6, 0, 0);
            this.labelPassword.Size = new System.Drawing.Size(613, 28);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Enter your password:";
            // 
            // TB_Password
            // 
            this.TB_Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Password.Location = new System.Drawing.Point(16, 103);
            this.TB_Password.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_Password.MaxLength = 32;
            this.TB_Password.Name = "TB_Password";
            this.TB_Password.Size = new System.Drawing.Size(579, 22);
            this.TB_Password.TabIndex = 4;
            this.TB_Password.UseSystemPasswordChar = true;
            // 
            // buttonReg
            // 
            this.buttonReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReg.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonReg.Location = new System.Drawing.Point(473, 186);
            this.buttonReg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonReg.Name = "buttonReg";
            this.buttonReg.Size = new System.Drawing.Size(127, 28);
            this.buttonReg.TabIndex = 5;
            this.buttonReg.Text = "&Registration";
            this.buttonReg.UseVisualStyleBackColor = true;
            this.buttonReg.Click += new System.EventHandler(this.OnReg_Click);
            // 
            // B_ChangePassword
            // 
            this.B_ChangePassword.DialogResult = System.Windows.Forms.DialogResult.No;
            this.B_ChangePassword.Location = new System.Drawing.Point(17, 150);
            this.B_ChangePassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.B_ChangePassword.Name = "B_ChangePassword";
            this.B_ChangePassword.Size = new System.Drawing.Size(155, 28);
            this.B_ChangePassword.TabIndex = 6;
            this.B_ChangePassword.Text = "Change password";
            this.B_ChangePassword.UseVisualStyleBackColor = true;
            this.B_ChangePassword.Click += new System.EventHandler(this.B_ChangePassword_Click);
            // 
            // B_ForgotPassword
            // 
            this.B_ForgotPassword.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.B_ForgotPassword.Location = new System.Drawing.Point(17, 186);
            this.B_ForgotPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.B_ForgotPassword.Name = "B_ForgotPassword";
            this.B_ForgotPassword.Size = new System.Drawing.Size(155, 28);
            this.B_ForgotPassword.TabIndex = 7;
            this.B_ForgotPassword.Text = "Forgot password";
            this.B_ForgotPassword.UseVisualStyleBackColor = true;
            this.B_ForgotPassword.Click += new System.EventHandler(this.B_ForgotPassword_Click);
            // 
            // B_GoogleLogin
            // 
            this.B_GoogleLogin.Location = new System.Drawing.Point(236, 230);
            this.B_GoogleLogin.Name = "B_GoogleLogin";
            this.B_GoogleLogin.Size = new System.Drawing.Size(78, 51);
            this.B_GoogleLogin.TabIndex = 8;
            this.B_GoogleLogin.Text = "Google+ Login";
            this.B_GoogleLogin.UseVisualStyleBackColor = true;
            this.B_GoogleLogin.Click += new System.EventHandler(this.B_GoogleLogin_Click);
            // 
            // B_FacebookLogin
            // 
            this.B_FacebookLogin.Location = new System.Drawing.Point(320, 230);
            this.B_FacebookLogin.Name = "B_FacebookLogin";
            this.B_FacebookLogin.Size = new System.Drawing.Size(78, 51);
            this.B_FacebookLogin.TabIndex = 9;
            this.B_FacebookLogin.Text = "Facebook Login";
            this.B_FacebookLogin.UseVisualStyleBackColor = true;
            this.B_FacebookLogin.Click += new System.EventHandler(this.B_FacebookLogin_Click);
            // 
            // NameDialog
            // 
            this.AcceptButton = this.buttonAuth;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 293);
            this.Controls.Add(this.B_FacebookLogin);
            this.Controls.Add(this.B_GoogleLogin);
            this.Controls.Add(this.B_ForgotPassword);
            this.Controls.Add(this.B_ChangePassword);
            this.Controls.Add(this.buttonReg);
            this.Controls.Add(this.TB_Password);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.TB_Nickname);
            this.Controls.Add(this.L_EnterNickname);
            this.Controls.Add(this.buttonAuth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NameDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nickname Selection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAuth;
        private System.Windows.Forms.Label L_EnterNickname;
        private System.Windows.Forms.TextBox TB_Nickname;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox TB_Password;
        private System.Windows.Forms.Button buttonReg;
        private System.Windows.Forms.Button B_ChangePassword;
        private System.Windows.Forms.Button B_ForgotPassword;
        private System.Windows.Forms.Button B_GoogleLogin;
        private System.Windows.Forms.Button B_FacebookLogin;
    }
}