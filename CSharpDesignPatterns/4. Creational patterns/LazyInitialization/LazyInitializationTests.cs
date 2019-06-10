namespace CSharpDesignPatterns._4._Creational_patterns.LazyInitialization
{
    using System.Linq;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class LazyInitializationTests
    {
        [Test]
        public void LazyInitialization_DontRequestChildren_VerifyThatGetChildrenWasNotCalled()
        {
            const string Name = "NodeName";
            var mock = this.GetMock(Name);

            var sut = new Node(Name, mock.Object);

            mock.Verify(m => m.GetChildrenByName(It.IsAny<string>()), Times.Never);               // GetChildrenByName was never called
        }

        [Test]
        public void LazyInitialization_RequestChildren_VerifyThatGetChildrenWasCalled()
        {
            const string Name = "NodeName";
            var mock = this.GetMock(Name);

            var sut = new Node(Name, mock.Object);
            var children = sut.Children;

            mock.Verify(m => m.GetChildrenByName(It.Is<string>(s => s != Name)), Times.Never);    // GetChildrenByName was never called with parameter different than Name
            mock.Verify(m => m.GetChildrenByName(Name), Times.Once);                              // GetChildrenByName was called with Name once
            Assert.AreEqual(2, children.Count());
        }

        private Mock<IChildrenRepository> GetMock(string name)
        {
            var mock = new Mock<IChildrenRepository>();

            mock.Setup(m => m.GetChildrenByName(name)).Returns(new[] { new Node("Child1", null), new Node("Child2", null) });

            return mock;
        }
    }
}