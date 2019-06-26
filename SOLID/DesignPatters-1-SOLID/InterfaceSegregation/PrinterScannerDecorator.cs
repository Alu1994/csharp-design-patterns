using System;

namespace DesignPatters_1.InterfaceSegregation
{
    public class PrinterScannerDecorator : IMultiFunctionMachine
    {
        private IPrinter printer;
        private IScanner scanner;

        public PrinterScannerDecorator(IPrinter printer, IScanner scanner)
        {
            this.printer = printer ?? throw new ArgumentNullException(paramName: nameof(printer));
            this.scanner = scanner ?? throw new ArgumentNullException(paramName: nameof(scanner));
        }

        public void Print(Document document) =>
            printer.Print(document); // decorator

        public void Scan(Document document) =>
            scanner.Scan(document); // decorator
    }
}