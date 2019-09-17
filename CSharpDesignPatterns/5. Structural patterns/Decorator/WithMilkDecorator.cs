namespace CSharpDesignPatterns._5._Structural_patterns.Decorator
{
    using System;
    using System.Collections.Generic;

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
        public WithMilkDecorator(ICoffee coffee)
        {
            throw new NotImplementedException();
        }

        public List<Ingredients> Contents { get; }
        public double            Cost     { get; }
    }
}