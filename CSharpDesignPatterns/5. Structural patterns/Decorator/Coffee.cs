namespace CSharpDesignPatterns._5._Structural_patterns.Decorator
{
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
        public List<Ingredients> Contents { get; }
        public double Cost { get; }
    }
}