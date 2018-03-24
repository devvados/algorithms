using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Shaker sort (cocktail sort, shake sort) is a stable sorting algorithm with quadratic asymptotic complexity O(n^{2}). 
 * Shakersort is a bidirectional version of bubble sort.
 *
 * Description
 * 1. Shaker sort unlike bubble sort orders the array in both directions. Hence every iteration of the algorithm consists of two phases. 
 * In the first one the lightest bubble ascends to the end of the array, in the second phase the heaviest bubble descends to the beginning of the array.
 * 2. This way an imperfection of bubble sort – the problem of rabbits and turtles – is mitigated. 
 * The problem of rabbits and turtles is a situation in bubble sort, when a heavy bubble is placed at the end of the array. 
 * While the light bubbles (rabbits) are ascending rapidly, the heavy bubble (turtle) descends only one position per each iteration.
 */

namespace SortApplication
{
    class ShakerSort : RecordArray
    {
        public ShakerSort()
        {
            Recs = new List<Record>();
        }

        public void Sort()
        {
            for (int i = 0; i < Recs.Count / 2; i++)
            {
                bool swapped = false;
                for (int j = i; j < Recs.Count - i - 1; j++)
                {
                    if (Recs[j] < Recs[j + 1])
                    {
                        Swap(j, j + 1);
                        swapped = true;
                    }
                }
                for (int j = Recs.Count - 2 - i; j > i; j--)
                {
                    if (Recs[j] > Recs[j - 1])
                    {
                        Swap(j, j - 1);
                        swapped = true;
                    }
                }
                if (!swapped) break;
            }
            Recs.Reverse();
        }

    }
}
