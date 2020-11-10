namespace A21_Ex01_Omer_206126128_Stav_205816705
{
    partial class MainFeed
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
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.UserNamePictureBox = new System.Windows.Forms.PictureBox();
            this.FeedBox = new System.Windows.Forms.ListBox();
            this.FetchaAlbumsBtn = new System.Windows.Forms.Button();
            this.FetchPostsBtn = new System.Windows.Forms.Button();
            this.FetchAccountInfoBtn = new System.Windows.Forms.Button();
            this.FetchEventsBtn = new System.Windows.Forms.Button();
            this.Extra1 = new System.Windows.Forms.Button();
            this.Extra2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserNamePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // WelcomeUserNameLable
            // 
            this.WelcomeUserNameLable.AutoSize = true;
            this.WelcomeUserNameLable.BackColor = System.Drawing.Color.RoyalBlue;
            this.WelcomeUserNameLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.WelcomeUserNameLable.ForeColor = System.Drawing.Color.White;
            this.WelcomeUserNameLable.Location = new System.Drawing.Point(416, 9);
            this.WelcomeUserNameLable.Name = "WelcomeUserNameLable";
            this.WelcomeUserNameLable.Size = new System.Drawing.Size(455, 55);
            this.WelcomeUserNameLable.TabIndex = 0;
            this.WelcomeUserNameLable.Text = "Welcome Full Name";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.RoyalBlue;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1312, 78);
            this.label1.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::A21_Ex01_Omer_206126128_Stav_205816705.Properties.Resources.FacebookIcom;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(12, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 55);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // UserNamePictureBox
            // 
            this.UserNamePictureBox.Location = new System.Drawing.Point(1198, 9);
            this.UserNamePictureBox.Name = "UserNamePictureBox";
            this.UserNamePictureBox.Size = new System.Drawing.Size(61, 55);
            this.UserNamePictureBox.TabIndex = 4;
            this.UserNamePictureBox.TabStop = false;
            // 
            // FeedBox
            // 
            this.FeedBox.FormattingEnabled = true;
            this.FeedBox.ItemHeight = 20;
            this.FeedBox.Location = new System.Drawing.Point(344, 81);
            this.FeedBox.Name = "FeedBox";
            this.FeedBox.Size = new System.Drawing.Size(582, 624);
            this.FeedBox.TabIndex = 6;
            // 
            // FetchaAlbumsBtn
            // 
            this.FetchaAlbumsBtn.Location = new System.Drawing.Point(43, 96);
            this.FetchaAlbumsBtn.Name = "FetchaAlbumsBtn";
            this.FetchaAlbumsBtn.Size = new System.Drawing.Size(238, 45);
            this.FetchaAlbumsBtn.TabIndex = 7;
            this.FetchaAlbumsBtn.Text = "Albums";
            this.FetchaAlbumsBtn.UseVisualStyleBackColor = true;
            this.FetchaAlbumsBtn.Click += new System.EventHandler(this.FetchaAlbumsBtn_Click);
            // 
            // FetchPostsBtn
            // 
            this.FetchPostsBtn.Location = new System.Drawing.Point(43, 159);
            this.FetchPostsBtn.Name = "FetchPostsBtn";
            this.FetchPostsBtn.Size = new System.Drawing.Size(238, 47);
            this.FetchPostsBtn.TabIndex = 8;
            this.FetchPostsBtn.Text = "Posts";
            this.FetchPostsBtn.UseVisualStyleBackColor = true;
            this.FetchPostsBtn.Click += new System.EventHandler(this.FetchPostsBtn_Click);
            // 
            // FetchAccountInfoBtn
            // 
            this.FetchAccountInfoBtn.Location = new System.Drawing.Point(43, 230);
            this.FetchAccountInfoBtn.Name = "FetchAccountInfoBtn";
            this.FetchAccountInfoBtn.Size = new System.Drawing.Size(238, 47);
            this.FetchAccountInfoBtn.TabIndex = 9;
            this.FetchAccountInfoBtn.Text = "Account";
            this.FetchAccountInfoBtn.UseVisualStyleBackColor = true;
            this.FetchAccountInfoBtn.Click += new System.EventHandler(this.FetchAccountInfoBtn_Click);
            // 
            // FetchEventsBtn
            // 
            this.FetchEventsBtn.Location = new System.Drawing.Point(43, 298);
            this.FetchEventsBtn.Name = "FetchEventsBtn";
            this.FetchEventsBtn.Size = new System.Drawing.Size(238, 47);
            this.FetchEventsBtn.TabIndex = 10;
            this.FetchEventsBtn.Text = "Events";
            this.FetchEventsBtn.UseVisualStyleBackColor = true;
            this.FetchEventsBtn.Click += new System.EventHandler(this.FetchEventsBtn_Click);
            // 
            // Extra1
            // 
            this.Extra1.Location = new System.Drawing.Point(43, 369);
            this.Extra1.Name = "Extra1";
            this.Extra1.Size = new System.Drawing.Size(238, 47);
            this.Extra1.TabIndex = 11;
            this.Extra1.Text = "Extra";
            this.Extra1.UseVisualStyleBackColor = true;
            // 
            // Extra2
            // 
            this.Extra2.Location = new System.Drawing.Point(43, 437);
            this.Extra2.Name = "Extra2";
            this.Extra2.Size = new System.Drawing.Size(238, 47);
            this.Extra2.TabIndex = 12;
            this.Extra2.Text = "Extra";
            this.Extra2.UseVisualStyleBackColor = true;
            // 
            // MainFeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1303, 692);
            this.Controls.Add(this.Extra2);
            this.Controls.Add(this.Extra1);
            this.Controls.Add(this.FetchEventsBtn);
            this.Controls.Add(this.FetchAccountInfoBtn);
            this.Controls.Add(this.FetchPostsBtn);
            this.Controls.Add(this.FetchaAlbumsBtn);
            this.Controls.Add(this.FeedBox);
            this.Controls.Add(this.UserNamePictureBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.WelcomeUserNameLable);
            this.Controls.Add(this.label1);
            this.Name = "MainFeed";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserNamePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WelcomeUserNameLable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox UserNamePictureBox;
        private System.Windows.Forms.ListBox FeedBox;
        private System.Windows.Forms.Button FetchaAlbumsBtn;
        private System.Windows.Forms.Button FetchPostsBtn;
        private System.Windows.Forms.Button FetchAccountInfoBtn;
        private System.Windows.Forms.Button FetchEventsBtn;
        private System.Windows.Forms.Button Extra1;
        private System.Windows.Forms.Button Extra2;
    }
}