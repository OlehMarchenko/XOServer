﻿namespace XOClient.UI
{
    partial class PlayerSelectionForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TLP_Main = new System.Windows.Forms.TableLayoutPanel();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusBar_Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBar_PlayerName = new System.Windows.Forms.ToolStripStatusLabel();
            this.B_Invite = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CB_GameSelection = new System.Windows.Forms.ComboBox();
            this.L_GameSelection = new System.Windows.Forms.Label();
            this.LB_FreePlayers = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.B_Connection = new System.Windows.Forms.Button();
            this.B_Logout = new System.Windows.Forms.Button();
            this.TLP_Main.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLP_Main
            // 
            this.TLP_Main.ColumnCount = 3;
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.2188F));
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.23177F));
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.TLP_Main.Controls.Add(this.StatusBar, 0, 2);
            this.TLP_Main.Controls.Add(this.B_Invite, 1, 1);
            this.TLP_Main.Controls.Add(this.panel1, 2, 1);
            this.TLP_Main.Controls.Add(this.LB_FreePlayers, 0, 0);
            this.TLP_Main.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.TLP_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Main.Location = new System.Drawing.Point(0, 0);
            this.TLP_Main.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TLP_Main.Name = "TLP_Main";
            this.TLP_Main.RowCount = 3;
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP_Main.Size = new System.Drawing.Size(617, 551);
            this.TLP_Main.TabIndex = 0;
            // 
            // StatusBar
            // 
            this.TLP_Main.SetColumnSpan(this.StatusBar, 3);
            this.StatusBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBar_Label,
            this.StatusBar_PlayerName});
            this.StatusBar.Location = new System.Drawing.Point(0, 526);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.StatusBar.Size = new System.Drawing.Size(617, 25);
            this.StatusBar.TabIndex = 0;
            this.StatusBar.Text = "StatusBar";
            // 
            // StatusBar_Label
            // 
            this.StatusBar_Label.Name = "StatusBar_Label";
            this.StatusBar_Label.Size = new System.Drawing.Size(230, 20);
            this.StatusBar_Label.Text = "Waiting for connection to server...";
            // 
            // StatusBar_PlayerName
            // 
            this.StatusBar_PlayerName.Name = "StatusBar_PlayerName";
            this.StatusBar_PlayerName.Size = new System.Drawing.Size(367, 20);
            this.StatusBar_PlayerName.Spring = true;
            this.StatusBar_PlayerName.Text = "Your name: ";
            this.StatusBar_PlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // B_Invite
            // 
            this.B_Invite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Invite.Location = new System.Drawing.Point(283, 467);
            this.B_Invite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.B_Invite.Name = "B_Invite";
            this.B_Invite.Size = new System.Drawing.Size(123, 55);
            this.B_Invite.TabIndex = 2;
            this.B_Invite.Text = "Invite";
            this.B_Invite.UseVisualStyleBackColor = true;
            this.B_Invite.Click += new System.EventHandler(this.B_Invite_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CB_GameSelection);
            this.panel1.Controls.Add(this.L_GameSelection);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(410, 463);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 63);
            this.panel1.TabIndex = 3;
            // 
            // CB_GameSelection
            // 
            this.CB_GameSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.CB_GameSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_GameSelection.FormattingEnabled = true;
            this.CB_GameSelection.Items.AddRange(new object[] {
            "Tic-Tac-Toe"});
            this.CB_GameSelection.Location = new System.Drawing.Point(0, 31);
            this.CB_GameSelection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CB_GameSelection.Name = "CB_GameSelection";
            this.CB_GameSelection.Size = new System.Drawing.Size(207, 24);
            this.CB_GameSelection.TabIndex = 1;
            // 
            // L_GameSelection
            // 
            this.L_GameSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.L_GameSelection.Location = new System.Drawing.Point(0, 0);
            this.L_GameSelection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.L_GameSelection.Name = "L_GameSelection";
            this.L_GameSelection.Size = new System.Drawing.Size(207, 31);
            this.L_GameSelection.TabIndex = 0;
            this.L_GameSelection.Text = "Select game:";
            this.L_GameSelection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_FreePlayers
            // 
            this.TLP_Main.SetColumnSpan(this.LB_FreePlayers, 3);
            this.LB_FreePlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LB_FreePlayers.FormattingEnabled = true;
            this.LB_FreePlayers.ItemHeight = 16;
            this.LB_FreePlayers.Location = new System.Drawing.Point(4, 4);
            this.LB_FreePlayers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LB_FreePlayers.Name = "LB_FreePlayers";
            this.LB_FreePlayers.Size = new System.Drawing.Size(609, 455);
            this.LB_FreePlayers.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.B_Connection, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.B_Logout, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 465);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(273, 59);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // B_Connection
            // 
            this.B_Connection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Connection.Location = new System.Drawing.Point(4, 4);
            this.B_Connection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.B_Connection.Name = "B_Connection";
            this.B_Connection.Size = new System.Drawing.Size(128, 51);
            this.B_Connection.TabIndex = 2;
            this.B_Connection.Text = "Log in";
            this.B_Connection.UseVisualStyleBackColor = true;
            this.B_Connection.Click += new System.EventHandler(this.B_Connection_Click);
            // 
            // B_Logout
            // 
            this.B_Logout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Logout.Location = new System.Drawing.Point(139, 2);
            this.B_Logout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B_Logout.Name = "B_Logout";
            this.B_Logout.Size = new System.Drawing.Size(131, 55);
            this.B_Logout.TabIndex = 3;
            this.B_Logout.Text = "Log out";
            this.B_Logout.UseVisualStyleBackColor = true;
            this.B_Logout.Click += new System.EventHandler(this.B_Logout_Click);
            // 
            // PlayerSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 551);
            this.Controls.Add(this.TLP_Main);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PlayerSelectionForm";
            this.Text = "Player selection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerSelectionForm_FormClosing);
            this.TLP_Main.ResumeLayout(false);
            this.TLP_Main.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP_Main;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.Button B_Invite;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label L_GameSelection;
        private System.Windows.Forms.ComboBox CB_GameSelection;
        private System.Windows.Forms.ListBox LB_FreePlayers;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar_Label;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar_PlayerName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button B_Connection;
        private System.Windows.Forms.Button B_Logout;
    }
}

