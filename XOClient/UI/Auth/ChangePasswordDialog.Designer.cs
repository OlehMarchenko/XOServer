namespace XOClient.UI.Auth
{
    partial class ChangePasswordDialog
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.T_Login = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.T_Password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.T_NewPassword = new System.Windows.Forms.TextBox();
            this.B_Confirm = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.T_Login);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.T_Password);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.T_NewPassword);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(16, 15);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(351, 148);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Login :";
            // 
            // T_Login
            // 
            this.T_Login.Location = new System.Drawing.Point(4, 21);
            this.T_Login.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.T_Login.Name = "T_Login";
            this.T_Login.Size = new System.Drawing.Size(340, 22);
            this.T_Login.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password :";
            // 
            // T_Password
            // 
            this.T_Password.Location = new System.Drawing.Point(4, 68);
            this.T_Password.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.T_Password.Name = "T_Password";
            this.T_Password.Size = new System.Drawing.Size(340, 22);
            this.T_Password.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "New Password :";
            // 
            // T_NewPassword
            // 
            this.T_NewPassword.Location = new System.Drawing.Point(4, 115);
            this.T_NewPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.T_NewPassword.Name = "T_NewPassword";
            this.T_NewPassword.Size = new System.Drawing.Size(340, 22);
            this.T_NewPassword.TabIndex = 2;
            // 
            // B_Confirm
            // 
            this.B_Confirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.B_Confirm.Location = new System.Drawing.Point(213, 170);
            this.B_Confirm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.B_Confirm.Name = "B_Confirm";
            this.B_Confirm.Size = new System.Drawing.Size(153, 28);
            this.B_Confirm.TabIndex = 0;
            this.B_Confirm.Text = "Confirm";
            this.B_Confirm.UseVisualStyleBackColor = true;
            this.B_Confirm.Click += new System.EventHandler(this.B_Confirm_Click);
            // 
            // ChangePasswordDialog
            // 
            this.AcceptButton = this.B_Confirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 204);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.B_Confirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePasswordDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Password";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox T_Login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox T_Password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox T_NewPassword;
        private System.Windows.Forms.Button B_Confirm;
    }
}