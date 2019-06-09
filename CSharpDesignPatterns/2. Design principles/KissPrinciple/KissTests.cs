namespace CSharpDesignPatterns._2._Design_principles.KissPrinciple
{
    using NUnit.Framework;

    [TestFixture]
    internal class KissTests
    {
        [Test]
        public void Kiss_Mvc_ProperlyDisplaysHelloWorld()
        {
            // Act
            var result = Kiss.MvcDisplay();
            Assert.AreEqual("Hello World", result);
        }

        [Test]
        public void Kiss_Simple_ProperlyDisplaysHelloWorld()
        {
            // Act
            var result = Kiss.SimpleDisplay();
            Assert.AreEqual("Hello World", result);
        }
    }
}