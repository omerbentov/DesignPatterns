﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using FacebookWrapper.ObjectModel;
using System.Windows.Forms;

namespace A21_Ex01_Omer_206126128_Stav_205816705
{
    public static class MainOps
    {
        public static Label createNewDefaultLabel(string i_text, Point i_Location, GroupBox i_feedGroupBox)
        {
            Label tempLabel = new Label();
            tempLabel.AutoSize = true;
            tempLabel.MaximumSize = new Size(i_feedGroupBox.Width, int.MaxValue);
            tempLabel.Text = i_text;
            tempLabel.Location = i_Location;

            return tempLabel;
        }

        public static Point CalculateNextLabelPosition(Point i_prevPoint)
        {
            return new Point(i_prevPoint.X, i_prevPoint.Y + 50);
        }

        public static Point CalculateNextButtonPosition(Point i_prevPoint, int i_labelWidth)
        {
            return new Point(i_labelWidth + 10, i_prevPoint.Y + MainFeed.LabelMargin);
        }

        public static Label CreateNewDefaultLabel(string i_text, Point i_Location, int i_WidthSize)
        {
            Label tempLabel = new Label();
            tempLabel.AutoSize = true;
            tempLabel.MaximumSize = new Size(i_WidthSize, int.MaxValue);
            tempLabel.Text = i_text;
            tempLabel.Location = i_Location;

            return tempLabel;
        }

        public static void ResetFeedGroupBox(GroupBox i_FeedGroupBox, int i_Width)
        {
            i_FeedGroupBox.Controls.Clear();
            i_FeedGroupBox.Visible = true;
            i_FeedGroupBox.BackColor = Color.Transparent;
            i_FeedGroupBox.Width = i_Width;
            i_FeedGroupBox.MaximumSize = new Size(i_Width, int.MaxValue);
        }

        private static void CreateAndAddToGroupBoxInformationLabel(String i_type, String i_user, Point i_prevPoint, GroupBox i_FeedGroupBox)
        {
            Label tempLabel = new Label();
            tempLabel.Text = i_type + i_user;
            tempLabel.Location = CalculateNextLabelPosition(i_prevPoint);
            tempLabel.AutoSize = true;
            i_FeedGroupBox.Controls.Add(tempLabel);
        }
    }
}