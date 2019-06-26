using System;

namespace DesignPatters_1.InterfaceSegregation
{
    public class Scanner : IScanner
    {
        public void Scan(Document document)
        {
            Console.WriteLine("Scanning 'vmmmm vmmmm'");
        }
    }
}
