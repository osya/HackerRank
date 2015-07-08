using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    static void Main(String[] args)
    {
        var t = int.Parse(Console.ReadLine());
        int[] n = new int[t];
        int[] k = new int[t];
        int[][] time = new int[t][];
        for (int i = 0; i < t; i++)
        {
            var line = Console.ReadLine().Split(' ');
            n[i] = int.Parse(line[0]);
            k[i] = int.Parse(line[1]);
            time[i] = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        }
        for (int i = 0; i < t; i++)
        {
            var c = 0;
            for (int j = 0; j < n[i]; j++)
            {
                if (time[i][j] <= 0)
                {
                    c++;
                }
            }
            if (c < k[i])
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        Console.ReadLine();
    }
}