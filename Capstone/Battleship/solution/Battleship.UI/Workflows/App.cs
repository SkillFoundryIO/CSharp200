using Battleship.UI.Actions;
using Battleship.UI.DTOs;
using Battleship.UI.Enums;
using Battleship.UI.Interfaces;

namespace Battleship.UI.Workflows
{
    public class App
    {
        private IPlayer _player1;
        private IPlayer _player2;

        public App(IPlayer player1, IPlayer player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public void Run()
        {
            _player1.PlaceShips();
            _player2.PlaceShips();

            bool player1Turn = true;
            ShotResult result;

            do
            {
                Console.Clear();

                if(player1Turn)
                {
                    ConsoleIO.DisplayPlayerStatus(_player2.PlayerName, _player2.Grid.Ships);
                    Console.WriteLine($"{_player1.PlayerName}'s turn.");
                    Coordinate shot = _player1.TakeTurn();
                    result = _player2.Grid.ProcessShot(shot);
                    _player1.ShotHistory.AddShot(new ShotHistoryCoordinate(shot, result));
                    ConsoleIO.OutputResult(result, shot, _player1.PlayerName);

                    if (_player2.Grid.GameOver)
                    {
                        ConsoleIO.EndGame(_player1.PlayerName);
                        ConsoleIO.AnyKey();
                        return;
                    }
                }
                else
                {
                    ConsoleIO.DisplayPlayerStatus(_player1.PlayerName, _player1.Grid.Ships);
                    Console.WriteLine($"{_player2.PlayerName}'s turn.");
                    Coordinate shot = _player2.TakeTurn();
                    result = _player1.Grid.ProcessShot(shot);
                    _player2.ShotHistory.AddShot(new ShotHistoryCoordinate(shot, result));
                    ConsoleIO.OutputResult(result, shot, _player2.PlayerName);

                    if(_player1.Grid.GameOver)
                    {
                        ConsoleIO.EndGame(_player2.PlayerName);
                        ConsoleIO.AnyKey();
                        return;
                    }
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                player1Turn = !player1Turn; // flip the bool to change the turn.
            } while (true);
        }
    }
}
