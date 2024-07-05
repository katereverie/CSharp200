namespace GridCalculations
{
    public static class App
    {
        public static void Run()
        {
            while (true)
            {
                Console.Clear();

                var p1 = ConsoleIO.GetCoordinate();
                var p2 = ConsoleIO.GetCoordinate();

                Console.WriteLine($"Coordinates:\nPoint 1: {p1.ToString()}\nPoint 2: {p2.ToString()}\n");

                ConsoleIO.DisplayCalculations(p1, p2);

                if (ConsoleIO.PromptQuit())
                {
                    break;
                }
            }
        }
    }
}
