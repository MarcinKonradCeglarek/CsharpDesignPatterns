namespace CSharpDesignPatterns._5._Structural_patterns.Bridge
{
    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class BridgeTests
    {
        [Test]
        public void Circle_ImplementationOfGreenCircle_ContainsGreenString()
        {
            // Arrange
            var greenCircle = new Circle(100, 100, 10, new ImplementationOfGreenCircle());

            // Act
            var result = greenCircle.Draw();

            // Assert
            Assert.IsTrue(result.Contains("GREEN"));
        }

        [Test]
        public void Circle_ImplementationOfRedCircle_ContainsRedString()
        {
            // Arrange
            var redCircle = new Circle(100, 100, 10, new ImplementationOfRedCircle());

            // Act
            var result = redCircle.Draw();

            // Assert
            Assert.IsTrue(result.Contains("RED"));
        }

        [Test]
        public void Circle_Mock_MethodIsInvoked()
        {
            // Arrange
            var mock       = new Mock<IBridge>();
            var mockCircle = new Circle(1000, 100, 10, mock.Object);

            // Act
            var result = mockCircle.Draw();

            // Assert
            mock.Verify(m => m.Draw(mockCircle), Times.Once);
        }
    }
}