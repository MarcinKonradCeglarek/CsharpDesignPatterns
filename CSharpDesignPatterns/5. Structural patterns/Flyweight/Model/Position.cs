namespace CSharpDesignPatterns._5._Structural_patterns.Flyweight
{
    public struct Position
    {
        public readonly double X;
        public readonly double Y;
        public readonly double Z;

        public Position(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }
}