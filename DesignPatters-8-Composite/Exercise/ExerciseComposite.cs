using System;
using System.Collections;
using System.Collections.Generic;

namespace Coding.Exercise
{
    public static class MainExercise
    {
        static void Mains(string[] args)
        {
            var single1 = new SingleValue();
            var single2 = new SingleValue();
            single1.Value = 1;
            single2.Value = 2;

            Console.WriteLine(single1.Sum().ToString());
            Console.WriteLine(single2.Sum().ToString());

            var many1 = new ManyValues();
            var many2 = new ManyValues();
            many1.Add(single1);
            many1.Add(single2);

            many2.Add(single2);
            many2.Add(single2);

            Console.WriteLine(many1.Sum().ToString());
            Console.WriteLine(many2.Sum().ToString());

            Console.ReadLine();
        }
    }

    public interface IValueContainer
    {
        int Value { get; set; }
    }

    public class SingleValue : IEnumerable<SingleValue>, IValueContainer
    {
        public int Value { get; set; }

        public IEnumerator<SingleValue> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class ManyValues : List<SingleValue>
    {
        
    }

    public static class ExtensionMethods
    {
        public static int Sum(this IEnumerable<SingleValue> containers)
        {
            int result = 0;
            foreach (var c in containers)
                foreach (var i in c)
                    result += i.Value;
            return result;
        }
    }
}
