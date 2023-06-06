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
            Choice userChoice = ConsoleIO.GetUserChoice();
            Choice computerChoice = (Choice)_random.Next(1, 4);

            Console.WriteLine($"You picked {userChoice} and the Computer picked {computerChoice}");

            if (userChoice == computerChoice)
            {
                Console.WriteLine("You tied!\n");
                _ties++;
            }
            else if ((userChoice == Choice.Rock && computerChoice == Choice.Scissors) ||
                     (userChoice == Choice.Paper && computerChoice == Choice.Rock) ||
                     (userChoice == Choice.Scissors && computerChoice == Choice.Paper))
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
