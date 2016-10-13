using System;
using System.Collections.Generic;

namespace SortingAlgorithmsPack
{
    class SortingMain
    {
        static void Main()
        {
            var numbers = new List<int> { 7, 2, -5, 10, 1, 0, 9, 4, 3, 20 };
            var sortingAlgorithm = new QuickSort<int>();
            sortingAlgorithm.Sort(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
