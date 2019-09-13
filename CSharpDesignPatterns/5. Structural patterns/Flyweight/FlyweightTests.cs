namespace CSharpDesignPatterns._5._Structural_patterns.Flyweight
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using Ploeh.AutoFixture;

    [TestFixture]
    public class FlyweightTests
    {
        private static readonly Fixture Fixture = new Fixture();

        [Test]
        public void IsReferenceEquals_True()
        {
            var repository = new FlyweightTreeRepository();

            repository.CreateTree(new TreeModel("Oak"),   Fixture.Create<Position>());
            repository.CreateTree(new TreeModel("Birch"), Fixture.Create<Position>());
            repository.CreateTree("Oak",                  Fixture.Create<Position>());
            repository.CreateTree("Birch",                Fixture.Create<Position>());

            var treeId = repository.CreateTree(new TreeModel("Oak"), Fixture.Create<Position>());

            Assert.AreEqual(2, repository.TreeTypes.Count);
            Assert.AreEqual(5, repository.Trees.Count);

            Assert.IsTrue(ReferenceEquals(repository.TreeTypes["Oak"], repository.Trees[treeId].TreeModel));
        }

        [Test]
        public void SeveralOrders_MinimumNumberOfCacheItems()
        {
            var repository = new FlyweightTreeRepository();

            var input = new[] { "Oak", "Birch", "Maple", "Oak", "Birch", "Maple", "Oak", "Birch", "Maple" };

            var treeIds = new List<Guid>();
            foreach (var flavor in input)
            {
                treeIds.Add(repository.CreateTree(flavor, Fixture.Create<Position>()));
            }

            Assert.AreEqual(3, repository.TreeTypes.Count);
            Assert.AreEqual(9, repository.Trees.Count);
            CollectionAssert.AreEquivalent(treeIds, repository.Trees.Keys);
        }

        [Test]
        public void ThreeOrders_MinimumNumberOfCacheItems()
        {
            var repository = new FlyweightTreeRepository();
            repository.CreateTree("Oak",   Fixture.Create<Position>());
            repository.CreateTree("Birch", Fixture.Create<Position>());

            Assert.AreEqual(2, repository.TreeTypes.Count);
        }
    }
}