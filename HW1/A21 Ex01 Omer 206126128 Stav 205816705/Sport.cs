using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A21_Ex01_Omer_206126128_Stav_205816705
{
    public interface Sport
    {
        void MySportList(string i_CustomThing);
        Dictionary<string, string> MySportTasks { get; }
        DateTime DateLimit { get; set; }
        int CountNumberOfTask { get; set; }
    }
}
