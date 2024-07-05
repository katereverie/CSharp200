namespace GridCalculations
{
    public static class ConsoleIO
    {
        private static double PromptDoubleValue(string prompt)
        {
            Console.Write(prompt);
            
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double val))
                {
                    return val;
                }

                Console.WriteLine("Invalid input.");
            }

        }

        public static Coordinate GetCoordinate()
        {
            double x = PromptDoubleValue("Please enter value for x: ");
            double y = PromptDoubleValue("Please enter value for y: ");

            return new Coordinate(x, y);
        }

        public static void DisplayCalculations(Coordinate coord1, Coordinate coord2)
        {
            // Use Calculator class and use two fixed decimal points for the output
            var distance = Calculator.CalculateDistance(coord1, coord2);
            var slope = Calculator.CalculateSlope(coord1, coord2);
            var midpoint = Calculator.CalculateMidpoint(coord1, coord2);
            var angle = Calculator.CalculateAngle(coord1, coord2);

            Console.WriteLine($"Distance between points: {distance:F2}");
            Console.WriteLine($"Slope of the line: {slope:F2}");
            Console.WriteLine($"Midpoint: ({midpoint.X:F2}, {midpoint.Y:F2})");
            Console.WriteLine($"Angle (in degrees) between the line segment and the positive x-axis: {angle:F2}");
        }

        public static bool PromptQuit()
        {
            Console.Write("Do you want to quit? (Y/N): ");

            while (true)
            {
                switch (Console.ReadLine().ToUpper())
                {
                    case "Y":
                        return true;
                    case "N":
                        return false;
                    default:
                        Console.WriteLine("Please enter a valid answer.");
                        continue;
                }
            }
        }
    }
}
