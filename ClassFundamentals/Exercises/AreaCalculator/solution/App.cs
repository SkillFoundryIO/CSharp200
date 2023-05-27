namespace AreaCalculator
{
    public class App
    {
        private ConsoleIO _io;

        public void Run()
        {
            _io = new ConsoleIO();
            int choice;
            do
            {
                choice = _io.GetMenuChoice();
                switch (choice)
                {
                    case 1:
                        CalculateRectangle();
                        break;
                    case 2:
                        CalculateCircle();
                        break;
                    case 3:
                        CalculateTriangle();
                        break;
                    case 4:
                        return;
                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            } while (choice != 4);
        }

        private void CalculateRectangle()
        {
            Rectangle rectangle = new Rectangle();

            double length = _io.GetPositiveValue("Enter length: ");
            double width = _io.GetPositiveValue("Enter width: ");
            double area = rectangle.GetArea(length, width);

            Console.WriteLine($"The area of a rectangle {length}x{width} is {area}.");
        }

        private void CalculateCircle()
        {
            Circle circle = new Circle();

            double radius = _io.GetPositiveValue("Enter radius: ");
            double area = circle.GetArea(radius);

            Console.WriteLine($"The area of a circle with radius {radius} is {area:0.00}.");
        }

        private void CalculateTriangle()
        {
            Triangle triangle = new Triangle();

            double baseLength = _io.GetPositiveValue("Enter base: ");
            double height = _io.GetPositiveValue("Enter height: ");
            double area = triangle.GetArea(baseLength, height);

            Console.WriteLine($"The area of a triangle with base {baseLength} and height {height} is {area:0.00}.");
        }
    }

}
