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
        List<int>[][] graph = new List<int>[t][];
        for (int i = 0; i < t; i++)
        {
            n[i] = int.Parse(Console.ReadLine());
            graph[i] = new List<int>[n[i]+1];
            for (int j = 0; j < n[i]+1; j++)
            {
                graph[i][j] = Console.ReadLine().Split(' ').Skip(1).Select(x => int.Parse(x)).ToList();
            }
        }

        Console.ReadLine();
    }
}