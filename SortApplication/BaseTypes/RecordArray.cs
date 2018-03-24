using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortApplication
{
    public class RecordArray
    {
        List<Record> recs;

        public List<Record> Recs
        {
            get
            {
                return recs;
            }
            set
            {
                recs = value;
            }
        }

        public RecordArray()
        {
            recs = new List<Record>();
        }

        public void GenExampleNumbers()
        {
            recs.Clear();

            List<int> hs = new List<int>();
            hs.Add(503);
            hs.Add(87);
            hs.Add(512);
            hs.Add(61);
            hs.Add(908);
            hs.Add(170);
            hs.Add(897);
            hs.Add(275);
            hs.Add(653);
            hs.Add(426);
            hs.Add(154);
            hs.Add(509);
            hs.Add(612);
            hs.Add(677);
            hs.Add(765);
            hs.Add(703);

            int iter = 0;
            foreach (int generated_val in hs)
            {
                recs.Add(new Record(generated_val)
                {
                    //Key = generated_val,
                    Info = "Record № " + iter.ToString()
                });
                iter++;
            }
        }

        public void Swap(int index1, int index2)
        {
            var temp = recs[index1];
            recs[index1] = recs[index2];
            recs[index2] = temp;
        }

        public int GetMaxKey()
        {
            int max = 0;
            List<int> keys = new List<int>();

            for (int i = 0; i < recs.Count; i++)
                keys.Add(recs[i].Key);
            max = keys.Max();

            return max;
        }
    }
}
