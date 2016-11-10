using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditDistnace
{
    enum Moves
    {
        None,
        Match,
        Insert,
        Delete,
        Replace
    }

    class EditDistanceExample
    {
        static int replaceCost;
        static int insertCost;
        static int deleteCost;

        static string s1;
        static string s2;

        static int[,] dp;
        static Moves[,] moves;

        static void Main(string[] args)
        {
            replaceCost = int.Parse(Console.ReadLine());
            insertCost = int.Parse(Console.ReadLine());
            deleteCost = int.Parse(Console.ReadLine());

            s1 = Console.ReadLine();
            s2 = Console.ReadLine();

            dp = new int[s2.Length + 1, s1.Length + 1];
            moves = new Moves[s2.Length + 1, s1.Length + 1];
            for (int i = 1; i < dp.GetLength(0); i++)
            {
                dp[i, 0] = i * insertCost;
            }

            for (int j = 1; j < dp.GetLength(1); j++)
            {
                dp[0, j] = j * deleteCost;
            }

            for (int i = 1; i < dp.GetLength(0); i++)
            {
                for (int j = 1; j < dp.GetLength(1); j++)
                {
                    var min = int.MaxValue;
                    var move = Moves.None;
                    if (s2[i - 1] == s1[j - 1])
                    {
                        min = dp[i - 1, j - 1];
                        move = Moves.Match;
                    }
                    else
                    {
                        if (dp[i - 1, j - 1] + replaceCost < min)
                        {
                            min = dp[i - 1, j - 1] + replaceCost;
                            move = Moves.Replace;
                        }
                        if (dp[i - 1, j] + insertCost < min)
                        {
                            min = dp[i - 1, j] + insertCost;
                            move = Moves.Insert;
                        }
                        if (dp[i, j - 1] + deleteCost < min)
                        {
                            min = dp[i, j - 1] + deleteCost;
                            move = Moves.Delete;
                        }
                    }

                    dp[i, j] = min;
                    moves[i, j] = move;
                }
            }

            Console.WriteLine("Minimum edit distance: {0}", dp[s2.Length, s1.Length]);
            //PrintDp();
            var result = ReconstructSolution();
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }

        static void PrintDp()
        {
            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int j = 0; j < dp.GetLength(1); j++)
                {
                    Console.Write(dp[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        static string[] ReconstructSolution()
        {
            int i = dp.GetLength(0) - 1;
            int j = dp.GetLength(1) - 1;
            var result = new Stack<string>();
            while (i > 0 && j > 0)
            {
                switch (moves[i, j])
                {
                    case Moves.Match:
                        i--;
                        j--;
                        break;
                    case Moves.Replace:
                        result.Push(string.Format("REPLACE({0}, {1})", j - 1, s2[i - 1]));
                        j--;
                        i--;
                        break;
                    case Moves.Insert:
                        result.Push(string.Format("INSERT({0}, {1})", j - 1, s2[i - 1]));
                        i--;
                        break;
                    case Moves.Delete:
                        result.Push(string.Format("DELETE({0})", j - 1));
                        j--;
                        break;
                    default:
                        throw new ArgumentException("Invalid move");
                }
            }

            for (int k = i; k > 0; k--)
            {
                result.Push(string.Format("INSERT({0}, {1})", j, s2[k - 1]));
            }

            for (int k = j; k > 0; k--)
            {
                result.Push(string.Format("DELETE({0})", k - 1));
            }

            return result.ToArray();
        }
    }
}
