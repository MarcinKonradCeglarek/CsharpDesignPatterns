namespace CSharpDesignPatterns._6._Behavioral_patterns.ChainOfResponsibility
{
    using System;

    [Flags]
    public enum LogLevel
    {
        None              = 0b00000000,
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
        public ChainOfResponsibilityLogger(LogLevel mask)
        {
            throw new NotImplementedException();
        }

        protected LogLevel LogMask { get; }
        protected ChainOfResponsibilityLogger Next { get; set; }

        public void Message(string msg, LogLevel severity)
        {
            throw new NotImplementedException();
        }

        public ChainOfResponsibilityLogger AddNext(ChainOfResponsibilityLogger nextChainOfResponsibilityLogger)
        {
            throw new NotImplementedException();
        }

        protected abstract void WriteMessage(string msg);
    }

    public class ChainOfResponsibilityConsoleLogger : ChainOfResponsibilityLogger
    {
        private readonly IMessageWriter messageMessageWriter;

        public ChainOfResponsibilityConsoleLogger(LogLevel mask, IMessageWriter messageMessageWriter)
            : base(mask)
        {
            throw new NotImplementedException();
        }

        protected override void WriteMessage(string msg)
        {
            throw new NotImplementedException();
        }
    }

    public class ChainOfResponsibilityEmailLogger : ChainOfResponsibilityLogger
    {
        private readonly IMessageWriter messageMessageWriter;

        public ChainOfResponsibilityEmailLogger(LogLevel mask, IMessageWriter messageMessageWriter)
            : base(mask)
        {
            throw new NotImplementedException();
        }

        protected override void WriteMessage(string msg)
        {
            throw new NotImplementedException();
        }
    }

    internal class ChainOfResponsibilityFileLogger : ChainOfResponsibilityLogger
    {
        private readonly IMessageWriter messageMessageWriter;

        public ChainOfResponsibilityFileLogger(LogLevel mask, IMessageWriter messageMessageWriter)
            : base(mask)
        {
            throw new NotImplementedException();
        }

        protected override void WriteMessage(string msg)
        {
            throw new NotImplementedException();
        }
    }
}