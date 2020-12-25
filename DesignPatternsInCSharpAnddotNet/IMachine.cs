using System;

namespace DesignPatternsInCSharpAnddotNet
{
    public interface IScanner
    {
        void Scan();
    }

    public interface IPrinter
    {
        void Print();
    }

    public interface IFax
    {
        void Fax();
    }

    public interface IMultipleFunctionDevice : IScanner, IPrinter
    {
    }

    public class Photocopier : IMultipleFunctionDevice
    {
        private readonly IScanner _scanner;
        private readonly IPrinter _printer;

        public Photocopier(IScanner scanner, IPrinter printer)
        {
            _scanner = scanner ?? throw new ArgumentNullException(nameof(scanner));
            _printer = printer ?? throw new ArgumentNullException(nameof(printer));
        }

        public void Scan()
        {
            _scanner.Scan();
        }

        public void Print()
        {
            _printer.Print();
        }
    }

    public class OldFashionPrinter : IFax
    {
        public void Fax()
        {
            // Do something
        }
    }
}