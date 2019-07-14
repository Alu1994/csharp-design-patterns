using System;
using static System.Console;

namespace DesignPatterns_4_Prototype.Example1
{
    public class PrototypeExampleBadCopy
    {
        static void Mains(string[] args)
        {
            var john = new Person(new[] { "John", "Smith" }, 
                                  new Address("London Road", 123));

            // --
            // Doesn't work
            var jane1 = john;
            //jane1.Names[0] = "Jane";
            // --

            var jane2 = (Person)john.Clone();
            jane2.Names[0] = "Jane";
            jane2.Address.HouseNumber = 321;

            WriteLine(john);
            WriteLine(jane1);
            WriteLine(jane2);
        }
    }

    public class Person : ICloneable
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            if (names == null)
                throw new ArgumentNullException(paramName: nameof(names));
            if (address == null)
                throw new ArgumentNullException(paramName: nameof(address));

            Names = names;
            Address = address;
        }

        // Shallow(rasa) Clone
        public object Clone()
        {
            return new Person((string[])Names.Clone(), (Address)Address.Clone());
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }
    }

    public class Address : ICloneable
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            if (streetName == null)
                throw new ArgumentNullException(paramName: nameof(streetName));

            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public object Clone()
        {
            return new Address(StreetName, HouseNumber);
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }
}
