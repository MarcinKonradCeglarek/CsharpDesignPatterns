namespace CSharpDesignPatterns._5._Structural_patterns.Bridge
{
    public interface IBridge
    {
        string Draw(int    radius, int x, int y);
        string Draw(Circle circle);
    }

    public abstract class Shape
    {
        protected readonly IBridge DrawApi;

        protected Shape(IBridge drawApi)
        {
            this.DrawApi = drawApi;
        }

        public abstract string Draw();
    }

    public class Circle : Shape
    {
        public readonly int Radius;
        public readonly int X;
        public readonly int Y;

        public Circle(int x, int y, int radius, IBridge drawApi)
            : base(drawApi)
        {
            this.X      = x;
            this.Y      = y;
            this.Radius = radius;
        }

        public override string Draw()
        {
            return this.DrawApi.Draw(this);
        }
    }

    public class ImplementationOfRedCircle : IBridge
    {
        public string Draw(int radius, int x, int y)
        {
            return $"RED, radius: {radius}, x: {x}, {y}]";
        }

        public string Draw(Circle circle)
        {
            return $"RED, radius: {circle.Radius}, x: {circle.X}, {circle.Y}]";
        }
    }

    public class ImplementationOfGreenCircle : IBridge
    {
        public string Draw(int radius, int x, int y)
        {
            return $"GREEN, radius: {radius}, x: {x}, {y}]";
        }

        public string Draw(Circle circle)
        {
            return $"GREEN, radius: [{circle.Radius}, x: {circle.X}, {circle.Y}]";
        }
    }
}