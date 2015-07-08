using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

class Solution
{
    private string checkRow(int pRow, int gRow, int gCol, string[] g, string[] p)
    {
        if (g[gRow].Substring(gCol, p[0].Length) == p[pRow])
        {
            if (pRow == p.Length)
            {
                return "YES";
            }
            else if ((pRow < p.Length) && (gRow < g.Length))
            {
                return checkRow(pRow + 1, gRow + 1, gCol, g, p);
            }
        }
        else
        {
            // Найти все вхождения подстроки
            g[gRow].
        }
    }

    static void Main(String[] args)
    {
        using (StreamReader sr = new StreamReader("data.txt"))
        {
            var t = int.Parse(sr.ReadLine());
            int[] r1 = new int[t];
            int[] c1 = new int[t];
            int[] r2 = new int[t];
            int[] c2 = new int[t];
            string[][] g = new string[t][];
            string[][] p = new string[t][];
            for (int i = 0; i < t; i++)
            {
                var line = sr.ReadLine().Split(' ');
                r1[i] = int.Parse(line[0]);
                c1[i] = int.Parse(line[1]);
                g[i] = new string[r1[i]];
                for (int j = 0; j < r1[i]; j++)
                {
                    g[i][j] = sr.ReadLine();
                }
                line = sr.ReadLine().Split(' ');
                r2[i] = int.Parse(line[0]);
                c2[i] = int.Parse(line[1]);
                p[i] = new string[r2[i]];
                for (int j = 0; j < r2[i]; j++)
                {
                    p[i][j] = sr.ReadLine();
                }
            }

            for (int i = 0; i <= r1[i]-r2[i]; i++)
            {
                for (int j = 0; j <= c1[i]-c2[i]; j++)
                {
                    
                }
            }
        }

        Console.ReadLine();
    }
}