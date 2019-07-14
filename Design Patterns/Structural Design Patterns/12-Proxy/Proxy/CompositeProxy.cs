using System.Collections.Generic;

namespace DesignPatterns_12_Proxy.Composite
{
    public class CompositeProxy
    {
        public static void Main_s(string[] args)
        {
            var creatures = new Creature[100];
            for (int index = 0; creatures.Length < 100; index++)
            {
                creatures[index] = new Creature(); // since the values of the array are null, we need to instanciate every single one of them.
                creatures[index].X++; // not memory-efficient.
            }

            var creatures2 = new Creatures(100);
            foreach (var c in creatures2)
            {
                c.X++;
            }

            foreach (var c in creatures2)
            {
                c.X++;
            }
        }
    }

    class Creature
    {
        public byte Age;
        public int X, Y;
    }

    class Creatures
    {
        private readonly int size;
        private byte[] age;
        private int[] x, y;

        public Creatures(int size)
        {
            this.size = size;
            age = new byte[size];
            x = new int[size];
            y = new int[size];
        }

        public struct CreatureProxy
        {
            private readonly Creatures creatures;
            private readonly int index;

            public CreatureProxy(Creatures creatures, int index)
            {
                this.creatures = creatures;
                this.index = index;
            }

            public ref byte Age => ref creatures.age[index];
            public ref int X => ref creatures.x[index];
            public ref int Y => ref creatures.y[index];
        }

        public IEnumerator<CreatureProxy> GetEnumerator()
        {
            for (int pos = 0; pos < size; ++pos)
                yield return new CreatureProxy(this, pos);
        }
    }
}