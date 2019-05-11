using System;
using System.Collections.Generic;
using static System.Console;

namespace DesignPatters_3_Factory.Example5
{

    // Still Violates the Open Closed Principle
    // Because of the Enum inside the factory class

    public class AbstractFactoryExample
    {
        static void Mains(string[] args)
        {
            var machine = new HotDrinkMachine();
            
            // Abstract class
            var drinkTea = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 100);
            drinkTea.Consume();

            WriteLine("");

            // Interface class
            var drinkCoffee = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Coffee, 100);
            drinkCoffee.Consume();
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
        public enum AvailableDrink
        {
            Coffee, Tea
        }

        private const string FACTORY_LABEL = "Factory";

        private Dictionary<AvailableDrink, IHotDrinkFactory> factories = new Dictionary<AvailableDrink, IHotDrinkFactory>();

        public HotDrinkMachine()
        {
            string namespaceFactory = GetNamespaceFactory();            

            foreach(AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
            {
                string className = Enum.GetName(typeof(AvailableDrink), drink);
                var factory = (IHotDrinkFactory)Activator.
                    CreateInstance(
                        Type.GetType($"{namespaceFactory}.{className}{FACTORY_LABEL}")
                    );
                factories.Add(drink, factory);
            }
        }

        public IHotDrink MakeDrink(AvailableDrink drink, int amount) => 
            factories[drink].Prepare(amount);

        private string GetNamespaceFactory() => typeof(HotDrinkMachine.AvailableDrink).Namespace;
    }
}