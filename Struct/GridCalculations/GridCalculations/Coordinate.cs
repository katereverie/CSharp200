namespace GridCalculations
{
    public struct Coordinate
    {
        public double X {  get; }
        public double Y { get; }

        public Coordinate(double x, double y)
        {
            X = x; 
            Y = y; 
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
