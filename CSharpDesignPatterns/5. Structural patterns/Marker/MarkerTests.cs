namespace CSharpDesignPatterns._5._Structural_patterns.Marker
{
    using System.Collections.Generic;
    using System.Linq;

    using Castle.Core.Internal;

    using NUnit.Framework;

    [TestFixture]
    public class MarkerTests
    {
        private readonly IList<IAlive> aliveEntities = new List<IAlive>()
                                                  {
                                                      new Human(),
                                                      new Elephant(),
                                                      new Human(),
                                                      new Dog(),
                                                      new Mushroom(),
                                                      new Mushroom(),
                                                      new Tree(),
                                                      new Bush()
                                                  };
        [Test]
        public void SentientEntities()
        {
            var sentientItems = this.aliveEntities.Where(i => i.GetType().HasAttribute<SentientAttribute>()).ToList();

            Assert.AreEqual(2, sentientItems.Count);
            CollectionAssert.AllItemsAreInstancesOfType(sentientItems, typeof(Human));
        }

        [Test]
        public void PlantEntities()
        {
            var sentientItems = this.aliveEntities.Where(i => i.GetType().HasAttribute<PlantAttribute>()).ToList();

            Assert.AreEqual(4, sentientItems.Count);
        }

        [Test]
        public void AnimalEntities()
        {
            var sentientItems = this.aliveEntities.Where(i => i.GetType().HasAttribute<AnimalAttribute>()).ToList();

            Assert.AreEqual(4, sentientItems.Count);
        }

        [Test]
        public void NotSentientAnimalsEntities()
        {
            var sentientItems = this.aliveEntities.Where(
                i => i.GetType().HasAttribute<AnimalAttribute>()
                     && !i.GetType().HasAttribute<SentientAttribute>()).ToList();

            Assert.AreEqual(2, sentientItems.Count);
        }
    }
}