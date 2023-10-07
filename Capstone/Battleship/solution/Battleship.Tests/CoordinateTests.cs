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
            Assert.AreEqual(1, CoordinateConverter.ConvertLetterToNumber("A"));
            Assert.AreEqual(2, CoordinateConverter.ConvertLetterToNumber("B"));
            Assert.AreEqual(3, CoordinateConverter.ConvertLetterToNumber("C"));
            Assert.AreEqual(4, CoordinateConverter.ConvertLetterToNumber("D"));
            Assert.AreEqual(5, CoordinateConverter.ConvertLetterToNumber("E"));
            Assert.AreEqual(6, CoordinateConverter.ConvertLetterToNumber("F"));
            Assert.AreEqual(7, CoordinateConverter.ConvertLetterToNumber("G"));
            Assert.AreEqual(8, CoordinateConverter.ConvertLetterToNumber("H"));
            Assert.AreEqual(9, CoordinateConverter.ConvertLetterToNumber("I"));
            Assert.AreEqual(10, CoordinateConverter.ConvertLetterToNumber("J"));
        }

        [Test]
        public void InvalidLetter()
        {
            Assert.AreEqual(-1, CoordinateConverter.ConvertLetterToNumber("asdf"));
        }

        [Test]
        public void NumbersToLetters()
        {
            Assert.AreEqual("A", CoordinateConverter.ConvertNumberToLetter(1));
            Assert.AreEqual("B", CoordinateConverter.ConvertNumberToLetter(2));
            Assert.AreEqual("C", CoordinateConverter.ConvertNumberToLetter(3));
            Assert.AreEqual("D", CoordinateConverter.ConvertNumberToLetter(4));
            Assert.AreEqual("E", CoordinateConverter.ConvertNumberToLetter(5));
            Assert.AreEqual("F", CoordinateConverter.ConvertNumberToLetter(6));
            Assert.AreEqual("G", CoordinateConverter.ConvertNumberToLetter(7));
            Assert.AreEqual("H", CoordinateConverter.ConvertNumberToLetter(8));
            Assert.AreEqual("I", CoordinateConverter.ConvertNumberToLetter(9));
            Assert.AreEqual("J", CoordinateConverter.ConvertNumberToLetter(10));
        }

        [Test]
        public void InvalidNumber()
        {
            Assert.AreEqual("", CoordinateConverter.ConvertNumberToLetter(42));
        }
    }
}
