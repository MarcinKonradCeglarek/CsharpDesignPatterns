namespace CSharpDesignPatterns._5._Structural_patterns.Adapter
{
    using System;

    internal interface IOurLogger
    {
        bool SendLogMessage(LogLevel level, string message, Exception exception = null);
    }

    internal class Adapter : IOurLogger
    {
        public Adapter(IExternalLoggingInterface mockObject)
        {
        }

        public bool SendLogMessage(LogLevel level, string message, Exception exception = null)
        {
            throw new NotImplementedException();
        }
    }

    internal enum LogLevel
    {
        Debug,
        Info,
        Warn,
        Error,
        Exception
    }

    public interface IExternalLoggingInterface
    {
        void LogDebug(string message);

        void LogError(string message);

        void LogException(Exception ex, string message);

        void LogInfo(string message);

        void LogWarn(string message);
    }
}