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
    public class LabelApp
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
    }
}
