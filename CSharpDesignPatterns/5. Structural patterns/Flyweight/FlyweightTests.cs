﻿namespace CSharpDesignPatterns._5._Structural_patterns.Flyweight
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class FlyweightTests
    {
        [Test]
        public void Flyweight_3Orders_MinimumNumberOfCacheItems()
        {
            var shop = new FlyweightCoffeeShop();
            shop.TakeOrder(Guid.NewGuid(), "Cappuccino");
            shop.TakeOrder(Guid.NewGuid(), "Espresso");

            Assert.AreEqual(2, shop.CoffeeFlavours.Count);
        }


        [Test]
        public void Flyweight_SeveralOrders_MinimumNumberOfCacheItems()
        {
            var shop = new FlyweightCoffeeShop();

            var input = new Dictionary<Guid, string>()
                            {
                                { Guid.NewGuid(), "Cappuccino"},
                                { Guid.NewGuid(), "Espresso" },
                                { Guid.NewGuid(), "Frappe" },
                                { Guid.NewGuid(), "Cappuccino" },
                                { Guid.NewGuid(), "Espresso" },
                                { Guid.NewGuid(), "Frappe" },
                                { Guid.NewGuid(), "Cappuccino" },
                                { Guid.NewGuid(), "Espresso" },
                                { Guid.NewGuid(), "Frappe" },
                            };

            foreach (var o in input)
            {
                shop.TakeOrder(o.Key, o.Value);
            }

            Assert.AreEqual(3, shop.CoffeeFlavours.Count);
            Assert.AreEqual(9, shop.Orders.Count);
            CollectionAssert.AreEquivalent(input.Keys, shop.Orders.Keys);
        }

        [Test]
        public void Flyweight_IsReferenceEquals_True()
        {
            var shop = new FlyweightCoffeeShop();

            shop.TakeOrder(Guid.NewGuid(), "Cappuccino");
            shop.TakeOrder(Guid.NewGuid(), "Espresso");
            shop.TakeOrder(Guid.NewGuid(), "Cappuccino");
            shop.TakeOrder(Guid.NewGuid(), "Espresso");

            var thisOrder = Guid.NewGuid();
            shop.TakeOrder(thisOrder, "Cappuccino");

            Assert.IsTrue(object.ReferenceEquals(shop.CoffeeFlavours["Cappuccino"], shop.Orders[thisOrder]));
        }
    }
}