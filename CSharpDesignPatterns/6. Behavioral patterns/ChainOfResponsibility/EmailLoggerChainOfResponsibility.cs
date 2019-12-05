namespace CSharpDesignPatterns._6._Behavioral_patterns.ChainOfResponsibility
{
    using CSharpDesignPatterns.Common.Model;

    public interface IEmail
    {
        void SendEmail(string contents);
    }

    public class EmailLoggerChainOfResponsibility : LoggerChainOfResponsibility
    {
        private readonly IEmail email;

        public EmailLoggerChainOfResponsibility(LogLevel mask, IEmail email)
            : base(mask)
        {
            this.email = email;
        }

        protected override void ProcessMessage(string message)
        {
            this.email.SendEmail(message);
        }
    }
}