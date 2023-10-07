using Battleship.UI.DTOs;
using Battleship.UI.Enums;

namespace Battleship.UI.Actions
{
    /// <summary>
    /// Manages all the ships on a grid for a player including placement and target checking
    /// </summary>
    public class GridManager
    {
        public Ship[] Ships { get; private set; } = new Ship[5];

        /// <summary>
        /// Game is over if all ships are sunk
        /// </summary>
        public bool GameOver
        {
            get
            {
                for (int i = 0; i < Ships.Length; i++)
                {
                    if (Ships[i] != null)
                    {
                        if (!Ships[i].IsSunk)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }

        /// <summary>
        /// Reports whether an incoming shot hit, missed, or sunk a ship.
        /// </summary>
        /// <param name="target">The target coordinate</param>
        /// <returns>Enum indicating result</returns>
        public ShotResult ProcessShot(Coordinate target)
        {
            ShotResult result = ShotResult.Miss;

            for (int i = 0; i < Ships.Length; i++)
            {
                if (Ships[i] != null)
                {
                    // we don't need to check sunk ships
                    if (!Ships[i].IsSunk)
                    {
                        result = Ships[i].ProcessShot(target);

                        // if we detect a hit, we can stop
                        if (result != ShotResult.Miss)
                        {
                            return result;
                        }
                    }
                }
            }

            // if we get here, it was a miss
            return result;
        }

        /// <summary>
        /// Tries to place a ship on the grid. It will validate the ship is on the board and does not overlap existing ships
        /// </summary>
        /// <param name="name">Name of ship, ex: Destroyer</param>
        /// <param name="size">Size in grid squares of ship</param>
        /// <param name="start">Starting coordinate</param>
        /// <param name="direction">Direction of placement</param>
        /// <returns></returns>
        public PlaceShipResult PlaceShip(string name, int size, ShipCoordinate start, PlacementDirection direction)
        {
            // see if the ship will end up off the board
            if(ShipPlacementOffBoard(size, start, direction))
            {
                return PlaceShipResult.ShipOffBoard;
            }

            // we have valid coordinates, let's generate the coordinates and create a ship object
            Ship ship = CreateShip(name, size, start, direction);

            // loop the ships to see if we have any overlaps
            for (int i = 0; i < Ships.Length; i++)
            {
                if (Ships[i] != null)
                {
                    // check each ship coordinate against the existing ship coordinates.
                    for (int j = 0; j < ship.Coordinates.Length; j++)
                    {
                        if (Ships[i].HasCoordinate(ship.Coordinates[j]))
                        {
                            return PlaceShipResult.ShipOverlap;
                        }
                    }
                }
                else // this ship is good, store it in the null slot and exit
                {
                    Ships[i] = ship;
                    return PlaceShipResult.Success;
                }
            }

            // If we get here and didn't place the ship, something went very wrong.
            return PlaceShipResult.Error;
        }

        /// <summary>
        /// Create a ship with coordinates, the ship off board should already have been validated.
        /// </summary>
        /// <param name="name">Name of ship, ex: Destroyer</param>
        /// <param name="size">Size in grid squares of ship</param>
        /// <param name="start">Starting coordinate</param>
        /// <param name="direction">Direction of placement</param>
        /// <returns>An instantiated ship object</returns>
        private Ship CreateShip(string name, int size, ShipCoordinate start, PlacementDirection direction)
        {
            ShipCoordinate[] coordinates = new ShipCoordinate[size];

            if (direction == PlacementDirection.Horizontal)
            {
                int currentX = start.X;

                for (int i = 0; i < size; i++)
                {
                    coordinates[i] = new ShipCoordinate(currentX, start.Y);
                    currentX++;
                }
            }
            else
            {
                int currentY = start.Y;

                for (int i = 0; i < size; i++)
                {
                    coordinates[i] = new ShipCoordinate(start.X, currentY);
                    currentY++;
                }
            }

            return new Ship(name, coordinates);
        }

        /// <summary>
        /// Checks to see if the size/direction of the ship will place it off the board. Coordinates are inclusive so we take 1 off.
        /// </summary>
        /// <param name="size">Size in grid squares of the ship</param>
        /// <param name="start">Starting coordinate</param>
        /// <param name="direction">Direction of the placement</param>
        /// <returns>Whether or not this hypothetical ship will be off the board (true is bad)</returns>
        private bool ShipPlacementOffBoard(int size, Coordinate start, PlacementDirection direction)
        {
            if(direction == PlacementDirection.Horizontal)
            {
                if(start.X + size - 1 > 10)
                {
                    return true;
                }
            }
            else
            {
                if(start.Y + size - 1 > 10)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
