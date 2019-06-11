namespace CSharpDesignPatterns._5._Structural_patterns.Adapter
{
    using System;

    internal interface IOurLogger
    {
        bool SendLogMessage(LogLevel level, string message, Exception exception = null);
    }

    internal class Adapter : IOurLogger
    {
        private readonly IExternalLoggingInterface externalLogger;

        public Adapter(IExternalLoggingInterface externalLogger)
        {
            this.externalLogger = externalLogger;
        }

        public bool SendLogMessage(LogLevel level, string message, Exception exception = null)
        {
            try
            {
                switch (level)
                {
                    case LogLevel.Debug:
                        this.externalLogger.LogDebug(message);
                        break;
                    case LogLevel.Info:
                        this.externalLogger.LogInfo(message);
                        break;
                    case LogLevel.Warn:
                        this.externalLogger.LogWarn(message);
                        break;
                    case LogLevel.Error:
                        this.externalLogger.LogError(message);
                        break;
                    case LogLevel.Exception:
                        this.externalLogger.LogException(exception, message);
                        break;
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
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