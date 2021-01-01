using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public interface IMySportList
    {
        void SportList(SportActivity i_CustomThing);
        Dictionary<string, string> SportActivities { get; }
        DateTime DateLimit { get; set; }
        int NumberOfActivities { get; set; }
    }
}
