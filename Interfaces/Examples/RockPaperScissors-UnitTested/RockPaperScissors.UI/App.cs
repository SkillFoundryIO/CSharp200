using RockPaperScissors.UI.Implementations;

namespace RockPaperScissors.UI;

public static class App
{
    public static void Run()
    {
        Console.WriteLine("Welcome to Rock, Paper, Scissors!\n");

        GameManager gameManager = new GameManager(new ConsoleGetter(), new RandomGetter());

        do
        {
            var result = gameManager.PlayRound();
            ConsoleIO.DisplayChoices(gameManager.Player1Choice, gameManager.Player2Choice);
            ConsoleIO.DisplayResult(result);

        } while (ConsoleIO.PlayAgain());

        ConsoleIO.DisplayGameSummary(gameManager.Wins, gameManager.Losses, gameManager.Ties);
    }
}
