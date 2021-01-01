using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public class SportActivity
    {
        private DateTime m_dateTime;
        private string m_activityName;

        public SportActivity(DateTime i_dateTime, string i_activityName)
        {
            m_dateTime = i_dateTime;
            m_activityName = i_activityName;

        }

        public String Name
        {
            get
            {
                return m_activityName;
            }

            set
            {
                m_activityName = value;
            }
        }

        public DateTime Time {
            get 
            {
                return m_dateTime;
            }
            set 
            {
                m_dateTime = value;
            }
        }
    }
}
