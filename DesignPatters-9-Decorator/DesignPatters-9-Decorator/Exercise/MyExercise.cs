using static System.Console;

namespace DesignPatters_9_Decorator.Exercise
{
    public class MyExercise
    {
        static void Main(string[] args)
        {
            var d = new Dragon();
            d.Age = 2;
            WriteLine(d.Fly());
            WriteLine(d.Crawl());
        }
    }

    public class Bird
    {
        public int Age { get; set; }

        public string Fly() => (Age < 10) ? "flying" : "too old";
    }

    public class Lizard
    {
        public int Age { get; set; }

        public string Crawl() => (Age > 1) ? "crawling" : "too young";
    }

    public class Dragon // no need for interfaces
    {
        public Lizard lizard = new Lizard();
        public Bird bird = new Bird();
        private int age;

        public int Age
        {
            get => age;
            set
            {
                age = value;
                bird.Age = value;
                lizard.Age = value;
            }
        }

        public string Fly() => bird.Fly();

        public string Crawl() => lizard.Crawl();
    }
}
