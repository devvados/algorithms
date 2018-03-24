using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Counting sort(ultra sort, math sort) is an efficient sorting algorithm with asymptotic complexity O(n+k), which was devised by Harold Seward in 1954. 
 * As opposed to bubble sort and quicksort, counting sort is not comparison based, since it enumerates occurrences of contained values.
 *
 * Description
 * 1. Counting sort utilizes the knowledge of the smallest and the largest element in the array(structure). 
 * Using this information, it can create a helper array of frequencies of all discrete values in the main array and later recalculate it into the array of occurrences 
 * (for every value the array of occurrences contains an index of its last occurrence in a sorted array).
 * 2. With this information the actual sorting is simple. Counting sort iterates over the main array and fills the appropriate values, whose positions are known thanks to the array of occurrences.
 */

namespace SortApplication
{
    class CountOfComparisons : RecordArray
    {
        public CountOfComparisons()
        {
            Recs = new List<Record>();
        }

        public void Sort()
        {
            var sortedArray = new List<Record>(Recs);

            // find smallest and largest value
            int minVal = Recs[0].Key;
            int maxVal = Recs[0].Key;
            for (int i = 1; i < Recs.Count; i++)
            {
                if (Recs[i].Key < minVal) minVal = Recs[i].Key;
                else if (Recs[i].Key > maxVal) maxVal = Recs[i].Key;
            }

            // init array of frequencies
            int[] counts = new int[maxVal - minVal + 1];

            // init the frequencies
            for (int i = 0; i < Recs.Count; i++)
            {
                counts[Recs[i].Key - minVal]++;
            }

            // recalculate
            counts[0]--;
            for (int i = 1; i < counts.Length; i++)
            {
                counts[i] = counts[i] + counts[i - 1];
            }

            // Sort the array
            for (int i = Recs.Count - 1; i >= 0; i--)
            {
                sortedArray[counts[Recs[i].Key - minVal]--] = Recs[i];
            }

            Recs = new List<Record>(sortedArray);
        }
    }
}
