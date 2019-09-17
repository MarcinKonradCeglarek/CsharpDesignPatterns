namespace CSharpDesignPatterns._5._Structural_patterns.Decorator
{
    using System.Linq;

    using NUnit.Framework;

    [TestFixture]
    public class DecoratorTests
    {
        [Test]
        public void SimpleCoffeeValidCostAndIngredients()
        {
            var coffee = new Coffee();

            Assert.AreEqual(1,                  coffee.Cost);
            Assert.AreEqual(1,                  coffee.Contents.Count());
            Assert.AreEqual(Ingredients.Coffee, coffee.Contents.Single());
        }

        [Test]
        public void CoffeeWithMilkValidCostAndIngredients()
        {
            var coffee = new Coffee();
            var coffeeWithMilk = new WithMilkDecorator(coffee);

            // Coffee
            Assert.AreEqual(1,                  coffee.Cost);
            Assert.AreEqual(1,                  coffee.Contents.Count());
            Assert.AreEqual(Ingredients.Coffee, coffee.Contents.Single());

            // CoffeeWithMilk
            Assert.AreEqual(1.5, coffeeWithMilk.Cost);
            Assert.AreEqual(2,   coffeeWithMilk.Contents.Count());
            CollectionAssert.Contains(coffeeWithMilk.Contents, Ingredients.Coffee);
            CollectionAssert.Contains(coffeeWithMilk.Contents, Ingredients.Milk);
        }

        [Test]
        public void CoffeeWithSprinklesValidCostAndIngredients()
        {
            var coffee = new Coffee();
            var coffeeWithSprinkles = new WithSprinklesDecorator(coffee);

            // Coffee
            Assert.AreEqual(1,                  coffee.Cost);
            Assert.AreEqual(1,                  coffee.Contents.Count());
            Assert.AreEqual(Ingredients.Coffee, coffee.Contents.Single());

            // CoffeeWithSprinkles
            Assert.AreEqual(1.2, coffeeWithSprinkles.Cost);
            Assert.AreEqual(2,   coffeeWithSprinkles.Contents.Count());
            CollectionAssert.Contains(coffeeWithSprinkles.Contents, Ingredients.Coffee);
            CollectionAssert.Contains(coffeeWithSprinkles.Contents, Ingredients.Sprinkles);
        }

        [Test]
        public void CoffeeWithMilkAndSprinklesValidCostAndIngredients()
        {
            var cofee                      = new Coffee();
            var coffeeWithMilkAndSprinkles = new WithMilkDecorator(new WithSprinklesDecorator(cofee));

            Assert.AreEqual(1.7, coffeeWithMilkAndSprinkles.Cost);
            Assert.AreEqual(3,   coffeeWithMilkAndSprinkles.Contents.Count());
            CollectionAssert.Contains(coffeeWithMilkAndSprinkles.Contents, Ingredients.Coffee);
            CollectionAssert.Contains(coffeeWithMilkAndSprinkles.Contents, Ingredients.Milk);
            CollectionAssert.Contains(coffeeWithMilkAndSprinkles.Contents, Ingredients.Sprinkles);
        }

        [Test]
        public void CoffeeWithSprinklesAndMilkValidCostAndIngredients()
        {
            var cofee                      = new Coffee();
            var coffeeWithSprinklesAndMilk = new WithSprinklesDecorator(new WithMilkDecorator(cofee));

            Assert.AreEqual(1.7, coffeeWithSprinklesAndMilk.Cost);
            Assert.AreEqual(3,   coffeeWithSprinklesAndMilk.Contents.Count());
            CollectionAssert.Contains(coffeeWithSprinklesAndMilk.Contents, Ingredients.Coffee);
            CollectionAssert.Contains(coffeeWithSprinklesAndMilk.Contents, Ingredients.Milk);
            CollectionAssert.Contains(coffeeWithSprinklesAndMilk.Contents, Ingredients.Sprinkles);
        }

        [Test]
        public void SimpleCoffeasdfasdfnts()
        {
            var originalCoffe = new Coffee();
            var coffee = new WithMilkDecorator(new WithMilkDecorator(originalCoffe));

            Assert.AreEqual(1, originalCoffe.Contents.Count());
            Assert.AreEqual(Ingredients.Coffee, originalCoffe.Contents.Single());

            Assert.AreEqual(2,                  coffee.Cost);
            Assert.AreEqual(3,                  coffee.Contents.Count());
            CollectionAssert.AreEquivalent(
                new[] { Ingredients.Coffee, Ingredients.Milk, Ingredients.Milk },
                coffee.Contents);
        }
    }
}