using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public class MustDo : IMySportList
    {
        private Dictionary<string, string> m_SportActivity;
        private static MustDo s_ActivityIMustDo = null;
        private static DateTime m_DateLimit;
        private static int m_NumberOfActivities;
        private static object s_LockObj = new object();

        private MustDo()
        {
            m_SportActivity = new Dictionary<string, string>()
            {
                { "Run 1 km", "Unchecked" },
                { "20 pushups", "Unchecked" },
                { "Run 2 km", "Unchecked" },
                { "20 Squats","Unchecked" },
                { "Run 3 km", "Unchecked" },
                { "Yoga morning session", "Unchecked" },
                { "Find a friend and run 4 km", "Unchecked" },
            };
        }

        public static MustDo Instance
        {
            get
            {
                if (s_ActivityIMustDo == null)
                {
                    lock (s_LockObj)
                    {
                        if (s_ActivityIMustDo == null)
                        {
                            s_ActivityIMustDo = new MustDo();
                        }
                    }
                }
                return s_ActivityIMustDo;
            }
        }

        public Dictionary<string, string> SportActivities
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

        public void SportList(SportActivity i_addingActivity)
        {
            m_SportActivity[i_addingActivity.Name] = "Unchecked";
        }
    }
}
