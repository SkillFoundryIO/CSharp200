using GuessingGame.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame.Tests
{
    public class AlwaysPicksFive : INumberGenerator
    {
        public int MaxGuess { get; set; } = 10;

        public int GenerateNumber()
        {
            return 5;
        }
    }
}
