namespace CSharpDesignPatterns._6._Behavioral_patterns.ChainOfResponsibility
{
    using System;

    using CSharpDesignPatterns.Common.Model;

    /*
     * https://refactoring.guru/design-patterns/chain-of-responsibility
     *
     * https://en.wikipedia.org/wiki/Chain-of-responsibility_pattern
     */

    public abstract class LoggerChainOfResponsibility
    {
        private readonly LogLevel mask;

        protected LoggerChainOfResponsibility(LogLevel mask)
        {
            this.mask = mask;
        }

        public LoggerChainOfResponsibility Next { get; private set; }

        public LoggerChainOfResponsibility AddNext(LoggerChainOfResponsibility @new)
        {
            if (this.Next == null)
            {
                this.Next = @new;
            }
            else
            {
                this.Next.AddNext(@new);
            }

            return this;
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
    }
}