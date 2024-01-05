namespace Battleship.UI.DTOs
{
    /// <summary>
    /// Adds hit data to a ship's coordinate
    /// </summary>
    public class ShipCoordinate : Coordinate
    {
        public bool IsHit { get; set; }

        public ShipCoordinate(int x, int y) : base(x, y)
        {

        }
    }
}
