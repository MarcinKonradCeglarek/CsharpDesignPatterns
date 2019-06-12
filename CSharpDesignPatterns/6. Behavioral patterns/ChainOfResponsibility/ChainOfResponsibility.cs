﻿namespace CSharpDesignPatterns._6._Behavioral_patterns.ChainOfResponsibility
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
        private readonly LogLevel mask;

        public ChainOfResponsibilityLogger(LogLevel mask)
        {
            this.mask = mask;
        }

        protected LogLevel LogMask { get; }
        protected ChainOfResponsibilityLogger Next { get; set; }

        public void Message(string msg, LogLevel severity)
        {
            if ((severity & this.mask) != 0)
            {
                WriteMessage(msg);
            }

            this.Next?.Message(msg, severity);
        }

        public ChainOfResponsibilityLogger AddNext(ChainOfResponsibilityLogger nextChainOfResponsibilityLogger)
        {
            if (this.Next != null)
            {
                nextChainOfResponsibilityLogger.Next = this.Next;
            }

            this.Next = nextChainOfResponsibilityLogger;
            return this;
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