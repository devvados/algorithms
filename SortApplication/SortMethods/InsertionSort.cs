using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Insertion sort is a sorting algorithm based on comparison of elements. Insertion sort is stable and has quadratic asymptotic complexity O(n^{2}). 
 * Generalized version of this algorithm is Shell sort, which is an insertion sort with diminishing increment.
 * 
 * Description
 * The idea of the insertion sort is simple:
 * 1. One element is sorted trivially
 * 2. Pick element next to the already sorted sequence and insert it to the correct place - move every element of the already sorted sequence, 
 * which has a higher value than the element being sorted, one place right, than put the element into the gap (correct place within the sequence).
 * 3. While array contains any unsorted elements GOTO: 2.
 */

namespace SortApplication
{
    class InsertionSort : RecordArray
    {
        public InsertionSort()
        {
            Recs = new List<Record>();
        }

        public void Sort()
        {
            for (int i = 0; i < Recs.Count - 1; i++)
            {
                int j = i + 1;
                var tmp = Recs[j];
                while (j > 0 && tmp > Recs[j - 1])
                {
                    Recs[j] = Recs[j - 1];
                    j--;
                }
                Recs[j] = tmp;
            }
            Recs.Reverse();
        }
    }
}
