using System;
using System.Collections.Generic;
using static System.Console;

namespace DesignPatterns_3_Factory.Example6
{
    public class AbstractFactoryExample
    {
        static void Mains(string[] args)
        {
            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink();
            drink?.Consume();
        }
    }


    /// <summary>    
    // Construct the environment to consume the Hot Drink
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            WriteLine("This tea is nice but I'd prefer it with milk.");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            WriteLine("This coffee is sensational!");
        }
    }
    /// </summary>


    /// <summary>    
    // Construct The factory to "prepare" the Hot Drink and then "consume"

    // You can either use an Interface
    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    // Or

    // You can use an Abstract Factory
    public abstract class HotDrinkFactory : IHotDrinkFactory, IHotDrink
    {
        public virtual IHotDrink Prepare(int amount)
        {
            WriteLine($"There is no Hot Drink Informed!");
            return this;
        }

        public void Consume() =>
            WriteLine($"There is no Hot Drink Informed, so we can't consume something there is not even prepared.. XD");
    }
    /// </summary>


    // Abstract Class
    internal class TeaFactory : HotDrinkFactory
    {
        public override IHotDrink Prepare(int amount)
        {
            WriteLine($"Put in a tea bag, boil water, pour {amount} ml, add lemon, enjoy!");
            return new Tea();
        }
    }

    // Interface
    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"Grind some beans, boil water, pour {amount} ml, add cream and sugar, enjoy!");
            return new Coffee();
        }
    }

    // The Real Factory
    public class HotDrinkMachine
    {
        private List<Tuple<string, IHotDrinkFactory>> factories = new List<Tuple<string, IHotDrinkFactory>>();

        public HotDrinkMachine()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) &&
                    !t.IsInterface && !t.IsAbstract)
                {
                    factories.Add(
                        Tuple.Create(
                            t.Name.Replace("Factory", string.Empty),
                            (IHotDrinkFactory)Activator.CreateInstance(t)
                            ));
                }
            }
        }

        public IHotDrink MakeDrink()
        {
            WriteLine("Available drinks:");
            for (int index = 0; index < factories.Count; index++)
            {
                var tuple = factories[index];
                WriteLine($"{index}: {tuple.Item1}");
            }
            string s;
            if ((s = ReadLine()) != null
                && int.TryParse(s, out int i)
                && i >= 0
                && i < factories.Count)
            {
                Write("Specify amount: ");
                s = ReadLine();
                if (s != null
                    && int.TryParse(s, out int amount)
                    && amount > 0)
                {
                    return factories[i].Item2.Prepare(amount);
                }
            }
            WriteLine("Incorrect input, try again!");
            return null;
        }
    }
}