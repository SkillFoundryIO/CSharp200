using GuessingGame.UI.Interfaces;

namespace GuessingGame.UI
{
    public class GameManager
    {
        private INumberGenerator _generator;
        private int _numberToGuess;

        public GameManager(INumberGenerator generator)
        {
            _generator = generator;
            _numberToGuess = _generator.GenerateNumber();
        }

        public int MaxGuess { get { return _generator.MaxGuess; } }

        public GuessResult ParseGuess(int guess)
        {
            if (guess < _numberToGuess)
            {
                return GuessResult.Higher;
            }
            else if (guess > _numberToGuess)
            {
                return GuessResult.Lower;
            }
            else
            {
                return GuessResult.Correct;
            }
        }
    }
}
