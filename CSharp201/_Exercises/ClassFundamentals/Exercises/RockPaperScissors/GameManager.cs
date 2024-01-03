using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class GameManager
    {
        private Random _random = new Random();
        private int _wins = 0;
        private int _losses = 0;
        private int _ties = 0;

        public void PlayRound()
        {
            int userChoice = ConsoleIO.GetUserChoice();
            int computerChoice = _random.Next(1, 4);

            Console.WriteLine($"You picked {ConsoleIO.ChoiceToString(userChoice)} and the Computer picked {ConsoleIO.ChoiceToString(computerChoice)}");

            if (userChoice == computerChoice)
            {
                Console.WriteLine("You tied!\n");
                _ties++;
            }
            else if ((userChoice == 1 && computerChoice == 3) ||
                     (userChoice == 2 && computerChoice == 1) ||
                     (userChoice == 3 && computerChoice == 2))
            {
                Console.WriteLine("You won!\n");
                _wins++;
            }
            else
            {
                Console.WriteLine("You lost!\n");
                _losses++;
            }
        }

        public void DisplayGameSummary()
        {
            Console.WriteLine("\nGame Summary:");
            Console.WriteLine($"Wins: {_wins}");
            Console.WriteLine($"Losses: {_losses}");
            Console.WriteLine($"Ties: {_ties}");
            Console.WriteLine("Thank you for playing Rock, Paper, Scissors!");
        }
    }
}
