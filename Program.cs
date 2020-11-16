using System;
using System.Linq;

namespace QueenMovementAlgorithmQUIZ
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 8;
            int c = 4;
            int r = 4;
            int k = 0;

            var count = PossibleMovesOfQueentWithoutObstacles(n, r, c);
            Console.WriteLine($"Count of queen Avaliable Movements on chessBoard of {n}*{n} " +
                $"on postion {r}*{c}:{count}");
            var engel = new int[n + 1, n + 1];

            engel[3, 5] = 1;
            k = 1;
            count = PossibleMovesOfQueentWithObstacles(n, r, c, k, engel);
            Console.WriteLine($"Count of queen Avaliable Movements on chessBoard of {n}*{n} " +
             $"on postion {r}*{c}:{count}");
            n = 5;
            c = 3;
            r = 4;



            engel = new int[n + 1, n + 1];

            engel[4, 2] = 1;
            engel[2, 3] = 1;
            engel[5, 5] = 1;
            k = 3;
            count = PossibleMovesOfQueentWithObstacles(n, r, c, k, engel);
            Console.WriteLine($"Count of queen Avaliable Movements on chessBoard of {n}*{n} " +
             $"on postion {r}*{c}:{count}");
            Console.ReadLine();
        }

        /// <summary>
        /// SORU 1
        /// Compute Count of squares that queen can move on an empty Chess board 
        /// according to the following Parameters
        /// </summary>
        /// <param name="n">chess board Dimensions n*n</param>
        /// <param name="r">represent position of queen vertically(Y AXIS)</param>
        /// <param name="c">represent position of queen horizontally ( X AXIS)</param>
        /// <returns>Count Possible moves of the queen</returns>
        public static int PossibleMovesOfQueentWithoutObstacles(int n, int r, int c)
        {
            // calculate all the possible movements of queen on all direactions
            int leftDown = Math.Min(c - 1, r - 1);
            int left = c - 1;
            int leftUp = Math.Min(c - 1, n - r);
            int up = n - r;
            int rightUp = Math.Min(n - c, n - r);
            int right = n - c;
            int rightDown = Math.Min(n - c, r - 1);
            int down = r - 1;


            int MovCount = leftUp + left + leftDown + down + rightDown + right + rightUp + up;
            return MovCount;
        }
        /// <summary>
        /// SORU 2
        /// </summary>
        /// <param name="n">chess board Dimensions n*n</param>
        /// <param name="r">represent position of queen vertically(Y AXIS)</param>
        /// <param name="c">represent position of queen horizontally ( X AXIS)</param>
        /// <param name="k">number of Obstacles</param>
        /// <param name="engel">Obstacles Position Array</param>
        /// <returns>Count Possible moves of the queen</returns>
        public static int PossibleMovesOfQueentWithObstacles(int n, int r, int c, int k, int[,] engel)
        {
            // calculate all the possible movements of queen on all directions
            int leftDown = Math.Min(c - 1, r - 1);
            int left = c - 1;
            int leftUp = Math.Min(c - 1, n - r);
            int up = n - r;
            int rightUp = Math.Min(n - c, n - r);
            int right = n - c;
            int rightDown = Math.Min(n - c, r - 1);
            int down = r - 1;

            for (int i = 1; i < engel.GetLength(0); i++)
            {
                if (k == 0)
                {
                    break;
                }
                for (int j = 1; j < engel.GetLength(1); j++)
                {

                    if (engel[i, j] == 1)
                    {
                        k--;
                        int x = j - c;
                        int y = i - r;

                        if (x == 0)
                        {
                            if (y > 0)
                            {
                                right = Math.Min(right, y - 1);
                            }
                            if (y < 0)
                            {
                                down = Math.Min(down, Math.Abs(y) - 1);

                            }
                        }
                        if (y == 0)
                        {
                            if (x > 0)
                            {
                                right = Math.Min(right, x - 1);
                            }
                            if (x < 0)
                            {
                                left = Math.Min(left, Math.Abs(x) - 1);

                            }
                        }

                        if (x < 0 && y < 0 && Math.Abs(x) == Math.Abs(y))
                        {
                            leftDown = Math.Min(leftDown, Math.Abs(x) - 1);
                        }
                        if (x < 0 && y > 0 && Math.Abs(x) == Math.Abs(y))
                        {
                            leftUp = Math.Min(leftUp, Math.Abs(x) - 1);
                        }
                        if (x > 0 && y < 0 && Math.Abs(x) == Math.Abs(y))
                        {
                            rightDown = Math.Min(rightDown, Math.Abs(x) - 1);
                        }
                        if (x > 0 && y > 0 && Math.Abs(x) == Math.Abs(y))
                        {
                            rightUp = Math.Min(rightUp, Math.Abs(x) - 1);
                        }
                    }
                }
            }

            int MovCount = leftDown + left + leftUp + up + rightUp + right + rightDown + down;


            return MovCount;
        }
    }
}
