using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Quicksort is a very fast unstable sorting algorithm based on divide and conquer principle.
 * It's asymptotic complexity is O(n^{2}), but the expected complexity is only O(n*log{n}) and quicksort usually outperforms other algorithms in this complexity class such as heapsort or merge sort.
 *
 * Description
 * 1. Algorithm picks one random element of the input array (pivot). In next steps it reorganizes the array in such a way, that all elements with higher value than the pivot 
 * are located before the pivot and all elements with lower value than the pivot are after it. We can see that the pivot itself is located at the correct position (i.e. it is already sorted).
 * 2. Algorithm now repeats the procedure described above on both (unsorted) halves of the array. When the algorithm reaches all the subproblems of size 1, which are solved trivially 
 * (one element itself is already sorted), the whole array is sorted in descending order.
 */

namespace SortApplication
{
    class QuickSort : RecordArray
    {
        public QuickSort()
        {
            Recs = new List<Record>();
        }

        public void SortRecursive(int low, int high)
        {
            if (high > low)
            {
                int partitionIndex = Partition(Recs, low, high);
                SortRecursive(low, partitionIndex - 1);
                SortRecursive(partitionIndex + 1, high);
            }
        }

        private int Partition(List<Record> rec, int low, int high)
        {
            int pivot = rec[high].Key;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (rec[j].Key <= pivot)
                {
                    i++;
                    Swap(rec, i, j);
                }
            }
            Swap(rec, i + 1, high);
            return i + 1;
        }

        private void Swap(List<Record> rec, int i, int j)
        {
            var temp = rec[i];
            rec[i] = rec[j];
            rec[j] = temp;
        }

        public void Sort()
        {
            Stack stack = new Stack();
            int pivot;
            int pivotIndex = 0;
            int leftIndex = pivotIndex + 1;
            int rightIndex = Recs.Count - 1;

            stack.Push(pivotIndex); //кладем в стек левую и правую границу
            stack.Push(rightIndex);

            int leftIndexOfSubSet, rightIndexOfSubset;

            while (stack.Count > 0)
            {
                //левая и правая границы, которые вытащили из стека (для подмассивов)
                rightIndexOfSubset = (int)stack.Pop();
                leftIndexOfSubSet = (int)stack.Pop();

                leftIndex = leftIndexOfSubSet + 1;
                pivotIndex = leftIndexOfSubSet;
                rightIndex = rightIndexOfSubset;

                pivot = Recs[pivotIndex].Key;

                if (leftIndex > rightIndex)
                    continue;

                while (leftIndex < rightIndex)
                {
                    while ((leftIndex <= rightIndex) && (Recs[leftIndex].Key <= pivot))
                        leftIndex++;    //увеличиваем правую границу, чтобы найти элемент больший чем опорный элемент 

                    while ((leftIndex <= rightIndex) && (Recs[rightIndex].Key >= pivot))
                        rightIndex--; //уменьшить правую границу, чтобы найти элемент меньший чем опорный элемент

                    if (rightIndex >= leftIndex)
                        Swap(leftIndex, rightIndex);
                }

                if (pivotIndex <= rightIndex)
                    if (Recs[pivotIndex] > Recs[rightIndex])
                        Swap(pivotIndex, rightIndex);

                if (leftIndexOfSubSet < rightIndex)
                {
                    //задаем границы подмассива
                    stack.Push(leftIndexOfSubSet);
                    stack.Push(rightIndex - 1);
                }

                if (rightIndexOfSubset > rightIndex)
                {
                    //задаем границы подмассива
                    stack.Push(rightIndex + 1);
                    stack.Push(rightIndexOfSubset);
                }
            }
        }
    }
}
