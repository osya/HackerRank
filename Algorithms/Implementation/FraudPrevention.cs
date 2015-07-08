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
        public bool isFraud { get; set; }

        public Record()
        {
            isFraud = false;
        }
        public Record(string commaSeparatedString): this()
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

        public static string EmailMunging(string email)
        {
            var res = email.ToLower();
            res = res.Split('@')[0].Split('+')[0].Replace(".", "") + "@" + res.Split('@')[1];
            return res;
        }

        public static string ZipCodeMunging(string zipCode)
        {
            return zipCode.Replace("-", "");
        }

        public static string AddressMunging(string address)
        {
            var res = address.Replace("Street", "St.").Replace("Road", "Rd.").ToLower();
            return res;
        }

        public static string CityMunging(string city)
        {
            return city.ToLower();
        }

        public static string StateMunging(string state)
        {
            var res = state.Replace("Illinois", "IL").Replace("California", "CA").Replace("New York", "NY").ToLower();
            return res;
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

        var addrDictionary = new Dictionary<Tuple<int, string, string, string, string>, List<int>>();
        var emailDictionary = new Dictionary<Tuple<int, string>, List<int>>(); 
        for (int i = 0; i < n; i++)
        {
            var keyAddr = new Tuple<int, string, string, string, string>(records[i].DealId, Record.AddressMunging(records[i].Address),
                Record.CityMunging(records[i].City), Record.StateMunging(records[i].State), Record.ZipCodeMunging(records[i].ZipCode));
            var keyEmail = new Tuple<int, string>(records[i].DealId, Record.EmailMunging(records[i].Email));
            if (addrDictionary.ContainsKey(keyAddr))
            {
                if (records[i].CreditCardNumber != records[addrDictionary[keyAddr][0]].CreditCardNumber)
                {
                    foreach (var j in addrDictionary[keyAddr])
                    {
                        records[j].isFraud = true;
                    }

                    records[i].isFraud = true;
                }
                else
                {
                    addrDictionary[keyAddr].Add(i);
                }
            }
            else
            {
                addrDictionary[keyAddr] = new List<int>();
                addrDictionary[keyAddr].Add(i);
            }
            if (emailDictionary.ContainsKey(keyEmail))
            {
                if (records[i].CreditCardNumber != records[emailDictionary[keyEmail][0]].CreditCardNumber)
                {
                    foreach (var j in emailDictionary[keyEmail])
                    {
                        records[j].isFraud = true;
                    }
                    records[i].isFraud = true;
                }
                else
                {
                    emailDictionary[keyEmail].Add(i);
                }
            }
            else
            {
                emailDictionary[keyEmail] = new List<int>();
                emailDictionary[keyEmail].Add(i);
            }
        }

        var res = new List<int>();
        for (int i = 0; i < n; i++)
        {
            if (records[i].isFraud)
            {
                res.Add(i+1);
            }
        }
        Console.WriteLine(String.Join(",", res));
        Console.ReadLine();
    }
}