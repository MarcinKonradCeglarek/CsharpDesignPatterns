namespace CSharpDesignPatterns._5._Structural_patterns.Adapter
{
    using System;

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

            var sut = new Adapter();
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

            var sut = new Adapter();
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

            var sut = new Adapter();
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

            var sut = new Adapter();
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

            var sut = new Adapter();
            sut.SendLogMessage(LogLevel.Exception, message, exception);

            // Assert
            mock.Verify(o => o.LogException(exception, message), Times.Once);

            mock.Verify(o => o.LogDebug(It.IsAny<string>()), Times.Never);
            mock.Verify(o => o.LogInfo(It.IsAny<string>()), Times.Never);
            mock.Verify(o => o.LogWarn(It.IsAny<string>()), Times.Never);
            mock.Verify(o => o.LogError(It.IsAny<string>()), Times.Never);
        }
    }
}