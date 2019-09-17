namespace CSharpDesignPatterns._5._Structural_patterns.Bridge.Model
{
    public abstract class Shape
    {
        protected readonly IDrawBridge DrawBridge;

        protected Shape(IDrawBridge drawBridge)
        {
            this.DrawBridge = drawBridge;
        }

        public abstract string Draw();
    }
}