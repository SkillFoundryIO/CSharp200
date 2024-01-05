using GuessingGame.UI.Implementations;

namespace GuessingGame.UI
{
    public static class App
    {
        public static void Run()
        {
            GameManager mgr;

            do
            {
                Console.Clear();

                Console.WriteLine("Welcome to the Guessing Game!");

                if(ConsoleIO.YesNoPrompt("Would you like to set the max guess ? (yes / no) :"))
                {
                    mgr = new GameManager(new UserPromptGenerator());
                }
                else
                {
                    mgr = new GameManager(new DefaultGenerator());
                }    

                Console.WriteLine($"I'm thinking of a number between 1 and {mgr.MaxGuess}. Can you guess it?");
                int guessCount = 0;
                GuessResult result;

                do
                {
                    int guess = ConsoleIO.GetGuess(mgr.MaxGuess);
                    guessCount++;
                    result = mgr.ParseGuess(guess);
                    ConsoleIO.PrintMessage(result);
                } while (result != GuessResult.Correct);

                Console.WriteLine($"It took you {guessCount} guesses.");

            } while (ConsoleIO.YesNoPrompt("Would you like to play again? (yes/no): "));
        }
    }
}
