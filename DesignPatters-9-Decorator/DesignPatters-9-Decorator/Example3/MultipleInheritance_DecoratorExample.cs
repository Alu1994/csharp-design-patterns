using System;
using System.Runtime.Serialization;
using System.Text;
using static System.Console;

namespace DesignPatters_9_Decorator.Example3
{
    public class MultipleInheritance_DecoratorExample
    {
        static void Mains(string[] args)
        {
            var b = new Bird();
            var l = new Lizard();
            var d = new Dragon(b, l);
            d.Weight = 123;
            d.Fly();
            d.Crawl();
        }
    }

    public interface IBird
    {
        void Fly();
        int Weight { get; set; }
    }

    public interface ILizard
    {
        void Crawl();
        int Weight { get; set; }
    }


    public class Bird : IBird
    {
        public int Weight { get; set; }

        public void Fly() => WriteLine($"Soaring in the sky with weight {Weight}");
    }

    public class Lizard : ILizard
    {
        public int Weight { get; set; }

        public void Crawl() => WriteLine($"Crawling in the dirt with weight {Weight}");
    }

    public class Dragon : IBird, ILizard // no multiple inheritance
    {
        private Bird bird;
        private Lizard lizard;
        private int weight;

        public Dragon(Bird bird, Lizard lizard)
        {
            this.bird = bird ?? throw new ArgumentNullException(paramName: nameof(bird));
            this.lizard = lizard ?? throw new ArgumentNullException(paramName: nameof(lizard));
        }

        public int Weight
        {
            get => weight;
            set
            {
                weight = value;
                bird.Weight = value;
                lizard.Weight = value;
            }
        }

        public void Crawl() => lizard.Crawl();

        public void Fly() => bird.Fly();
    }
}