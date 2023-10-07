using Battleship.UI.Actions;
using Battleship.UI.DTOs;

namespace Battleship.UI.Interfaces
{
    public interface IPlayer
    {
        string PlayerName { get; set; }
        GridManager Grid { get; set; }
        ShotHistoryTracker ShotHistory { get; set; }

        void PlaceShips();
        Coordinate TakeTurn();
    }
}
