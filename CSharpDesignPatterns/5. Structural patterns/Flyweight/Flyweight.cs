namespace CSharpDesignPatterns._5._Structural_patterns.Flyweight
{
    using System;
    using System.Collections.Generic;

    internal class FlyweightCoffeeShop
    {
        public IDictionary<string, CoffeeFlavor> CoffeeFlavors { get; } = new Dictionary<string, CoffeeFlavor>();
        public IDictionary<Guid, CoffeeFlavor> Orders          { get; } = new Dictionary<Guid, CoffeeFlavor>();

        public Guid CreateOrder(CoffeeFlavor flavor)
        {
            throw new NotImplementedException();
        }

        public Guid CreateOrder(string flavor)
        {
            throw new NotImplementedException();
        }
    }

    public class CoffeeFlavor
    {
        public CoffeeFlavor(string flavor)
        {
            this.Flavor = flavor;
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Flavor { get; }

        public override string ToString()
        {
            return $"{this.Flavor}: {this.Id}";
        }
    }
}