namespace CSharpDesignPatterns._5._Structural_patterns.Adapter
{
    using System;
    using System.Web;

    using CSharpDesignPatterns.Common.Model;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class AdapterTests
    {
        [Test]
        public void DebugMessage_ProperlyInvokesExternalInterface()
        {
            var mock    = new Mock<ILogger>();
            var message = Guid.NewGuid().ToString();

            var sut = new OurLoggingToNewLoggingAdapter(mock.Object);
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
        public void ErrorMessage_ProperlyInvokesExternalInterface()
        {
            var mock    = new Mock<ILogger>();
            var message = Guid.NewGuid().ToString();

            var sut = new OurLoggingToNewLoggingAdapter(mock.Object);
            sut.SendLogMessage(LogLevel.Error, message);

            // Assert
            mock.Verify(o => o.LogError(message), Times.Once);

            mock.Verify(o => o.LogDebug(It.IsAny<string>()),                            Times.Never);
            mock.Verify(o => o.LogInfo(It.IsAny<string>()),                             Times.Never);
            mock.Verify(o => o.LogWarn(It.IsAny<string>()),                             Times.Never);
            mock.Verify(o => o.LogException(It.IsAny<Exception>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void ExceptionMessage_ProperlyInvokesExternalInterface()
        {
            var mock      = new Mock<ILogger>();
            var message   = Guid.NewGuid().ToString();
            var exception = new Exception();

            var sut = new OurLoggingToNewLoggingAdapter(mock.Object);
            sut.SendLogMessage(LogLevel.Exception, message, exception);

            // Assert
            mock.Verify(o => o.LogException(exception, message), Times.Once);

            mock.Verify(o => o.LogDebug(It.IsAny<string>()), Times.Never);
            mock.Verify(o => o.LogInfo(It.IsAny<string>()),  Times.Never);
            mock.Verify(o => o.LogWarn(It.IsAny<string>()),  Times.Never);
            mock.Verify(o => o.LogError(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void InfoMessage_ProperlyInvokesExternalInterface()
        {
            var mock    = new Mock<ILogger>();
            var message = Guid.NewGuid().ToString();

            var sut = new OurLoggingToNewLoggingAdapter(mock.Object);
            sut.SendLogMessage(LogLevel.Info, message);

            // Assert
            mock.Verify(o => o.LogInfo(message), Times.Once);

            mock.Verify(o => o.LogDebug(It.IsAny<string>()),                            Times.Never);
            mock.Verify(o => o.LogWarn(It.IsAny<string>()),                             Times.Never);
            mock.Verify(o => o.LogError(It.IsAny<string>()),                            Times.Never);
            mock.Verify(o => o.LogException(It.IsAny<Exception>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void Adapter_WarnMessage_ProperlyInvokesExternalInterface()
        {
            var mock    = new Mock<ILogger>();
            var message = Guid.NewGuid().ToString();

            var sut = new OurLoggingToNewLoggingAdapter(mock.Object);
            sut.SendLogMessage(LogLevel.Warn, message);

            // Assert
            mock.Verify(o => o.LogWarn(message), Times.Once);

            mock.Verify(o => o.LogDebug(It.IsAny<string>()),                            Times.Never);
            mock.Verify(o => o.LogInfo(It.IsAny<string>()),                             Times.Never);
            mock.Verify(o => o.LogError(It.IsAny<string>()),                            Times.Never);
            mock.Verify(o => o.LogException(It.IsAny<Exception>(), It.IsAny<string>()), Times.Never);
        }

        [Ignore("nice to have")]
        [Test]
        public void RemoteAdapterThrowsExceptionOnDebug_ProperlyReturnsFalse()
        {
            // Arrange
            var mock      = new Mock<ILogger>();
            var exception = new HttpException(404, "Server not found");
            mock.Setup(m => m.LogDebug(It.IsAny<string>())).Throws(exception);

            var sut = new OurLoggingToNewLoggingAdapter(mock.Object);

            // Act
            var debugResult = sut.SendLogMessage(LogLevel.Debug, Guid.NewGuid().ToString());

            // Assert
            Assert.IsFalse(debugResult);
            mock.Verify(o => o.LogDebug(It.IsAny<string>()),                            Times.Once);
            mock.Verify(o => o.LogInfo(It.IsAny<string>()),                             Times.Never);
            mock.Verify(o => o.LogWarn(It.IsAny<string>()),                             Times.Never);
            mock.Verify(o => o.LogError(It.IsAny<string>()),                            Times.Never);
            mock.Verify(o => o.LogException(It.IsAny<Exception>(), It.IsAny<string>()), Times.Never);
        }

        [Ignore("nice to have")]
        [Test]
        public void RemoteAdapterThrowsExceptionOnError_ProperlyReturnsFalse()
        {
            // Arrange
            var mock      = new Mock<ILogger>();
            var exception = new HttpException(404, "Server not found");
            mock.Setup(m => m.LogError(It.IsAny<string>())).Throws(exception);

            var sut = new OurLoggingToNewLoggingAdapter(mock.Object);

            // Act
            var errorResult = sut.SendLogMessage(LogLevel.Error, Guid.NewGuid().ToString());

            // Assert
            Assert.IsFalse(errorResult);
            mock.Verify(o => o.LogDebug(It.IsAny<string>()),                            Times.Never);
            mock.Verify(o => o.LogInfo(It.IsAny<string>()),                             Times.Never);
            mock.Verify(o => o.LogWarn(It.IsAny<string>()),                             Times.Never);
            mock.Verify(o => o.LogError(It.IsAny<string>()),                            Times.Once);
            mock.Verify(o => o.LogException(It.IsAny<Exception>(), It.IsAny<string>()), Times.Never);
        }

        [Ignore("nice to have")]
        [Test]
        public void RemoteAdapterThrowsExceptionOnException_ProperlyReturnsFalse()
        {
            // Arrange
            var mock      = new Mock<ILogger>();
            var exception = new HttpException(404, "Server not found");
            mock.Setup(m => m.LogException(It.IsAny<Exception>(), It.IsAny<string>())).Throws(exception);

            var sut = new OurLoggingToNewLoggingAdapter(mock.Object);

            // Act
            var exceptionResult = sut.SendLogMessage(LogLevel.Exception, Guid.NewGuid().ToString());

            // Assert
            Assert.IsFalse(exceptionResult);
            mock.Verify(o => o.LogDebug(It.IsAny<string>()),                            Times.Never);
            mock.Verify(o => o.LogInfo(It.IsAny<string>()),                             Times.Never);
            mock.Verify(o => o.LogWarn(It.IsAny<string>()),                             Times.Never);
            mock.Verify(o => o.LogError(It.IsAny<string>()),                            Times.Never);
            mock.Verify(o => o.LogException(It.IsAny<Exception>(), It.IsAny<string>()), Times.Once);
        }

        [Ignore("nice to have")]
        [Test]
        public void RemoteAdapterThrowsExceptionOnInfo_ProperlyReturnsFalse()
        {
            // Arrange
            var mock      = new Mock<ILogger>();
            var exception = new HttpException(404, "Server not found");
            mock.Setup(m => m.LogInfo(It.IsAny<string>())).Throws(exception);

            var sut = new OurLoggingToNewLoggingAdapter(mock.Object);

            // Act
            var infoResult = sut.SendLogMessage(LogLevel.Info, Guid.NewGuid().ToString());

            // Assert
            Assert.IsFalse(infoResult);
            mock.Verify(o => o.LogDebug(It.IsAny<string>()),                            Times.Never);
            mock.Verify(o => o.LogInfo(It.IsAny<string>()),                             Times.Once);
            mock.Verify(o => o.LogWarn(It.IsAny<string>()),                             Times.Never);
            mock.Verify(o => o.LogError(It.IsAny<string>()),                            Times.Never);
            mock.Verify(o => o.LogException(It.IsAny<Exception>(), It.IsAny<string>()), Times.Never);
        }

        [Ignore("nice to have")]
        [Test]
        public void RemoteAdapterThrowsExceptionOnWarn_ProperlyReturnsFalse()
        {
            // Arrange
            var mock      = new Mock<ILogger>();
            var exception = new HttpException(404, "Server not found");
            mock.Setup(m => m.LogWarn(It.IsAny<string>())).Throws(exception);

            var sut = new OurLoggingToNewLoggingAdapter(mock.Object);

            // Act
            var warnResult = sut.SendLogMessage(LogLevel.Warn, Guid.NewGuid().ToString());

            // Assert
            Assert.IsFalse(warnResult);
            mock.Verify(o => o.LogDebug(It.IsAny<string>()),                            Times.Never);
            mock.Verify(o => o.LogInfo(It.IsAny<string>()),                             Times.Never);
            mock.Verify(o => o.LogWarn(It.IsAny<string>()),                             Times.Once);
            mock.Verify(o => o.LogError(It.IsAny<string>()),                            Times.Never);
            mock.Verify(o => o.LogException(It.IsAny<Exception>(), It.IsAny<string>()), Times.Never);
        }
    }
}