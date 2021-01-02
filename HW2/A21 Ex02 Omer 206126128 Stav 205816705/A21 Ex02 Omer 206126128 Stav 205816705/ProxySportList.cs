using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public class ProxySportList
    {
        private SprotList m_SportList;

        public ProxySportList()
        {
            m_SportList = SprotList.Instance;
        }

        public Dictionary<string, SportActivity> SportActivities
        {
            get
            {
                return m_SportList.SportActivities;
            }
            set
            {
                m_SportList.SportActivities = value;
            }
        }

        // Validator
        public void AddSportActivity(SportActivity i_addingActivity, CheckedListBox i_sportCheckedListBox)
        {
            if (SportActivities.ContainsKey(i_addingActivity.Name))
            {
                throw new Exception("This Activity is already on the list");
            }
            if(i_addingActivity.limitTime < DateTime.Now)
            {
                throw new Exception("Choose different time");
            }
            else
            {
                SportActivities.Add(i_addingActivity.Name, i_addingActivity);
                i_sportCheckedListBox.Items.Add(i_addingActivity, i_addingActivity.Checked);
            }
        }

        public static void InitList(CheckedListBox i_sportCheckedListBox)
        {
            SportActivity run22 = new SportActivity(false, "Run 22 miles", DateTime.Now);
            SportActivity Swim10 = new SportActivity(false, "Swim 10 miles", DateTime.Now);
            SportActivity BB = new SportActivity(false, "Basketball with friend", DateTime.Now);

            SprotList.Instance.AddSportActivity(run22);
            SprotList.Instance.AddSportActivity(Swim10);
            SprotList.Instance.AddSportActivity(BB);

            i_sportCheckedListBox.Items.Add(run22,run22.Checked);
            i_sportCheckedListBox.Items.Add(Swim10, Swim10.Checked);
            i_sportCheckedListBox.Items.Add(BB, BB.Checked);
        }
    }
}

