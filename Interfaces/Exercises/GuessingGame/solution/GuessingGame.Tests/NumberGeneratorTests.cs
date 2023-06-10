using GuessingGame.UI;
using NUnit.Framework;

namespace GuessingGame.Tests
{
    [TestFixture]
    public class NumberGeneratorTests
    {
        [Test]
        public void ReturnsLower()
        {
            var gm = new GameManager(new AlwaysPicksFive());

            var result = gm.ParseGuess(10);

            Assert.AreEqual(GuessResult.Lower, result);
        }

        [Test]
        public void ReturnsHigher()
        {
            var gm = new GameManager(new AlwaysPicksFive());

            var result = gm.ParseGuess(3);

            Assert.AreEqual(GuessResult.Higher, result);
        }

        [Test]
        public void ReturnsCorrect()
        {
            var gm = new GameManager(new AlwaysPicksFive());

            var result = gm.ParseGuess(5);

            Assert.AreEqual(GuessResult.Correct, result);
        }
    }
}