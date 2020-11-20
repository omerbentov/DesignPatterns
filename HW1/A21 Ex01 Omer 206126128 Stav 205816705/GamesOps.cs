using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace A21_Ex01_Omer_206126128_Stav_205816705
{

    public static class GamesOps
    {
        //Style
        private const int k_PostsMargin = 20;
        private const int k_NumOfGuessingGameQuestions = 5;

        // Values
        private static int m_GuessingGameQuestionNumber = 1;
        private static List<Button> m_AllGames = new List<Button>();
        private static List<Control> m_GuessingGameControls = new List<Control>();

        public static List<Button> AllGamesBtn
        {
            get
            {
                return m_AllGames;
            }
        }

        public static void AddAllButtunsToConstorls(List<Button> i_Buttons, Control.ControlCollection i_Controls)
        {
            foreach (Button button in i_Buttons)
            {
                i_Controls.Add(button);
            }
        }

        public static void RemoveAllButtunsFromConstorls(List<Button> i_Buttons, Control.ControlCollection i_Controls)
        {
            foreach (Button button in i_Buttons)
            {
                i_Controls.Remove(button);
            }
        }

        public static void NewAgeQuestion(object sender, string i_Question, int i_Y_Location, Control i_Control, MainFeedForm i_MainFeed)
        {
            Label QuestionLabel = MainOps.CreateNewDefaultLabel(i_Question, new Point(0,0), MainFeedForm.DefaultCenterWidth);
            i_Control.Controls.Add(QuestionLabel);
            Point labelLocation = new Point((i_Control.Width / 2) - QuestionLabel.Width, i_Y_Location);
            QuestionLabel.Location = labelLocation;
            m_GuessingGameControls.Add(QuestionLabel);

            TextBox answerTextBox = new TextBox();
            answerTextBox.Location = new Point(QuestionLabel.Location.X + QuestionLabel.Width + k_PostsMargin, QuestionLabel.Location.Y);
            m_GuessingGameControls.Add(answerTextBox);
            Point answerLocation = new Point(QuestionLabel.Location.X + QuestionLabel.Width, QuestionLabel.Location.Y);
            answerTextBox.Location = answerLocation;
            i_Control.Controls.Add(answerTextBox);

            Button SubmitBtn = new Button();
            SubmitBtn.Text = "Submit";
            SubmitBtn.Location = new Point(answerTextBox.Location.X + answerTextBox.Width + k_PostsMargin, answerTextBox.Location.Y);
            SubmitBtn.Click += (sender_, EventArgs) => {
                buttonNext_Click(
                    sender,
                    EventArgs,
                    answerTextBox.Text.Equals("45"),
                    new Point(QuestionLabel.Location.X, QuestionLabel.Location.Y + QuestionLabel.Height),
                    i_Control,
                    i_MainFeed);
            };
            i_Control.Controls.Add(SubmitBtn);
            m_GuessingGameControls.Add(SubmitBtn);
        }

        private static void buttonNext_Click(object sender, EventArgs eventArgs, bool i_IsCorrect, Point i_Location, Control i_Control, MainFeedForm i_MainFeed)
        {
            Label isCorrectLabel = MainOps.CreateNewDefaultLabel(i_IsCorrect.ToString(), i_Location, MainFeedForm.DefaultCenterWidth);
            i_Control.Controls.Add(isCorrectLabel);
            m_GuessingGameControls.Add(isCorrectLabel);
            isCorrectLabel.BringToFront();

            if (m_GuessingGameQuestionNumber < k_NumOfGuessingGameQuestions)
            {
                m_GuessingGameQuestionNumber++;
                // In this case we need to ranomize a friend and get his birthday - but permission denied
                /* newQuestion(
                            sender,
                            "How old is <RandomUserFriend().FullName>?",
                            new Point(NewPost.Location.X, NewPost.Location.X + k_PostsMargin),
                            this);
                */
                NewAgeQuestion(
                    sender,
                    "How old is Guy Ronen?",
                    i_Location.Y + k_PostsMargin,
                    i_Control,
                    i_MainFeed);
            }
            else
            {
                m_GuessingGameQuestionNumber = 1;
                i_MainFeed.GamesBtn_Click(new object(), new EventArgs());
            }

        }

        public static Label CreateGameHeader(string i_HeaderTitle, Control i_Control)
        {
            Label Header = MainOps.CreateNewDefaultLabel(
               i_HeaderTitle,
               new Point(0, 0),
               MainFeedForm.DefaultCenterWidth);
            Header.Name = i_HeaderTitle + "HeaderLabel";
            Header.Font = new Font("Britannic Bold", 32);
            Header.ForeColor = Color.RoyalBlue;
            Header.Location = new Point((i_Control.Width / 2) - (Header.Width / 2), k_PostsMargin);
            i_Control.Controls.Add(Header);

            return Header;
        }
    }
}
