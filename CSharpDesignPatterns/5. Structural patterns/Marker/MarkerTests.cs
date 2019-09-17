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
        public void ClassesWithAnimalAttribute()
        {
            var sentientItems = this.aliveEntities.Where(i => i.GetType().HasAttribute<AnimalAttribute>()).ToList();

            Assert.AreEqual(4, sentientItems.Count);
        }

        [Test]
        public void ClassesWithPlantAttribute()
        {
            var sentientItems = this.aliveEntities.Where(i => i.GetType().HasAttribute<PlantAttribute>()).ToList();
            Assert.AreEqual(4, sentientItems.Count);
        }

        [Test]
        public void ClassesWithSentientAttribute()
        {
            var sentientItems = this.aliveEntities.Where(i => i.GetType().HasAttribute<SentientAttribute>()).ToList();

            Assert.AreEqual(2, sentientItems.Count);
            CollectionAssert.AllItemsAreInstancesOfType(sentientItems, typeof(Human));
        }

        [Test]
        public void ClassesWithAnimalAttributeAndWithoutSentientAttribute()
        {
            var sentientItems = this.aliveEntities.Where(i => i.GetType().HasAttribute<AnimalAttribute>() && !i.GetType().HasAttribute<SentientAttribute>()).ToList();

            Assert.AreEqual(2, sentientItems.Count);
        }

        [Test]
        public void ThereIs5IAnimalsInAssembly()
        {
            var assembly = typeof(IAnimal).Assembly;
            Assert.AreEqual(5, assembly.GetTypes().Count(t => typeof(IAnimal).IsAssignableFrom(t)));
        }

        [Test]
        public void ThereIs5IPlantsInAssembly()
        {
            var assembly = typeof(IPlant).Assembly;
            Assert.AreEqual(5, assembly.GetTypes().Count(t => typeof(IPlant).IsAssignableFrom(t)));
        }

        [Test]
        public void ClassesInAssemblyWithAnimalAttribute()
        {
            var assembly = typeof(AnimalAttribute).Assembly;
            Assert.AreEqual(4, assembly.GetTypes().Count(t => t.HasAttribute<AnimalAttribute>()));
        }

        [Test]
        public void ClassesInAssemblyWithPlantAttribute()
        {
            var assembly = typeof(PlantAttribute).Assembly;
            Assert.AreEqual(4, assembly.GetTypes().Count(t => t.HasAttribute<PlantAttribute>()));
        }

        [Test]
        public void ClassesInAssemblyWithSentientAttribute()
        {
            var assembly = typeof(SentientAttribute).Assembly;
            Assert.AreEqual(1, assembly.GetTypes().Count(t => t.HasAttribute<SentientAttribute>()));
        }
    }
}