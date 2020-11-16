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
        private const int k_NumOfGuessingGameQuestions = 5;
        private const int k_LabelMargin = 50;

        private string m_TextToFind;
        private bool m_IsCollapsed = false;
        private int m_Score = 0;
        private int m_GuessingGameQuestionNumber = 1;
        private List<Button> m_AllGames = new List<Button>();
        private List<Control> m_GuessingGameControls = new List<Control>();

        public MainFeed()
        {
            InitializeComponent();
            InitializeChildrenComponents();

            HomeBtn_Click(new object(), new EventArgs());
        }

        private void InitializeChildrenComponents()
        {
            WelcomeUserNameLable.Text = Global.User.FirstName;
            UserNamePictureBox.Image = Global.User.ImageSmall;
        }

        private void FetchaAlbumsBtn_Click(object sender, EventArgs e)
        {
            transition();

            Point picLocation = new Point(20, 50);
            Albums.addAlbums(picLocation, int.MaxValue, FeedGroupBox);
        }

        private void FetchPostsBtn_Click(object sender, EventArgs e)
        {
            transition();

            Point groupBoxLocation = new Point();
            Point baseLocation = new Point(20, 10);

            Posts.addPosts(groupBoxLocation, baseLocation, int.MaxValue, FeedGroupBox);
        }

        private void transition()
        {
            NewPost.Visible = true;
            resetFeedGroupBox();
            removeAllGuessingGameControls();
        }

        private void resetFeedGroupBox()
        {
            FeedGroupBox.Controls.Clear();
            FeedGroupBox.Visible = true;
            FeedGroupBox.BackColor = Color.Transparent;
            FeedGroupBox.Width = NewPost.Width;
            FeedGroupBox.MaximumSize = new Size(new Point(NewPost.Width, int.MaxValue));
        }

        private Point calculateNextLabelPosition(Point i_prevPoint)
        {
            return new Point(i_prevPoint.X , i_prevPoint.Y + 50);
        }

        private void FetchAccountInfoBtn_Click(object sender, EventArgs e)
        {
            transition();
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
            
            if (Global.User.Name == null)
            {
                CreateAddingButton("Name :", LabelLocation);
            }
            else
            {
                CreateInformationLabel("Name :", Global.User.Name, baseLocation);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + k_LabelMargin);

            if (Global.User.Email == null)
            {
                CreateAddingButton("Email :", LabelLocation);
            }
            else
            {
                CreateInformationLabel("Email :", Global.User.Email, LabelLocation);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + k_LabelMargin);

            if (Global.User.Birthday == null)
            {
                CreateAddingButton("Birthday :", LabelLocation);
            }
            else
            {
                CreateInformationLabel("Birthday :", Global.User.Birthday, LabelLocation);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + k_LabelMargin);

            if (Global.User.Gender == null)
            {
                CreateAddingButton("Gender :", LabelLocation);
            }
            else
            {
                CreateInformationLabel("Gender :", Global.User.Gender.ToString(), LabelLocation);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + k_LabelMargin);

            if (Global.User.Hometown == null)
            {
                CreateAddingButton("Home Town :", LabelLocation);
            }
            else
            {
                CreateInformationLabel("Home Town :", Global.User.Hometown.ToString(), LabelLocation);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + k_LabelMargin);

            if (Global.User.Educations == null)
            {
                CreateAddingButton("Education :", LabelLocation);
            }
            else
            {
                CreateInformationLabel("Education :", Global.User.Educations.ToString(), LabelLocation);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + k_LabelMargin);

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
            tempLabel.AutoSize = true;
            FeedGroupBox.Controls.Add(tempLabel);
        }

        private Point calculateNextButtonPosition(Point i_prevPoint, int i_labelWidth)
        {
            return new Point(i_labelWidth + 10 , i_prevPoint.Y + k_LabelMargin);
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
            transition();
            FeedGroupBox.Visible = true;
            FeedGroupBox.BackColor = Color.White;

            Label header = new Label();
            header.Text = "Your Events";
            header.Size = new System.Drawing.Size(50, 27);
            header.AutoSize = true;
            header.ForeColor = Color.Blue;
            header.Location = new Point(20, 20);
            FeedGroupBox.Controls.Add(header);

            if (Global.User.Events.Count == 0)
            {
                MessageBox.Show("No events on your Facebook account");
            }

            foreach (Event myEvent in Global.User.Events)
            {
                addEvent(myEvent);
                addPicture(myEvent);
            }
        }

        private void addEvent(Event i_newEvent)
        {
            Point LabelLocation = new Point(10, 10);

            Label eventLabel = new Label();
            string eventName = i_newEvent.Name;
            string eventTime = i_newEvent.StartTime.ToString();
            long attendingCount = (long)i_newEvent.AttendingCount;
            string newEvent = String.Format("Event: {0}\n start at: {1}\n attending: {2}\n", eventName, eventTime, attendingCount);

            eventLabel.Text = newEvent;
            eventLabel.AutoSize = true;
            eventLabel.Location = calculateNextLabelPosition(LabelLocation);
            eventLabel.Visible = true;

            FeedGroupBox.Controls.Add(eventLabel);
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

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            resetFeedGroupBox();

            Point groupBoxLocation = new Point();
            Point baseLocation = new Point(20, 10);

            Point nextPosition = Posts.addPosts(groupBoxLocation, baseLocation, k_NumOfPostsInHomePage, FeedGroupBox);
            nextPosition.Y += k_PostsMargin;
            Albums.addAlbums(nextPosition, k_NumOfAlbumsInHomePage, FeedGroupBox);
        }

        // Games
        private void GamesBtn_Click(object sender, EventArgs e)
        {
            NewPost.Hide();
            FeedGroupBox.Hide();

            Label Header = createNewDefaultLabel("Games", NewPost.Location);
            Controls.Add(Header);

            Button guessingGameBtn = new Button();
            guessingGameBtn.Text = "Guessing game";
            guessingGameBtn.Click += BirthdaysGameBtn_Click;
            guessingGameBtn.Location = new Point(NewPost.Location.X, NewPost.Location.Y + k_PostsMargin);
            m_AllGames.Add(guessingGameBtn);

            Button g = new Button();
            g.Text = "G";
            g.Click += BirthdaysGameBtn_Click;
            g.Location = new Point(NewPost.Location.X, guessingGameBtn.Location.Y + guessingGameBtn.Height + k_PostsMargin);
            m_AllGames.Add(g);

            addAllButtunsToConstorls(m_AllGames);
        }

        void addAllButtunsToConstorls(List<Button> i_Buttons)
        {
            foreach(Button button in i_Buttons)
            {
                Controls.Add(button);
            }
        }

        private void removeAllButtunsFromConstorls(List<Button> i_Buttons)
        {
            foreach (Button button in i_Buttons)
            {
                Controls.Remove(button);
            }
        }

        private void BirthdaysGameBtn_Click(object sender, EventArgs e)
        {
            removeAllButtunsFromConstorls(m_AllGames);

            Random rnd = new Random();
            int typeOfQuestions = rnd.Next(0, 1);

            switch(typeOfQuestions)
            {
                case 0:
                    // In this case we need to ranomize a friend and get his birthday - but permission denied
                    // newQuestion(sender, "How old is <RandomUserFriend()FullName>?", new Point(NewPost.Location.X, NewPost.Location.X + k_PostsMargin));
                    newQuestion(sender, "How old is Guy Ronen?", new Point(NewPost.Location.X, NewPost.Location.Y + k_PostsMargin));
                    break;
            }
        }

        private void newQuestion(object sender, string i_Question, Point i_BaseLOaction)
        {
            Label QuestionLabel = createNewDefaultLabel(i_Question, i_BaseLOaction);
            Controls.Add(QuestionLabel);
            m_GuessingGameControls.Add(QuestionLabel);

            TextBox answerTextBox = new TextBox();
            answerTextBox.Location = new Point(QuestionLabel.Location.X + QuestionLabel.Width + k_PostsMargin, QuestionLabel.Location.Y);
            Controls.Add(answerTextBox);
            m_GuessingGameControls.Add(answerTextBox);

            Button SubmitBtn = new Button();
            SubmitBtn.Text = "Submit";
            SubmitBtn.Location = new Point(answerTextBox.Location.X + answerTextBox.Width + k_PostsMargin, QuestionLabel.Location.Y);
            SubmitBtn.Click += (sender_, EventArgs) => {
                buttonNext_Click(
                    sender,
                    EventArgs,
                    answerTextBox.Text.Equals("45"),
                    new Point(QuestionLabel.Location.X, QuestionLabel.Location.Y + QuestionLabel.Height)
                    );
            };
            Controls.Add(SubmitBtn);
            m_GuessingGameControls.Add(SubmitBtn);
        }

        private void buttonNext_Click(object sender, EventArgs eventArgs, bool i_IsCorrect, Point i_Location)
        {
            Label isCorrectLabel = createNewDefaultLabel(i_IsCorrect.ToString(), i_Location);
            Controls.Add(isCorrectLabel);
            m_GuessingGameControls.Add(isCorrectLabel);
            isCorrectLabel.BringToFront();

            if (i_IsCorrect)
            {
                if (m_GuessingGameQuestionNumber < k_NumOfGuessingGameQuestions)
                {
                    m_GuessingGameQuestionNumber++;
                    m_Score++;
                    newQuestion(
                        sender,
                        "How old is guy ronen",
                        new Point(i_Location.X, i_Location.Y + (sender as Button).Height + k_PostsMargin));
                }
                else
                {
                    m_GuessingGameQuestionNumber = 1;
                    m_Score++;
                    removeAllGuessingGameControls();
                }
            }
        }

        private void removeAllGuessingGameControls()
        {
            foreach (Control control in m_GuessingGameControls)
            {
                Controls.Remove(control);
            }
        }

        // serach
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(m_TextToFind))
            {
                clearAllFindings();
                setEventsSearch();
                //setPagesFindings();
                //setGroupsFindings();
                //setFriendPosts();
            }
            else
            {
                MessageBox.Show("Please enter phrase to search", "Missing Input");
            }
        }

        private void clearAllFindings()
        {
            FeedGroupBox.Controls.Clear();
        }

        private void setFriendPosts()
        {
            foreach (User user in Global.User.Friends)
            {
                foreach (Post post in user.Posts)
                {
                    if (!string.IsNullOrEmpty(post.Message))
                    {
                        if (post.Message.Contains(m_TextToFind))
                        {
                            Label postOfAFriend = new Label();
                            String userName = post.From.Name + "posted";
                            postOfAFriend.Text = userName + post.Message;
                            postOfAFriend.AutoSize = true;
                            postOfAFriend.Location = new Point();
                            FeedGroupBox.Controls.Add(postOfAFriend);
                        }
                    }
                }
            }
        }

        private void addPicture(Event i_newEvent)
        {
            PictureBox eventPicture = new PictureBox();
            Point LabelLocation = new Point(10, 10);
            //eventPicture.ImageLocation = i_newEvent.PictureSqaureURL;
            //eventPicture.LoadAsync(i_newEvent.PictureSmallURL);
            eventPicture.Image = Properties.Resources.Facebook_1_Cake;
            eventPicture.Visible = true;
            eventPicture.SizeMode = PictureBoxSizeMode.Zoom;
            eventPicture.Location = calculateNextButtonPosition(LabelLocation, 100);
            eventPicture.MaximumSize = new Size(new Point(k_PostProfilePictureSize + 20, k_PostProfilePictureSize + 20));
            FeedGroupBox.Controls.Add(eventPicture);
        }

        private void setEventsSearch()
        {
            Point LabelLocation = new Point(10, 10);

            try
            {
                foreach (Event myEvent in Global.User.Events)
                {
                    if (!string.IsNullOrEmpty(myEvent.Name))
                    {
                        if (myEvent.Name.Contains(m_TextToFind))
                        {
                            addEvent(myEvent);
                            addPicture(myEvent);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                errMessage();
            }
        }

        private void errMessage()
        {
            FeedGroupBox.Controls.Clear();
            Label errMessage = new Label();
            errMessage.Text = "sorry, we can't access the information";
            errMessage.AutoSize = true;
            errMessage.Location = new Point(20, 20);
            FeedGroupBox.Controls.Add(errMessage);
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            m_TextToFind = SearchTextBox.Text;
        }
    }
}
