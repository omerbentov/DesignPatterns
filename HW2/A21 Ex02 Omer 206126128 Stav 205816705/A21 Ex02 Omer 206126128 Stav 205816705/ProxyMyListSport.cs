using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public class ProxyMyListSport : IMySportList
    {
        private MustDo m_MustDo;
        public ProxyMyListSport()
        {
            m_MustDo = MustDo.Instance;
        }

        public Dictionary<string, string> SportActivities
        {
            get
            {
                return m_MustDo.SportActivities;
            }
            set
            {
                m_MustDo.SportActivities = value;
            }
        }

        public DateTime DateLimit
        {
            get
            {
                return m_MustDo.DateLimit;
            }
            set
            {
                if (value >= DateTime.Today)
                {
                    m_MustDo.DateLimit = value;
                }
                else
                {
                    throw new Exception("Invalid date");
                }
            }
        }

        public int NumberOfActivities
        {
            get
            {
                return m_MustDo.NumberOfActivities;
            }
            set
            {
                m_MustDo.NumberOfActivities = value;
            }
        }

        public void SportList(SportActivity i_addingActivity)
        {
            if (SportActivities.ContainsKey(i_addingActivity.Name))
            {
                throw new Exception("This Activity is already on the list"); 
            }

            if(i_addingActivity.Time <= DateTime.Today)
            {
                throw new Exception("Time is invalid");
            }
           
            SportActivities.Add(i_addingActivity.Name, "Unchecked");
        }
    }
}

