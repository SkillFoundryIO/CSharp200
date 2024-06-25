
namespace GridCalculations
{
    public static class ConsoleIO
    {
        public static Coordinate GetCoordinate()
        {
            double x = PromptDoubleValue("Enter the X value: ");
            double y = PromptDoubleValue("Enter the Y value: ");
            return new Coordinate(x, y);
        }

        private static double PromptDoubleValue(string prompt)
        {
            double value;

            do
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
                    
                Console.WriteLine("Invalid input. Please enter a valid number.");
            } while(true);
        }

        public static bool PromptQuit()
        {
            do
            {
                Console.Write("Do you want to quit? (Y/N): ");
                string input = Console.ReadLine().ToUpper();
                if (input == "Y")
                    return true;
                else if (input == "N")
                    return false;
                Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");

            } while (true);
        }

        public static void DisplayCalculations(Coordinate c1, Coordinate c2)
        {
            Console.WriteLine("Coordinates:");
            Console.WriteLine($"Point 1: ({c1.X}, {c1.Y})");
            Console.WriteLine($"Point 2: ({c2.X}, {c2.Y})");
            Console.WriteLine();

            double distance = Calculator.CalculateDistance(c1, c2);
            Console.WriteLine($"Distance between points: {distance:F2}");

            double slope = Calculator.CalculateSlope(c1, c2);
            Console.WriteLine($"Slope of the line: {slope:F2}");

            Coordinate midpoint = Calculator.CalculateMidpoint(c1, c2);
            Console.WriteLine($"Midpoint: ({midpoint.X:F2}, {midpoint.Y:F2})");

            double angle = Calculator.CalculateAngle(c1, c2);
            Console.WriteLine($"Angle (in degrees) between the line segment and the positive x-axis: {angle:F2}");

            Console.WriteLine();
        }
    }
}
