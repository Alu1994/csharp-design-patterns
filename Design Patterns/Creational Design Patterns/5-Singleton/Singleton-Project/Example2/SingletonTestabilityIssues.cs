using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace DesignPatterns_5_Singleton.Example2
{
    class SingletonTestabilityIssues
    {
        static void Mains(string[] args)
        {
            var db = SingletonDatabase.Instance;
            var city = "Tokyo";
            
            WriteLine($"{city} as population: {db.GetPopulation(city)}");
        }
    }

    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;

        private static int instanceCount; //0
        public static int Count => instanceCount;

        private SingletonDatabase()
        {
            instanceCount++;

            WriteLine("Initializing database");

            capitals = File.ReadAllLines(
                Path.Combine(
                    new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName,
                    "Example2\\capitals.txt"
                    )
                )
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1))
                );
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }

        private static Lazy<SingletonDatabase> instance = 
            new Lazy<SingletonDatabase>(() => new SingletonDatabase());

        public static SingletonDatabase Instance => instance.Value;
    }

    public class SingletonRecordFinder
    {
        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
                result += SingletonDatabase.Instance.GetPopulation(name);
            return result;
        }
    }
}