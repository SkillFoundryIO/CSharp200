using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    public class GameManager
    {
        private int _numberToGuess;

        public void GenerateNumber(int maxGuess)
        {
            Random random = new Random();
            _numberToGuess = random.Next(1, maxGuess + 1);
        }

        public bool ParseGuess(int guess)
        {
            if (guess < _numberToGuess)
            {
                Console.WriteLine("Higher");
                return false;
            }
            else if (guess > _numberToGuess)
            {
                Console.WriteLine("Lower");
                return false;
            }
            else
            {
                Console.WriteLine("You got it!");
                return true;
            }
        }
    }
}
