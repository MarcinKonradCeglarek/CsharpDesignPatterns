namespace CSharpDesignPatterns._5._Structural_patterns.Decorator
{
    using System.Collections.Generic;
    using System.Linq;

    internal interface ICoffee
    {
        IEnumerable<string> Contents { get; }

        double Cost { get; }
    }

    public class Coffee : ICoffee
    {
        public IEnumerable<string> Contents { get; } = new List<string> { "Coffee" };

        public double Cost { get; } = 1;
    }

    internal abstract class CoffeeDecorator : ICoffee
    {
        private readonly ICoffee decoratedCoffee;

        public CoffeeDecorator(ICoffee c)
        {
            this.decoratedCoffee = c;
        }

        public virtual IEnumerable<string> Contents => this.decoratedCoffee.Contents;

        public virtual double Cost => this.decoratedCoffee.Cost;
    }

    internal class WithMilkDecorator : CoffeeDecorator
    {
        public WithMilkDecorator(ICoffee c)
            : base(c)
        {
        }

        public override IEnumerable<string> Contents => base.Contents.Concat(new[] { "Milk" });

        public override double Cost => base.Cost + 0.5;
    }

    internal class WithSprinklesDecorator : CoffeeDecorator
    {
        public WithSprinklesDecorator(ICoffee c)
            : base(c)
        {
        }

        public override IEnumerable<string> Contents => base.Contents.Concat(new[] { "Sprinkles" });

        public override double Cost => base.Cost + 0.2;
    }
}