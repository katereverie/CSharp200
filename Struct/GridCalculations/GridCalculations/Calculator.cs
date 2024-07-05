namespace GridCalculations
{
    public static class Calculator
    {
        public static double CalculateDistance(Coordinate c1, Coordinate c2)
        {
            double distance = Math.Sqrt(Math.Pow((c2.X - c1.X), 2) + Math.Pow((c2.Y - c1.Y), 2));

            return distance;
        }

        public static double CalculateSlope(Coordinate c1, Coordinate c2)
        {
            double slope = (c2.Y - c1.Y) / (c2.X - c1.X);

            return slope;
        }

        public static Coordinate CalculateMidpoint(Coordinate c1, Coordinate c2)
        {
            Coordinate midpoint = new Coordinate((c1.X + c2.X) / 2, (c1.Y + c2.Y) / 2);

            return midpoint;
        }

        public static double CalculateAngle(Coordinate c1, Coordinate c2)
        {
            double dx = c2.X - c1.X;
            double dy = c2.Y - c1.Y;
            double radians = Math.Atan2(dx, dy);
            double degrees = radians * 180 / Math.PI;

            return degrees;

        }
    }
}
