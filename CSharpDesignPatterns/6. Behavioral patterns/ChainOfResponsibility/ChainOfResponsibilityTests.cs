namespace CSharpDesignPatterns._6._Behavioral_patterns.ChainOfResponsibility
{
    using System;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class ChainOfResponsibilityTests
    {
        [Test]
        public void DebugAndInfoMessagesHandledOnlyByConsoleLogger()
        {
            var message1 = Guid.NewGuid().ToString();
            var message2 = Guid.NewGuid().ToString();

            var consoleWriter = new Mock<IMessageWriter>();
            var emailWriter   = new Mock<IMessageWriter>();
            var fileWriter    = new Mock<IMessageWriter>();

            var logger = new ChainOfResponsibilityConsoleLogger(LogLevel.All, consoleWriter.Object)
                        .AddNext(new ChainOfResponsibilityEmailLogger(LogLevel.FunctionalMessage | LogLevel.FunctionalError, emailWriter.Object))
                        .AddNext(new ChainOfResponsibilityFileLogger(LogLevel.Warning            | LogLevel.Error, fileWriter.Object));

            logger.Message(message1, LogLevel.Debug);
            logger.Message(message2, LogLevel.Info);

            // Assert
            consoleWriter.Verify(m => m.WriteMessage(message1), Times.Once);
            consoleWriter.Verify(m => m.WriteMessage(message2), Times.Once);

            emailWriter.Verify(m => m.WriteMessage(It.IsAny<string>()), Times.Never);
            fileWriter.Verify(m => m.WriteMessage(It.IsAny<string>()), Times.Never);
        }

        [Ignore("")]
        [Test]
        public void FunctionalMessagesHandledByConsoleAndEmailLoggers()
        {
            var message1 = Guid.NewGuid().ToString();
            var message2 = Guid.NewGuid().ToString();

            var consoleWriter = new Mock<IMessageWriter>();
            var emailWriter   = new Mock<IMessageWriter>();
            var fileWriter    = new Mock<IMessageWriter>();

            var logger = new ChainOfResponsibilityConsoleLogger(LogLevel.All, consoleWriter.Object)
                        .AddNext(new ChainOfResponsibilityEmailLogger(LogLevel.FunctionalMessage | LogLevel.FunctionalError, emailWriter.Object))
                        .AddNext(new ChainOfResponsibilityFileLogger(LogLevel.Warning            | LogLevel.Error, fileWriter.Object));

            logger.Message(message1, LogLevel.FunctionalError);
            logger.Message(message2, LogLevel.FunctionalMessage);

            // Assert
            consoleWriter.Verify(m => m.WriteMessage(message1), Times.Once);
            consoleWriter.Verify(m => m.WriteMessage(message2), Times.Once);

            emailWriter.Verify(m => m.WriteMessage(message1), Times.Once);
            emailWriter.Verify(m => m.WriteMessage(message2), Times.Once);

            fileWriter.Verify(m => m.WriteMessage(It.IsAny<string>()), Times.Never);
        }

        [Ignore("")]
        [Test]
        public void WarningAndErrorMessagesHandledByConsoleAndFileLoggers()
        {
            var message1 = Guid.NewGuid().ToString();
            var message2 = Guid.NewGuid().ToString();

            var consoleWriter = new Mock<IMessageWriter>();
            var emailWriter   = new Mock<IMessageWriter>();
            var fileWriter    = new Mock<IMessageWriter>();

            var logger = new ChainOfResponsibilityConsoleLogger(LogLevel.All, consoleWriter.Object)
                        .AddNext(new ChainOfResponsibilityEmailLogger(LogLevel.FunctionalMessage | LogLevel.FunctionalError, emailWriter.Object))
                        .AddNext(new ChainOfResponsibilityFileLogger(LogLevel.Warning            | LogLevel.Error, fileWriter.Object));

            logger.Message(message1, LogLevel.Error);
            logger.Message(message2, LogLevel.Warning);

            // Assert
            consoleWriter.Verify(m => m.WriteMessage(message1), Times.Once);
            consoleWriter.Verify(m => m.WriteMessage(message2), Times.Once);

            fileWriter.Verify(m => m.WriteMessage(message1), Times.Once);
            fileWriter.Verify(m => m.WriteMessage(message2), Times.Once);

            emailWriter.Verify(m => m.WriteMessage(It.IsAny<string>()), Times.Never);
        }
    }
}