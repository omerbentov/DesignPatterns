using FacebookWrapper.ObjectModel;
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
        }

        private void FetchaAlbumsBtn_Click(object sender, EventArgs e)
        {
            FeedGroupBox.Visible = true;
            FeedGroupBox.Controls.Clear();

            FacebookObjectCollection<Album> albums = Global.User.Albums;
            Point picLocation = new Point(20, 50);
            foreach (Album album in albums)
            {
                PictureBox albumPicture = new PictureBox();
                albumPicture.Size = new System.Drawing.Size(150, 150);
                albumPicture.Location = picLocation;
                albumPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                albumPicture.LoadAsync(album.PictureAlbumURL);
                FeedGroupBox.Controls.Add(albumPicture);

                Label albumName = new Label();
                albumName.Text = album.Name + "(" + album.Count + " Likes)";
                albumName.ForeColor = Color.Black;
                albumName.Location = new Point(picLocation.X, picLocation.Y - albumName.Size.Height);
                FeedGroupBox.Controls.Add(albumName);

                picLocation = calculateNextAlbumCUverPhotoPosition(picLocation);
            }
        }

        private Point calculateNextAlbumCUverPhotoPosition(Point i_prevPoint)
        {
            int x = i_prevPoint.X;
            int y = i_prevPoint.Y;

            x = (x + 200) % 400;
            if (x <= 50)
            {
                y += 220;
            }

            return new Point(x, y);
        }

        private void FetchPostsBtn_Click(object sender, EventArgs e)
        {
            FeedGroupBox.Controls.Clear();

            Point labelLocation = new Point(20, 10);
            int Y_Offset;
            foreach (Post post in Global.User.Posts)
            {
                Label postFromName = new Label();
                postFromName.Text = post.From.Name;
                postFromName.Location = labelLocation;
                FeedGroupBox.Controls.Add(postFromName);

                if (!postFromName.Text.Equals(Global.User.Name))
                {
                    Label ToMyUser = new Label();
                    ToMyUser.Text = "->" + Global.User.Name;
                    ToMyUser.Location = new Point(labelLocation.X + postFromName.Width, labelLocation.Y);
                    FeedGroupBox.Controls.Add(ToMyUser);
                }

                Y_Offset = 1;
                if (post.Name != null)
                {
                    Label postName = new Label();
                    postName.Text = post.Name;
                    postName.Location = new Point(labelLocation.X, labelLocation.Y + Y_Offset * postFromName.Height);
                    Y_Offset++;
                    FeedGroupBox.Controls.Add(postName);
                }

                if (post.Message != null)
                {
                    Label postMessage = new Label();
                    postMessage.Text = post.Message;
                    postMessage.Location = new Point(labelLocation.X, labelLocation.Y + Y_Offset * postFromName.Height);
                    FeedGroupBox.Controls.Add(postMessage);
                }

                labelLocation = calculateNextPostPosition(labelLocation);
            }
        }

        private Point calculateNextPostPosition(Point i_prevPoint)
        {
            return new Point(i_prevPoint.X, i_prevPoint.Y + 80);
        }

        private void FetchAccountInfoBtn_Click(object sender, EventArgs e)
        {
            /*
            FeedBox.Items.Clear();
            FeedBox.Items.Add("Name : " + Global.User.Name);
            FeedBox.Items.Add("Email : " + Global.User.Email);
            FeedBox.Items.Add("Birthday : " + Global.User.Birthday);
            FeedBox.Items.Add("Gender : " + Global.User.Gender);
            FeedBox.Items.Add("Home Town:" + Global.User.Hometown);
            */
        }

        private void FetchEventsBtn_Click(object sender, EventArgs e)
        {
            /*
            FeedBox.Items.Clear();
            foreach (Event event_ in Global.User.Events)
            {
                FeedBox.Items.Add(event_.Name);
                FeedBox.Items.Add(event_.StartTime);
                FeedBox.Items.Add("");
            }
            */
        }

        private void CreatNewPost(object sender, EventArgs e)
        {
            
        }

    }
}
