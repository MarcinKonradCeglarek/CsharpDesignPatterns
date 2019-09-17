namespace CSharpDesignPatterns._5._Structural_patterns.Decorator
{
    using System;
    using System.Collections.Generic;

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