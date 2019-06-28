namespace CSharpDesignPatterns._5._Structural_patterns.Adapter
{
    using System;

    using CSharpDesignPatterns.Common.Model;

    public interface IOurLogger
    {
        bool SendLogMessage(LogLevel level, string message, Exception exception = null);
    }

    public class OurLoggingToNewLoggingAdapter : IOurLogger
    {
        private readonly ILogger newLogger;

        public OurLoggingToNewLoggingAdapter(ILogger newLogger)
        {
            this.newLogger = newLogger;
        }

        public bool SendLogMessage(LogLevel level, string message, Exception exception = null)
        {
            throw new NotImplementedException();
        }
    }

    public enum LogLevel
    {
        Debug,
        Info,
        Warn,
        Error,
        Exception
    }
}