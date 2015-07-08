using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

class Solution
{
    static void Main(String[] args)
    {
        var t = int.Parse(Console.ReadLine());
        int[] r1 = new int[t];
        int[] c1 = new int[t];
        int[] r2 = new int[t];
        int[] c2 = new int[t];
        string[][] g = new string[t][];
        string[][] p = new string[t][];
        for (int i = 0; i < t; i++)
        {
            var line = Console.ReadLine().Split(' ');
            r1[i] = int.Parse(line[0]);
            c1[i] = int.Parse(line[1]);
            g[i] = new string[r1[i]];
            for (int j = 0; j < r1[i]; j++)
            {
                g[i][j] = Console.ReadLine();
            }
            line = Console.ReadLine().Split(' ');
            r2[i] = int.Parse(line[0]);
            c2[i] = int.Parse(line[1]);
            p[i] = new string[r2[i]];
            for (int j = 0; j < r2[i]; j++)
            {
                p[i][j] = Console.ReadLine();
            }
        }

        bool isContains, isFind;
        for (int m = 0; m < t; m++)
        {
            isFind = false;
            for (int i = 0; i <= r1[m]-r2[m]; i++)
            {
                for (int j = 0; j <= c1[m]-c2[m]; j++)
                {
                    isContains = true;
                    for (int k = 0; k < r2[m]; k++)
                    {
                        for (int l = 0; l < c2[m]; l++)
                        {
                            if (g[m][i + k][j + l] != p[m][k][l])
                            {
                                isContains = false;
                                break;
                            }
                        }
                        if (!isContains)
                        {
                            break;
                        }
                    }
                    if (isContains)
                    {
                        isFind = true;
                        Console.WriteLine("YES");
                        break;
                    }
                }
                if (isFind)
                {
                    break;
                }
            }
            if (!isFind)
            {
                Console.WriteLine("NO");
            }
        }

        Console.ReadLine();
    }
}