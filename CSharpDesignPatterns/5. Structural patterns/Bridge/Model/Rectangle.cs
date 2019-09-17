namespace CSharpDesignPatterns._5._Structural_patterns.Bridge.Model
{
    using System;

    public class Rectangle : Shape
    {
        public Rectangle(Point upperLeft, double width, double height, IDrawBridge drawBridge)
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