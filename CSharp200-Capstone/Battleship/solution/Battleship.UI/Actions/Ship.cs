using Battleship.UI.DTOs;
using Battleship.UI.Enums;

namespace Battleship.UI.Actions
{
    /// <summary>
    /// Contains all data and functions relating to a single ship
    /// </summary>
    public class Ship
    {
        public string Name { get; private set; }
        public int Size { get { return Coordinates.Length; } }
        public int HitsLeft { get; private set; }
        public bool IsSunk { get { return HitsLeft == 0; } }
        public ShipCoordinate[] Coordinates { get; private set; }

        /// <summary>
        /// Sets up a ship object
        /// </summary>
        /// <param name="name">Name of the ship (ex: Carrier)</param>
        /// <param name="coordinates">The coordinates on the grid the ship is located on</param>
        public Ship(string name, ShipCoordinate[] coordinates)
        {
            Coordinates = coordinates;
            HitsLeft = coordinates.Length;
            Name = name;
        }

        /// <summary>
        /// Checks to see if a shot would hit the ship, if so, null out the coordinate 
        /// and check to see if there are no more hits remaining, and therefore sunk.
        /// </summary>
        /// <param name="target">The target coordinate</param>
        /// <returns>The result of the shot (hit, miss, sunk)</returns>
        public ShotResult ProcessShot(Coordinate target)
        {
            for (int i = 0; i < Coordinates.Length; i++)
            {
                // coordinates can only be hit once
                if (Coordinates[i].Equals(target) && !Coordinates[i].IsHit)
                {
                    Coordinates[i].IsHit = true;
                    HitsLeft--;
                    if (HitsLeft == 0)
                    {
                        return ShotResult.HitAndSunk;
                    }

                    return ShotResult.Hit;
                }
            }

            return ShotResult.Miss;
        }

        /// <summary>
        /// Check to see if a coordinate intersects with the ship, for placement
        /// </summary>
        /// <param name="target">The target coordinate</param>
        /// <returns>True if the coordinate is in the ship array</returns>
        public bool HasCoordinate(Coordinate target)
        {
            for (int i = 0; i < Coordinates.Length; i++)
            {
                if (Coordinates[i].Equals(target))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
