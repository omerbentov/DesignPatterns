﻿using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using A21_Ex02_Omer_206126128_Stav_205816705;
using System.Threading;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public partial class MainFeed : Form
    {
        // Style
        private const int k_PostsMargin = 20;
        private const int k_PostProfilePictureSize = 55;
        private const int k_NumOfPostsInHomePage = 3;
        private const int k_NumOfAlbumsInHomePage = 4;
        private const int k_LabelMargin = 50;
        private const float k_SearchTextBoxRatio = 0.5f;

        private static int s_PostWidth;
        private static string s_TextToFind;
        private string m_AddingActivity;
        private DateTime m_dateTime;
        private bool m_IsCollapsed = false;

        private Label m_GameHeader;
        private ProxyMyListSport m_mySportList;

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

            Point nextPosition = new Point();
            nextPosition = PostsOps.addPosts(groupBoxLocation, baseLocation, k_NumOfPostsInHomePage, FeedGroupBox); 
            nextPosition.Y += k_PostsMargin;

            Thread albums = new Thread(() =>  AlbumsOps.addAlbums(nextPosition, k_NumOfAlbumsInHomePage, FeedGroupBox));
            albums.Start();
        }

        // Albums
        private void FetchaAlbumsBtn_Click(object sender, EventArgs e)
        {
            Transition();

            Point picLocation = new Point(20, 50);
            Thread albums = new Thread(() => AlbumsOps.addAlbums(picLocation, int.MaxValue, FeedGroupBox));
            albums.Start();
        }

        // Posts
        private void FetchPostsBtn_Click(object sender, EventArgs e)
        {
            Transition();

            Point groupBoxLocation = new Point();
            Point baseLocation = new Point(20, 10);
            PostsOps.addPosts(groupBoxLocation, baseLocation, k_NumOfPostsInHomePage, FeedGroupBox); 
        }

        // Account 
        private void FetchAccountInfoBtn_Click(object sender, EventArgs e)
        {
            Transition();

            FeedGroupBox.Visible = true;
            FeedGroupBox.BackColor = Color.White;

            Thread acountInfo = new Thread(() => AccountOps.AddAcountInfo(FeedGroupBox));
            acountInfo.Start();

        }

        //Events 
        private void FetchEventsBtn_Click(object sender, EventArgs e)
        {
            Transition();

            FeedGroupBox.Visible = true;
            FeedGroupBox.BackColor = Color.White;

            Thread addEvents = new Thread(() => EventsOps.AddEvents(FeedGroupBox));
            addEvents.Start();

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
        public void GamesBtn_Click(object sender, EventArgs e)
        {
            Transition();

            NewPost.Hide();
            FeedGroupBox.Hide();

            Label Header = MainOps.CreateNewDefaultLabel(
                "Games",
                new Point(0,0),
                DefaultCenterWidth);
            Controls.Add(Header);
            Header.Font = new Font("Britannic Bold", 32);
            Header.ForeColor = Color.RoyalBlue;
            Header.Location = new Point(NewPost.Location.X + (DefaultCenterWidth / 2) - (Header.Width / 2), NewPost.Location.Y + k_PostsMargin);
            m_GameHeader = Header;

            // Guessing game
            Button guessingGameBtn = new Button();
            guessingGameBtn.Click += BirthdaysGameBtn_Click;
            guessingGameBtn.Size = new Size(150, 100);
            guessingGameBtn.BackgroundImage = A21_Ex02_Omer_206126128_Stav_205816705.Properties.Resources.GuessingGamePicture;
            guessingGameBtn.BackgroundImageLayout = ImageLayout.Stretch;
            guessingGameBtn.Location = new Point(
                // ( ---- center of header ----------) - ( relative location)
                Header.Location.X + (Header.Width / 2) - (int)(1.5f * guessingGameBtn.Width),
                Header.Location.Y + Header.Height + k_PostsMargin);
            GamesOps.AllGamesBtn.Add(guessingGameBtn);


            Button g = new Button();
            g.Click += BirthdaysGameBtn_Click;
            g.Size = new Size(150, 100);
            g.BackgroundImage = A21_Ex02_Omer_206126128_Stav_205816705.Properties.Resources.GuessingGamePicture;
            g.BackgroundImageLayout = ImageLayout.Stretch;
            g.Location = new Point(Header.Location.X + (Header.Width / 2) + (g.Width / 2), Header.Location.Y + Header.Height + k_PostsMargin);
            GamesOps.AllGamesBtn.Add(g);

            GamesOps.AddAllButtunsToConstorls(GamesOps.AllGamesBtn, Controls);
        }

        private void BirthdaysGameBtn_Click(object sender, EventArgs e)
        {
            GamesOps.RemoveAllButtunsFromConstorls(GamesOps.AllGamesBtn, Controls);

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
                new Point(NewPost.Location.X, m_GameHeader.Location.Y + m_GameHeader.Height + k_PostsMargin), Controls,
                this);
        }

        // serach
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            Transition();

            if (!string.IsNullOrEmpty(s_TextToFind))
            {
                Transition();
                Thread addEventSearch= new Thread(() => SearchOps.SetEventsSearch(s_TextToFind, FeedGroupBox));
                addEventSearch.Start();

                Thread addFriendSearch = new Thread(() => SearchOps.SetFriendPosts(s_TextToFind, FeedGroupBox));
                addFriendSearch.Start();

                Thread addGroupSearch = new Thread(() => SearchOps.SetGroupsSearch(s_TextToFind, FeedGroupBox));
                addGroupSearch.Start();

                Thread addPageSearch = new Thread(() => SearchOps.SetPageSearchs(s_TextToFind, FeedGroupBox));
                addPageSearch.Start();
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
            GamesOps.RemoveAllGuessingGameControls(Controls);
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

        private void SportBtn_Click(object sender, EventArgs e)
        {
            Transition();
            addNewActivityTextBox.Visible = true;
            AddBth.Visible = true;
            SportCheckedListBox.Visible = true;
            FeedGroupBox.Visible = true;
            dateTimePickerForSport.Visible = true;

            Point LabelLocation = new Point(0, 0);

            Label header = MainOps.CreateNewDefaultLabel(
               "My Sport List",
               new Point(0, 0),
               DefaultCenterWidth);
            header.Font = new Font("Britannic Bold", 24);
            header.ForeColor = Color.RoyalBlue;
            header.Location = new Point(0,10);
            header.Visible = true;

            FeedGroupBox.Controls.Add(header);
            FeedGroupBox.BackColor = System.Drawing.Color.White;
            FeedGroupBox.Controls.Add(SportCheckedListBox);
            FeedGroupBox.Controls.Add(addNewActivityTextBox);
            FeedGroupBox.Controls.Add(AddBth);
            FeedGroupBox.Controls.Add(dateTimePickerForSport);

            //init list
            m_mySportList = new ProxyMyListSport();
            SportListOps.InitList(SportCheckedListBox, m_mySportList);
     
        }

        private void AddBth_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(m_AddingActivity))
            {
                SportActivity newSportActivity = new SportActivity(m_dateTime, m_AddingActivity);
                try
                {
                    m_mySportList.SportList(newSportActivity);
                    SportListOps.AddNewActivity(newSportActivity);
                }
                catch(Exception err) 
                {
                    MessageBox.Show(err.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please enter phrase to search", "Missing Input");
            }
        }

        private void AddActivity_TextChanged(object sender, EventArgs e)
        {
            m_AddingActivity = addNewActivityTextBox.Text;
        }

        private void SportList_ActivityChecked(object sender, ItemCheckEventArgs e)
        {
            switch (e.NewValue)
            {
                case (CheckState.Checked):
                    m_mySportList.NumberOfActivities--;
                    MessageBox.Show("You Are Killing It", "Good Job");
                    break;
                default:
                    break;
            }
        }

        private void dateTimePickerForSport_ValueChanged(object sender, EventArgs e)
        {
            m_dateTime = dateTimePickerForSport.Value;
        }

        
    }
}
