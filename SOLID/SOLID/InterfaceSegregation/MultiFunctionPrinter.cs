using static System.Console;

namespace DesignPatters_1.InterfaceSegregation
{
    public class MultiFunctionPrinter : IMachine
    {
        public void Fax(Document document)
        {
            WriteLine("Fax 'tutu tutu'");
        }

        public void Print(Document document)
        {
            WriteLine("Printing 'zup zup'");
        }

        public void Scan(Document document)
        {
            WriteLine("Scanning 'vmmmm vmmmm'");
        }
    }
}
