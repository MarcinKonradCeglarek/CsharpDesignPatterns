namespace CSharpDesignPatterns._5._Structural_patterns.Flyweight
{
    using System;
    using System.Collections.Generic;

    using Castle.Core.Internal;

    using NUnit.Framework;

    [TestFixture]
    public class FlyweightTests
    {
        [Test]
        public void ThreeOrders_MinimumNumberOfCacheItems()
        {
            var shop = new FlyweightCoffeeShop();
            shop.CreateOrder("Cappuccino");
            shop.CreateOrder("Espresso");

            Assert.AreEqual(2, shop.CoffeeFlavors.Count);
        }

        [Test]
        public void IsReferenceEquals_True()
        {
            var shop = new FlyweightCoffeeShop();

            shop.CreateOrder(new CoffeeFlavor("Cappuccino"));
            shop.CreateOrder(new CoffeeFlavor("Espresso"));
            shop.CreateOrder("Cappuccino");
            shop.CreateOrder("Espresso");

            var thisOrder = shop.CreateOrder(new CoffeeFlavor("Cappuccino"));

            Assert.IsTrue(ReferenceEquals(shop.CoffeeFlavors["Cappuccino"], shop.Orders[thisOrder]));
        }

        [Test]
        public void SeveralOrders_MinimumNumberOfCacheItems()
        {
            var shop = new FlyweightCoffeeShop();

            var input = new string[] { "Cappuccino", "Espresso", "Frappe", "Cappuccino", "Espresso", "Frappe", "Cappuccino", "Espresso", "Frappe" };

            var orderIds = new List<Guid>();
            foreach (var flavor in input)
            {
                orderIds.Add(shop.CreateOrder(flavor));
            }

            Assert.AreEqual(3, shop.CoffeeFlavors.Count);
            Assert.AreEqual(9, shop.Orders.Count);
            CollectionAssert.AreEquivalent(orderIds, shop.Orders.Keys);
        }
    }
}