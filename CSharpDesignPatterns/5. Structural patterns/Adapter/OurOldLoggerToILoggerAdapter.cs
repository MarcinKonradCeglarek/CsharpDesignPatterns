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
        public OurOldLoggerToILoggerAdapter(ILogger newLogger)
        {
            throw new NotImplementedException();
        }

        public bool SendLogMessage(LogLevel level, string message, Exception exception = null)
        {
            throw new NotImplementedException();
        }
    }
}