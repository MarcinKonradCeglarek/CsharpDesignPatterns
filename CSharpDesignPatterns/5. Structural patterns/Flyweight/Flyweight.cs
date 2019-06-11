namespace CSharpDesignPatterns._5._Structural_patterns.Flyweight
{
    using System;
    using System.Collections.Generic;

    internal class FlyweightCoffeeShop
    {
        public IDictionary<string, CoffeeFlavour> CoffeeFlavours { get; } = new Dictionary<string, CoffeeFlavour>();
        public IDictionary<Guid, CoffeeFlavour> Orders         { get; } = new Dictionary<Guid, CoffeeFlavour>();

        public void TakeOrder(Guid customerId, CoffeeFlavour flavour)
        {
            throw new NotImplementedException();
        }

        public void TakeOrder(Guid customerId, string flavour)
        {
            throw new NotImplementedException();
        }
    }

    public class CoffeeFlavour
    {
        public CoffeeFlavour(string flavour)
        {
            this.Flavour = flavour;
        }

        public string Flavour { get; }
    }
}