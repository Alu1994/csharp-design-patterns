using System;
using static System.Console;
using System.Collections.Generic;

namespace DesignPatterns_13_Chain_of_Responsibility.Exercise2
{
    public class TeachersSolutionExercise
    {
        public static void Main(string[] args)
        {
            var game = new Game();
            var goblin = new Goblin(game);           // 3/4
            var goblinKing = new GoblinKing(game);   // 4/6
            var goblinKing2 = new GoblinKing(game);  // 4/6
            var goblinKing3 = new GoblinKing(game);  // 4/6
            // var goblin2 = new Goblin(game);          // 3/4
            // game.Creatures.Add(goblin);

            game.Creatures.Add(goblin);
            game.Creatures.Add(goblinKing);
            game.Creatures.Add(goblinKing2);
            game.Creatures.Add(goblinKing3);
            // game.Creatures.Add(goblin2);

            foreach (var creature in game.Creatures)
                WriteLine($"Goblin has Attack of: {creature.Attack} and Defense of: {creature.Defense}");
        }
    }

    public abstract class Creature
    {
        protected Game game;
        protected readonly int baseAttack;
        protected readonly int baseDefense;

        protected Creature(Game game, int baseAttack, int baseDefense)
        {
            this.game = game;
            this.baseAttack = baseAttack;
            this.baseDefense = baseDefense;
        }

        public virtual int Attack { get; set; }
        public virtual int Defense { get; set; }
        public abstract void Query(object source, StatQuery sq);
    }

    public class Goblin : Creature
    {
        public override void Query(object source, StatQuery sq)
        {
            if (ReferenceEquals(source, this))
            {
                switch (sq.Statistic)
                {
                    case Statistic.Attack:
                        sq.Result += baseAttack;
                        break;
                    case Statistic.Defense:
                        sq.Result += baseDefense;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                if (sq.Statistic == Statistic.Defense)
                {
                    sq.Result++;
                }
            }
        }

        public override int Defense
        {
            get
            {
                var q = new StatQuery { Statistic = Statistic.Defense };
                foreach (var c in game.Creatures)
                    c.Query(this, q);
                return q.Result;
            }
        }

        public override int Attack
        {
            get
            {
                var q = new StatQuery { Statistic = Statistic.Attack };
                foreach (var c in game.Creatures)
                    c.Query(this, q);
                return q.Result;
            }
        }

        public Goblin(Game game) : base(game, 1, 1)
        {
        }

        protected Goblin(Game game, int baseAttack, int baseDefense) : base(game,
          baseAttack, baseDefense)
        {
        }
    }

    public class GoblinKing : Goblin
    {
        public GoblinKing(Game game) : base(game, 3, 3)
        {
        }

        public override void Query(object source, StatQuery sq)
        {
            if (!ReferenceEquals(source, this) && sq.Statistic == Statistic.Attack)
            {
                sq.Result++; // every goblin gets +1 attack
            }
            else base.Query(source, sq);
        }
    }

    public enum Statistic
    {
        Attack,
        Defense
    }

    public class StatQuery
    {
        public Statistic Statistic;
        public int Result;
    }

    public class Game
    {
        public IList<Creature> Creatures = new List<Creature>();
    }
}