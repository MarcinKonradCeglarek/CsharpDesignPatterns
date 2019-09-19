namespace CSharpDesignPatterns._5._Structural_patterns.Adapter
{
    using System;

    using CSharpDesignPatterns.Common.Model;

    /*
     * https://refactoring.guru/design-patterns/adapter
     *
     * LogLevel.Debug                -> LogDebug
     * LogLevel.Info                 -> LogInfo
     * LogLevel.Warning              -> LogWarn
     * LogLevel.Error                -> LogError
     * LogLevel.Error with Exception -> LogException
     * LogLevel.Functional*          -> none;
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
                    case LogLevel.Warning:
                        this.newLogger.LogWarn(message);
                        break;
                    case LogLevel.Error:
                        if (exception == null)
                        {
                            this.newLogger.LogError(message);
                        }
                        else
                        {
                            this.newLogger.LogException(exception, message);
                        }

                        break;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}