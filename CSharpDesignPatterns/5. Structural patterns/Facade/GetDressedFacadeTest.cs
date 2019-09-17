namespace CSharpDesignPatterns._5._Structural_patterns.Facade
{
    using NUnit.Framework;

    [TestFixture]
    public class FacadeTest
    {
        [Test]
        public void GetSmartClothes()
        {
            var sut = new GetDressedFacade();

            Assert.AreEqual(
                "Smart clothes: [Formal Shoes,Formal Jacket,Formal Trousers,Formal Shirt,Watch,Tie,Belt]",
                sut.GetSmartClothes());
        }

        [Test]
        public void GetCasualClothes()
        {
            var sut = new GetDressedFacade();

            Assert.AreEqual("Casual clothes: [Sneakers,T-Shirt,Shorts,Fitbit]", sut.GetCasualClothes());
        }
    }
}