using System;

namespace AboutMe
{
    public class Prompter
    {
        public static string GetRequiredString(string prompt)
        {
            string val;

            do
            {
                Console.Write(prompt);
                val = Console.ReadLine().Trim(); // remove spaces

                if(!string.IsNullOrEmpty(val))
                {
                    return val;
                }
                else
                {
                    Console.WriteLine("You must enter at least one non-space character!");
                }
            } while (true);
        }

        public static int GetIntInRange(string prompt, int min, int max)
        {
            int val;

            do
            {
                Console.Write(prompt);
                if(int.TryParse(Console.ReadLine(), out val))
                {
                    if(val >= min && val <= max)
                    {
                        return val;
                    }
                }
                else
                {
                    Console.WriteLine($"Age must be between {min} and {max}!");
                }
            } while (true);
        }

        public static string GetMaritalStatus()
        {
            string val;

            do
            {
                Console.Write("Marital Status (S)ingle, (M)arried: ");
                val = Console.ReadLine().ToUpper();

                if (val == "S" || val == "M")
                {
                    return val;
                }
                else
                {
                    Console.WriteLine("Marital status must be S or M!");
                }
            } while (true);
        }

        public static DateTime GetPastDate(string prompt)
        {
            DateTime val;

            do
            {
                Console.Write(prompt);
                if(DateTime.TryParse(Console.ReadLine(), out val))
                {
                    if(val < DateTime.Today)
                    {
                        return val;
                    }
                }
                else
                {
                    Console.WriteLine("Date must be in the past!");
                }
            } while (true);
        }
    }
}
