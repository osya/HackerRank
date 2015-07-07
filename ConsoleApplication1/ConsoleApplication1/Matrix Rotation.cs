using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    static void Main(String[] args)
    {
        var line = Console.ReadLine().Split(' ');
        var m = int.Parse(line[0]);
        var n = int.Parse(line[1]);
        var r = int.Parse(line[2]);
        int[][] a = new int[m][];
        for (int i = 0; i < m; i++)
        {
            a[i] = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        }

        int[][] aNew = new int[m][];
        for (int i = 0; i < m; i++)
        {
            aNew[i] = new int[n];
        }
        
        for (int k = 0; k < r; k++)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int iNew = i, jNew = j, c;
                    c = Math.Min(Math.Min(i, j), Math.Min(n-i - 1, n-j - 1));   // c- номер кольца начиная с 0
                    if ((j == c) && (i < m - c - 1))
                    {
                        iNew = i + 1;
                    }
                    else if ((j == n-c-1) && (i > c))
                    {
                        iNew = i - 1;
                    }
                    else if ((i == c) && (j>c))
                    {
                        jNew = j - 1;
                    }
                    else if ((i == m - c - 1) && (j < n-c-1))
                    {
                        jNew = j + 1;
                    }
                    aNew[iNew][jNew] = a[i][j];
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i][j] = aNew[i][j];
                }
            }
        }

        for (int i = 0; i < m; i++)
        {
            Console.WriteLine(String.Join(" ", a[i]));
        }
        Console.ReadLine();
    }
}