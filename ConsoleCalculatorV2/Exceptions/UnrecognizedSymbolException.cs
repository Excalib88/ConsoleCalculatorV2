using System;

namespace ConsoleCalculatorV2.Exceptions
{
    public class UnrecognizedSymbolException : Exception
    {
        public UnrecognizedSymbolException(string message) : base(message)
        {
        }
    }
}