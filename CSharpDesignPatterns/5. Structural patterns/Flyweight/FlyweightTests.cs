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
            var shop = new FlyweightTreeRepository();
            shop.CreateTree("Cappuccino", new Position(1, 10, 100));
            shop.CreateTree("Espresso", new Position(2, 20, 200));

            Assert.AreEqual(2, shop.TreeTypes.Count);
        }

        [Test]
        public void IsReferenceEquals_True()
        {
            var shop = new FlyweightTreeRepository();

            shop.CreateTree(new TreeModel("Cappuccino"), new Position(1, 10, 100));
            shop.CreateTree(new TreeModel("Espresso"), new Position(1, 10, 100));
            shop.CreateTree("Cappuccino", new Position(1, 10, 100));
            shop.CreateTree("Espresso", new Position(1, 10, 100));

            var thisOrder = shop.CreateTree(new TreeModel("Cappuccino"), new Position(1, 10, 100));

            Assert.AreEqual(2, shop.TreeTypes.Count);
            Assert.AreEqual(5, shop.Trees.Count);

            Assert.IsTrue(ReferenceEquals(shop.TreeTypes["Cappuccino"], shop.Trees[thisOrder].TreeModel));
        }

        [Test]
        public void SeveralOrders_MinimumNumberOfCacheItems()
        {
            var shop = new FlyweightTreeRepository();

            var input = new string[] { "Cappuccino", "Espresso", "Frappe", "Cappuccino", "Espresso", "Frappe", "Cappuccino", "Espresso", "Frappe" };

            var orderIds = new List<Guid>();
            foreach (var flavor in input)
            {
                orderIds.Add(shop.CreateTree(flavor, new Position(1, 10, 100)));
            }

            Assert.AreEqual(3, shop.TreeTypes.Count);
            Assert.AreEqual(9, shop.Trees.Count);
            CollectionAssert.AreEquivalent(orderIds, shop.Trees.Keys);
        }
    }
}