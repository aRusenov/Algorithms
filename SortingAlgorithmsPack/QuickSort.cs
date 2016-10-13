using System;
using System.Collections.Generic;

namespace SortingAlgorithmsPack
{
    public class QuickSort<T> : SortingAlgorithm<T>
        where T : IComparable<T>
    {
        public override bool Stable
        {
            get
            {
                return false;
            }
        }

        public override void Sort(List<T> list)
        {
            Quicksort(list, 0, list.Count - 1);
        }

        private void Quicksort(List<T> list, int start, int end)
        {
            if (start < end)
            {
                var pivotIndex = Partition(list, start, end);
                Quicksort(list, start, pivotIndex);
                Quicksort(list, pivotIndex + 1, end);
            }
        }

        private int Partition(List<T> list, int start, int end)
        {
            var pivot = list[start];
            var store = start + 1;
            for (int i = store; i <= end; i++)
            {
                if (list[i].CompareTo(pivot) <= 0)
                {
                    Swap(i, store, list);
                    store++;
                }
            }

            store--;
            Swap(start, store, list);

            return store;
        }
    }
}
