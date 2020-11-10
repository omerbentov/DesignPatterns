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
            // MainFeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1303, 692);
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
    }
}