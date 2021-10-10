using System.Globalization;

namespace ConsoleCalculatorV2
{
    public static class DoubleExtensions
    {
        public static bool TryParse(string input, out double number)
        {
            return double.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out number) ||
                   double.TryParse(input, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out number) ||
                   double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out number);
        }
    }
}