using System;

namespace Coding.Exercise
{
    public class Person
    {
        public static PersonFactory Factory = new PersonFactory();

        public int Id { get; private set; }
        public string Name { get; private set; }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        static void Main(string[] args)
        {
            var fernando = Factory.CreatePerson("Fernando");
            Console.WriteLine("{0} {1}", fernando.Id, fernando.Name);

            var claudia = Factory.CreatePerson("Claudia");
            Console.WriteLine("{0} {1}", claudia.Id, claudia.Name);

            var matheus = Factory.CreatePerson("Matheus");
            Console.WriteLine("{0} {1}", matheus.Id, matheus.Name);

            var henrique = Factory.CreatePerson("Henrique");
            Console.WriteLine("{0} {1}", henrique.Id, henrique.Name);
        }
    }

    public class PersonFactory
    {
        public static int Id = 0;
        
        public Person CreatePerson(string name)
        {
            return new Person(Id++, name);
        }
    }
}