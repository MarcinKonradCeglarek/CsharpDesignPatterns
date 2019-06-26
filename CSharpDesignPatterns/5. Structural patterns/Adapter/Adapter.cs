namespace CSharpDesignPatterns._5._Structural_patterns.Adapter
{
    using System;

    public interface IOurLogger
    {
        bool SendLogMessage(LogLevel level, string message, Exception exception = null);
    }

    public class Adapter : IOurLogger
    {
        private readonly IExternalLoggingInterface externalLogger;

        public Adapter(IExternalLoggingInterface externalLogger)
        {
            this.externalLogger = externalLogger;
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

    public interface IExternalLoggingInterface
    {
        void LogDebug(string        message);
        void LogError(string        message);
        void LogException(Exception ex, string message);
        void LogInfo(string         message);
        void LogWarn(string         message);
    }
}