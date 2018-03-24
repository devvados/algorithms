using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Selection sort is a simple sorting algorithm with asymptotic complexity O(n^{2}). In comparison with other quadratic sorting algorithms 
 * it almost always outperforms bubble sort, but it is usually slower than insertion sort. The advantage of selection sort over algorithms with O(n*log{n}) 
 * (quicksort, heapsort, merge sort) asymptotic complexity is it's constant memory complexity.
 *
 * Description
 * 1. The idea of selection sort is, that if we sort the array from largest to smallest element, than the first element of the sorted array will be the one with the largest value. 
 * Second will be the largest element of the rest of the array. Third will be the largest element of the new rest of the array (initial array without the two already sorted elements)...
 * 2. So we can iteratively select the largest element of the (reduced) array, swap it with the first element and than reduce the problem size by 1 
 * (sort only the rest of the array). When there remains only one element to sort, the algorithm terminates.
 */

namespace SortApplication
{
    class SelectionSort : RecordArray
    {
        public SelectionSort()
        {
            Recs = new List<Record>();
        }

        public void Sort()
        {
            Stack<Record> stack = new Stack<Record>();

            for (int i = Recs.Count - 1; i >= 0; i--)
            {
                int maxRecKey = GetMaxKey();
                int maxRecKeyIndex = Recs.FindLastIndex(x => x.Key == maxRecKey);

                Swap(i, maxRecKeyIndex);

                stack.Push(Recs[i]);
                Recs.RemoveAt(i);
            }
            Recs = new List<Record>(stack);
        }
    }
}
