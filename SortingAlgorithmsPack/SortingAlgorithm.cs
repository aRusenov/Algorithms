using System;
using System.Collections;
using System.Collections.Generic;

namespace SortingAlgorithmsPack
{
    public abstract class SortingAlgorithm<T> where T : IComparable<T>
    {
        public abstract bool Stable { get; }

        public abstract void Sort(List<T> data);

        protected void Swap(int i, int j, List<T> collection)
        {
            var oldValue = collection[i];
            collection[i] = collection[j];
            collection[j] = oldValue;
        }
    }
}
