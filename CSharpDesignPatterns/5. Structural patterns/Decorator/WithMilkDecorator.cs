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
    public class WithMilkDecorator : ICoffee
    {
        private readonly ICoffee coffee;

        public WithMilkDecorator(ICoffee coffee)
        {
            this.coffee = coffee;
        }

        public List<Ingredients> Contents => this.coffee.Contents.Concat(new[] { Ingredients.Milk }).ToList();
        public double Cost => this.coffee.Cost + 0.5;
    }
}