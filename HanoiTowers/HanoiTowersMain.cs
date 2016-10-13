using System;
using System.Collections.Generic;
using System.Linq;

namespace HanoiTowers
{
    class HanoiTowersMain
    {
        const int DiskCount = 3;

        static void Main()
        {
            var disks = Enumerable.Range(1, DiskCount).Reverse();
            var source = new Stack<int>(disks);
            var aux = new Stack<int>();
            var dest = new Stack<int>();
            Solve(DiskCount, source, dest, aux);

            PrintSolution(source, aux, dest);
        }

        static void Solve(int disk, Stack<int> source, Stack<int> dest, Stack<int> aux)
        {
            if (disk == 1)
            {
                dest.Push(source.Pop());
            }
            else
            {
                Solve(disk - 1, source, aux, dest);
                dest.Push(source.Pop());
                Solve(disk - 1, aux, dest, source);
            }
        }

        private static void PrintSolution(Stack<int> source, Stack<int> aux, Stack<int> dest)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < DiskCount; i++)
            {
                Console.WriteLine("{0} {1} {2}", PopIfAvailable(source), PopIfAvailable(aux), PopIfAvailable(dest));
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("| | |");
        }

        static string PopIfAvailable(Stack<int> rod)
        {
            return rod.Count > 0 ? rod.Pop().ToString() : " ";
        }
    }
}
