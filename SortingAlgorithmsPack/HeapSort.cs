using System;
using System.Collections.Generic;

namespace SortingAlgorithmsPack
{
    public class HeapSort<T> : SortingAlgorithm<T>
        where T : IComparable<T>
    {
        public override bool IsStable
        {
            get
            {
                return true;
            }
        }

        public override void Sort(List<T> data)
        {
            var maxHeap = new MaxHeap<T>(data);
            for (int i = data.Count - 1; i >= 0; i--)
            {
                var item = maxHeap.ExtractMax();
                data[i] = item;
            }
        }

        private class MaxHeap<T> where T : IComparable<T>
        {
            private List<T> heap;
            private int count;

            public MaxHeap(List<T> collection)
            {
                this.heap = collection;
                this.count = collection.Count;
                for (int i = collection.Count / 2; i >= 0; i--)
                {
                    HeapifyUp(i);
                }
            }

            public T ExtractMax()
            {
                var max = this.heap[0];
                var last = this.heap[this.count - 1];
                this.heap[0] = last;
                this.count--;

                if (this.count > 0)
                {
                    this.HeapifyDown(0);
                }

                return max;
            }

            private void HeapifyDown(int i)
            {
                var left = (2 * i) + 1;
                var right = (2 * i) + 2;
                var largest = i;

                if (left < this.count && this.heap[left].CompareTo(this.heap[largest]) > 0)
                {
                    largest = left;
                }

                if (right < this.count && this.heap[right].CompareTo(this.heap[largest]) > 0)
                {
                    largest = right;
                }

                if (largest != i)
                {
                    T old = this.heap[i];
                    this.heap[i] = this.heap[largest];
                    this.heap[largest] = old;
                    this.HeapifyDown(largest);
                }
            }

            private void HeapifyUp(int i)
            {
                var parent = (i - 1) / 2;
                while (i > 0 && this.heap[i].CompareTo(this.heap[parent]) > 0)
                {
                    T old = this.heap[i];
                    this.heap[i] = this.heap[parent];
                    this.heap[parent] = old;

                    i = parent;
                    parent = (i - 1) / 2;
                }
            }
        }
    }
}
