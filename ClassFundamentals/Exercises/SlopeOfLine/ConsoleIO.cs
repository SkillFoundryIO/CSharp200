using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlopeOfLine
{
    public class ConsoleIO
    {
        public static Point GetPoint(string prompt)
        {
            Console.WriteLine(prompt);

            double x = GetCoordinateValue("Enter X Coordinate: ");
            double y = GetCoordinateValue("Enter Y Coordinate: ");

            return new Point(x, y);
        }

        private static double GetCoordinateValue(string prompt)
        {
            double coord;

            do
            {
                Console.Write(prompt);
                if(double.TryParse(Console.ReadLine(), out coord))
                {
                    return coord;
                }

                Console.WriteLine("Invalid value, please provide a decimal value.");
            } while (true);
        }

        public static void OutputSlope(Line line)
        {
            if(line.IsVertical)
            {
                Console.WriteLine($"A line with points {DisplayCoordinate(line.StartPoint)} and {DisplayCoordinate(line.EndPoint)} is a vertical line and has no slope.");
                return;
            }

            Console.WriteLine($"The slope of a line with points {DisplayCoordinate(line.StartPoint)} and {DisplayCoordinate(line.EndPoint)} is {line.CalculateSlope()}.");
        }

        private static string DisplayCoordinate(Point point)
        {
            return $"({point.X},{point.Y})";
        }
    }
}
