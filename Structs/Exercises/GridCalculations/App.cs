namespace GridCalculations
{
    public static class App
    {
        public static void Run()
        {
            bool quit = false;

            while(!quit)
            {
                Console.Clear();
                Coordinate c1 = ConsoleIO.GetCoordinate();
                Coordinate c2 = ConsoleIO.GetCoordinate();

                ConsoleIO.DisplayCalculations(c1, c2);

                quit = ConsoleIO.PromptQuit();
            }
        }
    }
}
