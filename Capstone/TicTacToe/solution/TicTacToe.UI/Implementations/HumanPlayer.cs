using TicTacToe.UI.Interfaces;

namespace TicTacToe.UI.Implementations
{
    public class HumanPlayer : IPlayer
    {
        public string Symbol { get; set; }
        public bool IsHuman { get; private set; } = true;

        public byte GetPlacementPosition()
        {
            return ConsoleIO.GetPlayerGridPosition();
        }
    }
}
