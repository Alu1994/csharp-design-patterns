using System;

namespace DesignPatters_5_Singleton_Project.Exercise
{
    public class SingletonTester
    {
        private static StaticTest staticTest = new StaticTest();

        public static bool IsSingleton(Func<object> func)
        {
            // todo
            var instance1 = func();
            var instance2 = func();
            return ReferenceEquals(instance1, instance2);
        }

        public static object test()
        {
            return staticTest;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(IsSingleton(test));
        }
    }

    public class StaticTest
    {
        private static int count = 0;
    }
}