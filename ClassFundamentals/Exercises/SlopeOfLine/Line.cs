namespace SlopeOfLine
{
    public class Line
    {
        public Point StartPoint { get; private set; }
        public Point EndPoint { get; private set; }
        public bool IsVertical { get { return StartPoint.X - EndPoint.X == 0; } }

        public Line(Point start, Point end)
        {
            StartPoint = start;
            EndPoint = end;
        }

        public double CalculateSlope()
        {
            // do not allow divide by zero
            if(IsVertical)
            {
                return 0;
            }

            return (EndPoint.Y - StartPoint.Y) / (EndPoint.X - StartPoint.X);
        }
    }
}
