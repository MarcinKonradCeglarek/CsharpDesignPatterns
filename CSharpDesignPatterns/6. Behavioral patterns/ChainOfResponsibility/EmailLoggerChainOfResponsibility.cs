namespace CSharpDesignPatterns._6._Behavioral_patterns.ChainOfResponsibility
{
    using System;

    using CSharpDesignPatterns.Common.Model;

    public interface IEmail
    {
        void SendEmail(string contents);
    }

    public class EmailLoggerChainOfResponsibility : LoggerChainOfResponsibility
    {
        public EmailLoggerChainOfResponsibility(LogLevel mask, IEmail email)
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