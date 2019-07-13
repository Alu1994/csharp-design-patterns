using System;

// You are given the 'Person' "class" and asked to write a 'ResponsiblePerson' "proxy" that does the following:

// Allows person to drink unless they are younger than 18 (in that case, return "too young")
// Allows person to drive unless they are younger than 16 (otherwise, "too young")
// In case of driving while drinking, returns "dead"

namespace DesignPatterns_12_Proxy.Exercise
{
    public class Person
    {
        public int Age { get; set; }

        public string Drink()
        {
            return "drinking";
        }

        public string Drive()
        {
            return "driving";
        }

        public string DrinkAndDrive()
        {
            return "driving while drunk";
        }
    }

    public class ResponsiblePerson
    {
        private readonly Person person;
        public ResponsiblePerson(Person person)
        {
            this.person = person;
        }

        public int Age
        {
            get { return person.Age; }
            set { person.Age = value; }
        }

        public string Drink()
        {
            if (person.Age < 18)
                return "too young";
            return person.Drink();
        }

        public string Drive()
        {
            if (person.Age < 16)
                return "too young";
            return person.Drive();
        }

        public string DrinkAndDrive()
        {
            Console.WriteLine(person.DrinkAndDrive());
            return "dead";
        }
    }
}