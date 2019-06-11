namespace CSharpDesignPatterns._5._Structural_patterns.Adapter
{
    using System;
    using System.Web;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class AdapterTests
    {
        [Test]
        public void Adapter_DebugMessage_ProperlyInvokesExternalInterface()
        {
            var mock = new Mock<IExternalLoggingInterface>();
            var message = Guid.NewGuid().ToString();

            var sut = new Adapter(mock.Object);
            sut.SendLogMessage(LogLevel.Debug, message);

            // Assert
            mock.Verify(o => o.LogDebug(message), Times.Once);

            mock.Verify(o => o.LogDebug(It.Is<string>(s => s != message)), Times.Never);
            mock.Verify(o => o.LogInfo(It.IsAny<string>()), Times.Never);
            mock.Verify(o => o.LogWarn(It.IsAny<string>()), Times.Never);
            mock.Verify(o => o.LogError(It.IsAny<string>()), Times.Never);
            mock.Verify(o => o.LogException(It.IsAny<Exception>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void Adapter_InfoMessage_ProperlyInvokesExternalInterface()
        {
            var mock = new Mock<IExternalLoggingInterface>();
            var message = Guid.NewGuid().ToString();

            var sut = new Adapter(mock.Object);
            sut.SendLogMessage(LogLevel.Info, message);

            // Assert
            mock.Verify(o => o.LogInfo(message), Times.Once);

            mock.Verify(o => o.LogDebug(It.IsAny<string>()), Times.Never);
            mock.Verify(o => o.LogWarn(It.IsAny<string>()), Times.Never);
            mock.Verify(o => o.LogError(It.IsAny<string>()), Times.Never);
            mock.Verify(o => o.LogException(It.IsAny<Exception>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void Adapter_WarnMessage_ProperlyInvokesExternalInterface()
        {
            var mock = new Mock<IExternalLoggingInterface>();
            var message = Guid.NewGuid().ToString();

            var sut = new Adapter(mock.Object);
            sut.SendLogMessage(LogLevel.Warn, message);

            // Assert
            mock.Verify(o => o.LogWarn(message), Times.Once);

            mock.Verify(o => o.LogDebug(It.IsAny<string>()), Times.Never);
            mock.Verify(o => o.LogInfo(It.IsAny<string>()), Times.Never);
            mock.Verify(o => o.LogError(It.IsAny<string>()), Times.Never);
            mock.Verify(o => o.LogException(It.IsAny<Exception>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void Adapter_ErrorMessage_ProperlyInvokesExternalInterface()
        {
            var mock = new Mock<IExternalLoggingInterface>();
            var message = Guid.NewGuid().ToString();

            var sut = new Adapter(mock.Object);
            sut.SendLogMessage(LogLevel.Error, message);

            // Assert
            mock.Verify(o => o.LogError(message), Times.Once);

            mock.Verify(o => o.LogDebug(It.IsAny<string>()), Times.Never);
            mock.Verify(o => o.LogInfo(It.IsAny<string>()), Times.Never);
            mock.Verify(o => o.LogWarn(It.IsAny<string>()), Times.Never);
            mock.Verify(o => o.LogException(It.IsAny<Exception>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void Adapter_ExceptionMessage_ProperlyInvokesExternalInterface()
        {
            var mock = new Mock<IExternalLoggingInterface>();
            var message = Guid.NewGuid().ToString();
            var exception = new Exception();

            var sut = new Adapter(mock.Object);
            sut.SendLogMessage(LogLevel.Exception, message, exception);

            // Assert
            mock.Verify(o => o.LogException(exception, message), Times.Once);

            mock.Verify(o => o.LogDebug(It.IsAny<string>()), Times.Never);
            mock.Verify(o => o.LogInfo(It.IsAny<string>()), Times.Never);
            mock.Verify(o => o.LogWarn(It.IsAny<string>()), Times.Never);
            mock.Verify(o => o.LogError(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void Adapter_RemoteAdapterThrowsException_ProperlyReturnsFalse()
        {
            // Arrange
            var mock = new Mock<IExternalLoggingInterface>();
            var exception = new HttpException(404, "Server not found");
            mock.Setup(m => m.LogDebug(It.IsAny<string>())).Throws(exception);
            mock.Setup(m => m.LogInfo(It.IsAny<string>())).Throws(exception);
            mock.Setup(m => m.LogWarn(It.IsAny<string>())).Throws(exception);
            mock.Setup(m => m.LogError(It.IsAny<string>())).Throws(exception);
            mock.Setup(m => m.LogException(It.IsAny<Exception>(), It.IsAny<string>())).Throws(exception);

            var sut = new Adapter(mock.Object);

            // Act
            var debugResult = sut.SendLogMessage(LogLevel.Debug, Guid.NewGuid().ToString());
            var infoResult = sut.SendLogMessage(LogLevel.Info, Guid.NewGuid().ToString());
            var warnResult = sut.SendLogMessage(LogLevel.Warn, Guid.NewGuid().ToString());
            var errorResult = sut.SendLogMessage(LogLevel.Error, Guid.NewGuid().ToString());
            var exceptionResult = sut.SendLogMessage(LogLevel.Exception, Guid.NewGuid().ToString());

            // Assert
            Assert.IsFalse(debugResult);
            Assert.IsFalse(infoResult);
            Assert.IsFalse(warnResult);
            Assert.IsFalse(errorResult);
            Assert.IsFalse(exceptionResult);
        }
    }
}