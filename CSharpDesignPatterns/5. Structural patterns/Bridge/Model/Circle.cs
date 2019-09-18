namespace CSharpDesignPatterns._5._Structural_patterns.Bridge.Model
{
    using System;

    public class Circle : Shape
    {
        private readonly double radius;
        private readonly IDrawBridge drawBridge;
        private readonly Point  center;

        public Circle(Point center, double radius, IDrawBridge drawBridge)
            : base(drawBridge)
        {
            this.center = center;
            this.radius = radius;
            this.drawBridge = drawBridge;
        }

        public override string Draw()
        {
            return this.drawBridge.DrawCircle(this.center, this.radius);
        }
    }
}