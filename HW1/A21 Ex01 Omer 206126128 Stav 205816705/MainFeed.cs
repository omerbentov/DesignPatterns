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
            FeedBox.Items.Add("Please click on a button");
        }

<<<<<<< HEAD
        private void FetchaAlbumsBtn_Click(object sender, EventArgs e)
        {
            FeedBox.Items.Clear();
            FacebookObjectCollection<Album> albums = Global.User.Albums;
            foreach (Album album in albums)
            {
                FeedBox.Items.Add(album.Name + "(" + album.Count + " Likes)");
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
=======
            int i = 0;
            /*/   foreach(Post post in Global.User.Posts)
               {

                   PictureBox fromUserpicture = new PictureBox();
                   fromUserpicture.Image = post.From.ImageSmall;

                   Label fromUserName = new Label();
                   fromUserName.Text = post.From.Name;

                   Label ToUserName = new Label();
                   fromUserName.Text = Global.User.Name;

                   Label comment = new Label();
                   comment.Text = post.Message;

                   DateTime createdTime = (DateTime)post.CreatedTime;

                   FeedBox.Items.Add(post.From.Name);

                   i++;
                   if(i > 1)
                   {
                       break;
                   }
               }/*/
>>>>>>> 00c62f557e4d9c71b6ce8de8947301986de16b0f
        }
    }
}
