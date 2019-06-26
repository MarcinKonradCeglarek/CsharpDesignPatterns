namespace CSharpDesignPatterns._5._Structural_patterns.Flyweight
{
    using System;
    using System.Collections.Generic;

    internal class FlyweightCoffeeShop
    {
        public IDictionary<string, CoffeeFlavor> CoffeeFlavors { get; } = new Dictionary<string, CoffeeFlavor>();
        public IDictionary<Guid, CoffeeFlavor> Orders          { get; } = new Dictionary<Guid, CoffeeFlavor>();

        public void TakeOrder(Guid customerId, CoffeeFlavor flavor)
        {
            throw new NotImplementedException();
        }

        public void TakeOrder(Guid customerId, string flavour)
        {
            throw new NotImplementedException();
        }
    }

    public class CoffeeFlavor
    {
        public CoffeeFlavor(string flavor)
        {
            this.Flavor = flavor;
        }

        public string Flavor { get; }
    }
}