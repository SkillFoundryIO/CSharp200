using Battleship.UI.Actions;

namespace Battleship.UI.DTOs
{
    /// <summary>
    /// Coordinate class for interacting with grid. We are going to use numeric values and convert the letters to numbers elsewhere.
    /// </summary>
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{CoordinateConverter.ConvertNumberToLetter(X)}{Y}";
        }

        public override bool Equals(object? obj)
        {
            if(obj is Coordinate)
            {
                Coordinate other = (Coordinate)obj;

                return other.X == X && other.Y == Y;
            }

            return false;
        }
    }
}
