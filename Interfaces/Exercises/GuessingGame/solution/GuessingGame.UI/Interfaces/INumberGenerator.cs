using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame.UI.Interfaces
{
    public interface INumberGenerator
    {
        int MaxGuess { get; }
        int GenerateNumber();
    }
}
