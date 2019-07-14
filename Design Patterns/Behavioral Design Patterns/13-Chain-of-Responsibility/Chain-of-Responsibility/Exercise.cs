using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_13_Chain_of_Responsibility.Exercise
{
    public class Exercise
    {
        public static void Main(string[] args)
        {
            var game = new Game();
            var goblin = new Goblin(game);
            game.Creatures.Add(goblin);
            Console.WriteLine("Ola");
        }
    }

    public class Game
    {
        public IList<Creature> Creatures;

        public Game()
        {
            Creatures = new List<Creature>();
        }
    }

    public abstract class Creature
    {
        public int Attack { get; set; }
        public int Defense { get; set; }
    }

    public class Goblin : Creature
    {
        protected Game game;

        public Goblin(Game game)
        {
            
            game = game;
        }
    }

    public class GoblinKing : Goblin
    {
        public GoblinKing(Game game) : base(game)
        {

        }
    }
}