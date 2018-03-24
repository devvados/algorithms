using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Bubble sort is a simple sorting algorithm with quadratic asymptotic complexity O(n^{2}). 
 * Improved version of bubble sort is shaker sort(cocktail sort), which is a bidirectional version of this algorithm.
 *
 * Description
 * 1. We can imagine that sorted numbers are bubbles, the ones with lower value are lighter than the ones with higher value, hence they ascend to the surface faster.
 * 2. Bubble sort advances similarly. In every step it compares two adjacent elements and if the lower value is on the left side of the higher,
 * bubble sort swaps them (lighter value ascends to the end of the array) and with the same logic algorithm proceeds to the next item.
 * 3. After one iteration the lowest value is located at the end of the array. Algorithm now repeats the procedure with reduced array (the last element is already sorted). 
 * After n-1 iterations is the array completely sorted, because the last bubble is sorted trivially.
 */

namespace SortApplication
{
    class BubbleSort : RecordArray
    {
        public BubbleSort()
        {
            Recs = new List<Record>();
        }

        public void Sort()
        {
            for (int i = 0; i < Recs.Count - 1; i++)
            {
                int swapCount = 0;
                for (int j = 0; j < Recs.Count - i - 1; j++)
                {
                    if (Recs[j].Key > Recs[j + 1].Key)
                    {
                        Swap(j, j + 1);

                        swapCount = j;
                    }
                }
            }
        }

    }
}
