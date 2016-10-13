using System;
using System.Collections.Generic;

namespace SortingAlgorithmsPack
{
    public class SelectionSort<T> : SortingAlgorithm<T>
        where T : IComparable<T>
    {
        public override bool Stable
        {
            get
            {
                return false;
            }
        }

        public override void Sort(List<T> data)
        {
            var size = data.Count;
            for (int i = 0; i < size; i++)
            {
                var min = i;
                for (int j = i + 1; j < size; j++)
                {
                    if (data[j].CompareTo(data[min]) < 0)
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    Swap(i, min, data);
                }
            }
        }
    }
}
