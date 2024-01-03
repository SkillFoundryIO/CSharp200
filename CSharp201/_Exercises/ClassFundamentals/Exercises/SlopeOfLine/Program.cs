using SlopeOfLine;

Point p1 = ConsoleIO.GetPoint("Start Point");
Console.WriteLine();

Point p2 = ConsoleIO.GetPoint("End Point");
Console.WriteLine();

Line l1 = new Line(p1, p2);

ConsoleIO.OutputSlope(l1);
Console.ReadKey();
