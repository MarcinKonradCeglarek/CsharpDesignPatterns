namespace CSharpDesignPatterns._6._Behavioral_patterns.ChainOfResponsibility
{
    using System;

    using CSharpDesignPatterns.Common.Model;

    public interface IFileWriter
    {
        void AppendToLogFile(string message);
    }

    internal class FileLoggerChainOfResponsibility : LoggerChainOfResponsibility
    {
        public FileLoggerChainOfResponsibility(LogLevel mask, IFileWriter file)
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