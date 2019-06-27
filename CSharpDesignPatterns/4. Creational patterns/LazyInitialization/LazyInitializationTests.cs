namespace CSharpDesignPatterns._4._Creational_patterns.LazyInitialization
{
    using System;
    using System.Collections.Generic;

    using CSharpDesignPatterns.Common.Model;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class LazyInitializationTests
    {
        [Test]
        public void DontRequestChildrenWhenCreatingObjectAndVerifyThatReadWasNotCalled()
        {
            // Arrange
            const int RootId = 1;
            var children = new[] { 3, 5, 12, 15 };
            var mock = this.GetMock(children);

            // Act
            var sut = new Node<int>(RootId, children, mock.Object);

            // Arrange
            mock.Verify(m => m.Read(It.IsAny<int>()), Times.Never);
        }

        [Test]
        public void RequestChildrenMultipleTimesAndVerifyThatReadWasCalledOncePerChild()
        {
            // Arrange
            const int RootId = 1;
            var children = new[] { 3, 5, 12, 15 };
            var mock     = this.GetMock(children);

            var sut = new Node<int>(RootId, children, mock.Object);

            // Act
            var children1 = sut.Children;
            var children2 = sut.Children;
            var children3 = sut.Children;

            // Assert
            mock.Verify(m => m.Read(It.IsAny<int>()), Times.Exactly(children.Length));
            foreach (var child in children)
            {
                mock.Verify(m => m.Read(child), Times.Once);
            }
            
            Assert.AreEqual(children.Length, children1.Count);
        }

        private Mock<IRepository<T, Node<T>>> GetMock<T>(IEnumerable<T> ids)
        {
            var mock = new Mock<IRepository<T, Node<T>>>();

            foreach (var id in ids)
            {
                mock.Setup(m => m.Read(id)).Returns(new Node<T>(id, null, null));
            }

            return mock;
        }
    }
}