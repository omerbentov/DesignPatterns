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
        private const int k_PostProfilePictureSize = 55;

        private bool m_IsCollapsed = false;

        public MainFeed()
        {
            InitializeComponent();
            InitializeChildrenComponents();
        }

        private void InitializeChildrenComponents()
        {
            WelcomeUserNameLable.Text = Global.User.FirstName;
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
            FeedGroupBox.MaximumSize = new Size(new Point(NewPost.Width, int.MaxValue));

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
            defaultPic.Image = Properties.Resources.FacebookDefaultProfilePicture;
            defaultPic.MaximumSize = new Size(new Point(k_PostProfilePictureSize, k_PostProfilePictureSize));
            defaultPic.SizeMode = PictureBoxSizeMode.Zoom;

            return defaultPic;
        }

        private Point calculateNextPostPosition(Point i_prevPoint, int i_PrevGroupBoxHeight)
        {
            return new Point(i_prevPoint.X, i_prevPoint.Y + i_PrevGroupBoxHeight + k_PostsMargin);
        }

        private Point calculateNextLabelPosition(Point i_prevPoint)
        {
            return new Point(i_prevPoint.X , i_prevPoint.Y + 50);
        }

        private void FetchAccountInfoBtn_Click(object sender, EventArgs e)
        {
            FeedGroupBox.Controls.Clear();
            FeedGroupBox.Visible = true;
            Label top = new Label();
            top.Text = "Information About Your Account" ;
            FeedGroupBox.Controls.Add(top);
            Label line = new Label();
            line.Text = "----------------------------------------------------------";
            line.Width = 500;
            line.Location = new Point(0,30);
            FeedGroupBox.Controls.Add(line);
            Point LabelLocation = new Point(10,10);
            Point baseLocation = new Point(10, 10);
            
            if (Global.User.Name == null)
            {
                CreateAddingButton("Name :", LabelLocation);
            }
            else
            {
                CreateInformationLabel("Name :", Global.User.Name, baseLocation);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + 50);

            if (Global.User.Email == null)
            {
                CreateAddingButton("Email :", LabelLocation);
            }
            else
            {
                CreateInformationLabel("Email :", Global.User.Email, LabelLocation);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + 50);

            if (Global.User.Birthday == null)
            {
                CreateAddingButton("Birthday :", LabelLocation);
            }
            else
            {
                CreateInformationLabel("Birthday :", Global.User.Birthday, LabelLocation);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + 50);

            if (Global.User.Gender == null)
            {
                CreateAddingButton("Gender :", LabelLocation);
            }
            else
            {
                CreateInformationLabel("Gender :", Global.User.Gender.ToString(), LabelLocation);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + 50);

            if (Global.User.Hometown == null)
            {
                CreateAddingButton("Home Town :", LabelLocation);
            }
            else
            {
                CreateInformationLabel("Home Town :", Global.User.Hometown.ToString(), LabelLocation);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + 50);

            if (Global.User.Educations == null)
            {
                CreateAddingButton("Education :", LabelLocation);
            }
            else
            {
                CreateInformationLabel("Education :", Global.User.Educations.ToString(), LabelLocation);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + 50);

            if (Global.User.RelationshipStatus == null)
            {
                CreateAddingButton("RelationshipStatus :", LabelLocation);
            }
            else
            {
                CreateInformationLabel("RelationshipStatus  :", Global.User.RelationshipStatus.ToString(), LabelLocation);
            }

        }

        private void CreateInformationLabel(String i_type, String i_user, Point i_prevPoint)
        {
            Label tempLabel = new Label();
            tempLabel.Text = i_type + i_user;
            tempLabel.Location = calculateNextLabelPosition(i_prevPoint);
            tempLabel.MaximumSize = new Size(new Point((int)(NewPost.Width * 0.4), int.MaxValue));
            FeedGroupBox.Controls.Add(tempLabel);
        }

        private Point calculateNextButtonPosition(Point i_prevPoint, int i_labelWidth)
        {
            return new Point(i_labelWidth + 10 , i_prevPoint.Y + 50);
        }

        private void CreateAddingButton(String i_type, Point i_prevPoint)
        {
            Button addingButton = new Button();
            addingButton.Text = "Add Information";
            addingButton.BackColor = Color.White;
            addingButton.Visible = true;
            addingButton.AutoSize = true;
            Label tempLabel = new Label();
            tempLabel.Text = i_type;
            tempLabel.Width = 200;
            tempLabel.Location = calculateNextLabelPosition(i_prevPoint);
            addingButton.Location = calculateNextButtonPosition(i_prevPoint, tempLabel.Width);
            FeedGroupBox.Controls.Add(tempLabel);
            FeedGroupBox.Controls.Add(addingButton);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!m_IsCollapsed)
            {
                PanelDropDown.Height += 10;
                if (PanelDropDown.Size == PanelDropDown.MaximumSize)
                {
                    timer1.Stop();
                    m_IsCollapsed = true;
                }
            }
            else
            {
                PanelDropDown.Height -= 10;
                if (PanelDropDown.Size == PanelDropDown.MinimumSize)
                {
                    timer1.Stop();
                    m_IsCollapsed = false;
                }
            }
        }

        private void DropDownBar_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            Global.User = null;

            this.Hide();
            LogInForm logInForm = new LogInForm();
            logInForm.Show();
        }
    }
}
