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
    public class WithSprinklesDecorator : ICoffee
    {
        public WithSprinklesDecorator(ICoffee coffee)
        {
            throw new NotImplementedException();
        }

        // Everything in properties 
        public List<Ingredients> Contents => throw new NotImplementedException();
        public double            Cost     => throw new NotImplementedException();
    }
}