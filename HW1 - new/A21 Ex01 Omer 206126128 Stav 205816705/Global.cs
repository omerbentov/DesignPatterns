using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace A21_Ex01_Omer_206126128_Stav_205816705
{
    public static class Global
    {
        private static User m_User;
        private const string k_appID = "1556806451170375";

        public static User User
        {
            get
            {
                return m_User;
            }
            set
            {
                m_User = value;
            }
        }

        public static string AppId
        {
            get
            {
                return k_appID;
            }
        }
    }
}
