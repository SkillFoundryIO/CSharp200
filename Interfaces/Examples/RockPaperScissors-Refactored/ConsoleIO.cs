

namespace RockPaperScissors;

public static class ConsoleIO
{
    public static Choice GetUserChoice()
    {
        while (true)
        {
            Console.Write("Please enter your choice (R)ock, (P)aper, (S)cissors): ");
            char input = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (char.ToUpper(input))
            {
                case 'R':
                    return Choice.Rock;
                case 'P':
                    return Choice.Paper;
                case 'S':
                    return Choice.Scissors;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }
    }

    public static bool PlayAgain()
    {
        while (true)
        {
            Console.Write("Do you want to play again? (Y/N): ");
            char input = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (char.ToUpper(input) == 'Y')
                return true;
            else if (char.ToUpper(input) == 'N')
                return false;
            else
                Console.WriteLine("Invalid input. Please try again.");
        }
    }

    public static void DisplayChoices(Choice player1Choice, Choice player2Choice)
    {
        Console.WriteLine($"Player 1 picked {player1Choice} and player 2 picked {player2Choice}");
    }

    public static void DisplayResult(RoundResult result)
    {
        switch(result)
        {
            case RoundResult.Tie:
                Console.WriteLine("It's a tie!");
                break;
            case RoundResult.Player1Wins:
                Console.WriteLine("Player 1 wins!");
                break;
            case RoundResult.Player2Wins:
                Console.WriteLine("Player 2 wins!");
                break;
        }
    }

    public static void DisplayGameSummary(int wins, int losses, int ties)
    {
        Console.WriteLine("\nGame Summary:");
        Console.WriteLine($"Wins: {wins}");
        Console.WriteLine($"Losses: {losses}");
        Console.WriteLine($"Ties: {ties}");
        Console.WriteLine("Thank you for playing Rock, Paper, Scissors!");
    }
}
