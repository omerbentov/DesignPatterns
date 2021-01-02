using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public class SprotList : IActivityList
    {
        private Dictionary<string , SportActivity> m_SportActivity;
        private static SprotList s_ActivityIMustDo = null;
        private static DateTime m_DateLimit;
        private static int m_NumberOfActivities;
        private static object s_LockObj = new object();

        private SprotList()
        {
            m_SportActivity = new Dictionary<string, SportActivity>()
            {
                // add instances
            };
        }

        public static SprotList Instance
        {
            get
            {
                if (s_ActivityIMustDo == null)
                {
                    lock (s_LockObj)
                    {
                        if (s_ActivityIMustDo == null)
                        {
                            s_ActivityIMustDo = new SprotList();
                        }
                    }
                }
                return s_ActivityIMustDo;
            }
        }

        public Dictionary<string, SportActivity> SportActivities
        {
            get
            {
                return m_SportActivity;
            }
            set
            {
                m_SportActivity = value;
            }
        }

        public DateTime DateLimit
        {
            get
            {
                return m_DateLimit;
            }
            set
            {
                m_DateLimit = value;
            }
        }

        public int NumberOfActivities
        {
            get
            {
                return m_NumberOfActivities;
            }
            set
            {
                m_NumberOfActivities = value;
            }
        }

        public void AddSportActivity(SportActivity i_addingActivity)
        {
            if (i_addingActivity.Checked)
            {
                m_SportActivity[i_addingActivity.Name] = i_addingActivity;
            }
            else
            {
                m_SportActivity[i_addingActivity.Name] = i_addingActivity;
            }
        }
    }
}
