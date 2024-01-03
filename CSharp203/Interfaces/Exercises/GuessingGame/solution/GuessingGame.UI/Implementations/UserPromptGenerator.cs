using GuessingGame.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame.UI.Implementations
{
    public class UserPromptGenerator : INumberGenerator
    {
        private static Random _rng = new Random();
        public int MaxGuess { get; private set; }

        public int GenerateNumber()
        {
            MaxGuess = ConsoleIO.GetMaxNumber();
            return _rng.Next(1, MaxGuess + 1);
        }
    }
}
