using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using FacebookWrapper.ObjectModel;
using System.Windows.Forms;

namespace A21_Ex01_Omer_206126128_Stav_205816705
{
    public static class EventsOps
    {
        private const int k_PostProfilePictureSize = 55;
        private const string k_NoEventsMessage = "No events on your Facebook account";
        private const string k_HeaderText = "Your Events";
        private static Size s_HeaderSize = new Size(50, 27);
        private static Point s_HeaderLocation = new Point(20, 20);

        public static void AddEvents(GroupBox i_feedGroupBox)
        {
            Label header = new Label();
            header.Text = k_HeaderText;
            header.Size = s_HeaderSize;
            header.AutoSize = true;
            header.ForeColor = Color.Blue;
            header.Location = s_HeaderLocation;
            i_feedGroupBox.Controls.Add(header);

            if (GlobalData.User.Events.Count == 0)
            {
                MessageBox.Show(k_NoEventsMessage);
            }

            foreach (Event myEvent in GlobalData.User.Events)
            {
                addNewEvent(myEvent, i_feedGroupBox);
                addPicture(myEvent, i_feedGroupBox);
            }
        }

        private static void addNewEvent(Event i_newEvent, GroupBox i_feedGroupBox)
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

            i_feedGroupBox.Controls.Add(eventLabel);
        }

        private static void addPicture(Event i_newEvent, GroupBox i_feedGroupBox)
        {
            PictureBox eventPicture = new PictureBox();
            Point LabelLocation = new Point(10, 10);
            eventPicture.Image = Properties.Resources.Facebook_1_Cake;
            eventPicture.Visible = true;
            eventPicture.SizeMode = PictureBoxSizeMode.Zoom;
            eventPicture.Location = MainOps.CalculateNextButtonPosition(LabelLocation, 100);
            eventPicture.MaximumSize = new Size(new Point(k_PostProfilePictureSize + MainFeedForm.LabelMargin , k_PostProfilePictureSize + MainFeedForm.LabelMargin));
            i_feedGroupBox.Controls.Add(eventPicture);
        }
    }
}
