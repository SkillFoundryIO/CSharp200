namespace TicTacToe.UI
{
    public class GameManager
    {
        public string[] Grid { get; private set; }

        public GameManager()
        {
            Grid = new string[9];
        }

        /// <summary>
        /// Workflow for placing a symbol on the grid at a specified location.
        /// First, it checks validity, then places the symbol, then checks for game over conditions.
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public PlacementResult PlaceSymbol(string symbol, int location)
        {
            if (!CheckRange(location))
            {
                return PlacementResult.InvalidOffGrid;
            }

            int index = location - 1;
            if (CheckOverlap(index))
            {
                return PlacementResult.InvalidOverlap;
            }

            Grid[index] = symbol;

            if (CheckWin(symbol))
            {
                // they won, but which symbol won?
                if(symbol == "X")
                {
                    return PlacementResult.XWins;
                }
                else
                {
                    return PlacementResult.OWins;
                }
            }

            if (CheckDraw())
            {
                return PlacementResult.Draw;
            }

            return PlacementResult.SymbolPlaced;
        }

        /// <summary>
        /// Checks that a location attempted by the player is in range.
        /// </summary>
        /// <param name="location">location 1-9, which is converted to 0-8 for the array indexes</param>
        /// <returns>True if the location is valid.</returns>
        private bool CheckRange(int location)
        {
            return location >= 1 && location <= 9;
        }

        /// <summary>
        /// Checks to see if there is already a symbol in the given array element.
        /// </summary>
        /// <param name="index">Index of the array being checked.</param>
        /// <returns>True if there is already a symbol in the element.</returns>
        private bool CheckOverlap(int index)
        {
            return !string.IsNullOrEmpty(Grid[index]);
        }

        /// <summary>
        /// This method groups up all the win condition checks for readability and convenience
        /// </summary>
        /// <param name="symbol">The symbol the player played, checking for win</param>
        /// <returns>True if the given symbol is a winner</returns>
        private bool CheckWin(string symbol)
        {
            return CheckRows(symbol) || CheckColumns(symbol) || CheckDiagonals(symbol);
        }

        /// <summary>
        /// Check the rows 0, 3, 6 for horizontal wins based on the symbol played.
        /// </summary>
        /// <param name="symbol">The symbol the player played, checking for win</param>
        /// <returns>True if the given symbol is a winner</returns>
        private bool CheckRows(string symbol)
        {
            for (int i = 0; i < 9; i += 3)
            {
                if (Grid[i] == symbol && Grid[i + 1] == symbol && Grid[i + 2] == symbol)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Check the columns (0,1,2) for vertical wins, which are always 3 higher than the previous column
        /// </summary>
        /// <param name="symbol">The symbol the player played, checking for win</param>
        /// <returns>True if the given symbol is a winner</returns>
        private bool CheckColumns(string symbol)
        {
            for (int i = 0; i < 3; i++)
            {
                if (Grid[i] == symbol && Grid[i + 3] == symbol && Grid[i + 6] == symbol)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Check the diagonal possiblities against the symbol.
        /// </summary>
        /// <param name="symbol">The symbol the player played, checking for a win</param>
        /// <returns>True if the given symbol is a winner</returns>
        private bool CheckDiagonals(string symbol)
        {
            return (Grid[0] == symbol && Grid[4] == symbol && Grid[8] == symbol) ||
                   (Grid[2] == symbol && Grid[4] == symbol && Grid[6] == symbol);
        }

        /// <summary>
        /// Check for a draw, which happens if each grid slot is filled with no winner.
        /// If any grid slot is null or empty, it's not a draw.
        /// </summary>
        /// <returns>True if the game is a draw</returns>
        private bool CheckDraw()
        {
            for (int i = 0; i < Grid.Length; i++)
            {
                if (string.IsNullOrEmpty(Grid[i]))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
