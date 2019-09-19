namespace CSharpDesignPatterns._3._SOLID_principles
{
    using NUnit.Framework;

    [TestFixture]
    public class DependencyInversionTests
    {
        [Test]
        public void GetAndFormatData()
        {
            // Arrange
            var sut = new DependencyInversion();

            // Act
            var result = sut.GetAndFormatData();

            // Assert
            Assert.AreEqual("SomeDataFromFile\r\nAndAnotherLine\r\n", result);
        }
    }
}