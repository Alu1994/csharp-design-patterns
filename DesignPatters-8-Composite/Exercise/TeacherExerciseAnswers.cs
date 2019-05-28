using System;
using System.Collections;
using System.Collections.Generic;

namespace DotNetDesignPatternDemos.Structural.Composite
{
    namespace Coding.Exercise
    {
        public static class MainExercise
        {
            static void Main(string[] args)
            {
                var single1 = new SingleValue();
                var single2 = new SingleValue();
                var many1 = new ManyValues();
                var many2 = new ManyValues();

                single1.Value = 1;
                single2.Value = 2;

                many1.Add(single1.Value);
                many1.Add(single2.Value);
                many2.Add(single2.Value);
                many2.Add(single2.Value);

                List<IValueContainer> x = new List<IValueContainer>();
                x.Add(many1);
                x.Add(many2);
                x.Add(single1);
                x.Add(single2);

                Console.WriteLine(x.Sum());
                Console.ReadLine();
            }
        }


        public interface IValueContainer : IEnumerable<int>
        {

        }

        public class SingleValue : IValueContainer
        {
            public int Value;

            public IEnumerator<int> GetEnumerator()
            {
                yield return Value;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        public class ManyValues : List<int>, IValueContainer
        {

        }

        public static class ExtensionMethods
        {
            public static int Sum(this List<IValueContainer> containers)
            {
                int result = 0;
                foreach (var c in containers)
                    foreach (var i in c)
                        result += i;
                return result;
            }
        }
    }
}