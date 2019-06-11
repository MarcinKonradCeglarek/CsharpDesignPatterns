namespace CSharpDesignPatterns._5._Structural_patterns.Bridge
{
    public interface IBridge
    {
        string Draw(int radius, int x, int y);
    }

    internal abstract class Shape
    {
        protected readonly IBridge DrawApi;

        protected Shape(IBridge drawApi)
        {
            this.DrawApi = drawApi;
        }

        public abstract string Draw();
    }

    internal class Circle : Shape
    {
        private readonly int radius;

        private readonly int x;

        private readonly int y;

        public Circle(int x, int y, int radius, IBridge drawApi)
            : base(drawApi)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        public override string Draw()
        {
            return this.DrawApi.Draw(this.radius, this.x, this.y);
        }
    }

    internal class ImplementationOfRedCircle : IBridge
    {
        public string Draw(int radius, int x, int y)
        {
            return $"RED, radius: {radius}, x: {x}, {y}]";
        }
    }

    internal class ImplementationOfGreenCircle : IBridge
    {
        public string Draw(int radius, int x, int y)
        {
            return $"GREEN, radius: {radius}, x: {x}, {y}]";
        }
    }
}