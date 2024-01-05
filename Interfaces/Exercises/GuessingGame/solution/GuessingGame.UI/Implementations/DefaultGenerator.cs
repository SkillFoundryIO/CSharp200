using GuessingGame.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame.UI.Implementations
{
    public class DefaultGenerator : INumberGenerator
    {
        private static Random _rng = new Random();

        public int MaxGuess { get; private set; } = 20;

        public int GenerateNumber()
        {
            return _rng.Next(1, 21);
        }
    }
}
