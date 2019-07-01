using System;
using InterfaceSegregationPrinciple.Interfaces;

namespace InterfaceSegregationPrinciple
{
    public class FaxImplm : IFax
    {
        public void Fax(Document document)
        {
            Console.WriteLine("Fax 'tutu tutu'");
        }
    }
}
