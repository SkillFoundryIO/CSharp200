using ClassFields;

Coordinate c1 = new Coordinate();

c1.X = 3;
c1.Y = 5.5;

System.Console.WriteLine($"This coordinate is a point of ({c1.X}, {c1.Y})");

Coordinate[] myPoints = new Coordinate[5];

myPoints[0] = new Coordinate();
myPoints[0].X = 2;
myPoints[0].Y = -1.5;

ClassFields.Custom.Console myConsole = new ClassFields.Custom.Console();