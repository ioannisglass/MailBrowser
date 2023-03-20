using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModule
{
    public class SearchParam
    {
        public bool is_All;

        public DateTime dteAfter;
        public DateTime dteBefore;
        public List<string> lstrSubjectKeys;
        public List<string> lstrBodyKeys;

        public bool is_AllFolders;
        public bool is_InboxOnly;
        public bool is_SentOnly;

        public SearchParam()
        {
            is_All = false;

            dteAfter = DateTime.MinValue;
            dteBefore = DateTime.MaxValue;
            lstrSubjectKeys = new List<string>();
            lstrBodyKeys = new List<string>();

            is_AllFolders = false;
            is_InboxOnly = false;
            is_SentOnly = false;
        }
    }
}
