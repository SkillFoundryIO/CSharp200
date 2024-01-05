using Battleship.UI.Actions;
using Battleship.UI.DTOs;
using Battleship.UI.Enums;
using Battleship.UI.Interfaces;

namespace Battleship.UI.Implementations
{
    /// <summary>
    /// This is a human player that is prompted for all of the actions.
    /// </summary>
    public class HumanPlayer : IPlayer
    {
        public string PlayerName { get; set; }
        public GridManager Grid { get; set; }
        public ShotHistoryTracker ShotHistory { get; set; }

        public HumanPlayer(string name)
        {
            PlayerName = name;
            Grid = new GridManager();
            ShotHistory = new ShotHistoryTracker();
        }

        /// <summary>
        /// Manages a player's turn. It displays the shot history then gets a unique coordinate to shoot at.
        /// </summary>
        /// <returns>Target coordinate for the other player's grid to process</returns>
        public Coordinate TakeTurn()
        {
            GridPrinter.PrintShotHistoryGrid(ShotHistory.Shots);

            while (true)
            {
                Coordinate c = ConsoleIO.GetCoordinate("\nEnter target coordinate (ex: A5): ");
                if (!ShotHistory.IsDuplicateShot(c))
                {
                    return c;
                }
                else
                {
                    Console.WriteLine("You already tried shooting at that square, try a different one.");
                }
            }
        }

        /// <summary>
        /// Control flow for player placing all 5 of their ships.
        /// </summary>
        public void PlaceShips()
        {
            Console.Clear();
            Console.WriteLine($"Hello {PlayerName}, let's place your ships!");
            GridPrinter.PrintEmptyGrid();
            Console.WriteLine("Coordinates should be from A-J (column) and 1-10 (row).");
            Console.WriteLine("You will be prompted for the starting coordinate and the direction of placement.");

            PlaceShip("Aircraft Carrier", 5);
            ConsoleIO.AnyKey();

            GridPrinter.PrintShipGrid(Grid.Ships);
            PlaceShip("Battleship", 4);
            ConsoleIO.AnyKey();

            GridPrinter.PrintShipGrid(Grid.Ships);
            PlaceShip("Cruiser", 3);
            ConsoleIO.AnyKey();

            GridPrinter.PrintShipGrid(Grid.Ships);
            PlaceShip("Submarine", 3);
            ConsoleIO.AnyKey();

            GridPrinter.PrintShipGrid(Grid.Ships);
            PlaceShip("Destroyer", 2);
            GridPrinter.PrintShipGrid(Grid.Ships);
            ConsoleIO.AnyKey();
        }

        /// <summary>
        /// Human interaction version of placing ships.
        /// </summary>
        /// <param name="name">Name of ship (ex: Carrier)</param>
        /// <param name="size">Size of ship in grid squares</param>
        private void PlaceShip(string name, int size)
        {
            PlaceShipResult result;

            Console.WriteLine($"\nShip to place: {name} | Size: {size}");

            do
            {
                var coord = ConsoleIO.GetCoordinate("Enter the starting coordinate (ex: A5): ");
                ShipCoordinate start = new ShipCoordinate(coord.X, coord.Y);
                PlacementDirection dir = ConsoleIO.GetPlacementDirection();

                result = Grid.PlaceShip(name, size, start, dir);

                if(result == PlaceShipResult.ShipOffBoard)
                {
                    Console.WriteLine("You cannot place a ship off the grid! Try a better starting coordinate.");
                }
                else if (result == PlaceShipResult.ShipOverlap)
                {
                    Console.WriteLine("Ships may not overlap other ships! Try again.");
                }

            } while (result != PlaceShipResult.Success);

            Console.WriteLine($"You have placed your {name}");
        }
    }
}
