namespace CSharpDesignPatterns._5._Structural_patterns.Adapter
{
    using System;
    using System.Web;

    using CSharpDesignPatterns.Common.Model;

    using Moq;

    using NUnit.Framework;

    using Ploeh.AutoFixture;

    [TestFixture]
    public class OurOldLoggerToILoggerAdapterTests
    {
        private static readonly Fixture       Fixture         = new Fixture();
        private static readonly HttpException ServerException = new HttpException(404, "Server not found");

        [Test]
        public void SendLogMessageDebugOnlyInvokesLogDebugWithValidMessage()
        {
            var mock    = new Mock<ILogger>();
            var message = Fixture.Create<string>();

            var sut = new OurOldLoggerToILoggerAdapter(mock.Object);
            sut.SendLogMessage(LogLevel.Debug, message);

            // Assert
            mock.Verify(o => o.LogDebug(message), Times.Once);

            mock.Verify(o => o.LogDebug(It.Is<string>(s => s != message)),              Times.Never);
            mock.Verify(o => o.LogInfo(It.IsAny<string>()),                             Times.Never);
            mock.Verify(o => o.LogWarn(It.IsAny<string>()),                             Times.Never);
            mock.Verify(o => o.LogError(It.IsAny<string>()),                            Times.Never);
            mock.Verify(o => o.LogException(It.IsAny<Exception>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void SendLogMessageInfoOnlyInvokesLogInfoWithValidMessage()
        {
            var mock    = new Mock<ILogger>();
            var message = Fixture.Create<string>();

            var sut = new OurOldLoggerToILoggerAdapter(mock.Object);
            sut.SendLogMessage(LogLevel.Info, message);

            // Assert
            mock.Verify(o => o.LogInfo(message), Times.Once);

            mock.Verify(o => o.LogDebug(It.IsAny<string>()),                            Times.Never);
            mock.Verify(o => o.LogWarn(It.IsAny<string>()),                             Times.Never);
            mock.Verify(o => o.LogError(It.IsAny<string>()),                            Times.Never);
            mock.Verify(o => o.LogException(It.IsAny<Exception>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void SendLogMessageWarningOnlyInvokesLogWarnWithValidMessage()
        {
            var mock    = new Mock<ILogger>();
            var message = Fixture.Create<string>();

            var sut = new OurOldLoggerToILoggerAdapter(mock.Object);
            sut.SendLogMessage(LogLevel.Warning, message);

            // Assert
            mock.Verify(o => o.LogWarn(message), Times.Once);

            mock.Verify(o => o.LogDebug(It.IsAny<string>()),                            Times.Never);
            mock.Verify(o => o.LogInfo(It.IsAny<string>()),                             Times.Never);
            mock.Verify(o => o.LogError(It.IsAny<string>()),                            Times.Never);
            mock.Verify(o => o.LogException(It.IsAny<Exception>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void SendLogMessageErrorWithoutExceptionOnlyInvokesLogErrorWithValidMessage()
        {
            var mock    = new Mock<ILogger>();
            var message = Fixture.Create<string>();

            var sut = new OurOldLoggerToILoggerAdapter(mock.Object);
            sut.SendLogMessage(LogLevel.Error, message);

            // Assert
            mock.Verify(o => o.LogError(message), Times.Once);

            mock.Verify(o => o.LogDebug(It.IsAny<string>()),                            Times.Never);
            mock.Verify(o => o.LogInfo(It.IsAny<string>()),                             Times.Never);
            mock.Verify(o => o.LogWarn(It.IsAny<string>()),                             Times.Never);
            mock.Verify(o => o.LogException(It.IsAny<Exception>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void SendLogMessageErrorWithExceptionOnlyInvokesLogExceptionWithValidMessage()
        {
            var mock      = new Mock<ILogger>();
            var message   = Fixture.Create<string>();
            var exception = Fixture.Create<Exception>();

            var sut = new OurOldLoggerToILoggerAdapter(mock.Object);
            sut.SendLogMessage(LogLevel.Error, message, exception);

            // Assert
            mock.Verify(o => o.LogException(exception, message), Times.Once);

            mock.Verify(o => o.LogDebug(It.IsAny<string>()), Times.Never);
            mock.Verify(o => o.LogInfo(It.IsAny<string>()),  Times.Never);
            mock.Verify(o => o.LogWarn(It.IsAny<string>()),  Times.Never);
            mock.Verify(o => o.LogError(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void SendLogMessageFunctionalMessageDoesntInvoke()
        {
            var mock    = new Mock<ILogger>();
            var message = Fixture.Create<string>();

            var sut = new OurOldLoggerToILoggerAdapter(mock.Object);
            sut.SendLogMessage(LogLevel.FunctionalMessage, message);

            // Assert
            mock.Verify(o => o.LogDebug(It.IsAny<string>()),                            Times.Never);
            mock.Verify(o => o.LogInfo(It.IsAny<string>()),                             Times.Never);
            mock.Verify(o => o.LogWarn(It.IsAny<string>()),                             Times.Never);
            mock.Verify(o => o.LogError(It.IsAny<string>()),                            Times.Never);
            mock.Verify(o => o.LogException(It.IsAny<Exception>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void SendLogMessageFunctionalErrorDoesntInvoke()
        {
            var mock    = new Mock<ILogger>();
            var message = Fixture.Create<string>();

            var sut = new OurOldLoggerToILoggerAdapter(mock.Object);
            sut.SendLogMessage(LogLevel.FunctionalError, message);

            // Assert
            mock.Verify(o => o.LogDebug(It.IsAny<string>()),                            Times.Never);
            mock.Verify(o => o.LogInfo(It.IsAny<string>()),                             Times.Never);
            mock.Verify(o => o.LogWarn(It.IsAny<string>()),                             Times.Never);
            mock.Verify(o => o.LogError(It.IsAny<string>()),                            Times.Never);
            mock.Verify(o => o.LogException(It.IsAny<Exception>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void RemoteAdapterThrowsExceptionOnLogDebugOurAdapterReturnsFalse()
        {
            // Arrange
            var mock = new Mock<ILogger>();
            mock.Setup(m => m.LogDebug(It.IsAny<string>())).Throws(ServerException);

            var sut = new OurOldLoggerToILoggerAdapter(mock.Object);

            // Act
            var debugResult = sut.SendLogMessage(LogLevel.Debug, Guid.NewGuid().ToString());

            // Assert
            Assert.IsFalse(debugResult);
        }

        [Test]
        public void RemoteAdapterThrowsExceptionOnLogInfoOurAdapterReturnsFalse()
        {
            // Arrange
            var mock = new Mock<ILogger>();
            mock.Setup(m => m.LogInfo(It.IsAny<string>())).Throws(ServerException);

            var sut = new OurOldLoggerToILoggerAdapter(mock.Object);

            // Act
            var infoResult = sut.SendLogMessage(LogLevel.Info, Guid.NewGuid().ToString());

            // Assert
            Assert.IsFalse(infoResult);
        }

        [Test]
        public void RemoteAdapterThrowsExceptionOnLogWarnOurAdapterReturnsFalse()
        {
            // Arrange
            var mock = new Mock<ILogger>();
            mock.Setup(m => m.LogWarn(It.IsAny<string>())).Throws(ServerException);

            var sut = new OurOldLoggerToILoggerAdapter(mock.Object);

            // Act
            var warnResult = sut.SendLogMessage(LogLevel.Warning, Guid.NewGuid().ToString());

            // Assert
            Assert.IsFalse(warnResult);
        }

        [Test]
        public void RemoteAdapterThrowsExceptionOnLogErrorOurAdapterReturnsFalse()
        {
            // Arrange
            var mock = new Mock<ILogger>();
            mock.Setup(m => m.LogError(It.IsAny<string>())).Throws(ServerException);

            var sut = new OurOldLoggerToILoggerAdapter(mock.Object);

            // Act
            var errorResult = sut.SendLogMessage(LogLevel.Error, Guid.NewGuid().ToString());

            // Assert
            Assert.IsFalse(errorResult);
        }
    }
}