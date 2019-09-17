namespace CSharpDesignPatterns._6._Behavioral_patterns.ChainOfResponsibility
{
    using System;

    using CSharpDesignPatterns.Common.Model;

    /*
     * https://refactoring.guru/design-patterns/chain-of-responsibility
     *
     * https://en.wikipedia.org/wiki/Chain-of-responsibility_pattern
     */

    public interface IConsole
    {
        void WriteMessage(string message);
    }

    public interface IEmail
    {
        void SendEmail(string contents);
    }

    public interface IFileWriter
    {
        void AppendToLogFile(string message);
    }

    public abstract class ChainOfResponsibilityLogger
    {
        protected ChainOfResponsibilityLogger(LogLevel mask)
        {
            throw new NotImplementedException();
        }

        public ChainOfResponsibilityLogger Next { get; set; }

        public ChainOfResponsibilityLogger AddNext(ChainOfResponsibilityLogger newLogger)
        {
            throw new NotImplementedException();
        }

        public void LogMessage(LogLevel severity, string message)
        {
            throw new NotImplementedException();
        }

        protected abstract void ProcessMessage(string message);

        private ChainOfResponsibilityLogger InsertAsFirstElementOfChain(ChainOfResponsibilityLogger newLogger)
        {
            throw new NotImplementedException();
        }

        private ChainOfResponsibilityLogger InsertAsLastElementOfChain(ChainOfResponsibilityLogger nextChainOfResponsibilityLogger)
        {
            throw new NotImplementedException();
        }

        private ChainOfResponsibilityLogger InsertAsSecondElementOfChain(ChainOfResponsibilityLogger newLogger)
        {
            throw new NotImplementedException();
        }
    }

    public class ChainOfResponsibilityConsoleLogger : ChainOfResponsibilityLogger
    {
        public ChainOfResponsibilityConsoleLogger(LogLevel mask, IConsole messageConsole)
            : base(mask)
        {
            throw new NotImplementedException();
        }

        protected override void ProcessMessage(string message)
        {
            throw new NotImplementedException();
        }
    }

    public class ChainOfResponsibilityEmailLogger : ChainOfResponsibilityLogger
    {
        public ChainOfResponsibilityEmailLogger(LogLevel mask, IEmail email)
            : base(mask)
        {
            throw new NotImplementedException();
        }

        protected override void ProcessMessage(string message)
        {
            throw new NotImplementedException();
        }
    }

    internal class ChainOfResponsibilityFileLogger : ChainOfResponsibilityLogger
    {
        public ChainOfResponsibilityFileLogger(LogLevel mask, IFileWriter file)
            : base(mask)
        {
            throw new NotImplementedException();
        }

        protected override void ProcessMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}