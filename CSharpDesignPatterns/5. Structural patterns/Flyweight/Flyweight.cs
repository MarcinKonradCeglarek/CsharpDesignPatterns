namespace CSharpDesignPatterns._5._Structural_patterns.Flyweight
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class FlyweightCoffeeShop
    {
        public void TakeOrder(Guid customerId, CoffeeFlavour flavour)
        {
            if (this.Orders.ContainsKey(customerId))
            {
                return;
            }

            if (!this.CoffeeFlavours.ContainsKey(flavour.Flavour))
            {
                this.CoffeeFlavours.Add(flavour.Flavour, flavour);
            }

            this.Orders.Add(customerId, this.CoffeeFlavours[flavour.Flavour]);
        }

        public IDictionary<string, CoffeeFlavour> CoffeeFlavours { get; } = new Dictionary<string, CoffeeFlavour>();
        public IDictionary<Guid, CoffeeFlavour> Orders         { get; } = new Dictionary<Guid, CoffeeFlavour>();

        public void TakeOrder(Guid customerId, CoffeeFlavour flavour)
        {
            if (!this.CoffeeFlavours.ContainsKey(flavour))
            {
                this.CoffeeFlavours.Add(flavour, new CoffeeFlavour(flavour));
            }

            this.Orders.Add(customerId, this.CoffeeFlavours[flavour]);
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