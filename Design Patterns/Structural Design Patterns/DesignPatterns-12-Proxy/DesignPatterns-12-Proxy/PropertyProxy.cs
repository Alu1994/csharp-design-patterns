using System;
using System.Collections.Generic;
using static System.Console;

namespace DesignPatterns_12_Proxy.Property
{
    class PropertyProxy
    {
        static void Main_s(string[] args)
        {
            var c = new Creature();
            c.Agility = 10;  // c.set_Agility(10); Not
                             // c.Agility = new Property<int>(10)
            c.Agility = 20;

            c.Agility = 30;

            WriteLine(c.Agility);

            var c2 = new Creature2();
            c2.Agility = 10;
            c2.Agility = 20;
            c2.Agility = 30;

            WriteLine(c2.Agility);
        }
    }

    public class Property<T> where T : new()
    {
        private T value;

        public T Value
        {
            get => value;
            set
            {
                if (Equals(this.value, value)) return;
                WriteLine($"Assigning value to {value}");
                this.value = value;
            }
        }

        public Property() : this(Activator.CreateInstance<T>())
        {
            
        }

        public Property(T value) => 
            this.value = value;

        public static implicit operator T(Property<T> property)
        {
            return property.value; // int n = p_int;
        }

        public static implicit operator Property<T>(T value)
        {
            return new Property<T>(value); // Property<int> p = 123;
        }

        public bool Equals(Property<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T>.Default.Equals(value, other.value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Property<T>)obj);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public static bool operator ==(Property<T> left, Property<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Property<T> left, Property<T> right)
        {
            return !Equals(left, right);
        }
    }

    public class Creature
    {
        private Property<int> agility = new Property<int>();

        public int Agility
        {
            get => agility.Value;
            set => agility.Value = value;
        }
    }

    public class Creature2
    {
        public Property<int> Agility { get; set; }
    }
}
