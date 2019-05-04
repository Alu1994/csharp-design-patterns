using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatters_1.InterfaceSegregation
{
    public interface IMachine : IPrinter, IScanner, IFax
    {

    }
}
