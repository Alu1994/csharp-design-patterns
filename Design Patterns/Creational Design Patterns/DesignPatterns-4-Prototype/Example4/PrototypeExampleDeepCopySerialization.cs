using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using static System.Console;

namespace DesignPatterns_4_Prototype.Example4
{
    public class PrototypeExampleDeepCopySerialization
    {
        static void Mains(string[] args)
        {
            var john = new Person(new[] { "John", "Smith" }, 
                                  new Address("London Road", 123));

            var jane = john.DeepCopy();
            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 321;

            var marcus = john.DeepCopyXml();
            marcus.Names[0] = "Marcus";
            marcus.Address.HouseNumber = 231;

            WriteLine(john);
            WriteLine(jane);
            WriteLine(marcus);
        }
    }

    public static class ExtensionMethods
    {
        // Faster, but does require a [Serializable] DataAnnotation
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T)copy;
        }

        // Less faster, but only require an empty Constructor
        public static T DeepCopyXml<T>(this T self)
        {
            using (var ms =  new MemoryStream())
            {
                var xml = new XmlSerializer(typeof(T));
                xml.Serialize(ms, self);
                ms.Position = 0;
                return (T)xml.Deserialize(ms);
            }
        }
    }

    [Serializable]
    public class Person
    {
        public string[] Names;
        public Address Address;

        public Person()
        {

        }

        public Person(Person other)
        {
            Names = (string[])other.Names.Clone();
            Address = new Address(other.Address);
        }

        public Person(string[] names, Address address)
        {
            if (names == null)
                throw new ArgumentNullException(paramName: nameof(names));
            if (address == null)
                throw new ArgumentNullException(paramName: nameof(address));

            Names = names;
            Address = address;
        }
        
        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }
    }

    [Serializable]
    public class Address
    {
        public string StreetName;
        public int HouseNumber;

        public Address()
        {

        }

        public Address(Address other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        public Address(string streetName, int houseNumber)
        {
            if (streetName == null)
                throw new ArgumentNullException(paramName: nameof(streetName));

            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }
}