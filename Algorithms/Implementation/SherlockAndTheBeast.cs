using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        var t = int.Parse(Console.ReadLine());
        int[] nArr = new int[t];
        for (int i = 0; i < t; i++)
        {
            nArr[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < t; i++)
        {
            var res = "-1";

            for (int j = 0; j <= nArr[i]/5; j++)
            {
                if ((nArr[i] - j*5)%3 == 0)
                {
                    res = new String('5', nArr[i] - j*5) + new String('3', j*5);
                    break;
                }
            }
            Console.WriteLine(res);
        }

        Console.WriteLine();
        Console.ReadLine();
    }
}