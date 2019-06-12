namespace CSharpDesignPatterns._5._Structural_patterns.Flyweight
{
    using System;
    using System.Collections.Generic;

    internal class FlyweightCoffeeShop
    {
        public IDictionary<string, CoffeeFlavor> CoffeeFlavors { get; } = new Dictionary<string, CoffeeFlavor>();
        public IDictionary<Guid, CoffeeFlavor> Orders        { get; } = new Dictionary<Guid, CoffeeFlavor>();

        public void TakeOrder(Guid customerId, CoffeeFlavor flavor)
        {
            if (this.Orders.ContainsKey(customerId))
            {
                return;
            }

            if (!this.CoffeeFlavors.ContainsKey(flavor.Flavor))
            {
                this.CoffeeFlavors.Add(flavor.Flavor, flavor);
            }

            this.Orders.Add(customerId, this.CoffeeFlavors[flavor.Flavor]);
        }

        public void TakeOrder(Guid customerId, string flavour)
        {
            if (!this.CoffeeFlavors.ContainsKey(flavour))
            {
                this.CoffeeFlavors.Add(flavour, new CoffeeFlavor(flavour));
            }

            this.Orders.Add(customerId, this.CoffeeFlavors[flavour]);
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