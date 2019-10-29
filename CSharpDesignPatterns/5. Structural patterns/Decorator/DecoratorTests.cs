namespace CSharpDesignPatterns._5._Structural_patterns.Decorator
{
    using System.Linq;

    using NUnit.Framework;

    [TestFixture]
    public class DecoratorTests
    {
        [Test]
        public void Coffee()
        {
            var coffee = new Coffee();

            Assert.AreEqual(1,                  coffee.Cost);
            Assert.AreEqual(1,                  coffee.Contents.Count);
            Assert.AreEqual(Ingredients.Coffee, coffee.Contents.Single());
        }

        [Test]
        public void CoffeeWithMilk()
        {
            var coffee         = new Coffee();
            var coffeeWithMilk = new WithMilkDecorator(coffee);

            // Coffee
            Assert.AreEqual(1,                  coffee.Cost);
            Assert.AreEqual(1,                  coffee.Contents.Count);
            Assert.AreEqual(Ingredients.Coffee, coffee.Contents.Single());

            // CoffeeWithMilk
            Assert.AreEqual(1.5, coffeeWithMilk.Cost);
            Assert.AreEqual(2,   coffeeWithMilk.Contents.Count);
            CollectionAssert.Contains(coffeeWithMilk.Contents, Ingredients.Coffee);
            CollectionAssert.Contains(coffeeWithMilk.Contents, Ingredients.Milk);
        }

        [Test]
        public void CoffeeWithSprinkles()
        {
            var coffee              = new Coffee();
            var coffeeWithSprinkles = new WithSprinklesDecorator(coffee);

            // Coffee
            Assert.AreEqual(1,                  coffee.Cost);
            Assert.AreEqual(1,                  coffee.Contents.Count);
            Assert.AreEqual(Ingredients.Coffee, coffee.Contents.Single());

            // CoffeeWithSprinkles
            Assert.AreEqual(1.2, coffeeWithSprinkles.Cost);
            Assert.AreEqual(2,   coffeeWithSprinkles.Contents.Count);
            CollectionAssert.Contains(coffeeWithSprinkles.Contents, Ingredients.Coffee);
            CollectionAssert.Contains(coffeeWithSprinkles.Contents, Ingredients.Sprinkles);
        }

        [Test]
        public void CoffeeWithMilkAndSprinkles()
        {
            var cofee                      = new Coffee();
            var coffeeWithMilkAndSprinkles = new WithMilkDecorator(new WithSprinklesDecorator(cofee));

            Assert.AreEqual(1.7, coffeeWithMilkAndSprinkles.Cost);
            Assert.AreEqual(3,   coffeeWithMilkAndSprinkles.Contents.Count);
            CollectionAssert.Contains(coffeeWithMilkAndSprinkles.Contents, Ingredients.Coffee);
            CollectionAssert.Contains(coffeeWithMilkAndSprinkles.Contents, Ingredients.Milk);
            CollectionAssert.Contains(coffeeWithMilkAndSprinkles.Contents, Ingredients.Sprinkles);
        }

        [Test]
        public void CoffeeWithSprinklesAndMilk()
        {
            var cofee                      = new Coffee();
            var coffeeWithSprinklesAndMilk = new WithSprinklesDecorator(new WithMilkDecorator(cofee));

            Assert.AreEqual(1.7, coffeeWithSprinklesAndMilk.Cost);
            Assert.AreEqual(3,   coffeeWithSprinklesAndMilk.Contents.Count);
            CollectionAssert.Contains(coffeeWithSprinklesAndMilk.Contents, Ingredients.Coffee);
            CollectionAssert.Contains(coffeeWithSprinklesAndMilk.Contents, Ingredients.Milk);
            CollectionAssert.Contains(coffeeWithSprinklesAndMilk.Contents, Ingredients.Sprinkles);
        }

        [Test]
        public void CoffeeWithDoubleMilk()
        {
            var coffee               = new Coffee();
            var coffeeWithDoubleMilk = new WithMilkDecorator(new WithMilkDecorator(coffee));

            // Coffee
            Assert.AreEqual(1,                  coffee.Cost);
            Assert.AreEqual(1,                  coffee.Contents.Count);
            Assert.AreEqual(Ingredients.Coffee, coffee.Contents.Single());

            // CoffeeWithDoubleMilk
            Assert.AreEqual(2, coffeeWithDoubleMilk.Cost);
            Assert.AreEqual(3, coffeeWithDoubleMilk.Contents.Count);
            CollectionAssert.AreEquivalent(
                new[] { Ingredients.Coffee, Ingredients.Milk, Ingredients.Milk },
                coffeeWithDoubleMilk.Contents);
        }
    }
}