namespace CSharpDesignPatterns._6._Behavioral_patterns.ChainOfResponsibility
{
    using System;

    using CSharpDesignPatterns.Common.Model;

    public interface IConsole
    {
        void WriteMessage(string message);
    }

    public class ConsoleLoggerChainOfResponsibility : LoggerChainOfResponsibility
    {
        public ConsoleLoggerChainOfResponsibility(LogLevel mask, IConsole messageConsole)
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