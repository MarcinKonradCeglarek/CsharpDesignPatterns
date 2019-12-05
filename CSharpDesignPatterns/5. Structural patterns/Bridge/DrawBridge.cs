namespace CSharpDesignPatterns._5._Structural_patterns.Bridge
{
    using System;

    using CSharpDesignPatterns._5._Structural_patterns.Bridge.Model;

    public interface IDrawBridge
    {
        string DrawCircle(Point    center,    double radius);
        string DrawRectangle(Point upperLeft, double width, double height);
    }

    public class DrawBridge : IDrawBridge
    {
        private readonly string color;

        public DrawBridge(string color)
        {
            throw new NotImplementedException();
        }

        public string DrawCircle(Point center, double radius)
        {
            throw new NotImplementedException();
        }

        public string DrawRectangle(Point upperLeft, double width, double height)
        {
            throw new NotImplementedException();
        }
    }
}