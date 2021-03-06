﻿namespace A21_Ex01_Omer_206126128_Stav_205816705
{
    public partial class MainFeedForm
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
            this.components = new System.ComponentModel.Container();
            this.WelcomeUserNameLable = new System.Windows.Forms.Label();
            this.BlueTopBar = new System.Windows.Forms.Label();
            this.FetchaAlbumsBtn = new System.Windows.Forms.Button();
            this.FetchPostsBtn = new System.Windows.Forms.Button();
            this.FetchEventsBtn = new System.Windows.Forms.Button();
            this.GamesBtn = new System.Windows.Forms.Button();
            this.HomeBtn = new System.Windows.Forms.Button();
            this.NewPost = new System.Windows.Forms.RichTextBox();
            this.FeedGroupBox = new System.Windows.Forms.GroupBox();
            this.posted = new System.Windows.Forms.Button();
            this.PanelDropDown = new System.Windows.Forms.Panel();
            this.LogOut = new System.Windows.Forms.Button();
            this.Account = new System.Windows.Forms.Button();
            this.DropDownBar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.PictureBox();
            this.DropDownPictureBox = new System.Windows.Forms.PictureBox();
            this.UserNamePictureBox = new System.Windows.Forms.PictureBox();
            this.FacebookIcon = new System.Windows.Forms.PictureBox();
            this.PanelDropDown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DropDownPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserNamePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacebookIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // WelcomeUserNameLable
            // 
            this.WelcomeUserNameLable.AutoSize = true;
            this.WelcomeUserNameLable.BackColor = System.Drawing.Color.RoyalBlue;
            this.WelcomeUserNameLable.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeUserNameLable.ForeColor = System.Drawing.Color.White;
            this.WelcomeUserNameLable.Location = new System.Drawing.Point(1152, 20);
            this.WelcomeUserNameLable.Name = "WelcomeUserNameLable";
            this.WelcomeUserNameLable.Size = new System.Drawing.Size(71, 27);
            this.WelcomeUserNameLable.TabIndex = 0;
            this.WelcomeUserNameLable.Text = "Name";
            // 
            // BlueTopBar
            // 
            this.BlueTopBar.BackColor = System.Drawing.Color.RoyalBlue;
            this.BlueTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.BlueTopBar.ForeColor = System.Drawing.Color.White;
            this.BlueTopBar.Location = new System.Drawing.Point(0, 0);
            this.BlueTopBar.Name = "BlueTopBar";
            this.BlueTopBar.Size = new System.Drawing.Size(1578, 75);
            this.BlueTopBar.TabIndex = 1;
            // 
            // FetchaAlbumsBtn
            // 
            this.FetchaAlbumsBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.FetchaAlbumsBtn.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FetchaAlbumsBtn.ForeColor = System.Drawing.Color.White;
            this.FetchaAlbumsBtn.Location = new System.Drawing.Point(22, 204);
            this.FetchaAlbumsBtn.Name = "FetchaAlbumsBtn";
            this.FetchaAlbumsBtn.Size = new System.Drawing.Size(238, 45);
            this.FetchaAlbumsBtn.TabIndex = 7;
            this.FetchaAlbumsBtn.Text = "Albums";
            this.FetchaAlbumsBtn.UseVisualStyleBackColor = false;
            this.FetchaAlbumsBtn.Click += new System.EventHandler(this.FetchaAlbumsBtn_Click);
            // 
            // FetchPostsBtn
            // 
            this.FetchPostsBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.FetchPostsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FetchPostsBtn.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FetchPostsBtn.ForeColor = System.Drawing.Color.White;
            this.FetchPostsBtn.Location = new System.Drawing.Point(22, 150);
            this.FetchPostsBtn.Name = "FetchPostsBtn";
            this.FetchPostsBtn.Size = new System.Drawing.Size(238, 47);
            this.FetchPostsBtn.TabIndex = 8;
            this.FetchPostsBtn.Text = "Posts";
            this.FetchPostsBtn.UseVisualStyleBackColor = false;
            this.FetchPostsBtn.Click += new System.EventHandler(this.FetchPostsBtn_Click);
            // 
            // FetchEventsBtn
            // 
            this.FetchEventsBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.FetchEventsBtn.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FetchEventsBtn.ForeColor = System.Drawing.Color.White;
            this.FetchEventsBtn.Location = new System.Drawing.Point(22, 255);
            this.FetchEventsBtn.Name = "FetchEventsBtn";
            this.FetchEventsBtn.Size = new System.Drawing.Size(238, 47);
            this.FetchEventsBtn.TabIndex = 10;
            this.FetchEventsBtn.Text = "Events";
            this.FetchEventsBtn.UseVisualStyleBackColor = false;
            this.FetchEventsBtn.Click += new System.EventHandler(this.FetchEventsBtn_Click);
            // 
            // GamesBtn
            // 
            this.GamesBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.GamesBtn.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GamesBtn.ForeColor = System.Drawing.Color.White;
            this.GamesBtn.Location = new System.Drawing.Point(22, 308);
            this.GamesBtn.Name = "GamesBtn";
            this.GamesBtn.Size = new System.Drawing.Size(238, 47);
            this.GamesBtn.TabIndex = 14;
            this.GamesBtn.Text = "Games";
            this.GamesBtn.UseVisualStyleBackColor = false;
            this.GamesBtn.Click += new System.EventHandler(this.GamesBtn_Click);
            // 
            // HomeBtn
            // 
            this.HomeBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.HomeBtn.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeBtn.ForeColor = System.Drawing.Color.White;
            this.HomeBtn.Location = new System.Drawing.Point(22, 96);
            this.HomeBtn.Name = "HomeBtn";
            this.HomeBtn.Size = new System.Drawing.Size(238, 47);
            this.HomeBtn.TabIndex = 15;
            this.HomeBtn.Text = "Home";
            this.HomeBtn.UseVisualStyleBackColor = false;
            this.HomeBtn.Click += new System.EventHandler(this.HomeBtn_Click);
            // 
            // NewPost
            // 
            this.NewPost.Font = new System.Drawing.Font("Berlin Sans FB", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewPost.Location = new System.Drawing.Point(276, 101);
            this.NewPost.Name = "NewPost";
            this.NewPost.Size = new System.Drawing.Size(693, 111);
            this.NewPost.TabIndex = 18;
            this.NewPost.Text = "What\'s on your mind?";
            // 
            // FeedGroupBox
            // 
            this.FeedGroupBox.AutoSize = true;
            this.FeedGroupBox.BackColor = System.Drawing.Color.White;
            this.FeedGroupBox.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FeedGroupBox.Location = new System.Drawing.Point(276, 256);
            this.FeedGroupBox.Name = "FeedGroupBox";
            this.FeedGroupBox.Size = new System.Drawing.Size(693, 762);
            this.FeedGroupBox.TabIndex = 20;
            this.FeedGroupBox.TabStop = false;
            // 
            // posted
            // 
            this.posted.BackColor = System.Drawing.Color.RoyalBlue;
            this.posted.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.posted.Font = new System.Drawing.Font("Britannic Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posted.ForeColor = System.Drawing.Color.White;
            this.posted.Location = new System.Drawing.Point(878, 215);
            this.posted.Name = "posted";
            this.posted.Size = new System.Drawing.Size(91, 35);
            this.posted.TabIndex = 19;
            this.posted.Text = "Post";
            this.posted.UseVisualStyleBackColor = false;
            this.posted.Visible = false;
            // 
            // PanelDropDown
            // 
            this.PanelDropDown.BackColor = System.Drawing.Color.Transparent;
            this.PanelDropDown.Controls.Add(this.LogOut);
            this.PanelDropDown.Controls.Add(this.Account);
            this.PanelDropDown.Controls.Add(this.DropDownBar);
            this.PanelDropDown.Location = new System.Drawing.Point(1143, 67);
            this.PanelDropDown.Margin = new System.Windows.Forms.Padding(0);
            this.PanelDropDown.MaximumSize = new System.Drawing.Size(139, 83);
            this.PanelDropDown.MinimumSize = new System.Drawing.Size(139, 0);
            this.PanelDropDown.Name = "PanelDropDown";
            this.PanelDropDown.Size = new System.Drawing.Size(139, 0);
            this.PanelDropDown.TabIndex = 22;
            // 
            // LogOut
            // 
            this.LogOut.BackColor = System.Drawing.Color.RoyalBlue;
            this.LogOut.Location = new System.Drawing.Point(0, 40);
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(139, 44);
            this.LogOut.TabIndex = 23;
            this.LogOut.Text = "Log out";
            this.LogOut.UseVisualStyleBackColor = false;
            this.LogOut.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // Account
            // 
            this.Account.BackColor = System.Drawing.Color.RoyalBlue;
            this.Account.Location = new System.Drawing.Point(0, 3);
            this.Account.Name = "Account";
            this.Account.Size = new System.Drawing.Size(139, 44);
            this.Account.TabIndex = 23;
            this.Account.Text = "Account";
            this.Account.UseVisualStyleBackColor = false;
            this.Account.Click += new System.EventHandler(this.FetchAccountInfoBtn_Click);
            // 
            // DropDownBar
            // 
            this.DropDownBar.BackColor = System.Drawing.Color.RoyalBlue;
            this.DropDownBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.DropDownBar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DropDownBar.Location = new System.Drawing.Point(0, 0);
            this.DropDownBar.MaximumSize = new System.Drawing.Size(139, 196);
            this.DropDownBar.Name = "DropDownBar";
            this.DropDownBar.Size = new System.Drawing.Size(139, 84);
            this.DropDownBar.TabIndex = 21;
            this.DropDownBar.UseVisualStyleBackColor = false;
            this.DropDownBar.Click += new System.EventHandler(this.DropDownBar_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 15;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.SearchTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.SearchTextBox.Location = new System.Drawing.Point(84, 12);
            this.SearchTextBox.Multiline = true;
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(634, 47);
            this.SearchTextBox.TabIndex = 24;
            this.SearchTextBox.Text = "Search";
            this.SearchTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SearchTextBox_MouseClick);
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // SearchBtn
            // 
            this.SearchBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SearchBtn.Image = global::A21_Ex01_Omer_206126128_Stav_205816705.Properties.Resources.searchBtn;
            this.SearchBtn.Location = new System.Drawing.Point(665, 13);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(52, 45);
            this.SearchBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SearchBtn.TabIndex = 25;
            this.SearchBtn.TabStop = false;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // DropDownPictureBox
            // 
            this.DropDownPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.DropDownPictureBox.BackgroundImage = global::A21_Ex01_Omer_206126128_Stav_205816705.Properties.Resources.drop_down_arrow1;
            this.DropDownPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DropDownPictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.DropDownPictureBox.ErrorImage = null;
            this.DropDownPictureBox.Location = new System.Drawing.Point(1229, 20);
            this.DropDownPictureBox.Name = "DropDownPictureBox";
            this.DropDownPictureBox.Size = new System.Drawing.Size(34, 32);
            this.DropDownPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DropDownPictureBox.TabIndex = 23;
            this.DropDownPictureBox.TabStop = false;
            this.DropDownPictureBox.Click += new System.EventHandler(this.DropDownBar_Click);
            // 
            // UserNamePictureBox
            // 
            this.UserNamePictureBox.Image = global::A21_Ex01_Omer_206126128_Stav_205816705.Properties.Resources.FacebookDefaultProfilePicture;
            this.UserNamePictureBox.Location = new System.Drawing.Point(1089, 6);
            this.UserNamePictureBox.Name = "UserNamePictureBox";
            this.UserNamePictureBox.Size = new System.Drawing.Size(61, 55);
            this.UserNamePictureBox.TabIndex = 4;
            this.UserNamePictureBox.TabStop = false;
            // 
            // FacebookIcon
            // 
            this.FacebookIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FacebookIcon.Image = global::A21_Ex01_Omer_206126128_Stav_205816705.Properties.Resources.facebook_logo_png_38362;
            this.FacebookIcon.Location = new System.Drawing.Point(22, 12);
            this.FacebookIcon.Name = "FacebookIcon";
            this.FacebookIcon.Size = new System.Drawing.Size(43, 43);
            this.FacebookIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FacebookIcon.TabIndex = 3;
            this.FacebookIcon.TabStop = false;
            // 
            // MainFeedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1578, 1030);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.DropDownPictureBox);
            this.Controls.Add(this.UserNamePictureBox);
            this.Controls.Add(this.FeedGroupBox);
            this.Controls.Add(this.posted);
            this.Controls.Add(this.NewPost);
            this.Controls.Add(this.HomeBtn);
            this.Controls.Add(this.GamesBtn);
            this.Controls.Add(this.FetchEventsBtn);
            this.Controls.Add(this.FetchPostsBtn);
            this.Controls.Add(this.FetchaAlbumsBtn);
            this.Controls.Add(this.FacebookIcon);
            this.Controls.Add(this.WelcomeUserNameLable);
            this.Controls.Add(this.PanelDropDown);
            this.Controls.Add(this.BlueTopBar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ForeColor = System.Drawing.Color.Black;
            this.MinimumSize = new System.Drawing.Size(1600, 1018);
            this.Name = "MainFeedForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "newPost";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SizeChanged += new System.EventHandler(this.MainFeed_SizeChanged);
            this.PanelDropDown.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SearchBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DropDownPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserNamePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacebookIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WelcomeUserNameLable;
        private System.Windows.Forms.Label BlueTopBar;
        private System.Windows.Forms.Button FetchaAlbumsBtn;
        private System.Windows.Forms.Button FetchPostsBtn;
        private System.Windows.Forms.Button FetchEventsBtn;
        private System.Windows.Forms.Button GamesBtn;
        private System.Windows.Forms.Button HomeBtn;
        private System.Windows.Forms.Button posted;
        private System.Windows.Forms.PictureBox UserNamePictureBox;
        private System.Windows.Forms.Button DropDownBar;
        private System.Windows.Forms.Panel PanelDropDown;
        private System.Windows.Forms.Button Account;
        private System.Windows.Forms.Button LogOut;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox FacebookIcon;
        private System.Windows.Forms.PictureBox DropDownPictureBox;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.PictureBox SearchBtn;
        public System.Windows.Forms.RichTextBox NewPost;
        public System.Windows.Forms.GroupBox FeedGroupBox;
    }
}