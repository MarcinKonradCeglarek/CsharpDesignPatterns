using NUnit.Framework;

namespace CSharpDesignPatterns._5._Structural_patterns.Facade
{
    [TestFixture]
    public class GetDressedFacadeTest
    {
        [Test]
        public void GetSmartClothes()
        {
            var sut = new GetDressedFacade();

            CollectionAssert.AreEquivalent(
                new[] {"Formal Shoes", "Formal Jacket", "Formal Trousers", "Formal Shirt", "Watch", "Tie", "Belt"},
                sut.GetSmartClothes());
        }

        [Test]
        public void GetCasualClothes()
        {
            var sut = new GetDressedFacade();

            CollectionAssert.AreEquivalent(new[] {"Sneakers", "T-Shirt", "Shorts", "Fitbit"}, sut.GetCasualClothes());
        }
    }
}