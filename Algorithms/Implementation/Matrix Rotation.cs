using System;
using System.Collections.Generic;
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

        // Строим кольца
        var ringCount = Math.Min(m / 2 + m % 2, n / 2 + n % 2);
        
        List<int>[] rings = new List<int>[ringCount];
        for (int k = 0; k < ringCount; k++)
        {
            rings[k] = new List<int>();
            for (int j = k; j <= n-k-1; j++)
            {
                rings[k].Add(a[k][j]);
            }
            for (int i = k+1; i <= m-k-1; i++)
            {
                rings[k].Add(a[i][n-k-1]);
            }
            for (int j = n-k-2; j >= k; j--)
            {
                rings[k].Add(a[m-k-1][j]);
            }
            for (int i = m-k-2; i >= k+1; i--)
            {
                rings[k].Add(a[i][k]);
            }
        }

        // Вычисляем "головы" каждого кольца
        int[] heads = new int[ringCount];
        for (int i = 0; i < heads.Length; i++)
        {
            heads[i] = r%rings[i].Count;
        }

        // Строим результирующую матрицу по кольца и их новым "головам"
        int[][] aNew = new int[m][];
        for (int i = 0; i < m; i++)
        {
            aNew[i] = new int[n];
        }
        for (int k = 0; k < ringCount; k++)
        {
            var curInd = heads[k];
            for (int j = k; j <= n-k-1; j++)
            {
                aNew[k][j] = rings[k][curInd];
                curInd = (curInd + 1)%rings[k].Count;
            }
            for (int i = k+1; i <= m-k-1; i++)
            {
                aNew[i][n-k-1] = rings[k][curInd];
                curInd = (curInd + 1)%rings[k].Count;
            }
            for (int j = n-k-2; j >= k; j--)
            {
                aNew[m-k-1][j] = rings[k][curInd];
                curInd = (curInd + 1)%rings[k].Count;
            }
            for (int i = m-k-2; i >= k+1; i--)
            {
                aNew[i][k] = rings[k][curInd];
                curInd = (curInd + 1)%rings[k].Count;
            }
        }

        for (int i = 0; i < m; i++)
        {
            Console.WriteLine(String.Join(" ", aNew[i]));
        }
        Console.ReadLine();
    }
}