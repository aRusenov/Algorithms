using System;
using System.Collections.Generic;

namespace SortingAlgorithmsPack
{
    class SortingMain
    {
        static void Main()
        {
            var numbers = new List<int> { 7, 2, -5, 10, 1, 0, 9, 4 };
            var sortingAlgorithm = new HeapSort<int>();
            sortingAlgorithm.Sort(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
