namespace CSharpDesignPatterns._6._Behavioral_patterns.ChainOfResponsibility
{
    using System;

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

    public interface IMessageWriter
    {
        void WriteMessage(string message);
    }

    public abstract class ChainOfResponsibilityLogger
    {
        protected ChainOfResponsibilityLogger(LogLevel mask)
        {
            this.LogMask = mask;
        }

        protected LogLevel                    LogMask { get; }
        protected ChainOfResponsibilityLogger Next    { get; set; }

        public ChainOfResponsibilityLogger AddNext(ChainOfResponsibilityLogger nextChainOfResponsibilityLogger)
        {
            if (this.Next != null)
            {
                nextChainOfResponsibilityLogger.Next = this.Next;
            }

            this.Next = nextChainOfResponsibilityLogger;
            return this;
        }

        public void Message(string msg, LogLevel severity)
        {
            if ((severity & this.LogMask) != 0)
            {
                this.WriteMessage(msg);
            }

            this.Next?.Message(msg, severity);
        }

        protected abstract void WriteMessage(string msg);
    }

    public class ChainOfResponsibilityConsoleLogger : ChainOfResponsibilityLogger
    {
        private readonly IMessageWriter messageMessageWriter;

        public ChainOfResponsibilityConsoleLogger(LogLevel mask, IMessageWriter messageMessageWriter)
            : base(mask)
        {
            this.messageMessageWriter = messageMessageWriter;
        }

        protected override void WriteMessage(string msg)
        {
            this.messageMessageWriter.WriteMessage(msg);
        }
    }

    public class ChainOfResponsibilityEmailLogger : ChainOfResponsibilityLogger
    {
        private readonly IMessageWriter messageMessageWriter;

        public ChainOfResponsibilityEmailLogger(LogLevel mask, IMessageWriter messageMessageWriter)
            : base(mask)
        {
            this.messageMessageWriter = messageMessageWriter;
        }

        protected override void WriteMessage(string msg)
        {
            this.messageMessageWriter.WriteMessage(msg);
        }
    }

    internal class ChainOfResponsibilityFileLogger : ChainOfResponsibilityLogger
    {
        private readonly IMessageWriter messageMessageWriter;

        public ChainOfResponsibilityFileLogger(LogLevel mask, IMessageWriter messageMessageWriter)
            : base(mask)
        {
            this.messageMessageWriter = messageMessageWriter;
        }

        protected override void WriteMessage(string msg)
        {
            this.messageMessageWriter.WriteMessage(msg);
        }
    }
}