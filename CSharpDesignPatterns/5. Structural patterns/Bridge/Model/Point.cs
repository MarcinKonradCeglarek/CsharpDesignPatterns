namespace CSharpDesignPatterns._5._Structural_patterns.Bridge.Model
{
    public struct Point
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get;}
        public double Y { get; }
    }
}