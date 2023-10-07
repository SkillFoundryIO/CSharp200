using Battleship.UI.Actions;
using Battleship.UI.Enums;

namespace Battleship.UI.DTOs
{
    /// <summary>
    /// History element for printing a coordinate and the shot result.
    /// </summary>
    public class ShotHistoryCoordinate : Coordinate
    {
        public ShotResult ShotResult { get; set; }

        public ShotHistoryCoordinate(Coordinate coordinate, ShotResult result) : base(coordinate.X, coordinate.Y)
        {
            ShotResult = result;
        }

        public override string ToString()
        {
            return $"{CoordinateConverter.ConvertNumberToLetter(X)}{Y}";
        }
    }
}
