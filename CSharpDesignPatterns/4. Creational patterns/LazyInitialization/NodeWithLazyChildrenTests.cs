namespace CSharpDesignPatterns._4._Creational_patterns.LazyInitialization
{
    using System.Collections.Generic;
    using System.Linq;

    using CSharpDesignPatterns.Common.Model;

    using Moq;

    using NUnit.Framework;

    using Ploeh.AutoFixture;

    [TestFixture]
    public class NodeWithLazyChildrenTests
    {
        private static readonly Fixture Fixture = new Fixture();

        [Test]
        public void DontRequestChildrenWhenCreatingObjectAndVerifyThatReadWasNotCalled()
        {
            // Arrange
            const int RootId   = 0;
            var       children = Fixture.CreateMany<int>(4).ToList();
            var       mock     = this.GetMockRepository(children);

            // Act
            var sut = new NodeWithLazyChildren<int>(RootId, children, mock.Object);

            // Arrange
            mock.Verify(m => m.Read(It.IsAny<int>()), Times.Never);
        }

        [Test]
        public void RequestChildrenOneTimesAndVerifyThatReadWasCalled()
        {
            // Arrange
            const int RootId      = 1;
            var       childrenIds = Fixture.CreateMany<int>(4).ToList();
            var       mock        = this.GetMockRepository(childrenIds);

            var sut = new NodeWithLazyChildren<int>(RootId, childrenIds, mock.Object);

            // Act
            var children = sut.Children;

            // Assert
            mock.Verify(m => m.Read(It.IsAny<int>()), Times.Exactly(childrenIds.Count));
            CollectionAssert.AreEquivalent(childrenIds, children.Select(c => c.Id));
        }

        [Test]
        public void RequestChildrenMultipleTimesAndVerifyThatReadWasCalledOncePerChild()
        {
            // Arrange
            const int RootId      = 1;
            var       childrenIds = Fixture.CreateMany<int>(4).ToList();
            var       mock        = this.GetMockRepository(childrenIds);

            var sut = new NodeWithLazyChildren<int>(RootId, childrenIds, mock.Object);

            // Act
            var children1 = sut.Children;
            var children2 = sut.Children;
            var children3 = sut.Children;

            // Assert
            mock.Verify(m => m.Read(It.IsAny<int>()), Times.Exactly(childrenIds.Count));
            foreach (var child in childrenIds)
            {
                mock.Verify(m => m.Read(child), Times.Once);
            }

            Assert.AreEqual(childrenIds.Count, children1.Count);
            CollectionAssert.AreEquivalent(childrenIds, children1.Select(c => c.Id));
        }

        private Mock<IRepository<T, NodeWithLazyChildren<T>>> GetMockRepository<T>(IEnumerable<T> ids)
        {
            var mock = new Mock<IRepository<T, NodeWithLazyChildren<T>>>();

            foreach (var id in ids)
            {
                mock.Setup(m => m.Read(id)).Returns(new NodeWithLazyChildren<T>(id, null, null));
            }

            return mock;
        }
    }
}