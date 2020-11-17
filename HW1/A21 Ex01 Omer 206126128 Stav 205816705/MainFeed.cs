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
        private const int k_PostsMargin = 20;
        private const int k_PostWidth = 500;
        private const int k_PostProfilePictureSize = 55;
        private const int k_NumOfPostsInHomePage = 3;
        private const int k_NumOfAlbumsInHomePage = 4;
        private const int k_LabelMargin = 50;

        private static string k_TextToFind;
        private bool m_IsCollapsed = false;

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

        public MainFeed()
        {
            InitializeComponent();
            InitializeChildrenComponents();

            HomeBtn_Click(new object(), new EventArgs());
        }

        private void InitializeChildrenComponents()
        {
            WelcomeUserNameLable.Text = GlobalData.User.FirstName;
            UserNamePictureBox.Image = GlobalData.User.ImageSmall;
        }

        // Home 
        private void HomeBtn_Click(object sender, EventArgs e)
        {
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

        // Account - Class not needed?
        private void FetchAccountInfoBtn_Click(object sender, EventArgs e)
        {
            Transition();
            FeedGroupBox.Visible = true;
            FeedGroupBox.BackColor = Color.White;

            Label header = new Label();
            header.Text = "Information About Your Account" ;
            header.Location = new Point(0, 20);
            header.AutoSize = true;
            FeedGroupBox.Controls.Add(header);

            Label line = new Label();
            line.Text = "----------------------------------------------------------";
            line.AutoSize = true;
            line.Location = new Point(0,30);
            FeedGroupBox.Controls.Add(line);

            Point LabelLocation = new Point(10,10);
            Point baseLocation = new Point(10, 10);
            
            if (GlobalData.User.Name == null)
            {
                CreateAddingButton("Name :", LabelLocation);
            }
            else
            {
                CreateInformationLabel("Name :", GlobalData.User.Name, baseLocation);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + k_LabelMargin);

            if (GlobalData.User.Email == null)
            {
                CreateAddingButton("Email :", LabelLocation);
            }
            else
            {
                CreateInformationLabel("Email :", GlobalData.User.Email, LabelLocation);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + k_LabelMargin);

            if (GlobalData.User.Birthday == null)
            {
                CreateAddingButton("Birthday :", LabelLocation);
            }
            else
            {
                CreateInformationLabel("Birthday :", GlobalData.User.Birthday, LabelLocation);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + k_LabelMargin);

            if (GlobalData.User.Gender == null)
            {
                CreateAddingButton("Gender :", LabelLocation);
            }
            else
            {
                CreateInformationLabel("Gender :", GlobalData.User.Gender.ToString(), LabelLocation);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + k_LabelMargin);

            if (GlobalData.User.Hometown == null)
            {
                CreateAddingButton("Home Town :", LabelLocation);
            }
            else
            {
                CreateInformationLabel("Home Town :", GlobalData.User.Hometown.ToString(), LabelLocation);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + k_LabelMargin);

            if (GlobalData.User.Educations == null)
            {
                CreateAddingButton("Education :", LabelLocation);
            }
            else
            {
                CreateInformationLabel("Education :", GlobalData.User.Educations.ToString(), LabelLocation);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + k_LabelMargin);

            if (GlobalData.User.RelationshipStatus == null)
            {
                CreateAddingButton("RelationshipStatus :", LabelLocation);
            }
            else
            {
                CreateInformationLabel("RelationshipStatus  :", GlobalData.User.RelationshipStatus.ToString(), LabelLocation);
            }

        }

        private void CreateInformationLabel(String i_type, String i_user, Point i_prevPoint)
        {
            Label tempLabel = new Label();
            tempLabel.Text = i_type + i_user;
            tempLabel.Location = MainOps.CalculateNextLabelPosition(i_prevPoint);
            tempLabel.AutoSize = true;
            FeedGroupBox.Controls.Add(tempLabel);
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
            tempLabel.Location = MainOps.CalculateNextLabelPosition(i_prevPoint);
            addingButton.Location = MainOps.CalculateNextButtonPosition(i_prevPoint, tempLabel.Width);
            FeedGroupBox.Controls.Add(tempLabel);
            FeedGroupBox.Controls.Add(addingButton);
        }

        //Events - Need Class ?
        private void FetchEventsBtn_Click(object sender, EventArgs e)
        {
            Transition();
            FeedGroupBox.Visible = true;
            FeedGroupBox.BackColor = Color.White;

            Label header = new Label();
            header.Text = "Your Events";
            header.Size = new System.Drawing.Size(50, 27);
            header.AutoSize = true;
            header.ForeColor = Color.Blue;
            header.Location = new Point(20, 20);
            FeedGroupBox.Controls.Add(header);

            if (GlobalData.User.Events.Count == 0)
            {
                MessageBox.Show("No events on your Facebook account");
            }

            foreach (Event myEvent in GlobalData.User.Events)
            {
                addEvent(myEvent);
                addPicture(myEvent);
            }
        }

        // LogOut - Need Class !
        private void LogOut_Click(object sender, EventArgs e)
        {
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
        private void GamesBtn_Click(object sender, EventArgs e)
        {
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
            if (!string.IsNullOrEmpty(k_TextToFind))
            {
                Transition();
                SearchOps.setEventsSearch(k_TextToFind, FeedGroupBox);
                //setFriendPosts(m_TextToFind, FeedGroupBox);
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
