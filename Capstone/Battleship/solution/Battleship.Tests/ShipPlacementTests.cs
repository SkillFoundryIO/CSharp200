using Battleship.UI.Actions;
using Battleship.UI.DTOs;
using Battleship.UI.Enums;
using NUnit.Framework;

namespace Battleship.Tests
{
    [TestFixture]
    public class ShipPlacementTests
    {
        [Test]
        public void CanPlaceShips()
        {
            GridManager gm = new GridManager();

            ShipCoordinate start = new ShipCoordinate(1, 1);
            var result = gm.PlaceShip("Aircraft Carrier", 5, start, PlacementDirection.Vertical);
            Assert.AreEqual(PlaceShipResult.Success, result);
        }

        [Test]
        public void CannotOverlapShips()
        {
            GridManager gm = new GridManager();

            ShipCoordinate ship1Start = new ShipCoordinate(1, 1);
            var result1 = gm.PlaceShip("Aircraft Carrier", 5, ship1Start, PlacementDirection.Vertical);
            Assert.AreEqual(PlaceShipResult.Success, result1);

            ShipCoordinate ship2Start = new ShipCoordinate(1, 2);
            var result2 = gm.PlaceShip("Destroyer", 2, ship2Start, PlacementDirection.Horizontal);
            Assert.AreEqual(PlaceShipResult.ShipOverlap, result2);
        }

        [Test]
        public void CannotPlaceShipOffBoard()
        {
            GridManager gm = new GridManager();

            ShipCoordinate start = new ShipCoordinate(1, 8);
            var result = gm.PlaceShip("Aircraft Carrier", 5, start, PlacementDirection.Vertical);
            Assert.AreEqual(PlaceShipResult.ShipOffBoard, result);
        }
    }
}