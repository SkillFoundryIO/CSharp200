using Battleship.UI.DTOs;
using Battleship.UI.Enums;

namespace Battleship.UI.Actions
{
    public static class ConsoleIO
    {
        /// <summary>
        /// Ask user for the player type. This code can be expanded to include other IPlayer implementations.
        /// </summary>
        /// <returns>The letter code for the type of player</returns>
        public static string PromptPlayerType(string prompt)
        {
            string input;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }
                else
                {
                    input = input.ToUpper();
                    if (input == "H" || input == "C")
                    {
                        return input;
                    }
                }
            } while (true);
        }

        /// <summary>
        /// Gets a player's name, does not allow blanks.
        /// </summary>
        /// <returns>A valid player name</returns>
        public static string PromptPlayerName()
        {
            string name;

            do
            {
                Console.Write("Enter player name: ");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    continue;
                }
                else
                {
                    return name;
                }
            } while (true);
        }

        /// <summary>
        /// Messaging around taking a shot
        /// </summary>
        /// <param name="result">The shot result (hit, miss, etc.)</param>
        /// <param name="coordinate">Target coordinate</param>
        /// <param name="playerName">The player who fired the shot</param>
        public static void OutputResult(ShotResult result, Coordinate coordinate, string playerName)
        {
            Console.WriteLine($"{playerName} fires a shot at {CoordinateConverter.ConvertCoordinateToGridValue(coordinate)}");

            switch(result)
            {
                case ShotResult.Miss:
                    Console.WriteLine("Splash! The shot missed!");
                    break;
                case ShotResult.Hit:
                    Console.WriteLine("Boom! They hit something!");
                    break;
                default:
                    Console.WriteLine("Boom! Gurgle! The ship is sunk!");
                    break;
            }
        }

        /// <summary>
        /// Message for ending the game.
        /// </summary>
        /// <param name="playerName">The winning player</param>
        public static void EndGame(string playerName)
        {
            Console.WriteLine($"{playerName} is the winner!");
        }

        /// <summary>
        /// Gets a coordinate from the user in format [A-Z][1-10]
        /// </summary>
        /// <param name="prompt">Prompt to show the user, this can be used for both ship placement and firing shots.</param>
        /// <returns>A valid coordinate</returns>
        public static Coordinate GetCoordinate(string prompt)
        {
            int x, y;
            string input;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();

                if(IsValidLength(input))
                {
                    x = GetXCoordinate(input);
                    if (x == -1)
                    {
                        Console.WriteLine("The letter must be between A and J");
                        continue;
                    }

                    y = GetYCoordinate(input);
                    if (y == -1)
                    {
                        Console.WriteLine("The number must be between 1 and 10");
                        continue;
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("That is not a valid coordinate! Please format like \"B10\".");
                }             
            } while (true);
            

            return new Coordinate(x, y);
        }

        /// <summary>
        /// Checks to see if a user inputted coordinate is valid length. ex: "A5" or "A10"
        /// </summary>
        /// <param name="input">The user input</param>
        /// <returns>boolean value indicating the validity of the input.</returns>
        private static bool IsValidLength(string input)
        {
            // input must be at least length 2 but no more than 3.
            if (string.IsNullOrEmpty(input) || input.Length < 2 || input.Length > 3)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the letter part of the user input and converts it to a number.
        /// </summary>
        /// <param name="input">user input</param>
        /// <returns>integer between 1 and 10</returns>
        private static int GetXCoordinate(string input)
        {
            // first char should be a letter.
            return CoordinateConverter.ConvertLetterToNumber(input.Substring(0,1));
        }

        /// <summary>
        /// Gets the number part of the user input and checks to see if it's in range
        /// </summary>
        /// <param name="input">user input</param>
        /// <returns>integer between 1 and 10</returns>
        private static int GetYCoordinate(string input)
        {
            int result;

            if (int.TryParse(input.Substring(1), out result))
            {
                if (result >= 1 && result <= 10)
                {
                    return result;
                }
            }

            return -1;
        }

        /// <summary>
        /// Prompts user for vertical or horizontal placement direction
        /// </summary>
        /// <returns>Enum indicating direction</returns>
        public static PlacementDirection GetPlacementDirection()
        {
            string input;

            do
            {
                Console.Write("Place ship (V)ertical or (H)orizontal: ");
                input = Console.ReadLine().ToUpper();

                if(input == "H")
                {
                    return PlacementDirection.Horizontal;
                }
                else if (input == "V")
                {
                    return PlacementDirection.Vertical;
                }

                Console.WriteLine("Invalid input, plaase choose V or H.");
            } while (true); 
        }

        /// <summary>
        /// Displays the status of a player's ships
        /// </summary>
        /// <param name="ships">The array of ships</param>
        public static void DisplayPlayerStatus(string playerName, Ship[] ships)
        {
            int shipCount = 0;
            int shipSquares = 0;

            for (int i = 0; i < ships.Length; i++)
            {
                if (ships[i] != null && !ships[i].IsSunk)
                {
                    shipCount++;
                    shipSquares += ships[i].HitsLeft;
                }
            }

            Console.WriteLine($"{playerName} has {shipCount} ships remaining with {shipSquares} hits left.");
        }

        /// <summary>
        /// Pause then clear the screen after any keyboard input.
        /// </summary>
        public static void AnyKey()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
