namespace CSharpDesignPatterns._5._Structural_patterns.Bridge
{
    using System;

    using CSharpDesignPatterns._5._Structural_patterns.Bridge.Model;

    public interface IDrawBridge
    {
        string DrawCircle(Point center, double radius);
        string DrawRectangle(Point upperLeft, double width, double height);
    }

    public class DrawBridge : IDrawBridge
    {
        private readonly string color;

        public DrawBridge(string color)
        {
            this.color = color;
        }

        public string DrawCircle(Point center, double radius)
        {
            return $"{this.color} circle at [{center.X:N2}, {center.Y:N2}], radius: {radius:N2}";
        }

        public string DrawRectangle(Point upperLeft, double width, double height)
        {
            return $"{this.color} rectangle starting at [{upperLeft.X:N2}, {upperLeft.Y:N2}] with width: {width:N2} and height {height:N2}";
        }
    }
}