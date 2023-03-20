using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModule
{
    public class SearchResult
    {
        public string strMail;

        public string strSubject;
        public string strName;
        public string strFrom;
        public string strSize;
        public DateTime dteDate;
        public int nAttachNum;

        public string strEmlPath;

        public SearchResult()
        {
            strMail = "";

            strSubject = "";
            strName = "";
            strFrom = "";
            strSize = "";
            dteDate = DateTime.MinValue;
            nAttachNum = 0;

            strEmlPath = "";
        }
    }
}
