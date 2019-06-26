using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatters_1.InterfaceSegregation
{
    public class FaxImplm : IFax
    {
        public void Fax(Document document)
        {
            Console.WriteLine("Fax 'tutu tutu'");
        }
    }
}
