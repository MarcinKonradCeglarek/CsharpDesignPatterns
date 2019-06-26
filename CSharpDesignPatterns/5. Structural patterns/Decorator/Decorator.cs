namespace CSharpDesignPatterns._5._Structural_patterns.Decorator
{
    using System.Collections.Generic;
    using System.Linq;

    /*
     * Cost:
     * Coffe:       1.0,
     * Milk:        0.5,
     * Sprinkles:   0.2
     */
    public interface ICoffee
    {
        IEnumerable<Ingredients> Contents { get; }

        double Cost { get; }
    }

    public class Coffee : ICoffee
    {
        public IEnumerable<Ingredients> Contents { get; } = new List<Ingredients> { Ingredients.Coffee };

        public double Cost { get; } = 1;
    }

    public abstract class CoffeeDecorator : ICoffee
    {
        private readonly ICoffee decoratedCoffee;

        protected CoffeeDecorator(ICoffee c)
        {
            this.decoratedCoffee = c;
        }

        public IEnumerable<Ingredients> Contents { get; }
        public double Cost { get; }
    }

    public class WithMilkDecorator : CoffeeDecorator
    {
        public WithMilkDecorator(ICoffee c)
            : base(c)
        {
        }
    }

    public class WithSprinklesDecorator : CoffeeDecorator
    {
        public WithSprinklesDecorator(ICoffee c)
            : base(c)
        {
        }
    }

    public enum Ingredients
    {
        Coffee,
        Milk,
        Sprinkles
    }
}