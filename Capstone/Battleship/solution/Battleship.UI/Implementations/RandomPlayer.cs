using Battleship.UI.Actions;
using Battleship.UI.DTOs;
using Battleship.UI.Enums;
using Battleship.UI.Interfaces;

namespace Battleship.UI.Implementations
{
    /// <summary>
    /// This is a random implementation of a computer opponent, it fires shots randomly on the grid.
    /// </summary>
    public class RandomPlayer : IPlayer
    {
        private static Random _rng = new Random();

        public string PlayerName { get; set; }
        public GridManager Grid { get; set; }
        public ShotHistoryTracker ShotHistory { get; set; }

        public RandomPlayer()
        {
            ShotHistory = new ShotHistoryTracker();
            Grid = new GridManager();
            PlayerName = "CPU";
        }

        /// <summary>
        /// Random player must make a unique shot
        /// </summary>
        /// <returns>The target coordinate to be sent to the other player's grid</returns>
        public Coordinate TakeTurn()
        {
            while(true)
            {
                Coordinate c = GetRandomCoordinate();
                if(!ShotHistory.IsDuplicateShot(c))
                {
                    return c;
                }
            }
        }

        /// <summary>
        /// Randomly place each ship in the game.
        /// </summary>
        public void PlaceShips()
        {
            Console.Clear();
            Console.WriteLine($"{PlayerName} is placing their ships...");

            PlaceShip("Aircraft Carrier", 5);
            PlaceShip("Battleship", 4);
            PlaceShip("Cruiser", 3);
            PlaceShip("Submarine", 3);
            PlaceShip("Destroyer", 2);
        }

        /// <summary>
        /// Will keep trying to find a valid starting coordinate and direction until it successfully places the ship
        /// </summary>
        /// <param name="name">Name of the ship</param>
        /// <param name="size">Ship size in grid squares</param>
        private void PlaceShip(string name, int size)
        {
            PlaceShipResult result;

            do
            {
                ShipCoordinate start = GetRandomCoordinate();
                PlacementDirection dir = GetRandomDirection();

                result = Grid.PlaceShip(name, size, start, dir);
            } while (result != PlaceShipResult.Success);
        }

        /// <summary>
        /// Generate a random coordinate on the grid
        /// </summary>
        /// <returns>A coordinate object</returns>
        private ShipCoordinate GetRandomCoordinate()
        {
            return new ShipCoordinate(_rng.Next(1, 11), _rng.Next(1, 11));
        }

        /// <summary>
        /// Generate a random direction for ship placement.
        /// </summary>
        /// <returns>Vertical or Horizontal</returns>
        private PlacementDirection GetRandomDirection()
        {
            if(_rng.Next(1,101) > 50)
            {
                return PlacementDirection.Horizontal;
            }

            return PlacementDirection.Vertical;
        }
    }
}
