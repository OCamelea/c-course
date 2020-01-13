﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CS.Impl._03_Linq
{
    public class Linq
    {
        public IEnumerable<string> FindStringsWhichStartsAndEndsWithSpecificCharacter(string startCharacter, string endCharacter, IEnumerable<string> strings)
        {
           return strings.Where(word => word.StartsWith(startCharacter) && word.EndsWith(endCharacter));
        }

        public IEnumerable<int> GetGreaterNumbers(int limit, IEnumerable<int> numbers)
        {
            return numbers.Where(number => number > limit).ToList();
        }

        public IEnumerable<int> GetTopNRecords(int limit, IEnumerable<int> numbers)
        {
           return numbers.OrderByDescending(number => number).Take(limit);
        }

        public IDictionary<string, int> GetFileCountByExtension(IEnumerable<string> files)
        {
            //List<string> extensionsList = files.GroupBy (file => file.Split("."));
            throw new NotImplementedException();
        }

        public IEnumerable<Tuple<string, string, int, double>> GetFinalReceipe(List<Item> items, List<Client> clients, List<Purchase> purchases)
        {
            throw new NotImplementedException();
        }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public double Price { get; set; }
    }

    public class Purchase
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public int ClientId { get; set; }
    }

    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
