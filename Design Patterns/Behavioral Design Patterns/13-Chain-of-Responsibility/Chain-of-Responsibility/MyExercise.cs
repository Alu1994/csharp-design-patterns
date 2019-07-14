using System;
using static System.Console;
using System.Linq;
using System.Collections.ObjectModel;

namespace DesignPatterns_13_Chain_of_Responsibility.Exercise1
{
    public class Exercise
    {
        public static void Main_s(string[] args)
        {
            var game = new Game();
            var goblin = new Goblin(game);          // 3/4
            var goblinKing = new GoblinKing(game);  // 4/6
            var goblinKing2 = new GoblinKing(game); // 4/6
            var goblin2 = new Goblin(game);          // 3/4
            goblinKing2.Dispose();

            foreach (var creature in game)
                WriteLine($"{creature.Name} has Attack of: {creature.Attack} and Defense of: {creature.Defense}");
        }
    }

    public class Game : Collection<Creature>
    {

    }

    public abstract class Creature : Collection<Creature>, IDisposable
    {
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        public abstract void Dispose();
    }

    public class Goblin : Creature
    {
        protected Game game;

        public Goblin(Game game)
        {
            Name = nameof(Goblin);
            Attack = 1;
            Defense = 1;
            foreach (var creature in game)
                creature.Defense += 1;

            if (this.GetType() != typeof(GoblinKing))
            {
                game.ToList().ForEach((creature) =>
                {
                    if (creature.GetType() == typeof(Goblin))
                        Defense += 1;
                    else if (creature.GetType() == typeof(GoblinKing))
                    {
                        Attack += 1;
                        Defense += 1;
                    }
                });
                game.Add(this);
            }
            this.game = game;
        }

        public override void Dispose()
        {
            foreach (var creature in game)
                creature.Defense -= 1;
            game.Remove(this);
        }
    }

    public class GoblinKing : Goblin
    {
        public GoblinKing(Game game) : base(game)
        {
            Name = nameof(GoblinKing);
            Attack = 3;
            Defense = 3;
            foreach (var creature in game)
                if (creature != this)
                    creature.Attack += 1;

            game.ToList().ForEach((creature) =>
            {
                if (creature.GetType() == typeof(Goblin))
                    Defense += 1;
                else if (creature.GetType() == typeof(GoblinKing))
                {
                    Attack += 1;
                    Defense += 1;
                }
            });

            game.Add(this);
        }

        public override void Dispose()
        {
            foreach (var creature in game)
                creature.Attack -= 1;
            base.Dispose();
        }
    }
}