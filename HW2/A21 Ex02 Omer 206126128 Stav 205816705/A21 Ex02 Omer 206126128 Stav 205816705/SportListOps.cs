using System;
using System.Collections.Generic;
using System.Drawing;
using FacebookWrapper.ObjectModel;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public static class SportListOps
    {

        public static void InitList(CheckedListBox i_sportCheckedListBox, IMySportList i_mySportList)
        {
            foreach (KeyValuePair<string, string> sportActivity in i_mySportList.SportActivities)
            {
                i_sportCheckedListBox.Items.Add(sportActivity.Key);
            }
        }

        public static void AddNewActivity(SportActivity i_mySportList, TextBox i_addNewActivity, CheckedListBox i_sportCheckedListBox)
        {
            i_mySportList.SportList(i_addNewActivity.Text);
            i_sportCheckedListBox.Items.Add(i_addNewActivity.Text);
            i_addNewActivity.Text = "Add new activity";
        }
    }
}
