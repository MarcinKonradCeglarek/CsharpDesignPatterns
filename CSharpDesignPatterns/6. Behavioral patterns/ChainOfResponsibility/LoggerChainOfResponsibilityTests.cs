namespace CSharpDesignPatterns._6._Behavioral_patterns.ChainOfResponsibility
{
    using System;

    using CSharpDesignPatterns.Common.Model;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class LoggerChainOfResponsibilityTests
    {
        [Test]
        public void CheckSeverityMatchingMask()
        {
            var mask     = LogLevel.Error | LogLevel.Warning | LogLevel.Debug;
            var severity = LogLevel.Warning;

            Assert.IsTrue(Helper.DoesLevelMatchMask(severity, mask));
        }

        [Test]
        public void CheckSeverityNotMatchingMask()
        {
            var mask     = LogLevel.Error | LogLevel.Warning;
            var severity = LogLevel.Info;

            Assert.IsFalse(Helper.DoesLevelMatchMask(severity, mask));
        }

        [TestCase(LogLevel.Debug)]
        [TestCase(LogLevel.Info)]
        [TestCase(LogLevel.Error)]
        [TestCase(LogLevel.FunctionalError)]
        [TestCase(LogLevel.FunctionalMessage)]
        public void MessagesHandledBySingleConsoleLogger(LogLevel logLevel)
        {
            var message1      = Guid.NewGuid().ToString();
            var consoleWriter = new Mock<IConsole>();
            var logger        = new ConsoleLoggerChainOfResponsibility(logLevel, consoleWriter.Object);

            logger.LogMessage(logLevel, message1);

            // Assert
            consoleWriter.Verify(m => m.WriteMessage(message1), Times.Once);
        }

        [TestCase(LogLevel.Debug)]
        [TestCase(LogLevel.Info)]
        [TestCase(LogLevel.Error)]
        [TestCase(LogLevel.FunctionalError)]
        [TestCase(LogLevel.FunctionalMessage)]
        public void MessagesHandledBySingleEmailLogger(LogLevel logLevel)
        {
            var message1    = Guid.NewGuid().ToString();
            var emailWriter = new Mock<IEmail>();
            var logger      = new EmailLoggerChainOfResponsibility(logLevel, emailWriter.Object);

            logger.LogMessage(logLevel, message1);

            // Assert
            emailWriter.Verify(m => m.SendEmail(message1), Times.Once);
        }

        [TestCase(LogLevel.Debug)]
        [TestCase(LogLevel.Info)]
        [TestCase(LogLevel.Error)]
        [TestCase(LogLevel.FunctionalError)]
        [TestCase(LogLevel.FunctionalMessage)]
        public void MessagesHandledBySingleFileLogger(LogLevel logLevel)
        {
            var message1   = Guid.NewGuid().ToString();
            var fileWriter = new Mock<IFileWriter>();

            var logger = new FileLoggerChainOfResponsibility(logLevel, fileWriter.Object);

            logger.LogMessage(logLevel, message1);

            // Assert
            fileWriter.Verify(m => m.AppendToLogFile(message1), Times.Once);
        }

        [Test]
        public void DebugAndInfoMessagesHandledOnlyByConsoleLogger()
        {
            var message1 = Guid.NewGuid().ToString();
            var message2 = Guid.NewGuid().ToString();

            var consoleWriter = new Mock<IConsole>();
            var emailWriter   = new Mock<IEmail>();
            var fileWriter    = new Mock<IFileWriter>();

            var logger = new ConsoleLoggerChainOfResponsibility(LogLevel.All, consoleWriter.Object)
                        .AddNext(
                             new EmailLoggerChainOfResponsibility(
                                 LogLevel.FunctionalMessage | LogLevel.FunctionalError,
                                 emailWriter.Object))
                        .AddNext(
                             new FileLoggerChainOfResponsibility(LogLevel.Warning | LogLevel.Error, fileWriter.Object));

            logger.LogMessage(LogLevel.Debug, message1);
            logger.LogMessage(LogLevel.Info,  message2);

            // Assert
            consoleWriter.Verify(m => m.WriteMessage(message1), Times.Once);
            consoleWriter.Verify(m => m.WriteMessage(message2), Times.Once);

            emailWriter.Verify(m => m.SendEmail(It.IsAny<string>()), Times.Never);
            fileWriter.Verify(m => m.AppendToLogFile(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void FunctionalMessagesHandledByConsoleAndEmailLoggers()
        {
            var message1 = Guid.NewGuid().ToString();
            var message2 = Guid.NewGuid().ToString();

            var consoleWriter = new Mock<IConsole>();
            var emailWriter   = new Mock<IEmail>();
            var fileWriter    = new Mock<IFileWriter>();

            var logger = new ConsoleLoggerChainOfResponsibility(LogLevel.All, consoleWriter.Object)
                        .AddNext(
                             new EmailLoggerChainOfResponsibility(
                                 LogLevel.FunctionalMessage | LogLevel.FunctionalError,
                                 emailWriter.Object))
                        .AddNext(
                             new FileLoggerChainOfResponsibility(LogLevel.Warning | LogLevel.Error, fileWriter.Object));

            logger.LogMessage(LogLevel.FunctionalError,   message1);
            logger.LogMessage(LogLevel.FunctionalMessage, message2);

            // Assert
            consoleWriter.Verify(m => m.WriteMessage(message1), Times.Once);
            consoleWriter.Verify(m => m.WriteMessage(message2), Times.Once);

            emailWriter.Verify(m => m.SendEmail(message1), Times.Once);
            emailWriter.Verify(m => m.SendEmail(message2), Times.Once);

            fileWriter.Verify(m => m.AppendToLogFile(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void WarningAndErrorMessagesHandledByConsoleAndFileLoggers()
        {
            var message1 = Guid.NewGuid().ToString();
            var message2 = Guid.NewGuid().ToString();

            var consoleWriter = new Mock<IConsole>();
            var emailWriter   = new Mock<IEmail>();
            var fileWriter    = new Mock<IFileWriter>();

            var logger = new ConsoleLoggerChainOfResponsibility(LogLevel.All, consoleWriter.Object)
                        .AddNext(
                             new EmailLoggerChainOfResponsibility(
                                 LogLevel.FunctionalMessage | LogLevel.FunctionalError,
                                 emailWriter.Object))
                        .AddNext(
                             new FileLoggerChainOfResponsibility(LogLevel.Warning | LogLevel.Error, fileWriter.Object));

            logger.LogMessage(LogLevel.Error,   message1);
            logger.LogMessage(LogLevel.Warning, message2);

            // Assert
            consoleWriter.Verify(m => m.WriteMessage(message1), Times.Once);
            consoleWriter.Verify(m => m.WriteMessage(message2), Times.Once);

            fileWriter.Verify(m => m.AppendToLogFile(message1), Times.Once);
            fileWriter.Verify(m => m.AppendToLogFile(message2), Times.Once);

            emailWriter.Verify(m => m.SendEmail(It.IsAny<string>()), Times.Never);
        }
    }
}