using InterfaceSegregationPrinciple.Interfaces;
using static System.Console;

namespace InterfaceSegregationPrinciple
{
    public class Example
    {
        static void Main(string[] args)
        {
            IPrinter printer = new Printer();
            IScanner scanner = new Scanner();
            var printerScanner = new PrinterScannerDecorator(printer, scanner);
            printerScanner.Print(new Document());
            printerScanner.Scan(new Document());

            WriteLine(" ");
            WriteLine("-------------------------------------");
            WriteLine(" ");

            var printerScannerFax = new MultiFunctionPrinter();
            printerScannerFax.Print(new Document());
            printerScannerFax.Scan(new Document());
            printerScannerFax.Fax(new Document());
        }
    }
}
