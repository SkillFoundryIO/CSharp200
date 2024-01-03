using Battleship.UI.Actions;
using NUnit.Framework;

namespace Battleship.Tests
{
    [TestFixture]
    public class CoordinateTests
    {
        [Test]
        public void LettersToNumbers()
        {
            Assert.That(1, Is.EqualTo(CoordinateConverter.ConvertLetterToNumber("A")));
            Assert.That(2, Is.EqualTo(CoordinateConverter.ConvertLetterToNumber("B")));
            Assert.That(3, Is.EqualTo(CoordinateConverter.ConvertLetterToNumber("C")));
            Assert.That(4, Is.EqualTo(CoordinateConverter.ConvertLetterToNumber("D")));
            Assert.That(5, Is.EqualTo(CoordinateConverter.ConvertLetterToNumber("E")));
            Assert.That(6, Is.EqualTo(CoordinateConverter.ConvertLetterToNumber("F")));
            Assert.That(7, Is.EqualTo(CoordinateConverter.ConvertLetterToNumber("G")));
            Assert.That(8, Is.EqualTo(CoordinateConverter.ConvertLetterToNumber("H")));
            Assert.That(9, Is.EqualTo(CoordinateConverter.ConvertLetterToNumber("I")));
            Assert.That(10, Is.EqualTo(CoordinateConverter.ConvertLetterToNumber("J")));
        }

        [Test]
        public void InvalidLetter()
        {
            Assert.That(-1, Is.EqualTo(CoordinateConverter.ConvertLetterToNumber("asdf")));
        }

        [Test]
        public void NumbersToLetters()
        {
            Assert.That("A", Is.EqualTo(CoordinateConverter.ConvertNumberToLetter(1)));
            Assert.That("B", Is.EqualTo(CoordinateConverter.ConvertNumberToLetter(2)));
            Assert.That("C", Is.EqualTo(CoordinateConverter.ConvertNumberToLetter(3)));
            Assert.That("D", Is.EqualTo(CoordinateConverter.ConvertNumberToLetter(4)));
            Assert.That("E", Is.EqualTo(CoordinateConverter.ConvertNumberToLetter(5)));
            Assert.That("F", Is.EqualTo(CoordinateConverter.ConvertNumberToLetter(6)));
            Assert.That("G", Is.EqualTo(CoordinateConverter.ConvertNumberToLetter(7)));
            Assert.That("H", Is.EqualTo(CoordinateConverter.ConvertNumberToLetter(8)));
            Assert.That("I", Is.EqualTo(CoordinateConverter.ConvertNumberToLetter(9)));
            Assert.That("J", Is.EqualTo(CoordinateConverter.ConvertNumberToLetter(10)));
        }

        [Test]
        public void InvalidNumber()
        {
            Assert.That("", Is.EqualTo(CoordinateConverter.ConvertNumberToLetter(42)));
        }
    }
}
