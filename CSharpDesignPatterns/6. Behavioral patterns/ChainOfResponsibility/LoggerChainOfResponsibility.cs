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
        protected LoggerChainOfResponsibility(LogLevel mask)
        {
            throw new NotImplementedException();
        }

        public LoggerChainOfResponsibility Next { get; }

        public LoggerChainOfResponsibility AddNext(LoggerChainOfResponsibility @new)
        {
            throw new NotImplementedException();
        }

        public void LogMessage(LogLevel severity, string message)
        {
            throw new NotImplementedException();
        }

        protected abstract void ProcessMessage(string message);
    }
}