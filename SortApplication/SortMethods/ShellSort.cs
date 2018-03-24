using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Shell sort is an unstable quadratic sorting algorithm, which can be seen as a generalization of insertion sort. 
 * Althrought is has an O(n^2) asymptotic complexity, it is the most efficient algorithm of this class.
 *
 * Description
 * 1. An ordinary insertion sort maintains a list of already sorted elements. Than it picks the element next to the list and places it at the correct position within the list. 
 * By iteratively repeating this procedure (starting with a list of one element) the array gets sorted in n steps.
 * 2. Shell sort operates analogously. The main difference is, that Shell sort uses so called diminishing increment. 
 * It means that in every step only elements at some distance are compared (for example the first with the fifth, second with the sixth...). 
 * This approach ensures that elements with high and low value are moved to the appropriate side of the array very quickly. 
 * In every iteration the gap between the compared elements is reduced. In the iteration step, the gap is set to one – the algorithm degrades to an ordinary insertion sort, 
 * which terminates very quickly, because now the array contains only few misplaced elements.
 */

namespace SortApplication
{
    class ShellSort : RecordArray
    {
        public ShellSort()
        {
            Recs = new List<Record>();
        }

        public void Sort()
        {
            int n = Recs.Count;
            int gap = n / 2;
            Record temp;

            while (gap > 0)
            {
                for (int i = 0; i + gap < n; i++)
                {
                    int j = i + gap;
                    temp = Recs[j];

                    while (j - gap >= 0 && temp.Key < Recs[j - gap].Key)
                    {
                        Recs[j] = Recs[j - gap];
                        j = j - gap;
                    }

                    Recs[j] = temp;
                }

                gap = gap / 2;
            }
        }
    }
}
