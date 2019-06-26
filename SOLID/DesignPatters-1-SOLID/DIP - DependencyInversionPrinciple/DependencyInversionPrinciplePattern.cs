using DesignPatters_1.DIP___DependencyInversionPrinciple;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using static System.Console;

namespace DesignPatters_1
{
    public class DependencyInversionPrinciplePattern
    {
        static void Main_s(string[] args)
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