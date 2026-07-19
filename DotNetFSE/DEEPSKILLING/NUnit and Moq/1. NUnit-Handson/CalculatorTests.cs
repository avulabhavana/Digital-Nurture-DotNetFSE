using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator? _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [TearDown]
        public void Cleanup()
        {
            _calculator = null;
        }

        [TestCase(10, 20, 30)]
        [TestCase(5, 5, 10)]
        [TestCase(1, 2, 3)]
        public void Add_ShouldReturnExpectedResult(int a, int b, int expected)
        {
            int actual = _calculator!.Add(a, b);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}