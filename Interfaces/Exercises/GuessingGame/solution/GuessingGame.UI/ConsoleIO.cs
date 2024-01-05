namespace GuessingGame.UI
{
    public static class ConsoleIO
    {
        public static int GetMaxNumber()
        {
            while (true)
            {
                Console.Write("Enter the maximum value for the number you are seeking: ");
                if (int.TryParse(Console.ReadLine(), out int maxNumber) && maxNumber > 1)
                {
                    return maxNumber;
                }
                Console.WriteLine("Invalid input. Please enter a positive integer greater than 1.");
            }
        }

        public static int GetGuess(int maxGuess)
        {
            while (true)
            {
                Console.Write("Enter your guess: ");
                if (int.TryParse(Console.ReadLine(), out int guess) && guess >= 1 && guess <= maxGuess)
                {
                    return guess;
                }
                Console.WriteLine($"Invalid input. Please enter an integer between 1 and {maxGuess}.");
            }
        }

        public static bool YesNoPrompt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string response = Console.ReadLine().ToLower();
                if (response == "yes")
                {
                    return true;
                }
                else if (response == "no")
                {
                    return false;
                }
                Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
            }
        }

        public static void PrintMessage(GuessResult result)
        {
            switch(result)
            {
                case GuessResult.Correct:
                    Console.WriteLine("You got it!");
                    break;
                case GuessResult.Higher:
                    Console.WriteLine("Higher!");
                    break;
                default:
                    Console.WriteLine("Lower!");
                    break;
            }
        }
    }
}
