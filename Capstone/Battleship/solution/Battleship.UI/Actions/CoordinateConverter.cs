using Battleship.UI.DTOs;

namespace Battleship.UI.Actions
{
    public static class CoordinateConverter
    {

        public static string ConvertCoordinateToGridValue(Coordinate coordinate)
        {
            return $"{ConvertNumberToLetter(coordinate.X)}{coordinate.Y}";
        }

        public static int ConvertLetterToNumber(string letter)
        {
            switch (letter.ToUpper())
            {
                case "A":
                    return 1;
                case "B":
                    return 2;
                case "C":
                    return 3;
                case "D":
                    return 4;
                case "E":
                    return 5;
                case "F":
                    return 6;
                case "G":
                    return 7;
                case "H":
                    return 8;
                case "I":
                    return 9;
                case "J":
                    return 10;
                default:
                    return -1; // used for errors
            }
        }

        public static string ConvertNumberToLetter(int number)
        {
            switch (number)
            {
                case 1:
                    return "A";
                case 2:
                    return "B";
                case 3:
                    return "C";
                case 4:
                    return "D";
                case 5:
                    return "E";
                case 6:
                    return "F";
                case 7:
                    return "G";
                case 8:
                    return "H";
                case 9:
                    return "I";
                case 10:
                    return "J";
                default:
                    return ""; // used for errors
            }
        }
    }
}