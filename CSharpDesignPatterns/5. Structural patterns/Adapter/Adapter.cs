namespace CSharpDesignPatterns._5._Structural_patterns.Adapter
{
    using System;

    using CSharpDesignPatterns.Common.Model;

    /*
     * https://refactoring.guru/design-patterns/adapter
     */
    public interface IOurOldLogger
    {
        bool SendLogMessage(LogLevel level, string message, Exception exception = null);
    }

    public class OurOldLoggerToILoggerAdapter : IOurOldLogger
    {
        private readonly ILogger newLogger;

        public OurOldLoggerToILoggerAdapter(ILogger newLogger)
        {
            this.newLogger = newLogger;
        }

        public bool SendLogMessage(LogLevel level, string message, Exception exception = null)
        {
            try
            {
                switch (level)
                {
                    case LogLevel.Debug:
                        this.newLogger.LogDebug(message);
                        break;
                    case LogLevel.Info:
                        this.newLogger.LogInfo(message);
                        break;
                    case LogLevel.Warn:
                        this.newLogger.LogWarn(message);
                        break;
                    case LogLevel.Error:
                        this.newLogger.LogError(message);
                        break;
                    case LogLevel.Exception:
                        this.newLogger.LogException(exception, message);
                        break;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
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