using Battleship.UI.Actions;
using Battleship.UI.Enums;
using Battleship.UI.DTOs;
using NUnit.Framework;

namespace Battleship.Tests
{
    [TestFixture]
    public class GridTests
    {
        /// <summary>
        /// Create the sample grid from the instructions file
        /// </summary>
        /// <returns>A grid populated with ships</returns>
        private GridManager GetTestGrid()
        {
            var gm = new GridManager();

            gm.PlaceShip("Carrier", 5, new ShipCoordinate(1, 1), PlacementDirection.Vertical);
            gm.PlaceShip("Cruiser", 3, new ShipCoordinate(8, 1), PlacementDirection.Vertical);
            gm.PlaceShip("Battleship", 4, new ShipCoordinate(4, 6), PlacementDirection.Horizontal);
            gm.PlaceShip("Submarine", 3, new ShipCoordinate(2, 8), PlacementDirection.Vertical);
            gm.PlaceShip("Destroyer", 2, new ShipCoordinate(9, 10), PlacementDirection.Horizontal);

            return gm;
        }

        [Test]
        public void CanDetectMiss()
        {
            var gm = GetTestGrid();

            var result = gm.ProcessShot(new Coordinate(5, 5));

            Assert.AreEqual(ShotResult.Miss, result);
        }

        [Test]
        public void CanDetectHit()
        {
            var gm = GetTestGrid();

            var result = gm.ProcessShot(new Coordinate(1, 1));

            Assert.AreEqual(ShotResult.Hit, result);
        }

        [Test]
        public void CanSinkShip()
        {
            var gm = GetTestGrid();

            gm.ProcessShot(new Coordinate(9, 10));
            var result = gm.ProcessShot(new Coordinate(10, 10));

            Assert.AreEqual(ShotResult.HitAndSunk, result);
        }

        [Test]
        public void CanWinGame()
        {
            var gm = GetTestGrid();

            // carrier
            gm.ProcessShot(new Coordinate(1, 1));
            gm.ProcessShot(new Coordinate(1, 2)); 
            gm.ProcessShot(new Coordinate(1, 3));
            gm.ProcessShot(new Coordinate(1, 4));
            gm.ProcessShot(new Coordinate(1, 5));

            // cruiser
            gm.ProcessShot(new Coordinate(8, 1));
            gm.ProcessShot(new Coordinate(8, 2));
            gm.ProcessShot(new Coordinate(8, 3));

            // battleship
            gm.ProcessShot(new Coordinate(4, 6));
            gm.ProcessShot(new Coordinate(5, 6));
            gm.ProcessShot(new Coordinate(6, 6));
            gm.ProcessShot(new Coordinate(7, 6));

            // submarine
            gm.ProcessShot(new Coordinate(2, 8));
            gm.ProcessShot(new Coordinate(2, 9));
            gm.ProcessShot(new Coordinate(2, 10));

            // destroyer
            gm.ProcessShot(new Coordinate(9, 10));
            gm.ProcessShot(new Coordinate(10, 10));

            Assert.AreEqual(true, gm.GameOver);
        }
    }
}
