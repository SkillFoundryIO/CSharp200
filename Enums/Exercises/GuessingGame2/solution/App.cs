using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    public static class App
    {
        public static void Run()
        {
            GameManager mgr = new GameManager();

            do
            {
                Console.Clear();

                Console.WriteLine("Welcome to the Guessing Game!");
                int maxGuess = ConsoleIO.GetMaxNumber();

                mgr.GenerateNumber(maxGuess);

                Console.WriteLine($"I'm thinking of a number between 1 and {maxGuess}. Can you guess it?");
                int guessCount = 0;
                GuessResult result;

                do
                {
                    int guess = ConsoleIO.GetGuess(maxGuess);
                    guessCount++;
                    result = mgr.ParseGuess(guess);
                    ConsoleIO.PrintResult(result);
                } while (result != GuessResult.Win);

                Console.WriteLine($"It took you {guessCount} guesses.");

            } while (ConsoleIO.PlayAgain());
        }
    }
}
