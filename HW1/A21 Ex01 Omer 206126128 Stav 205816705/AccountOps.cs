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
        private static int s_LabelMargin = 50;

        public static void AddAcountInfo(GroupBox i_feedGroupBox)
        {
            Label header = MainOps.CreateNewDefaultLabel("Information About Your Account", new Point(0, 20), i_feedGroupBox);
            i_feedGroupBox.Controls.Add(header);

            Label line = MainOps.CreateNewDefaultLabel("----------------------------------------------------------", new Point(0, 30), i_feedGroupBox);
            i_feedGroupBox.Controls.Add(line);

            Point LabelLocation = new Point(10, 10);
            Point baseLocation = new Point(10, 10);

            if (GlobalData.User.Name == null)
            {
                createAddingButton("Name :", LabelLocation, i_feedGroupBox);
            }
            else
            {
                createInformationLabel("Name :", GlobalData.User.Name, baseLocation, i_feedGroupBox);
            }

            if(GlobalData.User.Email == null)
            { 
                createAddingButton("Email :", LabelLocation, i_feedGroupBox);
            }
            else
            {
                createInformationLabel("Email :", GlobalData.User.Email, LabelLocation, i_feedGroupBox);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + s_LabelMargin);

            if (GlobalData.User.Birthday == null)
            {
                createAddingButton("Birthday :", LabelLocation, i_feedGroupBox);
            }
            else
            {
                createInformationLabel("Birthday :", GlobalData.User.Birthday, LabelLocation, i_feedGroupBox);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + s_LabelMargin);

            if (GlobalData.User.Gender == null)
            {
                createAddingButton("Gender :", LabelLocation, i_feedGroupBox);
            }
            else
            {
                createInformationLabel("Gender :", GlobalData.User.Gender.ToString(), LabelLocation, i_feedGroupBox);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + s_LabelMargin);

            if (GlobalData.User.Hometown == null)
            {
                createAddingButton("Home Town :", LabelLocation, i_feedGroupBox);
            }
            else
            {
                createInformationLabel("Home Town :", GlobalData.User.Hometown.ToString(), LabelLocation, i_feedGroupBox);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + s_LabelMargin);

            if (GlobalData.User.Educations == null)
            {
                createAddingButton("Education :", LabelLocation, i_feedGroupBox);
            }
            else
            {
                createInformationLabel("Education :", GlobalData.User.Educations.ToString(), LabelLocation, i_feedGroupBox);
            }

            LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + s_LabelMargin);

            if (GlobalData.User.RelationshipStatus == null)
            {
                createAddingButton("RelationshipStatus :", LabelLocation, i_feedGroupBox);
            }
            else
            {
                 createInformationLabel("RelationshipStatus  :", GlobalData.User.RelationshipStatus.ToString(), LabelLocation, i_feedGroupBox);
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
