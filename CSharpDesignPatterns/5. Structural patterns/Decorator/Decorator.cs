namespace CSharpDesignPatterns._5._Structural_patterns.Decorator
{
    using System.Collections.Generic;
    using System.Linq;

    /*
     *
     * https://refactoring.guru/design-patterns/decorator
     *
     * Cost:
     * Coffee:      1.0,
     * Milk:        0.5,
     * Sprinkles:   0.2
     */
    public interface ICoffee
    {
        List<Ingredients> Contents { get; }

        double Cost { get; }
    }

    public class Coffee : ICoffee
    {
        public List<Ingredients> Contents => new List<Ingredients> { Ingredients.Coffee };
        public double            Cost     => 1.0;
    }

    public class WithMilkDecorator : ICoffee
    {
        public WithMilkDecorator(ICoffee coffee)
        {
            // Everything in costructor
            this.Cost     = 0.5 + coffee.Cost;
            this.Contents = coffee.Contents.Concat(new[] { Ingredients.Milk }).ToList();
        }

        public List<Ingredients> Contents { get; }
        public double            Cost     { get; }
    }

    public class WithSprinklesDecorator : ICoffee
    {
        private readonly ICoffee baseCoffie;

        public WithSprinklesDecorator(ICoffee coffee)
        {
            this.baseCoffie = coffee;
        }

        // Everything in properties 
        public List<Ingredients> Contents => this.baseCoffie.Contents.Concat(new[] { Ingredients.Sprinkles }).ToList();
        public double            Cost     => this.baseCoffie.Cost + 0.2;
    }

    public enum Ingredients
    {
        Coffee,
        Milk,
        Sprinkles
    }
}