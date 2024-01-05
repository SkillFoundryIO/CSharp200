using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public static class ConsoleIO
    {
        public static int GetUserChoice()
        {
            int choice = 0;
            while (choice == 0)
            {
                Console.Write("Please enter your choice (R)ock, (P)aper, (S)cissors): ");
                char input = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (char.ToUpper(input))
                {
                    case 'R':
                        choice = 1;
                        break;
                    case 'P':
                        choice = 2;
                        break;
                    case 'S':
                        choice = 3;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
            return choice;
        }

        public static bool PlayAgain()
        {
            while (true)
            {
                Console.Write("Do you want to play again? (Y/N): ");
                char input = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (char.ToUpper(input) == 'Y')
                    return true;
                else if (char.ToUpper(input) == 'N')
                    return false;
                else
                    Console.WriteLine("Invalid input. Please try again.");
            }
        }

        public static string ChoiceToString(int choice)
        {
            switch (choice)
            {
                case 1:
                    return "Rock";
                case 2:
                    return "Paper";
                case 3:
                    return "Scissors";
                default:
                    return "Invalid choice";
            }
        }
    }
}
