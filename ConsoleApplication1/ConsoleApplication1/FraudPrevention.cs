using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

class Solution
{
    private class Record
    {
        public int OrderId { get; private set; }
        public int DealId { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string CreditCardNumber { get; private set; }

        public Record(string commaSeparatedString)
        {
            var line = commaSeparatedString.Split(',').ToArray();
            OrderId = int.Parse(line[0]);
            DealId = int.Parse(line[1]);
            Email = line[2];
            Address = line[3];
            City = line[4];
            State = line[5];
            ZipCode = line[6];
            CreditCardNumber = line[7];
        }
    }

    static void Main(String[] args)
    {
        var n = int.Parse(Console.ReadLine());
        Record[] records = new Record[n];
        for (int i = 0; i < n; i++)
        {
            records[i] = new Record(Console.ReadLine());
        }

        Console.ReadLine();
    }
}