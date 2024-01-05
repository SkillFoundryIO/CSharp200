
namespace TicTacToe.UI.Interfaces
{
    public interface IPlayer
    {
        string Symbol { get; set; }
        bool IsHuman { get; }

        byte GetPlacementPosition();
    }

}
