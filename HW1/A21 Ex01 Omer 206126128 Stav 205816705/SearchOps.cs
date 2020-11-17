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
    public static class SearchOps
    {
        public static void setEventsSearch(string i_TextToFind, GroupBox i_FeedGroupBox)
        {
            Point LabelLocation = new Point(10, 10);

            try
            {
                foreach (Event myEvent in GlobalData.User.Events)
                {
                    if (!string.IsNullOrEmpty(myEvent.Name))
                    {
                        if (myEvent.Name.Contains(i_TextToFind))
                        {
                            addEvent(myEvent, i_FeedGroupBox);
                            addPicture(myEvent, i_FeedGroupBox);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                errMessage(i_FeedGroupBox);
            }
        }

        private static void setFriendPosts(string i_TextToFind, GroupBox i_FeedGroupBox)
        {
            foreach (User user in GlobalData.User.Friends)
            {
                foreach (Post post in user.Posts)
                {
                    if (!string.IsNullOrEmpty(post.Message))
                    {
                        if (post.Message.Contains(i_TextToFind))
                        {
                            Label postOfAFriend = new Label();
                            String userName = post.From.Name + "posted";
                            postOfAFriend.Text = userName + post.Message;
                            postOfAFriend.AutoSize = true;
                            postOfAFriend.Location = new Point();
                            i_FeedGroupBox.Controls.Add(postOfAFriend);
                        }
                    }
                }
            }
        }

        private static void addPicture(Event i_newEvent, GroupBox i_FeedGroupBox)
        {
            PictureBox eventPicture = new PictureBox();
            Point LabelLocation = new Point(10, 10);
            //eventPicture.ImageLocation = i_newEvent.PictureSqaureURL;
            //eventPicture.LoadAsync(i_newEvent.PictureSmallURL);
            eventPicture.Image = Properties.Resources.Facebook_1_Cake;
            eventPicture.Visible = true;
            eventPicture.SizeMode = PictureBoxSizeMode.Zoom;
            eventPicture.Location = MainOps.CalculateNextButtonPosition(LabelLocation, 100);
            eventPicture.MaximumSize = new Size(MainFeed.PostProfilePicturePointSize);
            i_FeedGroupBox.Controls.Add(eventPicture);
        }

        private static void errMessage(GroupBox i_FeedGroupBox)
        {
            i_FeedGroupBox.Controls.Clear();
            Label errMessage = new Label();
            errMessage.Text = "sorry, we can't access the information";
            errMessage.AutoSize = true;
            errMessage.Location = new Point(20, 20);
            i_FeedGroupBox.Controls.Add(errMessage);
        }

        private static void addEvent(Event i_newEvent, GroupBox i_FeedGroupBox)
        {
            Point LabelLocation = new Point(10, 10);

            Label eventLabel = new Label();
            string eventName = i_newEvent.Name;
            string eventTime = i_newEvent.StartTime.ToString();
            long attendingCount = (long)i_newEvent.AttendingCount;
            string newEvent = String.Format("Event: {0}\n start at: {1}\n attending: {2}\n", eventName, eventTime, attendingCount);

            eventLabel.Text = newEvent;
            eventLabel.AutoSize = true;
            eventLabel.Location = MainOps.CalculateNextLabelPosition(LabelLocation);
            eventLabel.Visible = true;

            i_FeedGroupBox.Controls.Add(eventLabel);
        }
    }
}
