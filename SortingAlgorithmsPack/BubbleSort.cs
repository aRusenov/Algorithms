using System;
using System.Collections.Generic;

namespace SortingAlgorithmsPack
{
    public class BubbleSort<T> : SortingAlgorithm<T>
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
            var size = data.Count;
            var swapped = true;
            while (swapped)
            {
                swapped = false;
                for (int i = 0; i < size - 1; i++)
                {
                    if (data[i].CompareTo(data[i + 1]) > 0)
                    {
                        Swap(i, i + 1, data);
                        swapped = true;
                    }
                }
            }
        }
    }
}
