using static System.Console;

namespace DependencyInversionPrinciple
{
    public class Example
    {
        static void Main(string[] args)
        {
            ResearchWrong.Search();
            WriteLine("");
            WriteLine("----------------------------------------");
            WriteLine("");
            Research.Search();
        }
    }

    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name;
    }
}