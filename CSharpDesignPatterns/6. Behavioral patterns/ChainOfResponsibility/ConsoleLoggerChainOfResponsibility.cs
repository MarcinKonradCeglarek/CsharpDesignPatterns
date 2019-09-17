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
        private readonly IConsole messageConsole;

        public ConsoleLoggerChainOfResponsibility(LogLevel mask, IConsole messageConsole)
            : base(mask)
        {
            this.messageConsole = messageConsole;
        }

        protected override void ProcessMessage(string message)
        {
            this.messageConsole.WriteMessage(message);
        }
    }
}