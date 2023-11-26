using NUnit.Framework;
using TicTacToe.UI;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class GameManagerTests
    {
        private GameManager _gameManager;

        /// <summary>
        /// This is a good example of how to use the NUnit [SetUp] attribute to perform 
        /// setup code before each test in the class is executed. Each test needed a new game manager 
        /// so I decided to not repeat myself.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _gameManager = new GameManager();
        }

        [Test]
        public void PlaceSymbol_ValidPosition_PlacesSymbol()
        {
            var result = _gameManager.PlaceSymbol("X", 1);
            Assert.That(PlacementResult.SymbolPlaced, Is.EqualTo(result));
            Assert.That("X", Is.EqualTo(_gameManager.Grid[0]));
        }

        [Test]
        public void PlaceSymbol_InvalidOffGrid_ReturnsInvalidOffGrid()
        {
            var result = _gameManager.PlaceSymbol("X", 10);
            Assert.That(PlacementResult.InvalidOffGrid, Is.EqualTo(result));
        }

        [Test]
        public void PlaceSymbol_InvalidOverlap_ReturnsInvalidOverlap()
        {
            _gameManager.PlaceSymbol("X", 1);
            var result = _gameManager.PlaceSymbol("O", 1);
            Assert.That(PlacementResult.InvalidOverlap, Is.EqualTo(result));
        }

        [Test]
        public void PlaceSymbol_XWins_ReturnsXWins()
        {
            _gameManager.PlaceSymbol("X", 1);
            _gameManager.PlaceSymbol("X", 2);
            var result = _gameManager.PlaceSymbol("X", 3);
            Assert.That(PlacementResult.XWins, Is.EqualTo(result));
        }

        [Test]
        public void PlaceSymbol_OWins_ReturnsOWins()
        {
            _gameManager.PlaceSymbol("O", 4);
            _gameManager.PlaceSymbol("O", 5);
            var result = _gameManager.PlaceSymbol("O", 6);
            Assert.That(PlacementResult.OWins, Is.EqualTo(result));
        }

        [Test]
        public void PlaceSymbol_Draw_ReturnsDraw()
        {
            _gameManager.PlaceSymbol("X", 1);
            _gameManager.PlaceSymbol("O", 2);
            _gameManager.PlaceSymbol("X", 3);
            _gameManager.PlaceSymbol("X", 4);
            _gameManager.PlaceSymbol("O", 5);
            _gameManager.PlaceSymbol("O", 6);
            _gameManager.PlaceSymbol("O", 7);
            _gameManager.PlaceSymbol("X", 8);
            var result = _gameManager.PlaceSymbol("X", 9);
            Assert.That(PlacementResult.Draw, Is.EqualTo(result));
        }

        [Test]
        public void PlaceSymbol_XWinsHorizontal_ReturnsXWins()
        {
            _gameManager.PlaceSymbol("X", 1);
            _gameManager.PlaceSymbol("X", 2);
            var result = _gameManager.PlaceSymbol("X", 3);
            Assert.That(PlacementResult.XWins, Is.EqualTo(result));
        }

        [Test]
        public void PlaceSymbol_OWinsVertical_ReturnsOWins()
        {
            _gameManager.PlaceSymbol("O", 2);
            _gameManager.PlaceSymbol("O", 5);
            var result = _gameManager.PlaceSymbol("O", 8);
            Assert.That(PlacementResult.OWins, Is.EqualTo(result));
        }

        [Test]
        public void PlaceSymbol_XWinsDiagonal_ReturnsXWins()
        {
            _gameManager.PlaceSymbol("X", 1);
            _gameManager.PlaceSymbol("O", 2);
            _gameManager.PlaceSymbol("O", 4);
            _gameManager.PlaceSymbol("X", 5);
            var result = _gameManager.PlaceSymbol("X", 9);
            Assert.That(PlacementResult.XWins, Is.EqualTo(result));
        }

        [Test]
        public void PlaceSymbol_OWinsDiagonal_ReturnsOWins()
        {
            _gameManager.PlaceSymbol("X", 1);
            _gameManager.PlaceSymbol("O", 3);
            _gameManager.PlaceSymbol("X", 4);
            _gameManager.PlaceSymbol("O", 5);
            var result = _gameManager.PlaceSymbol("O", 7);
            Assert.That(PlacementResult.OWins, Is.EqualTo(result));
        }
    }
}