namespace CSharpDesignPatterns._6._Behavioral_patterns.ChainOfResponsibility
{
    using System;

    /*
     * https://refactoring.guru/design-patterns/chain-of-responsibility
     *
     * https://en.wikipedia.org/wiki/Chain-of-responsibility_pattern
     */
    [Flags]
    public enum LogLevel
    {
        Info              = 0b00000001,
        Debug             = 0b00000010,
        Warning           = 0b00000100,
        Error             = 0b00001000,
        FunctionalMessage = 0b00010000,
        FunctionalError   = 0b00100000,
        All               = 0b00111111
    }

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
        private readonly LogLevel mask;

        protected ChainOfResponsibilityLogger(LogLevel mask)
        {
            this.mask = mask;
        }

        public ChainOfResponsibilityLogger Next { get; set; }

        public ChainOfResponsibilityLogger AddNext(ChainOfResponsibilityLogger newLogger)
        {
            return this.InsertAsLastElementOfChain(newLogger);
        }

        public void LogMessage(LogLevel severity, string message)
        {
            if (Helper.DoesLevelMatchMask(severity, this.mask))
            {
                this.ProcessMessage(message);
            }

            this.Next?.LogMessage(severity, message);
        }

        protected abstract void ProcessMessage(string message);

        private ChainOfResponsibilityLogger InsertAsFirstElementOfChain(ChainOfResponsibilityLogger newLogger)
        {
            newLogger.Next = this;
            return newLogger;
        }

        private ChainOfResponsibilityLogger InsertAsLastElementOfChain(ChainOfResponsibilityLogger nextChainOfResponsibilityLogger)
        {
            if (this.Next != null)
            {
                this.Next.AddNext(nextChainOfResponsibilityLogger);
            }
            else
            {
                this.Next = nextChainOfResponsibilityLogger;
            }

            return this;
        }

        private ChainOfResponsibilityLogger InsertAsSecondElementOfChain(ChainOfResponsibilityLogger newLogger)
        {
            newLogger.Next = this.Next;
            this.Next      = newLogger;
            return this;
        }
    }

    public class ChainOfResponsibilityConsoleLogger : ChainOfResponsibilityLogger
    {
        private readonly IConsole messageConsole;

        public ChainOfResponsibilityConsoleLogger(LogLevel mask, IConsole messageConsole)
            : base(mask)
        {
            this.messageConsole = messageConsole;
        }

        protected override void ProcessMessage(string message)
        {
            this.messageConsole.WriteMessage(message);
        }
    }

    public class ChainOfResponsibilityEmailLogger : ChainOfResponsibilityLogger
    {
        private readonly IEmail email;

        public ChainOfResponsibilityEmailLogger(LogLevel mask, IEmail email)
            : base(mask)
        {
            this.email = email;
        }

        protected override void ProcessMessage(string message)
        {
            this.email.SendEmail(message);
        }
    }

    internal class ChainOfResponsibilityFileLogger : ChainOfResponsibilityLogger
    {
        private readonly IFileWriter file;

        public ChainOfResponsibilityFileLogger(LogLevel mask, IFileWriter file)
            : base(mask)
        {
            this.file = file;
        }

        protected override void ProcessMessage(string message)
        {
            this.file.AppendToLogFile(message);
        }
    }
}