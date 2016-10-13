using System;
using System.Collections.Generic;

namespace SortingAlgorithmsPack
{
    public class MergeSort<T> : SortingAlgorithm<T>
        where T : IComparable<T>
    {
        public override bool Stable
        {
            get
            {
                return true;
            }
        }

        public override void Sort(List<T> data)
        {
            Merge(data, 0, data.Count - 1);
        }

        private void Merge(List<T> collection, int start, int end)
        {
            if (start == end)
            {
                return;
            }

            int mid = start + (end - start) / 2;
            Merge(collection, start, mid);
            Merge(collection, mid + 1, end);

            var temp = new T[end - start + 1];
            int left = start, right = mid + 1, k = 0;
            while (left <= mid && right <= end)
            {
                if (collection[left].CompareTo(collection[right]) <= 0)
                {
                    temp[k] = collection[left++];
                }
                else
                {
                    temp[k] = collection[right++];
                }

                k++;
            }

            while (left <= mid)
            {
                temp[k++] = collection[left++];
            }

            while (right <= end)
            {
                temp[k++] = collection[right++];
            }

            for (int i = 0, j = start; i < temp.Length; i++, j++)
            {
                collection[j] = temp[i];
            }
        }
    }
}
