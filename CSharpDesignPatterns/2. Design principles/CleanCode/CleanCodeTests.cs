namespace CSharpDesignPatterns._2._Design_principles.CleanCode
{
    using NUnit.Framework;

    [TestFixture]
    public class CleanCodeTests
    {
        [Test]
        public void AlwaysUseBraces()
        {
            // Arrange
            var input = 25;

            // Act
            var result = CleanCode.AlwaysUseBraces(input);

            // Assert
            Assert.AreEqual(125, result);
        }
    }
}