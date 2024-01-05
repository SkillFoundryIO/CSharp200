using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public static class ConsoleIO
    {
        public static Choice GetUserChoice()
        {
            while (true)
            {
                Console.Write("Please enter your choice (R)ock, (P)aper, (S)cissors): ");
                char input = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (char.ToUpper(input))
                {
                    case 'R':
                        return Choice.Rock;
                    case 'P':
                        return Choice.Paper;
                    case 'S':
                        return Choice.Scissors;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
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
    }
}
