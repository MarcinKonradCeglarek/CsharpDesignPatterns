namespace CSharpDesignPatterns._5._Structural_patterns.Flyweight
{
    using System.Collections.Generic;

    using CSharpDesignPatterns._5._Structural_patterns.Flyweight.Model;

    using NUnit.Framework;

    using Ploeh.AutoFixture;

    [TestFixture]
    public class TreeRepositoryFlyweightTests
    {
        private static readonly Fixture Fixture = new Fixture();

        [Test]
        public void CreateOneTreeChecksForTreesAndModels()
        {
            var repository = new TreeRepositoryFlyweight();
            var treeType   = Fixture.Create<string>();
            var position   = Fixture.Create<Position>();

            var id = repository.CreateTree(treeType, position);

            Assert.IsTrue(repository.TreeModels.ContainsKey(treeType));
            Assert.AreEqual(position, repository.Trees[id].Position);
        }

        [Test]
        public void CreateTwoTreesOfTheSameType()
        {
            var repository = new TreeRepositoryFlyweight();
            var treeType   = Fixture.Create<string>();
            var position1  = Fixture.Create<Position>();
            var position2  = Fixture.Create<Position>();

            var id1 = repository.CreateTree(treeType, position1);
            var id2 = repository.CreateTree(treeType, position2);

            Assert.AreEqual(1,         repository.TreeModels.Count);
            Assert.AreEqual(position1, repository.Trees[id1].Position);
            Assert.AreEqual(position2, repository.Trees[id2].Position);
        }

        [Test]
        public void CreateTwoDifferentTrees()
        {
            var repository = new TreeRepositoryFlyweight();
            var position1  = Fixture.Create<Position>();
            var position2  = Fixture.Create<Position>();

            repository.CreateTree("Oak",   position1);
            repository.CreateTree("Birch", position2);

            Assert.AreEqual(2, repository.TreeModels.Count);
            Assert.IsTrue(repository.TreeModels.ContainsKey("Oak"));
            Assert.IsTrue(repository.TreeModels.ContainsKey("Birch"));
        }

        [Test]
        public void CreateThreeOaksAndTwoBirchLastOakIsReferenceEqualsToFirst()
        {
            var repository = new TreeRepositoryFlyweight();

            repository.CreateTree(new TreeModel("Oak"),   Fixture.Create<Position>());
            repository.CreateTree(new TreeModel("Birch"), Fixture.Create<Position>());
            repository.CreateTree("Oak",                  Fixture.Create<Position>());
            repository.CreateTree("Birch",                Fixture.Create<Position>());

            var treeId = repository.CreateTree(new TreeModel("Oak"), Fixture.Create<Position>());

            Assert.AreEqual(2, repository.TreeModels.Count);
            Assert.AreEqual(5, repository.Trees.Count);

            Assert.IsTrue(ReferenceEquals(repository.TreeModels["Oak"], repository.Trees[treeId].TreeModel));
        }

        [Test]
        public void NineDistinctTreesChecksIfAllTreesAreReusingModels()
        {
            var repository = new TreeRepositoryFlyweight();

            var input = new[] { "Oak", "Birch", "Maple", "Oak", "Birch", "Maple", "Oak", "Birch", "Maple" };

            var treeIds = new List<int>();
            foreach (var flavor in input)
            {
                treeIds.Add(repository.CreateTree(flavor, Fixture.Create<Position>()));
            }

            Assert.AreEqual(3, repository.TreeModels.Count);
            Assert.AreEqual(9, repository.Trees.Count);

            foreach (var treeId in treeIds)
            {
                var actual   = repository.Trees[treeId].TreeModel;
                var expected = repository.TreeModels[actual.Name];

                Assert.IsTrue(ReferenceEquals(expected, actual));
            }
        }
    }
}