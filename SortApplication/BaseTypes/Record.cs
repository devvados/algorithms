using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortApplication
{
    public class Record
    {
        private int key;
        private string info;

        public int Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
            }
        }

        public string Info
        {
            get
            {
                return info;
            }
            set
            {
                info = value;
            }
        }

        public Record(int k)
        {
            Key = k;
            Info = "";
        }

        public Record(int k, string i)
        {
            Key = k;
            Info = i;
        }

        public static bool operator > (Record r1, Record r2)
        {
            if (r1.Key > r2.Key) return true;
            else return false;
        }

        public static bool operator < (Record r1, Record r2)
        {
            if (r1.Key < r2.Key) return true;
            else return false;
        }
    }
}
