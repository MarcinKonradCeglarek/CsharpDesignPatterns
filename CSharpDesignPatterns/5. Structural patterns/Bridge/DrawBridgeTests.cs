namespace CSharpDesignPatterns._5._Structural_patterns.Bridge
{
    using CSharpDesignPatterns._5._Structural_patterns.Bridge.Model;

    using Moq;

    using NUnit.Framework;

    using Ploeh.AutoFixture;

    [TestFixture]
    public class DrawBridgeTests
    {
        private static readonly Fixture Fixture = new Fixture();

        [Test]
        public void CircleWithMockDrawBridgeProperlyInvokesDrawCircle()
        {
            // Arrange
            var mock       = new Mock<IDrawBridge>();
            var center     = Fixture.Create<Point>();
            var radius     = Fixture.Create<double>();
            var mockCircle = new Circle(center, radius, mock.Object);

            // Act
            mockCircle.Draw();

            // Assert
            mock.Verify(m => m.DrawCircle(center, radius), Times.Once);
        }

        [Test]
        public void RectangleWithMockDrawBridgeProperlyInvokesDrawCircle()
        {
            // Arrange
            var mock          = new Mock<IDrawBridge>();
            var upperLeft     = Fixture.Create<Point>();
            var width         = Fixture.Create<double>();
            var height        = Fixture.Create<double>();
            var mockRectangle = new Rectangle(upperLeft, width, height, mock.Object);

            // Act
            mockRectangle.Draw();

            // Assert
            mock.Verify(m => m.DrawRectangle(upperLeft, width, height), Times.Once);
        }

        [Test]
        public void CircleWithRedDrawBridgeReturnsValidString()
        {
            // Arrange
            var center    = Fixture.Create<Point>();
            var radius    = Fixture.Create<double>();
            var redCircle = new Circle(center, radius, new DrawBridge("RED"));

            // Act
            var result = redCircle.Draw();

            // Assert
            Assert.AreEqual($"RED circle at [{center.X:N2}, {center.Y:N2}], radius: {radius:N2}", result);
        }

        [Test]
        public void CircleWithGreenDrawBridgeReturnsValidString()
        {
            // Arrange
            var center    = Fixture.Create<Point>();
            var radius    = Fixture.Create<double>();
            var redCircle = new Circle(center, radius, new DrawBridge("GREEN"));

            // Act
            var result = redCircle.Draw();

            // Assert
            Assert.AreEqual($"GREEN circle at [{center.X:N2}, {center.Y:N2}], radius: {radius:N2}", result);
        }

        [Test]
        public void RectangleWithRedDrawBridgeReturnsValidString()
        {
            // Arrange
            var upperLeft    = Fixture.Create<Point>();
            var width        = Fixture.Create<double>();
            var height       = Fixture.Create<double>();
            var redRectangle = new Rectangle(upperLeft, width, height, new DrawBridge("ORANGE"));

            // Act
            var result = redRectangle.Draw();

            // Assert
            Assert.AreEqual(
                $"ORANGE rectangle starting at [{upperLeft.X:N2}, {upperLeft.Y:N2}] with width: {width:N2} and height {height:N2}",
                result);
        }

        [Test]
        public void RectangleWithGreenDrawBridgeReturnsValidString()
        {
            // Arrange
            var upperLeft    = Fixture.Create<Point>();
            var width        = Fixture.Create<double>();
            var height       = Fixture.Create<double>();
            var redRectangle = new Rectangle(upperLeft, width, height, new DrawBridge("PURPLE"));

            // Act
            var result = redRectangle.Draw();

            // Assert
            Assert.AreEqual(
                $"PURPLE rectangle starting at [{upperLeft.X:N2}, {upperLeft.Y:N2}] with width: {width:N2} and height {height:N2}",
                result);
        }
    }
}