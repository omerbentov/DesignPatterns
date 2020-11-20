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
    public partial class MainFeedForm : Form
    {
        // Style
        private const int k_PostsMargin = 20;
        private const int k_PostProfilePictureSize = 55;
        private const int k_NumOfPostsInHomePage = 3;
        private const int k_NumOfAlbumsInHomePage = 6;
        private const int k_LabelMargin = 50;
        private const float k_SearchTextBoxRatio = 0.5f;

        private static int s_PostWidth;
        private static string s_TextToFind;

        private bool m_IsCollapsed = false;
        private Label m_GameHeader;


        // Prop
        public static Point PostProfilePicturePointSize
        {
            get
            {
                return new Point(k_PostProfilePictureSize, k_PostProfilePictureSize);
            }
        }

        public bool NewPostVisabilty
        {
           set
           {
                NewPost.Visible = value;
           }
        }

        public static int LabelMargin
        {
            get
            {
                return k_LabelMargin;
            }
        }

        public static int DefaultCenterWidth
        {
            get
            {
                return s_PostWidth;
            }
        }

        // Main
        public MainFeedForm()
        {
            InitializeComponent();
            initializeChildrenComponents();

            HomeBtn_Click(new object(), new EventArgs());
        }

        private void initializeChildrenComponents()
        {
            WelcomeUserNameLable.Text = GlobalData.User.FirstName;
            UserNamePictureBox.Image = GlobalData.User.ImageSmall;
        }

        // Home 
        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Transition();

            MainOps.ResetFeedGroupBox(FeedGroupBox, DefaultCenterWidth);

            Point groupBoxLocation = new Point();
            Point baseLocation = new Point(20, 10);

            Point nextPosition = PostsOps.addPosts(groupBoxLocation, baseLocation, k_NumOfPostsInHomePage, FeedGroupBox);
            nextPosition.Y += k_PostsMargin;
            AlbumsOps.addAlbums(nextPosition, k_NumOfAlbumsInHomePage, FeedGroupBox, GlobalData.User.Albums);
        }

        // Albums
        private void FetchaAlbumsBtn_Click(object sender, EventArgs e)
        {
            Transition();
            FeedGroupBox.BackColor = Color.White;

            Point picLocation = new Point(20, 80);
            AlbumsOps.addAlbums(null, int.MaxValue, FeedGroupBox, GlobalData.User.Albums);
        }

        // Posts
        private void FetchPostsBtn_Click(object sender, EventArgs e)
        {
            Transition();

            Point groupBoxLocation = new Point();
            Point baseLocation = new Point(20, 10);

            PostsOps.addPosts(groupBoxLocation, baseLocation, int.MaxValue, FeedGroupBox);
        }

        // Account 
        private void FetchAccountInfoBtn_Click(object sender, EventArgs e)
        {
            Transition();

            FeedGroupBox.Visible = true;
            FeedGroupBox.BackColor = Color.White;

            AccountOps.AddAcountInfo(FeedGroupBox);

        }

        //Events 
        private void FetchEventsBtn_Click(object sender, EventArgs e)
        {
            Transition();

            FeedGroupBox.Visible = true;
            FeedGroupBox.BackColor = Color.White;

            EventsOps.AddEvents(FeedGroupBox);

        }

        // LogOut
        private void LogOut_Click(object sender, EventArgs e)
        {
            Transition();

            GlobalData.User = null;

            this.Hide();
            LogInForm logInForm = new LogInForm();
            logInForm.Show();
        }

        private void DropDownBar_Click(object sender, EventArgs e)
        {
            timer1.Start();
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

        // Games
        public void GamesBtn_Click(object sender, EventArgs e)
        {
            Transition();
            NewPost.Show();
            FeedGroupBox.Show();
            FeedGroupBox.BackColor = Color.Transparent;
       
            m_GameHeader = GamesOps.CreateGameHeader("Games", FeedGroupBox);

            // Guessing game
            Button guessingGameBtn = new Button();
            guessingGameBtn.Click += BirthdaysGameBtn_Click;
            guessingGameBtn.Size = new Size(150, 100);
            guessingGameBtn.BackgroundImage = Properties.Resources.GuessingGamePicture;
            guessingGameBtn.BackgroundImageLayout = ImageLayout.Stretch;
            guessingGameBtn.Location = new Point(
                m_GameHeader.Location.X + (m_GameHeader.Width / 2) - (int)(1.5f * guessingGameBtn.Width),
                m_GameHeader.Location.Y + m_GameHeader.Height + k_PostsMargin);
            FeedGroupBox.Controls.Add(guessingGameBtn);

            Button comingSoonGameBtn = new Button();
            comingSoonGameBtn.Size = new Size(150, 100);
            comingSoonGameBtn.BackgroundImage = Properties.Resources.commingSoonGame;
            comingSoonGameBtn.BackgroundImageLayout = ImageLayout.Stretch;
            comingSoonGameBtn.Location = new Point(m_GameHeader.Location.X + (m_GameHeader.Width / 2) + (comingSoonGameBtn.Width / 2), m_GameHeader.Location.Y + m_GameHeader.Height + k_PostsMargin);
            FeedGroupBox.Controls.Add(comingSoonGameBtn);
        }

        private void BirthdaysGameBtn_Click(object sender, EventArgs e)
        {
            Transition();
            FeedGroupBox.Controls.Clear();
            GamesOps.CreateGameHeader("Guessing Game",FeedGroupBox);

            // In this case we need to ranomize a friend and get his birthday - but permission denied
            /* newQuestion(
                            sender,
                            "How old is <RandomUserFriend().FullName>?",
                            new Point(NewPost.Location.X, NewPost.Location.X + k_PostsMargin),
                            this);
            */
            GamesOps.NewAgeQuestion(
                sender,
                "How old is Guy Ronen?",
                m_GameHeader.Location.Y + m_GameHeader.Height,
                FeedGroupBox,
                this);
        }

        // serach
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            Transition();

            if (!string.IsNullOrEmpty(s_TextToFind))
            {
                Transition();
                SearchOps.SetEventsSearch(s_TextToFind, FeedGroupBox);
                SearchOps.SetFriendPosts(s_TextToFind, FeedGroupBox);
                SearchOps.SetGroupsSearch(s_TextToFind, FeedGroupBox);
                SearchOps.SetPageSearchs(s_TextToFind, FeedGroupBox);
            }
            else
            {
                MessageBox.Show("Please enter phrase to search", "Missing Input");
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            s_TextToFind = SearchTextBox.Text;
        }

        //General
        public void Transition()
        {
            NewPost.Visible = true;
            MainOps.ResetFeedGroupBox(FeedGroupBox, DefaultCenterWidth);
        }

        private void setControlsLocations()
        {
            DropDownPictureBox.Location = new Point(this.Size.Width - DropDownPictureBox.Width - k_LabelMargin, DropDownPictureBox.Location.Y);
            WelcomeUserNameLable.Location = new Point(DropDownPictureBox.Location.X - WelcomeUserNameLable.Width, WelcomeUserNameLable.Location.Y);
            UserNamePictureBox.Location = new Point(WelcomeUserNameLable.Location.X - UserNamePictureBox.Width, UserNamePictureBox.Location.Y);
            PanelDropDown.Location = new Point(UserNamePictureBox.Location.X, BlueTopBar.Height);

            SearchTextBox.Location = new Point((this.Size.Width / 2) - (SearchTextBox.Width / 2), SearchTextBox.Location.Y);
            SearchBtn.Location = new Point(SearchTextBox.Location.X + SearchTextBox.Width - SearchBtn.Width, SearchTextBox.Location.Y);

            NewPost.Location = new Point((this.Size.Width / 2) - (NewPost.Width / 2), NewPost.Location.Y);
            posted.Location = new Point(NewPost.Location.X - posted.Width, NewPost.Location.Y + NewPost.Height);

            FeedGroupBox.Location = new Point(NewPost.Location.X, posted.Location.Y + posted.Height + k_PostsMargin);

            HomeBtn.Location = new Point(((NewPost.Location.X - (k_PostsMargin + HomeBtn.Width)) / 2), NewPost.Location.Y);
            FetchPostsBtn.Location = new Point(((NewPost.Location.X - (k_PostsMargin + FetchPostsBtn.Width)) / 2), HomeBtn.Location.Y + HomeBtn.Height + 5);
            FetchaAlbumsBtn.Location = new Point(((NewPost.Location.X - (k_PostsMargin + FetchaAlbumsBtn.Width)) / 2), FetchPostsBtn.Location.Y + FetchPostsBtn.Height + 5);
            FetchEventsBtn.Location = new Point(((NewPost.Location.X - (k_PostsMargin + FetchEventsBtn.Width)) / 2), FetchaAlbumsBtn.Location.Y + FetchaAlbumsBtn.Height + 5);
            GamesBtn.Location = new Point(((NewPost.Location.X - (k_PostsMargin + GamesBtn.Width)) / 2), FetchEventsBtn.Location.Y + FetchEventsBtn.Height + 5);
        }

        private void setControlsSizes()
        {
            BlueTopBar.Height = (int)(FacebookIcon.Height * 1.5);
            SearchTextBox.Width = DefaultCenterWidth;
            NewPost.Width = DefaultCenterWidth;
            FeedGroupBox.Width = DefaultCenterWidth;
            PanelDropDown.MinimumSize = new Size(new Point(150, 0));
            PanelDropDown.MaximumSize = new Size(new Point(150, 150));

            foreach (Control control in Controls)
            {
                if (control.Tag != null)
                {
                    if (control.Tag.Equals("Center"))
                    {
                        control.Width = DefaultCenterWidth;
                    }
                }
            }
        }

        private void MainFeed_SizeChanged(object sender, EventArgs e)
        {
            s_PostWidth = (int)(Width * k_SearchTextBoxRatio);
            setControlsSizes();
            setControlsLocations();
        }
    }
}
