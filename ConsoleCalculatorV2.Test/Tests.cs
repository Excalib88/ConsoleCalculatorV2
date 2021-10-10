using NUnit.Framework;

namespace ConsoleCalculatorV2.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("2+3", 5)]
        [TestCase("(2+3)*6", 30)]
        [TestCase("2+-6", -4)]
        [TestCase("-(33*11)/(-11)", 33)]
        [TestCase("-2", -2)]
        [TestCase("2+3*5", 17)]
        [TestCase("(-(+2-1))", -1)]
        [TestCase("-(-(+2-1))", 1)]
        public void Test1(string input, double result)
        {
            var actual = ExpressionEngine.Calculate(input);

            Assert.AreEqual(result, actual);
        }
    }
}