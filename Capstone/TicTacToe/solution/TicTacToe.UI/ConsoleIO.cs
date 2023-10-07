namespace TicTacToe.UI
{
    public static class ConsoleIO
    {
        public static void PrintGridInstructions()
        {
            Console.WriteLine("Here are the positions of the grid: ");
            Console.WriteLine("");
            Console.WriteLine($" 1 | 2 | 3 ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" 4 | 5 | 6 ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" 7 | 8 | 9 ");
            Console.WriteLine("");
        }

        /// <summary>
        /// Print the grid based on the symbols array from the game manager.
        /// </summary>
        /// <param name="symbols">the array of symbols, it should always be length 9 since tic tac toe grid is static</param>
        public static void PrintGrid(string[] symbols)
        {
            Console.WriteLine("");
            Console.WriteLine($" {GetSymbolOrSpace(symbols[0])} | {GetSymbolOrSpace(symbols[1])} | {GetSymbolOrSpace(symbols[2])} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {GetSymbolOrSpace(symbols[3])} | {GetSymbolOrSpace(symbols[4])} | {GetSymbolOrSpace(symbols[5])} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {GetSymbolOrSpace(symbols[6])} | {GetSymbolOrSpace(symbols[7])} | {GetSymbolOrSpace(symbols[8])} ");
            Console.WriteLine("");
        }

        /// <summary>
        /// Given an array element value, return the symbol (X/O) or a space if it's empty/null
        /// </summary>
        /// <param name="symbol">The current symbol in the array element, it will be X, O, or null</param>
        /// <returns>Either the symbol, if present, or a space if it's not.</returns>
        private static string GetSymbolOrSpace(string symbol)
        {
            if (string.IsNullOrEmpty(symbol))
            {
                return " ";
            }
            else
            {
                return symbol;
            }
        }

        /// <summary>
        /// Gets the grid position that a player would like to put their symbol in (1-9)
        /// </summary>
        /// <returns>The chosen value between 1 and 9</returns>
        public static byte GetPlayerGridPosition()
        {
            byte position;
            bool valid;

            do
            {
                Console.Write("Choose a position (1-9): ");
                string input = Console.ReadLine();
                valid = byte.TryParse(input, out position) && position >= 1 && position <= 9;

                if (!valid)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                }
            } while (!valid);

            return position;
        }

        public static void PrintPlacementResultMessage(PlacementResult result)
        {
            switch (result)
            {
                case PlacementResult.XWins:
                    Console.WriteLine("Player X wins!");
                    break;
                case PlacementResult.OWins:
                    Console.WriteLine("Player O wins!");
                    break;
                case PlacementResult.Draw:
                    Console.WriteLine("It's a draw!");
                    break;
                case PlacementResult.InvalidOverlap:
                    Console.WriteLine("Invalid move. The position is already occupied.");
                    break;
                case PlacementResult.InvalidOffGrid:
                    Console.WriteLine("Invalid move. The position is outside the grid.");
                    break;
            }
        }

    }

}
