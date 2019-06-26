using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatters_1.InterfaceSegregation
{
    public class Printer : IPrinter
    {
        public void Print(Document document)
        {
            Console.WriteLine("Printing 'zup zup'");
        }
    }
}
