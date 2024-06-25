namespace GridCalculations
{
    public static class Calculator
    {
        public static double CalculateDistance(Coordinate point1, Coordinate point2)
        {
            double dx = point2.X - point1.X;
            double dy = point2.Y - point1.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public static double CalculateSlope(Coordinate point1, Coordinate point2)
        {
            double dx = point2.X - point1.X;
            double dy = point2.Y - point1.Y;
            return dy / dx;
        }

        public static Coordinate CalculateMidpoint(Coordinate point1, Coordinate point2)
        {
            double midX = (point1.X + point2.X) / 2;
            double midY = (point1.Y + point2.Y) / 2;
            return new Coordinate(midX, midY);
        }

        public static double CalculateAngle(Coordinate point1, Coordinate point2)
        {
            double dx = point2.X - point1.X;
            double dy = point2.Y - point1.Y;
            return Math.Atan2(dy, dx) * 180 / Math.PI;
        }
    }
}
