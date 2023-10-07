namespace TicTacToe.UI
{
    using System;
    using TicTacToe.UI.Interfaces;

    public class App
    {
        private readonly GameManager _gameManager;
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;
        private readonly Random _random;

        public App(IPlayer player1, IPlayer player2)
        {
            _player1 = player1;
            _player1.Symbol = "X";
            _player2 = player2;
            _player2.Symbol = "O";
            _gameManager = new GameManager();
            _random = new Random();
        }

        public void Run()
        {
            IPlayer currentPlayer = DetermineFirstPlayer();
            ConsoleIO.PrintGridInstructions();

            while (true)
            {              
                int position = currentPlayer.GetPlacementPosition();
                PlacementResult result = _gameManager.PlaceSymbol(currentPlayer.Symbol, position);
                
                // for computer players, just announce what they chose, human players were prompted.
                if (result == PlacementResult.SymbolPlaced && !currentPlayer.IsHuman)
                {
                    Console.WriteLine($"{currentPlayer.Symbol} chooses position {position}");
                }

                if (result == PlacementResult.InvalidOverlap || result == PlacementResult.InvalidOffGrid)
                {
                    // only print messages about this for humans, computers should just continue and try again.
                    if (currentPlayer.IsHuman)
                    {
                        ConsoleIO.PrintPlacementResultMessage(result);
                    }
                    continue;
                }

                if (result == PlacementResult.XWins || result == PlacementResult.OWins || result == PlacementResult.Draw)
                {
                    // print final grid and message then exit
                    ConsoleIO.PrintGrid(_gameManager.Grid);
                    ConsoleIO.PrintPlacementResultMessage(result);
                    break;
                }

                // swap the current player
                if (currentPlayer == _player1)
                {
                    currentPlayer = _player2;
                }
                else
                {
                    currentPlayer = _player1;
                }

                ConsoleIO.PrintGrid(_gameManager.Grid);
            }
        }

        private IPlayer DetermineFirstPlayer()
        {
            int randomNumber = _random.Next(1, 3);
            if (randomNumber == 1)
            {
                Console.WriteLine($"{_player1.Symbol} will go first!");
                return _player1;
            }
            else
            {
                Console.WriteLine($"{_player2.Symbol} will go first!");
                return _player2;
            }
        }
    }
}
