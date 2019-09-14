namespace CSharpDesignPatterns._5._Structural_patterns.Bridge
{
    using System;

    public interface IBridge
    {
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
            throw new NotImplementedException();
        }

        public override string Draw()
        {
            throw new NotImplementedException();
        }
    }

    public class ImplementationOfRedCircle : IBridge
    {
        public string Draw(Circle circle)
        {
            return $"RED circle, radius: {circle.Radius}, x: {circle.X}, {circle.Y}]";
        }
    }

    public class ImplementationOfGreenCircle : IBridge
    {
        public string Draw(Circle circle)
        {
            return $"GREEN circle, radius: [{circle.Radius}, x: {circle.X}, {circle.Y}]";
        }
    }
}