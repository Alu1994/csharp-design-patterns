using System;
using InterfaceSegregationPrinciple.Interfaces;

namespace InterfaceSegregationPrinciple
{
    public class Scanner : IScanner
    {
        public void Scan(Document document)
        {
            Console.WriteLine("Scanning 'vmmmm vmmmm'");
        }
    }
}
