using System;
using InterfaceSegregationPrinciple.Interfaces;

namespace InterfaceSegregationPrinciple
{
    public class Printer : IPrinter
    {
        public void Print(Document document)
        {
            Console.WriteLine("Printing 'zup zup'");
        }
    }
}
