using System;

namespace ConsoleCalculatorV2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(ExpressionEngine.Calculate("(-(-5*(-2+3))*2)"));
            // while (true)
            // {
            //     try
            //     {
            //         Console.Write("Введите выражение: ");
            //         Console.WriteLine(ExpressionEngine.Calculate(Console.ReadLine()));
            //     }
            //     catch (Exception e)
            //     {
            //         Console.WriteLine(e);
            //     }
            // }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}