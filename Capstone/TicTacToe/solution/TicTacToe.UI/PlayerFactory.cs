using TicTacToe.UI.Implementations;
using TicTacToe.UI.Interfaces;

namespace TicTacToe.UI
{
    public static class PlayerFactory
    {
        public static IPlayer GetPlayerImplementation(string prompt)
        {
            string input;
            IPlayer player;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine().ToUpper();

                if (input == "C")
                {
                    player = new ComputerRandomPlayer();
                    break;
                }
                else if (input == "H")
                {
                    player = new HumanPlayer();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'C' or 'H'.");
                }

            } while (true);

            return player;
        }
    }

}
