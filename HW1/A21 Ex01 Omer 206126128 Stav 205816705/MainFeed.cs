﻿using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A21_Ex01_Omer_206126128_Stav_205816705
{
    public partial class MainFeed : Form
    {
        public MainFeed()
        {
            InitializeComponent();
            InitializeChildrenComponents();
        }

        private void InitializeChildrenComponents()
        {
            WelcomeUserNameLable.Text = "Welcome " + Global.User.Name;
            UserNamePictureBox.Image = Global.User.ImageSmall;
            FeedBox.Items.Add("Please click on a button");
        }

        private void FetchaAlbumsBtn_Click(object sender, EventArgs e)
        {
            FeedBox.Items.Clear();
            FacebookObjectCollection<Album> albums = Global.User.Albums;
            int i = 0; 
            foreach (Album album in albums)
            {
                PictureBox albumPicture = new PictureBox();
                albumPicture.Location = new System.Drawing.Point(250,30+i);
                albumPicture.Size = new System.Drawing.Size(75, 75);
                albumPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                albumPicture.LoadAsync(album.PictureAlbumURL);
                FeedBox.Items.Add(album.Name + "(" + album.Count + " Likes)");
                FeedBox.Controls.Add(albumPicture);
                FeedBox.Items.Add("------------------------------------------------------");
                FeedBox.Items.Add("");
                FeedBox.Items.Add("");
                FeedBox.Items.Add("");
                i += 100;
            }
        }

        private void FetchPostsBtn_Click(object sender, EventArgs e)
        {
            FeedBox.Items.Clear();
            foreach (Post post in Global.User.Posts)
            {
                FeedBox.Items.Add(post.From.Name);
                if (post.Name != null)
                {
                    FeedBox.Items.Add(post.Name);
                }
                FeedBox.Items.Add(post.CreatedTime);
                FeedBox.Items.Add("");
            }
        }

        private void FetchAccountInfoBtn_Click(object sender, EventArgs e)
        {
            FeedBox.Items.Clear();
            FeedBox.Items.Add("Name : " + Global.User.Name);
            FeedBox.Items.Add("Email : " + Global.User.Email);
            FeedBox.Items.Add("Birthday : " + Global.User.Birthday);
            FeedBox.Items.Add("Gender : " + Global.User.Gender);
            FeedBox.Items.Add("Home Town:" + Global.User.Hometown);
        }

        private void FetchEventsBtn_Click(object sender, EventArgs e)
        {
            FeedBox.Items.Clear();
            foreach (Event event_ in Global.User.Events)
            {
                FeedBox.Items.Add(event_.Name);
                FeedBox.Items.Add(event_.StartTime);
                FeedBox.Items.Add("");
            }
        }
    }
}
