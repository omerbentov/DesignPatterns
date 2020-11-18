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
    public class AccountOps
    {
        private static int k_LabelMargin = 50;

        public static void AddAcountInfo(GroupBox i_feedGroupBox)
        {

            Label header = new Label();
            header.Text = "Information About Your Account";
            header.Location = new Point(0, 20);
            header.AutoSize = true;
            i_feedGroupBox.Controls.Add(header);

            Label line = new Label();
            line.Text = "----------------------------------------------------------";
            line.AutoSize = true;
            line.Location = new Point(0, 30);
            i_feedGroupBox.Controls.Add(line);

            Point LabelLocation = new Point(10, 10);
            Point baseLocation = new Point(10, 10);

            if (LoggedInUserData.User.Name == null)
            {
                createAddingButton("Name :", LabelLocation, i_feedGroupBox);
            }
            else
            {
                createInformationLabel("Name :", LoggedInUserData.User.Name, baseLocation, i_feedGroupBox);
            }

            if(LoggedInUserData.User.Email == null)
            { 
                createAddingButton("Email :", LabelLocation, i_feedGroupBox);
            }
            else
            {
                createInformationLabel("Email :", LoggedInUserData.User.Email, LabelLocation, i_feedGroupBox);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + k_LabelMargin);

            if (LoggedInUserData.User.Birthday == null)
            {
                createAddingButton("Birthday :", LabelLocation, i_feedGroupBox);
            }
            else
            {
                createInformationLabel("Birthday :", LoggedInUserData.User.Birthday, LabelLocation, i_feedGroupBox);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + k_LabelMargin);

            if (LoggedInUserData.User.Gender == null)
            {
                createAddingButton("Gender :", LabelLocation, i_feedGroupBox);
            }
            else
            {
                createInformationLabel("Gender :", LoggedInUserData.User.Gender.ToString(), LabelLocation, i_feedGroupBox);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + k_LabelMargin);

            if (LoggedInUserData.User.Hometown == null)
            {
                createAddingButton("Home Town :", LabelLocation, i_feedGroupBox);
            }
            else
            {
                createInformationLabel("Home Town :", LoggedInUserData.User.Hometown.ToString(), LabelLocation, i_feedGroupBox);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + k_LabelMargin);

            if (LoggedInUserData.User.Educations == null)
            {
                createAddingButton("Education :", LabelLocation, i_feedGroupBox);
            }
            else
            {
                createInformationLabel("Education :", LoggedInUserData.User.Educations.ToString(), LabelLocation, i_feedGroupBox);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + k_LabelMargin);

            if (LoggedInUserData.User.RelationshipStatus == null)
            {
                createAddingButton("RelationshipStatus :", LabelLocation, i_feedGroupBox);
            }
            else
            {
                 createInformationLabel("RelationshipStatus  :", LoggedInUserData.User.RelationshipStatus.ToString(), LabelLocation, i_feedGroupBox);
            }

        }

        private static void createInformationLabel(String i_type, String i_user, Point i_prevPoint, GroupBox i_feedGroupBox)
        {
            Label tempLabel = new Label();
            tempLabel.Text = i_type + i_user;
            tempLabel.Location = MainOps.CalculateNextLabelPosition(i_prevPoint);
            tempLabel.AutoSize = true;
            i_feedGroupBox.Controls.Add(tempLabel);
        }

        private static void createAddingButton(String i_type, Point i_prevPoint, GroupBox i_feedGroupBox)
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
            i_feedGroupBox.Controls.Add(tempLabel);
            i_feedGroupBox.Controls.Add(addingButton);
        }
    }
}
