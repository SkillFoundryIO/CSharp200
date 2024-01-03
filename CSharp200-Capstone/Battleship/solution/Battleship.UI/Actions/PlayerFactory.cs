using Battleship.UI.Implementations;
using Battleship.UI.Interfaces;

namespace Battleship.UI.Actions
{
    public static class PlayerFactory
    {
        public static IPlayer GetPlayer(int number)
        {
            string playerType = ConsoleIO.PromptPlayerType($"Is player {number} a (H)uman or (C)omputer? ");
            if (playerType == "H")
            {
                string name = ConsoleIO.PromptPlayerName();
                return new HumanPlayer(name);
            }
            else
            {
                return new RandomPlayer();
            }

        }
    }
}
