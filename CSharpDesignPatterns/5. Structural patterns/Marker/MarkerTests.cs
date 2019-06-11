namespace CSharpDesignPatterns._5._Structural_patterns.Marker
{
    using System.Collections.Generic;
    using System.Linq;

    using Castle.Core.Internal;

    using NUnit.Framework;

    [TestFixture]
    public class MarkerTests
    {
        private readonly IList<IAlive> aliveEntities =
            new List<IAlive> { new Human(), new Elephant(), new Human(), new Dog(), new Mushroom(), new Mushroom(), new Tree(), new Bush() };

        [Test]
        public void Marker_AnimalEntities_GetAllAnimals()
        {
            var sentientItems = this.aliveEntities.Where(i => i.GetType().HasAttribute<AnimalAttribute>()).ToList();

            Assert.AreEqual(4, sentientItems.Count);
        }

        [Test]
        public void Marker_CountClassesWithAnimalAttribute_4()
        {
            var assembly = typeof(IAlive).Assembly;
            Assert.AreEqual(4, assembly.GetTypes().Count(t => t.HasAttribute<AnimalAttribute>()));
        }

        [Test]
        public void Marker_CountClassesWithPlantAttribute_4()
        {
            var assembly = typeof(IAlive).Assembly;
            Assert.AreEqual(4, assembly.GetTypes().Count(t => t.HasAttribute<PlantAttribute>()));
        }

        [Test]
        public void Marker_CountClassesWithSentientAttribute_1()
        {
            var assembly = typeof(IAlive).Assembly;
            Assert.AreEqual(1, assembly.GetTypes().Count(t => t.HasAttribute<SentientAttribute>()));
        }

        [Test]
        public void Marker_NotSentientAnimalsEntities_ReturnsNotHumans()
        {
            var sentientItems = this.aliveEntities.Where(i => i.GetType().HasAttribute<AnimalAttribute>() && !i.GetType().HasAttribute<SentientAttribute>()).ToList();

            Assert.AreEqual(2, sentientItems.Count);
        }

        [Test]
        public void Marker_PlantEntities_GetAllPlants()
        {
            var sentientItems = this.aliveEntities.Where(i => i.GetType().HasAttribute<PlantAttribute>()).ToList();

            Assert.AreEqual(4, sentientItems.Count);
        }

        [Test]
        public void Marker_SentientEntities_GetsHumans()
        {
            var sentientItems = this.aliveEntities.Where(i => i.GetType().HasAttribute<SentientAttribute>()).ToList();

            Assert.AreEqual(2, sentientItems.Count);
            CollectionAssert.AllItemsAreInstancesOfType(sentientItems, typeof(Human));
        }
    }
}