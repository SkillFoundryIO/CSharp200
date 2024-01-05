using TicTacToe.UI;
using TicTacToe.UI.Interfaces;

Console.WriteLine("Welcome to Tic-Tac-Toe!");
IPlayer p1 = PlayerFactory.GetPlayerImplementation("Player 1 (X) - Human or Computer? (H / C): ");
IPlayer p2 = PlayerFactory.GetPlayerImplementation("Player 2 (O) - Human or Computer? (H / C): ");

App app = new App(p1, p2);
app.Run();