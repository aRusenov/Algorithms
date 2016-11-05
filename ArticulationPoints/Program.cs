using System;
using System.Collections.Generic;

namespace ArticulationPoints
{
    class Program
    {
        static int[][] graph;
        static int[] low;
        static int[] depths;
        static bool[] visited;
        static List<int> articulationNodes;

        static void Main(string[] args)
        {
            graph = new int[][]
            {
                new int[] { 1, 9, 7, 2, 6 },
                new int[] { 0, 6 },
                new int[] { 7, 0 },
                new int[] { 4 },
                new int[] { 6, 3, 10},
                new int[] { 7 },
                new int[] { 0, 1, 10, 4, 8, 11 },
                new int[] { 5, 9, 0, 2 },
                new int[] { 11, 6 },
                new int[] { 7, 0 },
                new int[] { 6, 4 },
                new int[] { 8, 6 }
            };

            // Targjan's algorithm
            visited = new bool[graph.Length];
            low = new int[graph.Length];
            depths = new int[graph.Length];
            for (int i = 0; i < low.Length; i++)
                low[i] = -1;
            
            articulationNodes = new List<int>();

            Tarjan(5, -1, 1);

            Console.WriteLine("Articulation points: {0}", 
                string.Join(" ", articulationNodes));
        }

        static void Tarjan(int node, int parent, int depth)
        {
            visited[node] = true;
            low[node] = depth;
            depths[node] = depth;
            bool isArticulation = false;
            for (int i = 0; i < graph[node].Length; i++)
            {
                var child = graph[node][i];
                if (!visited[child])
                {
                    Tarjan(child, node, depth + 1);
                    if (low[child] >= depth)
                    {
                        isArticulation = true;
                    }

                    low[node] = Math.Min(low[node], low[child]);
                } 
                else if (child != parent)
                {
                    low[node] = Math.Min(low[node], depths[child]);
                }
            }

            if ((parent != -1 && isArticulation) || 
                (parent == -1 && graph[node].Length > 1))
            {
                articulationNodes.Add(node);
            }
        }
    }
}
