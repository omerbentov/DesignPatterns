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
        private const int k_NumOfPostsInHomePage = 3;
        private const int k_NumOfAlbumsInHomePage = 4;
        private const int k_LabelMargin = 50;

        private static string k_TextToFind;
        private bool m_IsCollapsed = false;

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
                return k_PostWidth;
            }
        }

        // Main
        public MainFeed()
        {
            InitializeComponent();
            InitializeChildrenComponents();

            HomeBtn_Click(new object(), new EventArgs());
        }

        private void InitializeChildrenComponents()
        {
            WelcomeUserNameLable.Text = LoggedInUserData.User.FirstName;
            UserNamePictureBox.Image = LoggedInUserData.User.ImageSmall;
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
            AlbumsOps.addAlbums(nextPosition, k_NumOfAlbumsInHomePage, FeedGroupBox);
        }

        // Albums
        private void FetchaAlbumsBtn_Click(object sender, EventArgs e)
        {
            Transition();

            Point picLocation = new Point(20, 50);
            AlbumsOps.addAlbums(picLocation, int.MaxValue, FeedGroupBox);
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

            LoggedInUserData.User = null;

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
        private void GamesBtn_Click(object sender, EventArgs e)
        {
            Transition();

            NewPost.Hide();
            FeedGroupBox.Hide();

            Label Header = MainOps.CreateNewDefaultLabel("Games", NewPost.Location, DefaultCenterWidth);
            Controls.Add(Header);

            Button guessingGameBtn = new Button();
            guessingGameBtn.Text = "Guessing game";
            guessingGameBtn.Click += BirthdaysGameBtn_Click;
            guessingGameBtn.Location = new Point(NewPost.Location.X, NewPost.Location.Y + k_PostsMargin);
            GamesOps.AllGamesBtn.Add(guessingGameBtn);

            Button g = new Button();
            g.Text = "G";
            g.Click += BirthdaysGameBtn_Click;
            g.Location = new Point(NewPost.Location.X, guessingGameBtn.Location.Y + guessingGameBtn.Height + k_PostsMargin);
            GamesOps.AllGamesBtn.Add(g);

            GamesOps.AddAllButtunsToConstorls(GamesOps.AllGamesBtn, Controls);
        }

        private void BirthdaysGameBtn_Click(object sender, EventArgs e)
        {
            GamesOps.RemoveAllButtunsFromConstorls(GamesOps.AllGamesBtn, Controls);

            Random rnd = new Random();
            int typeOfQuestions = rnd.Next(0, 1);

            switch (typeOfQuestions)
            {
                case 0:
                    // In this case we need to ranomize a friend and get his birthday - but permission denied
                    // newQuestion(sender, "How old is <RandomUserFriend()FullName>?", new Point(NewPost.Location.X, NewPost.Location.X + k_PostsMargin));
                    GamesOps.NewQuestion(sender, "How old is Guy Ronen?", new Point(NewPost.Location.X, NewPost.Location.Y + k_PostsMargin), Controls);
                    break;
            }
        }

        // serach
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            Transition();

            if (!string.IsNullOrEmpty(k_TextToFind))
            {
                Transition();
                SearchOps.SetEventsSearch(k_TextToFind, FeedGroupBox);
                SearchOps.SetFriendPosts(k_TextToFind, FeedGroupBox);
                //setPagesFindings();
                //setGroupsFindings();
            }
            else
            {
                MessageBox.Show("Please enter phrase to search", "Missing Input");
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            k_TextToFind = SearchTextBox.Text;
        }

        //General
        public void Transition()
        {
            NewPost.Visible = true;
            MainOps.ResetFeedGroupBox(FeedGroupBox, DefaultCenterWidth);
            GamesOps.RemoveAllGuessingGameControls(Controls);
        }
    }
}
