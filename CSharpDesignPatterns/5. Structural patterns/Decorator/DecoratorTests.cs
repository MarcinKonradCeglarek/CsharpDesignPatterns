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
            var coffeeWithMilk = new WithMilkDecorator(new Coffee());

            Assert.AreEqual(1.5, coffeeWithMilk.Cost);
            Assert.AreEqual(2,   coffeeWithMilk.Contents.Count());
            CollectionAssert.Contains(coffeeWithMilk.Contents, Ingredients.Coffee);
            CollectionAssert.Contains(coffeeWithMilk.Contents, Ingredients.Milk);
        }

        [Test]
        public void CoffeeWithSprinklesValidCostAndIngredients()
        {
            var coffeeWithSprinkles = new WithSprinklesDecorator(new Coffee());

            Assert.AreEqual(1.2, coffeeWithSprinkles.Cost);
            Assert.AreEqual(2,   coffeeWithSprinkles.Contents.Count());
            CollectionAssert.Contains(coffeeWithSprinkles.Contents, Ingredients.Coffee);
            CollectionAssert.Contains(coffeeWithSprinkles.Contents, Ingredients.Sprinkles);
        }

        [Ignore("Combination of 2")]
        [Test]
        public void CoffeeWithMilkAndSprinklesValidCostAndIngredients()
        {
            var coffeeWithMilkAndSprinkles = new WithMilkDecorator(new WithSprinklesDecorator(new Coffee()));

            Assert.AreEqual(1.7, coffeeWithMilkAndSprinkles.Cost);
            Assert.AreEqual(3,   coffeeWithMilkAndSprinkles.Contents.Count());
            CollectionAssert.Contains(coffeeWithMilkAndSprinkles.Contents, Ingredients.Coffee);
            CollectionAssert.Contains(coffeeWithMilkAndSprinkles.Contents, Ingredients.Milk);
            CollectionAssert.Contains(coffeeWithMilkAndSprinkles.Contents, Ingredients.Sprinkles);
        }

        [Ignore("Combination of 2")]
        [Test]
        public void CoffeeWithSprinklesAndMilkValidCostAndIngredients()
        {
            var coffeeWithSprinklesAndMilk = new WithSprinklesDecorator(new WithMilkDecorator(new Coffee()));

            Assert.AreEqual(1.7, coffeeWithSprinklesAndMilk.Cost);
            Assert.AreEqual(3,   coffeeWithSprinklesAndMilk.Contents.Count());
            CollectionAssert.Contains(coffeeWithSprinklesAndMilk.Contents, Ingredients.Coffee);
            CollectionAssert.Contains(coffeeWithSprinklesAndMilk.Contents, Ingredients.Milk);
            CollectionAssert.Contains(coffeeWithSprinklesAndMilk.Contents, Ingredients.Sprinkles);
        }


    }
}