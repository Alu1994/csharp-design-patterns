using static System.Console;

namespace DesignPatters_5_Singleton.Example4
{
    class MonostatePatern
    {
        static void Mains(string[] args)
        {
            _ = new CEO
            {
                Name = "Adam Smith",
                Age = 55
            };

            var ceo2 = new CEO();
            WriteLine(ceo2);
        }
    }

    public class CEO
    {
        private static string name;
        private static int age;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }
    }
}