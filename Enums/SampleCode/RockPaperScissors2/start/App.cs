using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public static class App
    {
        public static void Run()
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors!\n");

            GameManager gameManager = new GameManager();

            do
            {
                gameManager.PlayRound();
            } while (ConsoleIO.PlayAgain());

            gameManager.DisplayGameSummary();
        }
    }
}
