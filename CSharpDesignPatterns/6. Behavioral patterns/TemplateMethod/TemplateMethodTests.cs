namespace CSharpDesignPatterns._6._Behavioral_patterns.TemplateMethod
{
    using System;
    using System.Linq;

    using Castle.Core.Internal;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class TemplateMethodTests
    {
        [Test]
        public void InMemCache_EmptyCache_FetchesResource()
        {
            const string Url     = "Some Url";
            const string Content = "Some content";

            var remoteDataFetcher = new Mock<IRemoteDataFetcher>();
            remoteDataFetcher.Setup(m => m.FetchUrl(Url)).Returns(Content);

            var sut = new InMemCache(remoteDataFetcher.Object);

            var result = sut.GetResource(Url);

            Assert.AreEqual(Content, result);
            remoteDataFetcher.Verify(m => m.FetchUrl(Url), Times.Once);
        }

        [Test]
        public void InMemCache_EmptyCacheMultipleCalls_FetchesResourceJustOnce()
        {
            const string Url     = "Some Url";
            const string Content = "Some content";

            var remoteDataFetcher = new Mock<IRemoteDataFetcher>();
            remoteDataFetcher.Setup(m => m.FetchUrl(Url)).Returns(Content);

            var sut = new InMemCache(remoteDataFetcher.Object);

            var result = sut.GetResource(Url);

            Assert.AreEqual(Content, result);
            remoteDataFetcher.Verify(m => m.FetchUrl(Url), Times.Once);

            result = sut.GetResource(Url);
            result = sut.GetResource(Url);
            result = sut.GetResource(Url);

            remoteDataFetcher.Verify(m => m.FetchUrl(Url), Times.Once);
        }

        [Test]
        public void InMemCache_EmptyChacheMultipleUrls_ProperlyRetrievesAllUrls()
        {
            // Arrange
            var inputData = Enumerable.Range(0, 20).Select(i => Guid.NewGuid()).ToDictionary(g => g.ToString(), g => $"Content of {g.ToString()}");
            var remoteDataFetcher = new Mock<IRemoteDataFetcher>();

            inputData.ForEach(i => remoteDataFetcher.Setup(m => m.FetchUrl(i.Key)).Returns(i.Value));

            var sut = new InMemCache(remoteDataFetcher.Object);

            // Act & Assert
            foreach (var input in inputData)
            {
                var result = sut.GetResource(input.Key);
                Assert.AreEqual(input.Value, result);
            }

            foreach (var input in inputData)
            {
                var result = sut.GetResource(input.Key);
                Assert.AreEqual(input.Value, result);
            }

            foreach (var input in inputData)
            {
                var result = sut.GetResource(input.Key);
                Assert.AreEqual(input.Value, result);
            }

            foreach (var input in inputData)
            {
                remoteDataFetcher.Verify(m => m.FetchUrl(input.Key), Times.Once);
            }
        }
    }
}