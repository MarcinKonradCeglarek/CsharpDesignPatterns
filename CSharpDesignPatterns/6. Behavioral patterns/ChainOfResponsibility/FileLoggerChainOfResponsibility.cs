namespace CSharpDesignPatterns._6._Behavioral_patterns.ChainOfResponsibility
{
    using CSharpDesignPatterns.Common.Model;

    public interface IFileWriter
    {
        void AppendToLogFile(string message);
    }

    internal class FileLoggerChainOfResponsibility : LoggerChainOfResponsibility
    {
        private readonly IFileWriter file;

        public FileLoggerChainOfResponsibility(LogLevel mask, IFileWriter file)
            : base(mask)
        {
            this.file = file;
        }

        protected override void ProcessMessage(string message)
        {
            this.file.AppendToLogFile(message);
        }
    }
}