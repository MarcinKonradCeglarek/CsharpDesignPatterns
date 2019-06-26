namespace CSharpDesignPatterns._5._Structural_patterns.Adapter
{
    using System;

    public interface IOurLogger
    {
        bool SendLogMessage(LogLevel level, string message, Exception exception = null);
    }

    public class OurLoggingToNewLoggingAdapter : IOurLogger
    {
        private readonly INewLoggingInterface newLogger;

        public OurLoggingToNewLoggingAdapter(INewLoggingInterface newLogger)
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

    public interface INewLoggingInterface
    {
        void LogDebug(string        message);
        void LogError(string        message);
        void LogException(Exception ex, string message);
        void LogInfo(string         message);
        void LogWarn(string         message);
    }
}