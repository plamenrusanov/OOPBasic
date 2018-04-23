using System;
using System.Linq;

class Program
{
    static int[,] galaxy;
    
    static void Main()
    {
        int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        FillGalaxy(dimestions);

        string command;
        long ivoPower = 0;
        while ((command = Console.ReadLine()) != "Let the Force be with you")
        {
            int[] ivoS = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[] evil = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            EvilCrossesGalaxy(evil);

            ivoPower += IvoCollectPower(ivoS);
        }

        Console.WriteLine(ivoPower);

    }

    private static long IvoCollectPower(int[] ivoS)
    {
        int ivoStartRow = ivoS[0];
        int ivoStartCol = ivoS[1];
        long power = 0;
        while (ivoStartRow >= 0 && ivoStartCol < galaxy.GetLength(1))
        {
            if (ivoStartRow >= 0 && ivoStartRow < galaxy.GetLength(0) && ivoStartCol >= 0 && ivoStartCol < galaxy.GetLength(1))
            {
                power += galaxy[ivoStartRow, ivoStartCol];
            }

            ivoStartCol++;
            ivoStartRow--;
        }
        return power;
    }

    private static void EvilCrossesGalaxy(int[] evil)
    {
        int evilStartRow = evil[0];
        int evilStartCol = evil[1];

        while (evilStartRow >= 0 && evilStartCol >= 0)
        {
            if (evilStartRow >= 0 && evilStartRow < galaxy.GetLength(0) && evilStartCol >= 0 && evilStartCol < galaxy.GetLength(1))
            {
                galaxy[evilStartRow, evilStartCol] = 0;
            }
            evilStartRow--;
            evilStartCol--;
        }

    }

    private static void FillGalaxy(int[] dimestions)
    {
        int rowLength = dimestions[0];
        int colLength = dimestions[1];

        galaxy = new int[rowLength, colLength];

        int value = 0;
        for (int row = 0; row < rowLength; row++)
        {
            for (int col = 0; col < colLength; col++)
            {
                galaxy[row, col] = value++;
            }
        }
    }
}

