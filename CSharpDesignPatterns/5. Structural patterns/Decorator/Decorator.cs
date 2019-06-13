﻿namespace CSharpDesignPatterns._5._Structural_patterns.Decorator
{
    using System.Collections.Generic;
    using System.Linq;

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

        public virtual IEnumerable<Ingredients> Contents => this.decoratedCoffee.Contents;
        public virtual double                   Cost     => this.decoratedCoffee.Cost;
    }

    public class WithMilkDecorator : CoffeeDecorator
    {
        public WithMilkDecorator(ICoffee c)
            : base(c)
        {
        }

        public override IEnumerable<Ingredients> Contents => base.Contents.Concat(new[] { Ingredients.Milk });
        public override double                   Cost     => base.Cost + 0.5;
    }

    public class WithSprinklesDecorator : CoffeeDecorator
    {
        public WithSprinklesDecorator(ICoffee c)
            : base(c)
        {
        }

        public override IEnumerable<Ingredients> Contents => base.Contents.Concat(new[] { Ingredients.Sprinkles });
        public override double                   Cost     => base.Cost + 0.2;
    }

    public enum Ingredients
    {
        Coffee,
        Milk,
        Sprinkles
    }
}