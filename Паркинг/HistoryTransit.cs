using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Паркинг
{
    public class HistoryTransit
    {
        public string fio;
        public string serialNum;
        public string balance;
        public string avto;
        public string LicenseNum;
        public bool blackList = false;
        public string comment;
        public string dateEnter;
        public string dateExit;
        public string cost = "0";
        public bool added = true;
    }
}
