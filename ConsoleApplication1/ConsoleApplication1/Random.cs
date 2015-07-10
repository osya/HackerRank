using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    private static Tuple<int, int> getLR(Random rnd, int n)
    {
        int l = 0, r = 0;
        while (!(l < r))
        {
            l = rnd.Next(n);
            r = rnd.Next(n);
        }
        return new Tuple<int, int>(l, r);
    }

    static void Main(String[] args)
    {
        var line = Console.ReadLine().Split(' ');

        var n = int.Parse(line[0]);
        var a = int.Parse(line[1]);
        var b = int.Parse(line[2]);
        var d = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        var rnd = new Random();
        Tuple<int, int> tup;
        for (int i = 0; i < a; i++)
        {
            tup = getLR(rnd, n);
            var t = d[tup.Item1];
            d[tup.Item1] = d[tup.Item2];
            d[tup.Item2] = t;
        }
        for (int i = 0; i < b; i++)
        {
            tup = getLR(rnd, n);
            var d2 = new int[tup.Item2 - tup.Item1 + 1];
            Array.Copy(d, tup.Item1, d2, 0, tup.Item2 - tup.Item1 + 1);
            d2 = d2.Reverse().ToArray();
            Array.Copy(d2, 0, d, tup.Item1, tup.Item2 - tup.Item1 + 1);
        }
        tup = getLR(rnd, n);
        var d3 = new int[tup.Item2 - tup.Item1 + 1];
        Array.Copy(d, tup.Item1, d3, 0, tup.Item2 - tup.Item1 + 1);
        Console.WriteLine(d3.Sum().ToString());

        Console.ReadLine();
    }
}