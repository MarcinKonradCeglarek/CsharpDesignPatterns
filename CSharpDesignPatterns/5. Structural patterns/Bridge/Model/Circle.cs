namespace CSharpDesignPatterns._5._Structural_patterns.Bridge.Model
{
    using System;

    public class Circle : Shape
    {
        private readonly double radius;
        private readonly Point  center;

        public Circle(Point center, double radius, IDrawBridge drawBridge)
            : base(drawBridge)
        {
            throw new NotImplementedException();
        }

        public override string Draw()
        {
            throw new NotImplementedException();
        }
    }
}