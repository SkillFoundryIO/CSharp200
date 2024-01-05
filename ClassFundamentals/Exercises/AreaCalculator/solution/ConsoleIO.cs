using System;

namespace AreaCalculator
{
    public class ConsoleIO
    {
        public double GetPositiveValue(string prompt)
        {
            double value;

            do
            {
                Console.Write(prompt);

                if(double.TryParse(Console.ReadLine(), out value))
                {
                    if (value >= 0)
                    {
                        return value;
                    }  
                }

                Console.WriteLine("Enter a positive value!");

            } while (true);
        }

        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Area Calculator");
            Console.WriteLine("=================");
            
            Console.WriteLine("1. Rectangle");
            Console.WriteLine("2. Circle");
            Console.WriteLine("3. Triangle");
            Console.WriteLine("4. Quit");
            Console.WriteLine();

            Console.Write("Enter choice: ");
        }

        public int GetMenuChoice()
        {
            int choice;

            do
            {
                DisplayMenu();
                if(int.TryParse(Console.ReadLine(), out choice))
                {
                    if(choice >= 1 && choice <= 4)
                    {
                        return choice;
                    }
                }

                Console.Write("Invalid choice! Press any key to continue...");
                Console.ReadKey();
            } while (true);
        }
    }
}
