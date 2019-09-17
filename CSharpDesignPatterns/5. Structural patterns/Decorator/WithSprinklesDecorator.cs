namespace CSharpDesignPatterns._5._Structural_patterns.Decorator
{
    using System;
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
    public class WithSprinklesDecorator : ICoffee
    {
        public WithSprinklesDecorator(ICoffee coffee)
        {
            this.Cost = coffee.Cost + 0.2;
            this.Contents = coffee.Contents.Concat(new[] { Ingredients.Sprinkles }).ToList();
        }

        // Everything in properties 
        public List<Ingredients> Contents { get; }
        public double Cost { get; }
    }
}