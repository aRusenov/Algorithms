namespace FloydWarshall
{
    using System;

    public class FloydWarshallExample
    {
        private const double Inf = double.PositiveInfinity;

        static void Main()
        {
            var graph = new double[,]
            {
                //0    1    2    3
                { 0,   4,  -2,   Inf },
                { Inf, 0,   3,   -1 },
                { Inf, Inf, 0,   2 },
                { Inf, Inf, Inf, 0 }
            };

            var dist = graph.Clone() as double[,];
            var vertices = graph.GetLength(0);
            for (int k = 0; k < vertices; k++)
            {
                for (int i = 0; i < vertices; i++)
                {
                    for (int j = 0; j < vertices; j++)
                    {
                        if (dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                        }
                    }
                }
            }

            Console.WriteLine("Shortest path between (0..3): {0}", dist[0, 3]);
        }
    }
}
