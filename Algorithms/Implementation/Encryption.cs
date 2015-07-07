using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;

class Solution
{
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        var msg = Console.ReadLine();

        int cols = (int)Math.Sqrt(msg.Length);
        int rows = (int)Math.Ceiling((double)msg.Length / cols);
        while (rows > Math.Ceiling(Math.Sqrt(msg.Length)))
        {
            rows--;
            cols++;
        }

        string res = "";
        for (int i = 0; i < rows; i++)
        {
            string line = "";
            for (int j = 0; j < cols; j++)
            {
                if (j*rows + i < msg.Length)
                    line += msg[j*rows + i];
            }
            res += line + " ";
        }
        Console.WriteLine(res.Substring(0, res.Length-1));
        Console.ReadLine();
    }
}