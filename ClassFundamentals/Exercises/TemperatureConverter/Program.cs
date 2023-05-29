using TemperatureConverter;

Temperature t1 = new Temperature();

Console.Write("Enter temperature (K): ");
t1.Kelvin = double.Parse(Console.ReadLine());

Console.WriteLine($"The temperature is {t1.Kelvin}K, {t1.Celsius}C, {t1.Fahrenheit}F.");