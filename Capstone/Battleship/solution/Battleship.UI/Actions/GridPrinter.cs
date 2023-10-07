using Battleship.UI.DTOs;
using Battleship.UI.Enums;

namespace Battleship.UI.Actions
{
    /// <summary>
    /// This handles printing the various grid views to the console window
    /// </summary>
    public static class GridPrinter
    {
        /// <summary>
        /// Prints the empty battleship grid for players to review
        /// </summary>
        public static void PrintEmptyGrid()
        {
            // Define the grid size
            int rows = 10;
            int cols = 10;

            Console.WriteLine();

            // Print the column headers
            Console.Write("   ");
            for (int c = 0; c < cols; c++)
            {
                Console.Write((char)('A' + c) + " ");
            }
            Console.WriteLine();

            // Print the rows
            for (int r = 1; r <= rows; r++)
            {
                // Print the row number
                Console.Write(r.ToString().PadLeft(2) + " ");

                // Print the cells for this row
                for (int c = 0; c < cols; c++)
                {
                    Console.Write("- ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Prints a color coded shot history grid, given a player's shot history
        /// </summary>
        /// <param name="history">The array of shots taken, this is a 100 element array
        /// with null values for shots not yet taken</param>
        public static void PrintShotHistoryGrid(ShotHistoryCoordinate[] history)
        {
            // Create a char array to hold the grid state
            // Battleship is 10x10 so there are 100 positions
            char[] grid = new char[100];

            // Fill the grid with dashes to represent empty cells
            for (int i = 0; i < grid.Length; i++)
            {
                grid[i] = '-';
            }

            // Update the grid with shot results from the history
            for (int i = 0; i < history.Length; i++)
            {
                // we put shots in the array in order, a null element means we're done
                if (history[i] == null)
                {
                    break;
                }

                ShotHistoryCoordinate shot = history[i];

                // get the grid position associated with the shot
                int index = (shot.Y - 1) * 10 + (shot.X - 1);
                if (shot.ShotResult == ShotResult.Miss)
                {
                    grid[index] = 'M';
                }
                else if (shot.ShotResult == ShotResult.Hit || shot.ShotResult == ShotResult.HitAndSunk)
                {
                    grid[index] = 'H';
                }
            }

            // Print the column headers
            Console.WriteLine("");
            Console.WriteLine("    A B C D E F G H I J");

            // Print the rows
            for (int row = 1; row <= 10; row++)
            {
                // Print the row number, offset #10 because it is two digits.
                if (row == 10)
                {
                    Console.Write($" {row} ");
                }
                else
                {
                    Console.Write($"  {row} ");
                }


                // Print the cells for this row, coloring Red for hit and White for miss
                for (int col = 0; col < 10; col++)
                {
                    // Because we know what row/col we are at we can do the math to convert it to a position on
                    // our 100 element grid array.
                    int index = (row - 1) * 10 + col;
                    char cell = grid[index];
                    if (cell == 'M')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (cell == 'H')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(cell + " ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Prints a grid with the ships marked on it. This is used for ship placement.
        /// </summary>
        /// <param name="ships">The array of ships. This is always length 5 with nulls 
        /// if the ships haven't all been placed yet</param>
        public static void PrintShipGrid(Ship[] ships)
        {
            // Create a char array to hold the grid state
            // Battleship is 10x10 so there are 100 positions
            char[] grid = new char[100];

            // Fill the grid with dashes to represent empty cells
            for (int i = 0; i < grid.Length; i++)
            {
                grid[i] = '-';
            }

            // Update the grid with each ship's coordinates
            for (int i = 0; i < ships.Length; i++)
            {
                // we put ships in the array in order, a null element means we're done
                if (ships[i] == null)
                {
                    break;
                }

                Ship ship = ships[i];
                for (int j = 0; j < ship.Coordinates.Length; j++)
                {
                    if (ship.Coordinates[j] == null)
                    {
                        break;
                    }

                    Coordinate coord = ship.Coordinates[j];
                    // get the grid position associated with the ship coordinate
                    int index = (coord.Y - 1) * 10 + (coord.X - 1);
                    grid[index] = ship.Name[0]; // use the first letter of the ship name to represent it.
                }
            }

            // Print the column headers
            Console.WriteLine("");
            Console.WriteLine("    A B C D E F G H I J");

            // Print the rows
            for (int row = 1; row <= 10; row++)
            {
                // Print the row number, offset #10 because it is two digits.
                if (row == 10)
                {
                    Console.Write($" {row} ");
                }
                else
                {
                    Console.Write($"  {row} ");
                }


                // Print the cells for this row
                for (int col = 0; col < 10; col++)
                {
                    // Because we know what row/col we are at we can do the math to convert it to a position on
                    // our 100 element grid array.
                    int index = (row - 1) * 10 + col;
                    char cell = grid[index];
                    Console.Write(cell + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
