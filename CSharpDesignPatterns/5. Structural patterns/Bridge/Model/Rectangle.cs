namespace CSharpDesignPatterns._5._Structural_patterns.Bridge.Model
{
    using System;

    public class Rectangle : Shape
    {
        private readonly Point upperLeft;
        private readonly double width;
        private readonly double height;
        private readonly IDrawBridge drawBridge;

        public Rectangle(Point upperLeft, double width, double height, IDrawBridge drawBridge)
            : base(drawBridge)
        {
            this.upperLeft = upperLeft;
            this.width = width;
            this.height = height;
            this.drawBridge = drawBridge;
        }

        public override string Draw()
        {
            return this.drawBridge.DrawRectangle(this.upperLeft, this.width, this.height);
        }
    }
}