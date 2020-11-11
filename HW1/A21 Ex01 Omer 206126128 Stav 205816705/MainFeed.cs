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
        private const int k_PostsMargin = 20;
        private const int k_PostWidth = 500;
        private const string k_DefaultFacebookPictureUrl = "./Assets/FacebookDefauleProfilePicture.PNG";
        private const int k_PostProfilePictureSize = 55;

        private bool m_IsCollapsed = false;

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
                albumName.Text = album.Name;
                albumName.ForeColor = Color.Black;
                albumName.Location = new Point(picLocation.X, picLocation.Y - albumName.Size.Height);
                FeedGroupBox.Controls.Add(albumName);

                Point countLabelPoint = new Point(picLocation.X, picLocation.Y + albumPicture.Height);
                Label albumCount = createNewDefaultLabel(album.Count + " Photos", countLabelPoint);
                FeedGroupBox.Controls.Add(albumCount);

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
            FeedGroupBox.Visible = true;
            FeedGroupBox.BackColor = Color.Transparent;
            FeedGroupBox.Width = NewPost.Width;

            Point groupBoxLocation = new Point();
            Point baseLocation = new Point(20, 10);

            foreach (Post post in Global.User.Posts)
            {
                int Y_Offset = 1;

                GroupBox singlePostGroupBox = createPostGroupPost(groupBoxLocation);

                PictureBox defaultPic = createDefaultFacebookProfilePicture(singlePostGroupBox);

                PictureBox myPic = new PictureBox();
                myPic.Image = Global.User.ImageSmall;
                myPic.MaximumSize = new Size(new Point(k_PostProfilePictureSize, k_PostProfilePictureSize));

                if (post.From.Name != null)
                {
                    Point labelLocation = baseLocation;
                    labelLocation.X += defaultPic.Width;
                    Label postFromName = createNewDefaultLabel(post.From.Name, labelLocation);
                    singlePostGroupBox.Controls.Add(postFromName);

                    if (!postFromName.Text.Equals(Global.User.Name))
                    {
                        Point location = new Point(postFromName.Location.X + postFromName.Width, postFromName.Location.Y);
                        Label ToMyUser = createNewDefaultLabel("->" + Global.User.Name, location);
                        singlePostGroupBox.Controls.Add(ToMyUser);
                        singlePostGroupBox.Controls.Add(defaultPic);
                    }
                    else
                    {
                        singlePostGroupBox.Controls.Add(myPic);
                    }

                    if (post.Name != null)
                    {
                        Point location = new Point(postFromName.Location.X, baseLocation.Y + Y_Offset * postFromName.Height);
                        Label postName = createNewDefaultLabel(post.Name, location);
                        Y_Offset++;
                        singlePostGroupBox.Controls.Add(postName);
                    }

                    if (post.CreatedTime != null)
                    {
                        Point location = new Point(postFromName.Location.X, baseLocation.Y + Y_Offset * postFromName.Height);
                        Label postDate = createNewDefaultLabel(post.CreatedTime.ToString(), location);
                        singlePostGroupBox.Controls.Add(postDate);
                    }

                    if (post.Message != null)
                    {
                        Point location = new Point(defaultPic.Location.X, defaultPic.Location.Y + defaultPic.Height);
                        Label postMessage = createNewDefaultLabel(post.Message, location);
                        Y_Offset++;
                        singlePostGroupBox.Controls.Add(postMessage);
                    }

                    FeedGroupBox.Controls.Add(singlePostGroupBox);
                    groupBoxLocation = calculateNextPostPosition(groupBoxLocation, singlePostGroupBox.Height);
                }
            }
        }

        private GroupBox createPostGroupPost(Point i_GroupBoxLoaction)
        {
            GroupBox singlePostGroupBox = new GroupBox();
            singlePostGroupBox.AutoSize = true;
            singlePostGroupBox.BackColor = Color.White;
            singlePostGroupBox.MaximumSize = new Size(FeedGroupBox.Width, int.MaxValue);
            singlePostGroupBox.Width = NewPost.Width;
            singlePostGroupBox.Location = i_GroupBoxLoaction;
            singlePostGroupBox.Visible = true;

            return singlePostGroupBox;
        }

        private PictureBox createDefaultFacebookProfilePicture(GroupBox i_SinglePostGroupBox)
        {
            PictureBox defaultPic = new PictureBox();
            defaultPic.LoadAsync(k_DefaultFacebookPictureUrl);
            defaultPic.MaximumSize = new Size(new Point(k_PostProfilePictureSize, k_PostProfilePictureSize));

            return defaultPic;
        }

        private Point calculateNextPostPosition(Point i_prevPoint, int i_PrevGroupBoxHeight)
        {
            return new Point(i_prevPoint.X, i_prevPoint.Y + i_PrevGroupBoxHeight + k_PostsMargin);
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

        private Label createNewDefaultLabel(string i_text, Point i_Location)
        {
            Label tempLabel = new Label();
            tempLabel.AutoSize = true;
            tempLabel.MaximumSize = new Size(FeedGroupBox.Width, int.MaxValue);
            tempLabel.Text = i_text;
            tempLabel.Location = i_Location;

            return tempLabel;
        }

        private void MainFeed_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (m_IsCollapsed)
            {
                PanelDropDown.Height += 10;
                if (PanelDropDown.Size == PanelDropDown.MaximumSize)
                {
                    timer1.Stop();
                    m_IsCollapsed = false;
                }
            }
            else
            {
                PanelDropDown.Height -= 10;
                if (PanelDropDown.Size == PanelDropDown.MinimumSize)
                {
                    timer1.Stop();
                    m_IsCollapsed = true;
                }
            }
        }

        private void DropDownBar_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
