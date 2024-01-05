using NUnit.Framework;

namespace TDDStringCalculator
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void EmptyStringReturnsZero()
        {
            var c = new StringCalculator();
            int val = c.Add("");

            Assert.AreEqual(0, val);
        }

        [Test]
        public void SingleNumberReturnsNumber()
        {
            var c = new StringCalculator();
            int val = c.Add("5");

            Assert.AreEqual(5, val);
        }

        [TestCase("1,2", 3)]
        [TestCase("3,4", 7)]
        public void TwoNumbersReturnsSum(string numbers, int expected)
        {
            var c = new StringCalculator();
            int val = c.Add(numbers);

            Assert.AreEqual(expected, val);
        }
    }
}
