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

            int i = 0;
            foreach(Post post in Global.User.Posts)
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
            }
        }
    }
}
