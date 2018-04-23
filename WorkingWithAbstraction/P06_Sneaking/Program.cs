using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static char[][] matrix;
        static void Main()
        {
            FillMatrix();
           
            var moves = Console.ReadLine().ToCharArray();
            int[] samPosition = new int[2];
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                    }
                }
            }
            for (int i = 0; i < moves.Length; i++)
            {

                MoveEnemis();
                int[] getEnemy = new int[2];
                if (IfEnemisKillSam(samPosition, getEnemy))
                {
                    break;
                }
                MoveSam(moves[i], samPosition, getEnemy);
                if (IfSamKillNikoladze(samPosition, getEnemy))
                {
                    break;
                }
            }
        }

        private static bool IfSamKillNikoladze(int[] samPosition, int[] getEnemy)
        {
            if (matrix[getEnemy[0]][getEnemy[1]] == 'N' && samPosition[0] == getEnemy[0])
            {
                matrix[getEnemy[0]][getEnemy[1]] = 'X';
                Console.WriteLine("Nikoladze killed!");
                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        Console.Write(matrix[row][col]);
                    }
                    Console.WriteLine();
                }
                return true;
            }
            return false;
        }

        private static bool IfEnemisKillSam(int[] samPosition, int[] getEnemy)
        {
            for (int j = 0; j < matrix[samPosition[0]].Length; j++)
            {
                if (matrix[samPosition[0]][j] != '.' && matrix[samPosition[0]][j] != 'S')
                {
                    getEnemy[0] = samPosition[0];
                    getEnemy[1] = j;
                }
            }
            if (samPosition[1] < getEnemy[1] && matrix[getEnemy[0]][getEnemy[1]] == 'd' && getEnemy[0] == samPosition[0])
            {
                matrix[samPosition[0]][samPosition[1]] = 'X';
                Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        Console.Write(matrix[row][col]);
                    }
                    Console.WriteLine();
                }
                return true;
            }
            else if (getEnemy[1] < samPosition[1] && matrix[getEnemy[0]][getEnemy[1]] == 'b' && getEnemy[0] == samPosition[0])
            {
                matrix[samPosition[0]][samPosition[1]] = 'X';
                Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        Console.Write(matrix[row][col]);
                    }
                    Console.WriteLine();
                }
                return true;
            }
            return false;
        }     

        private static void MoveSam(char v, int[] samPosition, int[] getEnemy)
        {
            matrix[samPosition[0]][samPosition[1]] = '.';
            switch (v)
            {
                case 'U':
                    samPosition[0]--;
                    break;
                case 'D':
                    samPosition[0]++;
                    break;
                case 'L':
                    samPosition[1]--;
                    break;
                case 'R':
                    samPosition[1]++;
                    break;
                default:
                    break;
            }
            matrix[samPosition[0]][samPosition[1]] = 'S';
            for (int j = 0; j < matrix[samPosition[0]].Length; j++)
            {
                if (matrix[samPosition[0]][j] != '.' && matrix[samPosition[0]][j] != 'S')
                {
                    getEnemy[0] = samPosition[0];
                    getEnemy[1] = j;
                }
            }
        }

        private static void MoveEnemis()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'b')
                    {
                        if (row >= 0 && row < matrix.Length && col + 1 >= 0 && col + 1 < matrix[row].Length)
                        {
                            matrix[row][col] = '.';
                            matrix[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            matrix[row][col] = 'd';
                        }
                    }
                    else if (matrix[row][col] == 'd')
                    {
                        if (row >= 0 && row < matrix.Length && col - 1 >= 0 && col - 1 < matrix[row].Length)
                        {
                            matrix[row][col] = '.';
                            matrix[row][col - 1] = 'd';
                        }
                        else
                        {
                            matrix[row][col] = 'b';
                        }
                    }
                }
            }
        }

        private static void FillMatrix()
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new char[n][];

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                matrix[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = input[col];
                }
            }
        }
    }
}
