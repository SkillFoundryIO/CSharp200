namespace ClassLibraries.Utilities
{
    public static class Prompter
    {
        public static int GetPositiveInteger(string prompt)
        {
            string input;
            int output;
            do
            {
                Console.Write(prompt);
                
                if(int.TryParse(Console.ReadLine(), out output))
                {
                    if(output > 0)
                    {
                        return output;
                    }

                    Console.WriteLine("Value must be positive.");
                }

                Console.WriteLine("Value must be an integer.");                
            } while (true);
        }

    }
}