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

            Assert.That(GuessResult.Lower, Is.EqualTo(result));
        }

        [Test]
        public void ReturnsHigher()
        {
            var gm = new GameManager(new AlwaysPicksFive());

            var result = gm.ParseGuess(3);

            Assert.That(GuessResult.Higher, Is.EqualTo(result));
        }

        [Test]
        public void ReturnsCorrect()
        {
            var gm = new GameManager(new AlwaysPicksFive());

            var result = gm.ParseGuess(5);

            Assert.That(GuessResult.Correct, Is.EqualTo(result));
        }
    }
}