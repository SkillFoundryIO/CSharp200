using System;

namespace PromptMethods.UI
{
    /// <summary>
    /// Contains methods for prompting users
    /// </summary>
    public class Prompter
    {
        /// <summary>
        /// Prompts the user for a non-zero length string
        /// </summary>
        /// <param name="prompt">The text you want to display to the user as a prompt</param>
        /// <returns>A non-zero length string</returns>
        public static string GetRequiredString(string prompt)
        {
            string input;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();

                if(!string.IsNullOrEmpty(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("You must enter at least one character!");
                }
            } while (true);
        }
    }
}
