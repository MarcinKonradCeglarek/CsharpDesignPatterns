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
    public interface ICoffee
    {
        List<Ingredients> Contents { get; }

        double Cost { get; }
    }

    public class Coffee : ICoffee
    {
        public List<Ingredients> Contents { get; } = new List<Ingredients> { Ingredients.Coffee };
        public double            Cost     => 1.0;
    }

    public class WithMilkDecorator : ICoffee
    {
        public WithMilkDecorator(ICoffee coffee)
        {
            throw new NotImplementedException();
        }

        public List<Ingredients> Contents { get; }
        public double            Cost     { get; }
    }

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

    public enum Ingredients
    {
        Coffee,
        Milk,
        Sprinkles
    }
}